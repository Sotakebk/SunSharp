using System;
using System.Collections.Generic;
using SunSharp.Native;

namespace SunSharp
{
    /// <summary>
    /// Allows for object-oriented approach to using the SunVox library.
    /// No manual locking should be necessary.
    /// </summary>
    public interface ISunVox : IDisposable
    {
        ISlots Slots { get; }
        bool NeedsUserCallback { get; }
        bool SingleThreaded { get; }
        OutputType? OutputType { get; }
        LibraryVersion Version { get; }
        int SampleRate { get; }
        AudioChannels Channels { get; }

        /// <summary>
        /// Handle input ON/OFF requests to enable/disable input ports of the sound card (for example, after the Input module creation). Call it from the main thread only, where the SunVox sound stream is not locked.
        /// </summary>
        void UpdateInputDevices();

        /// <summary>
        /// Get the next piece of audio.
        /// If library was initialized with <see cref="AudioChannels.Stereo"/>, the samples will be interlaced, and the buffer size must be a multiple of two.
        /// </summary>
        /// <param name="outputBuffer">Buffer to write sound data to.</param>
        /// <param name="latency">Audio latency (in frames).</param>
        /// <param name="outTime">Buffer output time (in system ticks).</param>
        bool AudioCallback(float[] outputBuffer, int latency, uint outTime);

        /// <inheritdoc cref="SunVox.AudioCallback(float[],int,uint)"/>
        bool AudioCallback(short[] outputBuffer, int latency, uint outTime);

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
        bool AudioCallback(float[] outputBuffer, float[] inputBuffer, AudioChannels inputChannels, int latency, uint outTime);

        /// <inheritdoc cref="SunVox.AudioCallback(float[],float[],SunSharp.AudioChannels,int,uint)"/>
        bool AudioCallback(float[] outputBuffer, short[] inputBuffer, AudioChannels inputChannels, int latency, uint outTime);

        /// <inheritdoc cref="SunVox.AudioCallback(float[],float[],SunSharp.AudioChannels,int,uint)"/>
        bool AudioCallback(short[] outputBuffer, float[] inputBuffer, AudioChannels inputChannels, int latency, uint outTime);

        /// <inheritdoc cref="SunVox.AudioCallback(float[],float[],SunSharp.AudioChannels,int,uint)"/>
        bool AudioCallback(short[] outputBuffer, short[] inputBuffer, AudioChannels inputChannels, int latency, uint outTime);

        uint GetTicks();

        uint GetTicksPerSecond();
    }

    /// <inheritdoc/>
    public sealed class SunVox : ISunVox
    {
        /// <summary>
        /// The underlying library interface. Direct use may break existing abstractions.
        /// </summary>
        public ISunVoxLib Library { get; }

        /// <inheritdoc cref="ISunVox.Slots"/>
        public Slots Slots { get; }

        /// <inheritdoc/>
        ISlots ISunVox.Slots => Slots;

        /// <inheritdoc/>
        public bool NeedsUserCallback => OutputType != null;

        /// <inheritdoc/>
        public bool SingleThreaded { get; }

        /// <inheritdoc/>
        public OutputType? OutputType { get; }

        /// <inheritdoc/>
        public LibraryVersion Version { get; }

        /// <inheritdoc/>
        public int SampleRate { get; }

        /// <inheritdoc/>
        public AudioChannels Channels { get; }

        /// <summary>
        /// Create an instance of the engine with own audio stream and threading.
        /// </summary>
        /// <param name="library"></param>
        /// <param name="channels"></param>
        /// <param name="bufferSize">Leave <see langword="null"/> for the value to be assigned by the engine.</param>
        /// <param name="deviceIn">Leave <see langword="null"/> for the value to be assigned by the engine.</param>
        /// <param name="deviceOut">Leave <see langword="null"/> for the value to be assigned by the engine.</param>
        /// <param name="driver">Leave <see langword="null"/> for the value to be assigned by the engine.</param>
        /// <param name="noDebugOutput">Limit information sent to Standard Output.</param>
        public SunVox(ISunVoxLib library, AudioChannels channels = AudioChannels.Stereo, uint? bufferSize = null,
            string? deviceIn = null, string? deviceOut = null, string? driver = null, bool noDebugOutput = true)
        {
            var flags = SunVoxInitOptions.None;
            if (noDebugOutput)
            {
                flags |= SunVoxInitOptions.NoDebugOutput;
            }

            var configuration = AssembleConfigurationParams(bufferSize, deviceIn, deviceOut, driver);

            Library = library;
            Version = Library.Initialize(sampleRate: -1, config: configuration, channels: channels, options: flags);
            SampleRate = Library.GetSampleRate();
            SingleThreaded = false;
            OutputType = null;
            Channels = channels;
            Slots = new Slots(this);
        }

        /// <summary>
        /// Create an instance of the engine with the intent of using AudioCallback.
        /// </summary>
        /// <param name="library"></param>
        /// <param name="sampleRate"></param>
        /// <param name="outputType"></param>
        /// <param name="channels"></param>
        /// <param name="singleThreaded">Use to promise that audio callback and other methods will be called from one thread.</param>
        /// <param name="noDebugOutput">Limit information sent to Standard Output.</param>
        /// <exception cref="System.ArgumentException"></exception>
        public SunVox(ISunVoxLib library, int sampleRate, OutputType outputType, AudioChannels channels = AudioChannels.Stereo,
            bool singleThreaded = false, bool noDebugOutput = true)
        {
            var flags = ConstructInitFlags(SunVoxInitOptions.UserAudioCallback, noDebugOutput, outputType, singleThreaded);

            if (sampleRate < 1)
            {
                throw new ArgumentException($"Invalid value: {sampleRate}", nameof(sampleRate));
            }

            Library = library;
            Version = Library.Initialize(sampleRate: sampleRate, channels: channels, options: flags);
            SampleRate = Library.GetSampleRate();
            SingleThreaded = false;
            Channels = channels;
            OutputType = outputType;
            Slots = new Slots(this);
        }

        private static string? AssembleConfigurationParams(uint? bufferSize, string? deviceIn, string? deviceOut, string? driver)
        {
            var arguments = new List<string>();
            if (bufferSize != null)
            {
                arguments.Add($"buffer={bufferSize.Value}");
            }

            if (deviceIn != null)
            {
                arguments.Add($"audiodevice_in={deviceIn}");
            }

            if (deviceOut != null)
            {
                arguments.Add($"audiodevice={deviceOut}");
            }

            if (driver != null)
            {
                arguments.Add($"audiodriver={driver}");
            }
            return arguments.Count != 0 ? string.Join("|", arguments) : null;
        }

        private static SunVoxInitOptions ConstructInitFlags(SunVoxInitOptions initial, bool noDebugOutput, OutputType outputType, bool singleThreaded)
        {
            var flags = initial;
            if (noDebugOutput)
            {
                flags |= SunVoxInitOptions.NoDebugOutput;
            }

            flags |= outputType switch
            {
                SunSharp.OutputType.Float32 => SunVoxInitOptions.AudioFloat32,
                SunSharp.OutputType.Int16 => SunVoxInitOptions.AudioInt16,
                _ => throw new ArgumentException($"Invalid value: {(int)outputType}", nameof(outputType))
            };

            if (singleThreaded)
            {
                flags |= SunVoxInitOptions.OneThread;
            }

            return flags;
        }

        #region disposable

        private bool _deinitialized;

        private void Dispose(bool disposing)
        {
            if (!_deinitialized)
            {
                if (disposing)
                {
                    // dispose managed state (managed objects)
                    // nothing right now
                }

                Library.Deinitialize();
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
            GC.SuppressFinalize(this);
        }

        #endregion disposable

        #region audio I/O

        /// <inheritdoc/>
        public void UpdateInputDevices()
        {
            Library.UpdateInputDevices();
        }

        private void AudioGuard(bool callIsFloat)
        {
            if (OutputType == null)
            {
                throw new InvalidOperationException("SunVox was not initialized in user callback mode.");
            }

            var outputTypeIsFloat = OutputType == SunSharp.OutputType.Float32;

            if (outputTypeIsFloat == callIsFloat)
            {
                return;
            }

            var expected = callIsFloat ? SunSharp.OutputType.Float32 : SunSharp.OutputType.Int16;
            var msg = $"SunVox was initialized with output type \"{OutputType}\", but callback was called expecting output type \"{expected}\"";
            throw new InvalidOperationException(msg);
        }

        /// <inheritdoc/>
        public bool AudioCallback(float[] outputBuffer, int latency, uint outTime)
        {
            AudioGuard(true);
            return Library.AudioCallback(outputBuffer, Channels, latency, outTime);
        }

        /// <inheritdoc/>
        public bool AudioCallback(short[] outputBuffer, int latency, uint outTime)
        {
            AudioGuard(false);
            return Library.AudioCallback(outputBuffer, Channels, latency, outTime);
        }

        /// <inheritdoc/>
        public bool AudioCallback(float[] outputBuffer, float[] inputBuffer, AudioChannels inputChannels, int latency, uint outTime)
        {
            AudioGuard(true);
            return Library.AudioCallback(outputBuffer, Channels, inputBuffer, inputChannels, latency, outTime);
        }

        /// <inheritdoc/>
        public bool AudioCallback(float[] outputBuffer, short[] inputBuffer, AudioChannels inputChannels, int latency, uint outTime)
        {
            AudioGuard(true);
            return Library.AudioCallback(outputBuffer, Channels, inputBuffer, inputChannels, latency, outTime);
        }

        /// <inheritdoc/>
        public bool AudioCallback(short[] outputBuffer, float[] inputBuffer, AudioChannels inputChannels, int latency, uint outTime)
        {
            AudioGuard(false);
            return Library.AudioCallback(outputBuffer, Channels, inputBuffer, inputChannels, latency, outTime);
        }

        /// <inheritdoc/>
        public bool AudioCallback(short[] outputBuffer, short[] inputBuffer, AudioChannels inputChannels, int latency, uint outTime)
        {
            AudioGuard(false);
            return Library.AudioCallback(outputBuffer, Channels, inputBuffer, inputChannels, latency, outTime);
        }

        #endregion audio I/O

        /// <inheritdoc/>
        public uint GetTicks()
        {
            return Library.GetTicks();
        }

        /// <inheritdoc/>
        public uint GetTicksPerSecond()
        {
            return Library.GetTicksPerSecond();
        }
    }
}
