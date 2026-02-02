#if RELEASE

using System;
using System.Threading;
using SunSharp;
using SunSharp.Modules;
using SunSharp.Redistribution;

namespace Examples;

internal sealed class Program
{
    private static void Main()
    {
        var libraryInstance = LibraryLoader.Load();
        using var sunVox = new SunVox(libraryInstance, noDebugOutput: false);

        if (!sunVox.Slots.TryOpenNewSlot(out var slot))
        {
            Console.WriteLine("Failed to open a new slot.");
            return;
        }

        AnalogGeneratorModuleHandle generator;
        using (var slotLock = slot.AcquireLock())
        {
            generator = slot.Synthesizer
                .CreateModule(SynthModuleType.AnalogGenerator, "My Generator Module")
                .AsAnalogGenerator();

            if (!slot.Synthesizer.TryGetModule(0, out var outputModule))
            {
                Console.WriteLine("Failed to get the output module.");
                return;
            }

            slot.Synthesizer.ConnectModule(generator.ModuleHandle, outputModule.Value);
        }

        slot.VirtualPattern.SendEvent(0, generator.MakeNoteEvent(Note.A(4)));

        Thread.Sleep(TimeSpan.FromSeconds(1));

        slot.VirtualPattern.SendEvent(0, PatternEvent.NoteEvent(Note.Off, generator.ModuleHandle.Id));
    }
}

#else

namespace Examples;

internal sealed class Program
{
    private static void Main()
    {
    }
}
#endif
