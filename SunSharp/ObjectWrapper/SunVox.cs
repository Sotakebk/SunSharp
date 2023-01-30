using SunSharp.ThinWrapper;
using System.Collections.Generic;
using System.Linq;

namespace SunSharp.ObjectWrapper
{
    public class SunVox : System.IDisposable
    {
        private readonly int _sampleRate;
        private readonly ISunVoxLib _lib;
        private readonly Slots _slots;
        private readonly OutputType? _outputType;
        private readonly Version _version;
        private readonly bool _singleThreaded;
        private readonly Channels _channels;

        public ISunVoxLib Library => _lib;
        public Slots Slots => _slots;
        public bool NeedsUserCallback => OutputType != null;
        public bool SingleThreaded => _singleThreaded;
        public OutputType? OutputType => _outputType;
        public Version Version => _version;
        public int SampleRate => _sampleRate;
        public Channels Channels => _channels;

        /// <summary>
        /// Create an instance of the engine with own audio stream and threading.
        /// </summary>
        /// <param name="lib"></param>
        /// <param name="bufferSize"></param>
        /// <param name="deviceIn"></param>
        /// <param name="deviceOut"></param>
        /// <param name="driver"></param>
        public SunVox(ISunVoxLib lib, Channels channels = Channels.Stereo, uint? bufferSize = null,
            string deviceIn = null, string deviceOut = null, string driver = null, bool noDebugOutput = true)
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
            _version = _lib.Init(sampleRate: -1, config: configuration, channels: channels, flags: flags);
            _sampleRate = _lib.GetSampleRate();
            _singleThreaded = false;
            _outputType = null;
            _channels = channels;
            _slots = new Slots(this);
        }

        /// <summary>
        /// Create an instance of the engine with the intent of using AudioCallback.
        /// </summary>
        /// <param name="lib"></param>
        /// <param name="sampleRate"></param>
        /// <param name="outputType"></param>
        /// <param name="singleThreaded"></param>
        /// <param name="noDebugOutput"></param>
        public SunVox(ISunVoxLib lib, int sampleRate, OutputType outputType, Channels channels = Channels.Stereo,
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
            _version = _lib.Init(sampleRate: sampleRate, channels: channels, flags: flags);
            _sampleRate = _lib.GetSampleRate();
            _singleThreaded = false;
            _channels = channels;
            _outputType = outputType;
            _slots = new Slots(this);
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

        public void Dispose()
        {
            Dispose(disposing: true);
            System.GC.SuppressFinalize(this);
        }

        #endregion disposable

        #region audio I/O

        public void UpdateInputDevices() => _lib.UpdateInputDevices();

        private void AudioGuard(bool @float)
        {
            if (_outputType == null)
                throw new System.InvalidOperationException("SunVox was not initialized in user callback mode.");

            if ((_outputType == ObjectWrapper.OutputType.Float32) == !@float)
            {
                var expected = @float ? ObjectWrapper.OutputType.Float32 : ObjectWrapper.OutputType.Int16;
                var msg = $"SunVox was initialized with output type \"{OutputType}\", but callback was called expecting output type \"{expected}\"";
                throw new System.InvalidOperationException(msg);
            }
        }

        public bool AudioCallback(float[] outputBuffer, int latency, uint outTime)
        {
            AudioGuard(true);
            return _lib.AudioCallback(outputBuffer, _channels, latency, outTime);
        }

        public bool AudioCallback(short[] outputBuffer, int latency, uint outTime)
        {
            AudioGuard(false);
            return _lib.AudioCallback(outputBuffer, _channels, latency, outTime);
        }

        public bool AudioCallback(float[] outputBuffer, float[] inputBuffer, Channels inputChannels, int latency, uint outTime)
        {
            AudioGuard(true);
            return _lib.AudioCallback(outputBuffer, _channels, inputBuffer, inputChannels, latency, outTime);
        }

        public bool AudioCallback(float[] outputBuffer, short[] inputBuffer, Channels inputChannels, int latency, uint outTime)
        {
            AudioGuard(true);
            return _lib.AudioCallback(outputBuffer, _channels, inputBuffer, inputChannels, latency, outTime);
        }

        public bool AudioCallback(short[] outputBuffer, float[] inputBuffer, Channels inputChannels, int latency, uint outTime)
        {
            AudioGuard(false);
            return _lib.AudioCallback(outputBuffer, _channels, inputBuffer, inputChannels, latency, outTime);
        }

        public bool AudioCallback(short[] outputBuffer, short[] inputBuffer, Channels inputChannels, int latency, uint outTime)
        {
            AudioGuard(false);
            return _lib.AudioCallback(outputBuffer, _channels, inputBuffer, inputChannels, latency, outTime);
        }

        #endregion audio I/O

        public uint GetTicks() => _lib.GetTicks();

        public uint GetTicksPerSecond() => _lib.GetTicksPerSecond();
    }
}
