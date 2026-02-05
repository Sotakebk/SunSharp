using SunSharp;
using SunSharp.Redistribution;

var libc = SunVoxLibraryLoader.Load();
using var sunVox = SunVox.WithOwnAudioStream(libc);

if (!sunVox.Slots.TryOpenNewSlot(out var slot))
{
    return -1;
}

slot.Load("bass_and_melody.sunvox");
slot.SetAutomaticStop(false);
slot.StartPlaybackFromBeginning();

var start = DateTime.UtcNow;
do
{
    Thread.Sleep(100);
} while (DateTime.UtcNow - start < TimeSpan.FromSeconds(10));
slot.SetAutomaticStop(true);

do
{
    Thread.Sleep(100);
} while (slot.IsPlaying() || slot.GetCurrentSignalLevel() > 0);

return 0;
