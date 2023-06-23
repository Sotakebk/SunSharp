using NAudio.Wave;
using SunSharp;
using SunSharp.ThinWrapper;

namespace Examples
{
    internal class ThinWrapperUserAudioCallback : BaseExample
    {
        protected override void RunTest(ISunVoxLib lib)
        {
            WriteLine("Initializing");
            lib.Init(48000, channels: AudioChannels.Stereo,
                flags: InitFlags.UserAudioCallback | InitFlags.AudioFloat32);
            WriteLine("Loading the song");
            lib.OpenSlot(0);
            lib.Load(0, "the_lick.sunvox");
            WriteLine($"Loaded song: {lib.GetSongName(0)}");
            lib.SetAutoStop(0, autoStop: true);
            lib.Rewind(0, line: 0);
            WriteLine("Playing the song");
            lib.Play(0);

            using (var outputDevice = new WasapiOut())
            {
                var provider = new SunvoxStereoSampleProvider(lib, 48000, 1024);
                outputDevice.Init(provider);
                outputDevice.Play();

                int line = 0;
                while (line != lib.GetSongLengthInLines(0) - 1 || lib.IsPlaying(0))
                {
                    var currentLine = lib.GetCurrentLine(0);
                    if (currentLine != line)
                    {
                        line = currentLine;
                        WriteLine($"Current line: {line}");
                    }

                    Thread.Sleep(10);
                }

                WriteLine("Song finished");
                Thread.Sleep(1000); // wait a second, so the reverb may fade out a bit...
            }

            lib.CloseSlot(0);
            lib.Deinit();
        }

        private class SunvoxStereoSampleProvider : ISampleProvider
        {
            private ISunVoxLib _lib;
            private int _sampleRate;
            private float[] _internalBuffer;
            private int _offset = 0;

            public SunvoxStereoSampleProvider(ISunVoxLib lib, int sampleRate, int internalBufferSize)
            {
                _lib = lib;
                _sampleRate = sampleRate;
                _internalBuffer = new float[internalBufferSize];
                _offset = internalBufferSize;
            }

            public WaveFormat WaveFormat => WaveFormat.CreateIeeeFloatWaveFormat(_sampleRate, 2);

            public int Read(float[] buffer, int offset, int count)
            {
                var time = _lib.GetTicks();
                if (_offset >= _internalBuffer.Length)
                {
                    var ret = _lib.AudioCallback(_internalBuffer, AudioChannels.Stereo, 0, time);
                    _offset = 0;
                }

                var copiedCount = Math.Min(_internalBuffer.Length - _offset, count);
                for (int i = 0; i < copiedCount; i++)
                {
                    buffer[offset + i] = _internalBuffer[_offset + i];
                }

                _offset += copiedCount;
                return copiedCount;
            }
        }
    }
}
