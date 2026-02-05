# Getting Started with SunSharp

For API reference and documentation, please visit the [GitHub Pages site](https://sotakebk.github.io/SunSharp/).
Information about the underlying SunVox Library can be found on the [official SunVox website](https://warmplace.ru/soft/sunvox/sunvox_lib.php).

## Packages

Two packages are available on NuGet:

- [SunSharp](https://www.nuget.org/packages/Sotakebk.SunSharp/) ![Nuget](https://img.shields.io/nuget/vpre/Sotakebk.SunSharp) ![Nuget](https://img.shields.io/nuget/dt/Sotakebk.SunSharp)
- [SunSharp.Redistribution](https://www.nuget.org/packages/Sotakebk.SunSharp.Redistribution/)  ![Nuget](https://img.shields.io/nuget/vpre/Sotakebk.SunSharp.Redistribution) ![Nuget](https://img.shields.io/nuget/dt/Sotakebk.SunSharp.Redistribution)

For future development, please consider using the `2.0.0-dev` pre-release versions of the packages, as they contain major improvements, new features, and bug fixes.

The `SunSharp` package contains the C# wrapper code only, while the `SunSharp.Redistribution` package contains pre-built SunVox library binaries for multiple platforms and a loader for them. Depending on your use case, you may choose to use only the `SunSharp` package and provide your own SunVox library binaries. If you are working with a game engine, you may need to bind the library manually.

Depending on the engine, a dedicated package may be available:

- Unity: [SunSharpUnity](https://github.com/Sotakebk/SunSharpUnity);
- Godot: (in progress)

## Usage

There are two methods of using the wrapper in your project:

- using the object-oriented API, which provides a more user-friendly interface and is recommended for most use cases;
- using the functional API, which provides a more direct mapping to the underlying C API and may be useful for advanced users or for performance-critical code.

## Testability

If you need testability in your project, the API has full interface coverage, allowing you to mock the SunVox library calls with ease.

## Examples

For a quick start, see the example below:

```csharp
using SunSharp;
using SunSharp.Redistribution;

var libc = SunVoxLibraryLoader.Load();
using var sunVox = SunVox.WithOwnAudioStream(libc);
var slot = sunVox.Slots[0];

slot.Open();
slot.Load("bass_and_melody.sunvox");
slot.SetAutomaticStop(false);
slot.StartPlaybackFromBeginning();

do
{
    Thread.Sleep(100);
} while (slot.IsPlaying() || slot.GetCurrentSignalLevel() > 0);
```

There is code available in the [examples](https://github.com/Sotakebk/SunSharp/tree/master/Examples) folder of the repository that contains source code for simple console applications demonstrating the usage of the wrapper.
