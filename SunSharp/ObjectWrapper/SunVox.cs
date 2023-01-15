using SunSharp.ThinWrapper;
using System.Collections.Generic;
using System.Linq;
using static SunSharp.ThinWrapper.SunVoxHelper;

namespace SunSharp.ObjectWrapper
{
    public class SunVox : System.IDisposable
    {
        public ISunVoxLib Library => _lib;
        public Version Version => _version;
        public int SampleRate => _sampleRate;
        public Slots Slots { get; private set; }

        private readonly Version _version;
        private readonly int _sampleRate;
        private readonly ISunVoxLib _lib;
        private readonly bool _userCallback;
        private readonly bool _outputFloat;

        public SunVox(ISunVoxLib lib, int sampleRate, Channels channels = Channels.Stereo,
            InitFlags flags = InitFlags.Default, uint? bufferSize = null, string deviceIn = null,
            string deviceOut = null, string driver = null)
        {
            if (flags.HasFlag(InitFlags.AudioFloat32) && flags.HasFlag(InitFlags.AudioInt16))
                throw new System.ArgumentException($"InitFlags cannot have both {InitFlags.AudioFloat32} and {InitFlags.AudioInt16} set!");

            _userCallback = flags.HasFlag(InitFlags.UserAudioCallback);
            _outputFloat = _userCallback && flags.HasFlag(InitFlags.AudioFloat32);
            var @params = new List<string>();
            if (bufferSize != null) @params.Add($"buffer={bufferSize.Value}");
            if (deviceIn != null) @params.Add($"audiodevice_in={deviceIn}");
            if (deviceOut != null) @params.Add($"audiodevice={deviceOut}");
            if (driver != null) @params.Add($"audiodriver={driver}");
            var configuration = @params.Any() ? string.Join("|", @params) : null;
            _lib = lib;
            _version = Library.Init(configuration, sampleRate, channels, flags);
            _sampleRate = Library.GetSampleRate();

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

        public void Dispose()
        {
            Dispose(disposing: true);
            System.GC.SuppressFinalize(this);
        }

        #endregion disposable

        #region audio I/O

        public void UpdateInputDevices() => _lib.UpdateInputDevices();

        private void AudioGuard(bool floatOutput)
        {
            if (!_userCallback)
                throw new System.InvalidOperationException($"Engine was not initialized with {InitFlags.UserAudioCallback} flag.");
            if (floatOutput == _outputFloat)
                throw new System.InvalidOperationException("Output type not compatible with type defined at initialization.");
        }

        public bool AudioCallback(float[] outputBuffer, int latency, uint outTime)
        {
            AudioGuard(true);
            return _lib.AudioCallback(outputBuffer, latency, outTime);
        }

        public bool AudioCallback(short[] outputBuffer, int latency, uint outTime)
        {
            AudioGuard(false);
            return _lib.AudioCallback(outputBuffer, latency, outTime);
        }

        public bool AudioCallback(float[] outputBuffer, float[] inputBuffer, Channels inputChannels, int latency, uint outTime)
        {
            AudioGuard(true);
            return _lib.AudioCallback(outputBuffer, inputBuffer, inputChannels, latency, outTime);
        }

        public bool AudioCallback(float[] outputBuffer, short[] inputBuffer, Channels inputChannels, int latency, uint outTime)
        {
            AudioGuard(true);
            return _lib.AudioCallback(outputBuffer, inputBuffer, inputChannels, latency, outTime);
        }

        public bool AudioCallback(short[] outputBuffer, float[] inputBuffer, Channels inputChannels, int latency, uint outTime)
        {
            AudioGuard(false);
            return _lib.AudioCallback(outputBuffer, inputBuffer, inputChannels, latency, outTime);
        }

        public bool AudioCallback(short[] outputBuffer, short[] inputBuffer, Channels inputChannels, int latency, uint outTime)
        {
            AudioGuard(false);
            return _lib.AudioCallback(outputBuffer, inputBuffer, inputChannels, latency, outTime);
        }

        #endregion audio I/O
    }
}
