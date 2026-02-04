using System;
using System.Collections.Generic;
using SunSharp.Native;

namespace SunSharp
{
    /// <summary>
    /// Allows for object-oriented approach to using the SunVox library.
    /// </summary>
    public interface ISunVox : IDisposable
    {
        /// <inheritdoc cref="SunVox.Slots"/>
        ISlots Slots { get; }

        /// <inheritdoc cref="SunVox.NeedsUserCallback"/>
        bool NeedsUserCallback { get; }

        /// <inheritdoc cref="SunVox.SingleThreaded"/>
        bool SingleThreaded { get; }

        /// <inheritdoc cref="SunVox.Deinitialized"/>
        bool Deinitialized { get; }

        /// <inheritdoc cref="SunVox.OutputType"/>
        OutputType? OutputType { get; }

        /// <inheritdoc cref="SunVox.Version"/>
        SunVoxVersion Version { get; }

        /// <inheritdoc cref="SunVox.SampleRate"/>
        int SampleRate { get; }

        /// <inheritdoc cref="SunVox.Channels"/>
        AudioChannels Channels { get; }

        /// <inheritdoc cref="SunVox.Library"/>
        ISunVoxLib Library { get; }

        /// <inheritdoc cref="SunVox.UpdateInputDevices"/>
        void UpdateInputDevices();

        /// <inheritdoc cref="SunVox.AudioCallback(float[],int,uint)"/>
        bool AudioCallback(float[] outputBuffer, int latency, uint outTime);

        /// <inheritdoc cref="SunVox.AudioCallback(short[],int,uint)"/>
        bool AudioCallback(short[] outputBuffer, int latency, uint outTime);

        /// <inheritdoc cref="SunVox.AudioCallback(float[],float[],AudioChannels,int,uint)"/>
        bool AudioCallback(float[] outputBuffer, float[] inputBuffer, AudioChannels inputChannels, int latency, uint outTime);

        /// <inheritdoc cref="SunVox.AudioCallback(float[],short[],AudioChannels,int,uint)"/>
        bool AudioCallback(float[] outputBuffer, short[] inputBuffer, AudioChannels inputChannels, int latency, uint outTime);

        /// <inheritdoc cref="SunVox.AudioCallback(short[],float[],AudioChannels,int,uint)"/>
        bool AudioCallback(short[] outputBuffer, float[] inputBuffer, AudioChannels inputChannels, int latency, uint outTime);

        /// <inheritdoc cref="SunVox.AudioCallback(short[],short[],AudioChannels,int,uint)"/>
        bool AudioCallback(short[] outputBuffer, short[] inputBuffer, AudioChannels inputChannels, int latency, uint outTime);

        /// <inheritdoc cref="SunVox.GetTicks"/>
        uint GetTicks();

        /// <inheritdoc cref="SunVox.GetTicksPerSecond"/>
        uint GetTicksPerSecond();

        /// <inheritdoc cref="SunVox.GetLog(int)"/>
        string? GetLog(int length);
    }

    /// <inheritdoc/>
    public sealed class SunVox : ISunVox
    {
        /// <summary>
        /// The underlying library interface. Direct use may break existing abstractions.
        /// </summary>
#if SUNSHARP_RELEASE
        public SunVoxLib Library { get; }
#else
        public ISunVoxLib Library { get; }
#endif

        ISunVoxLib ISunVox.Library => Library;

        public Slots Slots { get; }

        /// <inheritdoc/>
        ISlots ISunVox.Slots => Slots;

        public bool NeedsUserCallback => OutputType != null;

        public bool SingleThreaded { get; }

        public OutputType? OutputType { get; }

        public SunVoxVersion Version { get; }

        public int SampleRate { get; }

        /// <summary>
        /// Number of channels SunVox was initialized with on startup.
        /// </summary>
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
#if SUNSHARP_RELEASE

        public SunVox(ISunVoxLibC library, AudioChannels channels = AudioChannels.Stereo, uint? bufferSize = null, string? deviceIn = null, string? deviceOut = null, string? driver = null, bool noDebugOutput = true)
#else

        public SunVox(ISunVoxLib library, AudioChannels channels = AudioChannels.Stereo, uint? bufferSize = null, string? deviceIn = null, string? deviceOut = null, string? driver = null, bool noDebugOutput = true)
#endif
        {
            if (library == null)
            {
                throw new ArgumentNullException(nameof(library));
            }

            var flags = SunVoxInitOptions.None;
            if (noDebugOutput)
            {
                flags |= SunVoxInitOptions.NoDebugOutput;
            }

            var configuration = AssembleConfigurationParams(bufferSize, deviceIn, deviceOut, driver);

#if SUNSHARP_RELEASE
            Library = new SunVoxLib(library);
#else
            Library = library;
#endif
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
#if SUNSHARP_RELEASE

        public SunVox(ISunVoxLibC library, int sampleRate, OutputType outputType, AudioChannels channels = AudioChannels.Stereo,
            bool singleThreaded = false, bool noDebugOutput = true)
#else

        public SunVox(ISunVoxLib library, int sampleRate, OutputType outputType, AudioChannels channels = AudioChannels.Stereo,
            bool singleThreaded = false, bool noDebugOutput = true)
#endif
        {
            if (library == null)
            {
                throw new ArgumentNullException(nameof(library));
            }

            var flags = ConstructInitFlags(SunVoxInitOptions.UserAudioCallback, noDebugOutput, outputType, singleThreaded);

            if (sampleRate < 1)
            {
                throw new ArgumentException($"Invalid value: {sampleRate}", nameof(sampleRate));
            }

#if SUNSHARP_RELEASE
            Library = new SunVoxLib(library);
#else
            Library = library;
#endif
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

        public bool Deinitialized { get; private set; }

        private void Dispose(bool disposing)
        {
            if (!Deinitialized)
            {
                if (disposing)
                {
                    // dispose managed state (managed objects)
                    // nothing right now
                }

                Deinitialized = true;
                try
                {
                    Library.Deinitialize();
                }
                catch (SunVoxException)
                {
                    // swallow exceptions on deinitialization
                    // this is because Deinitialize may fail if already deinitialized elsewhere somehow
                }
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

        /// <inheritdoc cref="SunVoxLib.UpdateInputDevices"/>
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

        /// <inheritdoc cref="SunVoxLib.AudioCallback(float[],AudioChannels,int,uint)"/>
        public bool AudioCallback(float[] outputBuffer, int latency, uint outTime)
        {
            AudioGuard(true);
            return Library.AudioCallback(outputBuffer, Channels, latency, outTime);
        }

        /// <inheritdoc cref="SunVoxLib.AudioCallback(short[],AudioChannels,int,uint)"/>
        public bool AudioCallback(short[] outputBuffer, int latency, uint outTime)
        {
            AudioGuard(false);
            return Library.AudioCallback(outputBuffer, Channels, latency, outTime);
        }

        /// <inheritdoc cref="SunVoxLib.AudioCallback(float[],AudioChannels,float[],AudioChannels,int,uint)"/>
        public bool AudioCallback(float[] outputBuffer, float[] inputBuffer, AudioChannels inputChannels, int latency, uint outTime)
        {
            AudioGuard(true);
            return Library.AudioCallback(outputBuffer, Channels, inputBuffer, inputChannels, latency, outTime);
        }

        /// <inheritdoc cref="SunVoxLib.AudioCallback(float[],AudioChannels,short[],AudioChannels,int,uint)"/>
        public bool AudioCallback(float[] outputBuffer, short[] inputBuffer, AudioChannels inputChannels, int latency, uint outTime)
        {
            AudioGuard(true);
            return Library.AudioCallback(outputBuffer, Channels, inputBuffer, inputChannels, latency, outTime);
        }

        /// <inheritdoc cref="SunVoxLib.AudioCallback(short[],AudioChannels,float[],AudioChannels,int,uint)"/>
        public bool AudioCallback(short[] outputBuffer, float[] inputBuffer, AudioChannels inputChannels, int latency, uint outTime)
        {
            AudioGuard(false);
            return Library.AudioCallback(outputBuffer, Channels, inputBuffer, inputChannels, latency, outTime);
        }

        /// <inheritdoc cref="SunVoxLib.AudioCallback(short[],AudioChannels,short[],AudioChannels,int,uint)"/>
        public bool AudioCallback(short[] outputBuffer, short[] inputBuffer, AudioChannels inputChannels, int latency, uint outTime)
        {
            AudioGuard(false);
            return Library.AudioCallback(outputBuffer, Channels, inputBuffer, inputChannels, latency, outTime);
        }

        #endregion audio I/O

        /// <inheritdoc cref="SunVoxLib.GetTicks"/>
        public uint GetTicks()
        {
            return Library.GetTicks();
        }

        /// <inheritdoc cref="SunVoxLib.GetTicksPerSecond"/>
        public uint GetTicksPerSecond()
        {
            return Library.GetTicksPerSecond();
        }

        /// <inheritdoc cref="SunVoxLib.GetLog(int)"/>
        public string? GetLog(int length)
        {
            return Library.GetLog(length);
        }
    }
}
