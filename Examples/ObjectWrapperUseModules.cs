using SunSharp;
using SunSharp.ObjectWrapper;
using SunSharp.ObjectWrapper.Modules;

namespace Examples;

internal class ObjectWrapperUseModules : BaseExample
{
    protected override void RunTest(ISunVoxLib lib)
    {
        WriteLine("Initializing");
        using (var sv = new SunVox(lib))
        {
            WriteLine("Loading the song");
            var slot = sv.Slots[0];
            slot.Open();
            slot.Load("the_lick.sunvox");
            WriteLine($"Loaded song: {slot.GetSongName()}");

            AnalogGeneratorModuleHandle analogGenerator = slot.Synthesizer
                .First(m => m.GetModuleType() == ModuleType.AnalogGenerator)
                .AsAnalogGenerator();

            WriteLine($"Generator waveform: {analogGenerator.GetWaveform()}");
            WriteLine($"Changing waveform");
            analogGenerator.SetWaveform(AnalogGeneratorWaveform.Drawn);
            Thread.Sleep(1000); // should be long enough
            WriteLine($"Generator waveform: {analogGenerator.GetWaveform()}");
            WriteLine($"Reading drawn values");
            var buffer = new float[32];
            analogGenerator.ReadDrawnValues(buffer);
            foreach (var f in buffer)
                WriteLine($"{f}");
            WriteLine($"Changing drawn values");
            for (int i = 0; i < 32; i++)
            {
                buffer[i] = MathF.Sin(i * MathF.PI * 2 / 32f);
            }

            analogGenerator.WriteDrawnValues(buffer);
            WriteLine($"Reading drawn values");
            analogGenerator.ReadDrawnValues(buffer);

            foreach (var f in buffer)
                WriteLine($"{f}");
            slot.SetAutostop(true);
            slot.Rewind(0);
            slot.Play();

            int line = 0;
            while (line != slot.GetSongLengthInLines() - 1 || slot.IsPlaying())
            {
                var currentLine = slot.GetCurrentLine();
                analogGenerator.SetPanning((int)(128 * MathF.Sin(currentLine / 32f * 4f)));
                if (currentLine != line)
                {
                    line = currentLine;
                    WriteLine($"Current line: {line}");
                }

                Thread.Sleep(10);
            }

            WriteLine("Song finished");
            Thread.Sleep(1000); // wait a second, so the reverb may fade out a bit...
            slot.Close();
        }
    }
}
