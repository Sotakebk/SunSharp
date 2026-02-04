# SunSharp

SunSharp is a C# wrapper and helper library for the [SunVox Library](https://warmplace.ru/soft/sunvox/) - a small, fast and powerful modular synthesizer with a pattern-based sequencer (tracker).

The objective of this project is to provide easy-to-use and discoverable C# bindings for the SunVox Library. The purpose is to enable developers to use SunVox as a sound engine and/or a dynamic music subsystem in their C# applications, including games.

SunVox is created and maintained by [Alexander Zolotov](https://warmplace.ru/).

Table of Contents

- [SunSharp](#sunsharp)
  - [State of the project](#state-of-the-project)
  - [Where to start](#where-to-start)
    - [How To Use](#how-to-use)
  - [Contributing](#contributing)
  - [Questions \& Answers](#questions--answers)

## State of the project

While the project is currently in active development, the latest (dev) NuGet packages should be reasonably stable and usable in a project.

The targeted SunVox version is 2.1.4.

The following features are planned or in progress:

- complete test coverage;
- separate build of the SunVox library;
  - own extensions to the SunVox library:
    - separate audio I/O per slot;
    - conditional effect execution;
    - callback effects;
    - log callback function instead of STDOUT logging;
    - 3D positioning/panning module;
- updated Unity package;
- Godot package;
- more examples and documentation;
- hosting the library in a separate process to avoid crashes;
- WASM support (SunVox has support for this, but it needs to be integrated into the wrapper)

Any contributions are welcome!

## Where to start

For API reference and documentation, please visit the [GitHub Pages site](https://sotakebk.github.io/SunSharp/).
Information about the underlying SunVox Library can be found on the [official SunVox website](https://warmplace.ru/soft/sunvox/sunvox_lib.php).

Two packages are available on NuGet:

- [SunSharp](https://www.nuget.org/packages/Sotakebk.SunSharp/) ![Nuget](https://img.shields.io/nuget/vpre/Sotakebk.SunSharp) ![Nuget](https://img.shields.io/nuget/dt/Sotakebk.SunSharp)
- [SunSharp.Redistribution](https://www.nuget.org/packages/Sotakebk.SunSharp.Redistribution/)  ![Nuget](https://img.shields.io/nuget/vpre/Sotakebk.SunSharp.Redistribution) ![Nuget](https://img.shields.io/nuget/dt/Sotakebk.SunSharp.Redistribution)

For future development, please consider using the `2.0.0-dev` pre-release versions of the packages, as they contain major improvements, new features, and bug fixes.

The `SunSharp` package contains the C# wrapper code only, while the `SunSharp.Redistribution` package contains pre-built SunVox library binaries for multiple platforms and a loader for them. Depending on your use case, you may choose to use only the `SunSharp` package and provide your own SunVox library binaries. If you are working with a game engine, you may need to bind the library manually.

Depending on the engine, a dedicated package may be available:

- Unity: [SunSharpUnity](https://github.com/Sotakebk/SunSharpUnity);
- Godot: (in progress)

### How To Use

Quick start example:

```csharp
// TODO
```

There is code available in the [examples](/examples) folder of the repository that contains source code for simple console applications demonstrating the usage of the wrapper.

## Contributing

Any contributions are welcome! Feel free to open issues or pull requests on GitHub.

Additional information on contributing can be found on the project [GitHub Pages site](https://sotakebk.github.io/SunSharp/).

## Questions & Answers

**Can I use multiple SunVox instances?**

Due to engine limitations, only one instance can be used per loaded library. Since it is possible to load multiple libraries, or versions of the same library into your process, it should be possible.

**Will it work on Android/iOS/whatever?**

It is currently not tested on mobile platforms, but in theory, it should be possible to use the SunVox library binaries for those platforms, load them and bind them with the wrapper.

**Is the library safe?**

The wrapper code should be safe. The underlying SunVox library may not be. There are known issues with memory corruption and crashes in some scenarios, but they only happen in edge cases. If you are using the library in a safe manner (e.g., not calling functions from multiple threads simultaneously), and ensure proper usage (e.g., by checking if the underlying module is of the expected type), it should be fine.

If you encounter any issues, please report them.

**Can I use this in my commercial project?**

Yes, you can.

- The wrapper is licensed under the MIT license.
- The SunVox library is distributed under the MIT license, and requires attribution and a note that it is based on SunVox. Please refer to the [author's website](https://warmplace.ru) for more details.
