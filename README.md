# SunSharp
*[SunVox](https://warmplace.ru/soft/sunvox/)* is a small, fast and powerful modular synthesizer with pattern-based sequencer (tracker). *SunVox Library* is the main part of the *SunVox* engine without a graphical interface.

*SunSharp* is a wrapper and helper library for *SunVox Library*, written in C#. The library contains a thin wrapper, allowing for comfortably making calls with C#-style methods and objects, as well as an intuitive object-oriented wrapper, managing a few more things for the user. Additionally, additional abstractions and mechanisms are provided to help implement dynamic music in games and other software.

Target SunVox version: 2.1b.
## How to install
Two packages are available on NuGet:
* [SunSharp](https://www.nuget.org/packages/Sotakebk.SunSharp/) ![Nuget](https://img.shields.io/nuget/v/Sotakebk.SunSharp) ![Nuget](https://img.shields.io/nuget/dt/Sotakebk.SunSharp)
* [SunSharp.Redistribution](https://www.nuget.org/packages/Sotakebk.SunSharp.Redistribution/)  ![Nuget](https://img.shields.io/nuget/v/Sotakebk.SunSharp.Redistribution) ![Nuget](https://img.shields.io/nuget/dt/Sotakebk.SunSharp.Redistribution)

To use the wrapper, install the *SunSharp* package.
To get automatically managed binaries, install the *SunSharp.Redistribution* package. Alternatively, you may load the library and provide necessary function delegates yourself (see: *SunSharp.LibraryLoading::ProxyClass* and *SunSharp.Redistribution::LibraryLoader*).

Platforms supported by the binaries in *SunSharp.Redistribution* are:
* Windows x86, x86_64;
* Linux x86, x86_64, arm64;
* macOS x86_64, arm64.

There is also a [Unity package](https://github.com/Sotakebk/SunSharpUnity).

## How to start
### Object wrapper
After obtaining an instance of *ISunVoxLib* representing the loaded library, you may create an 'instance' of the engine. All library functions are grouped into objects that make sense together.

Here's an example that plays a song, then waits until it's finished:
```csharp
using SunSharp.ObjectWrapper;
/* ... */
var sv = new SunVox(lib))
var slot = sv.Slots[0];
slot.Open();
slot.Load("song.sunvox");
slot.SetAutostop(true);
slot.Rewind(0);
slot.Play();
int line = 0;
while (line != slot.GetSongLengthInLines() - 1 || slot.IsPlaying())
    line = slot.GetCurrentLine();

WriteLine("Song finished");
slot.Close();
sv.Dispose();
```
### Thin wrapper
If you wish to use the functions as provided, you may use the thin wrapper. All the calls are directly available from the *ISunVoxLib* interface, though using extensions provided in *SunSharp.ThinWrapper* namespace is advisable. The extension methods handle  marshalling and other annoying boilerplate for you; the names are very similar to those in official documentation, and their usage should be very intuitive.

Remember, you will have to deal with locking/unlocking yourself!

Here's an example, equivalent to object wrapper code:
```csharp
using SunSharp.ThinWrapper;
/* ... */
lib.Init(sampleRate: -1);
lib.OpenSlot(0);
lib.Load(0, "song.sunvox");
lib.SetAutostop(0, autostop: true);
lib.Rewind(0, line: 0);
lib.Play(0);
int line = 0;
while (line != lib.GetSongLengthInLines(0) - 1 || lib.IsPlaying(0))
    line = lib.GetCurrentLine(0);

lib.CloseSlot(0);
lib.Deinit();
```
### More examples
More examples available in the [Examples](/Examples) folder.

## Bug reporting
Please use the issues page of this repository. If the problem is with the underlying library, I will pass the necessary information to the SunVox forums myself.

## Questions & Answers
##### Can I use multiple SunVox instances?
Due to engine limitations, only one instance can be used per loaded library. Since it is possible to load multiple libraries, or versions of the same library into your process, it should be possible.
##### Will it work on Android/iOS/whatever?
Maybe? My code is basically a wrapper, so it should be platform invariant. If the platform in question is supported by the SunVox Library, and there is a binary provided, you should be able to load it yourself.
##### Is the library safe?
If you want to, you can shoot yourself in the foot, although there should be warning signs along the way. The code should be transparent enough that any unexpected behaviour should originate from SunVox itself. No promises are made, but if you don't mix thin and object wrapper code, it should be fine.
