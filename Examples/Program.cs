using System;
using System.Threading;
using SunSharp;
using SunSharp.Redistribution;

namespace Examples;

internal sealed class Program
{
    private static void Main()
    {
        LibraryLoader.Load();
        var libraryInstance = LibraryLoader.GetLibraryInstance();

        using var sunVox = new SunVox(libraryInstance, noDebugOutput: false);

        if (!sunVox.Slots.TryOpenNewSlot(out var slot))
        {
            Console.WriteLine("Failed to open a new slot.");
            return;
        }

        var generator = slot.Synthesizer
            .CreateModule(SynthModuleType.AnalogGenerator, "My Generator Module")
            .AsAnalogGenerator();

        if (!slot.Synthesizer.TryGetModule(0, out var outputModule))
        {
            Console.WriteLine("Failed to get the output module.");
            return;
        }

        slot.Synthesizer.ConnectModule(generator.ModuleHandle, outputModule.Value);

        slot.VirtualPattern.SendEvent(0, PatternEvent.NoteEvent(Note.A(4), generator.ModuleHandle.Id));

        Thread.Sleep(TimeSpan.FromSeconds(1));

        slot.VirtualPattern.SendEvent(0, PatternEvent.NoteEvent(Note.Off, generator.ModuleHandle.Id));
    }
}
