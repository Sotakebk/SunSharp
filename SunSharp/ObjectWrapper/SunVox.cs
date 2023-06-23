using System.Collections.Generic;
using System.Linq;
using SunSharp.ThinWrapper;

namespace SunSharp.ObjectWrapper
{
    /// <summary>
    /// Allows for object-oriented approach to using the SunVox library.
    /// No manual locking should be necessary.
    /// </summary>
    public class SunVox : System.IDisposable
    {
        private readonly ISunVoxLib _lib;
        private readonly OutputType? _outputType;

        /// <summary>
        /// The underlying library. Direct use is potentially dangerous and may break existing abstractions.
        /// </summary>
        public ISunVoxLib Library => _lib;

        public Slots Slots { get; }

        public bool NeedsUserCallback => OutputType != null;
        public bool SingleThreaded { get; }

        public OutputType? OutputType => _outputType;
        public Version Version { get; }
        public int SampleRate { get; }
        public AudioChannels Channels { get; }

        /// <summary>
        /// Create an instance of the engine with own audio stream and threading.
        /// </summary>
        /// <param name="lib"></param>
        /// <param name="channels"></param>
        /// <param name="bufferSize">Leave <see langword="null"/> for the value to be assigned by the engine.</param>
        /// <param name="deviceIn">Leave <see langword="null"/> for the value to be assigned by the engine.</param>
        /// <param name="deviceOut">Leave <see langword="null"/> for the value to be assigned by the engine.</param>
        /// <param name="driver">Leave <see langword="null"/> for the value to be assigned by the engine.</param>
        /// <param name="noDebugOutput">Limit information sent to Standard Output.</param>
        public SunVox(ISunVoxLib lib, AudioChannels channels = AudioChannels.Stereo, uint? bufferSize = null,
            string? deviceIn = null, string? deviceOut = null, string? driver = null, bool noDebugOutput = true)
        {
            var flags = InitFlags.Default;
            if (noDebugOutput)
                flags |= InitFlags.NoDebugOutput;

            var @params = new List<string>();
            if (bufferSize != null) @params.Add($"buffer={bufferSize.Value}");
            if (deviceIn != null) @params.Add($"audiodevice_in={deviceIn}");
            if (deviceOut != null) @params.Add($"audiodevice={deviceOut}");
            if (driver != null) @params.Add($"audiodriver={driver}");
            var configuration = @params.Any() ? string.Join("|", @params) : null;

            _lib = lib;
            Version = _lib.Init(sampleRate: -1, config: configuration, channels: channels, flags: flags);
            SampleRate = _lib.GetSampleRate();
            SingleThreaded = false;
            _outputType = null;
            Channels = channels;
            Slots = new Slots(this);
        }

        /// <summary>
        /// Create an instance of the engine with the intent of using AudioCallback.
        /// </summary>
        /// <param name="lib"></param>
        /// <param name="sampleRate"></param>
        /// <param name="outputType"></param>
        /// <param name="channels"></param>
        /// <param name="singleThreaded">Use to promise that audio callback and other methods will be called from one thread.</param>
        /// <param name="noDebugOutput">Limit information sent to Standard Output.</param>
        /// <exception cref="System.ArgumentException"></exception>
        public SunVox(ISunVoxLib lib, int sampleRate, OutputType outputType,
            AudioChannels channels = AudioChannels.Stereo,
            bool singleThreaded = false, bool noDebugOutput = true)
        {
            var flags = InitFlags.UserAudioCallback;

            if (noDebugOutput)
                flags |= InitFlags.NoDebugOutput;

            if (outputType == ObjectWrapper.OutputType.Float32)
                flags |= InitFlags.AudioFloat32;
            else if (outputType == ObjectWrapper.OutputType.Int16)
                flags |= InitFlags.AudioInt16;
            else
                throw new System.ArgumentException($"Invalid value: {(int)outputType}", nameof(outputType));

            if (singleThreaded)
                flags |= InitFlags.OneThread;

            if (sampleRate < 1)
                throw new System.ArgumentException($"Invalid value: {sampleRate}", nameof(sampleRate));

            _lib = lib;
            Version = _lib.Init(sampleRate: sampleRate, channels: channels, flags: flags);
            SampleRate = _lib.GetSampleRate();
            SingleThreaded = false;
            Channels = channels;
            _outputType = outputType;
            Slots = new Slots(this);
        }

        #region disposable

        private bool _deinitialized;

        protected virtual void Dispose(bool disposing)
        {
            if (!_deinitialized)
            {
                if (disposing)
                {
                }

                Library.Deinit();
                _deinitialized = true;
            }
        }

        ~SunVox()
        {
            Dispose(disposing: false);
        }

        /// <summary>
        /// Use to deinitialize the library and free resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(disposing: true);
            System.GC.SuppressFinalize(this);
        }

        #endregion disposable

        #region audio I/O

        /// <summary>
        /// Handle input ON/OFF requests to enable/disable input ports of the sound card (for example, after the Input module creation). Call it from the main thread only, where the SunVox sound stream is not locked.
        /// </summary>
        public void UpdateInputDevices() => _lib.UpdateInputDevices();

        private void AudioGuard(bool @float)
        {
            if (_outputType == null)
                throw new System.InvalidOperationException("SunVox was not initialized in user callback mode.");

            if (_outputType == ObjectWrapper.OutputType.Float32 != !@float)
                return;

            var expected = @float ? ObjectWrapper.OutputType.Float32 : ObjectWrapper.OutputType.Int16;
            var msg =
                $"SunVox was initialized with output type \"{OutputType}\", but callback was called expecting output type \"{expected}\"";
            throw new System.InvalidOperationException(msg);
        }

        /// <summary>
        /// Get the next piece of audio.
        /// If library was initialized with <see cref="AudioChannels.Stereo"/>, the samples will be interlaced, and the buffer size must be a multiple of two.
        /// </summary>
        /// <param name="outputBuffer">Buffer to write sound data to.</param>
        /// <param name="latency">Audio latency (in frames).</param>
        /// <param name="outTime">Buffer output time (in system ticks).</param>
        public bool AudioCallback(float[] outputBuffer, int latency, uint outTime)
        {
            AudioGuard(true);
            return _lib.AudioCallback(outputBuffer, Channels, latency, outTime);
        }

        /// <inheritdoc cref="AudioCallback(float[], int, uint)"/>
        public bool AudioCallback(short[] outputBuffer, int latency, uint outTime)
        {
            AudioGuard(false);
            return _lib.AudioCallback(outputBuffer, Channels, latency, outTime);
        }

        /// <summary>
        /// Get the next piece of audio.
        /// If audio is stereo, the samples will be interlaced, and the buffer size must be a multiple of two.
        /// Sends equal size buffer of an input device, which will be applied to any Input modules.
        /// </summary>
        /// <param name="outputBuffer">Buffer to write sound data to.</param>
        /// <param name="inputBuffer">Buffer to read sound data from.</param>
        /// <param name="inputChannels">Input data channels.</param>
        /// <param name="latency">Audio latency (in frames).</param>
        /// <param name="outTime">Buffer output time (in system ticks).</param>
        public bool AudioCallback(float[] outputBuffer, float[] inputBuffer, AudioChannels inputChannels, int latency,
            uint outTime)
        {
            AudioGuard(true);
            return _lib.AudioCallback(outputBuffer, Channels, inputBuffer, inputChannels, latency, outTime);
        }

        /// <inheritdoc cref="AudioCallback(float[], float[], AudioChannels, int, uint)"/>
        public bool AudioCallback(float[] outputBuffer, short[] inputBuffer, AudioChannels inputChannels, int latency,
            uint outTime)
        {
            AudioGuard(true);
            return _lib.AudioCallback(outputBuffer, Channels, inputBuffer, inputChannels, latency, outTime);
        }

        /// <inheritdoc cref="AudioCallback(float[], float[], AudioChannels, int, uint)"/>
        public bool AudioCallback(short[] outputBuffer, float[] inputBuffer, AudioChannels inputChannels, int latency,
            uint outTime)
        {
            AudioGuard(false);
            return _lib.AudioCallback(outputBuffer, Channels, inputBuffer, inputChannels, latency, outTime);
        }

        /// <inheritdoc cref="AudioCallback(float[], float[], AudioChannels, int, uint)"/>
        public bool AudioCallback(short[] outputBuffer, short[] inputBuffer, AudioChannels inputChannels, int latency,
            uint outTime)
        {
            AudioGuard(false);
            return _lib.AudioCallback(outputBuffer, Channels, inputBuffer, inputChannels, latency, outTime);
        }

        #endregion audio I/O

        public uint GetTicks() => _lib.GetTicks();

        public uint GetTicksPerSecond() => _lib.GetTicksPerSecond();
    }
}
