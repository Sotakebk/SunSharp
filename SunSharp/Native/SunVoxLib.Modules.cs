using System;
using System.Runtime.InteropServices;

namespace SunSharp.Native
{
    public partial struct SunVoxLib : ISunVoxLib
    {
        /// <summary>
        /// Connect the source module to the destination module.
        /// </summary>
        /// <param name="slotId">slot number (0 to 15).</param>
        /// <param name="source">Source module number (0-based).</param>
        /// <param name="destination">Destination module number (0-based).</param>
        /// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
        /// <remarks>
        /// <para>Requires <see cref="LockSlot"/> / <see cref="UnlockSlot"/>.</para>
        /// Calls <see cref="ISunVoxLibC.sv_connect_module"/>.
        /// </remarks>
        public void ConnectModule(int slotId, int source, int destination)
        {
            var ret = _lib.sv_connect_module(slotId, source, destination);
            if (ret != 0)
            {
                var details = $"{nameof(slotId)}: {slotId}, {nameof(source)}: {source}, {nameof(destination)}: {destination}.";
                throw new SunVoxException(ret, nameof(_lib.sv_connect_module), details);
            }
        }

        /// <inheritdoc cref="CreateModule(int, string, string?, int, int, int)"/>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the module type is not valid.</exception>
        public int CreateModule(int slotId, SynthModuleType type, string? name = null, int x = 0, int y = 0, int z = 0)
        {
            if (!SynthModuleTypeHelper.IsValid(type))
            {
                throw new ArgumentOutOfRangeException(nameof(type), "The ModuleType value is not defined.");
            }
            return CreateModule(slotId, SynthModuleTypeHelper.InternalNameFromType(type), name, x, y, z);
        }

        /// <summary>
        /// Create a new module.
        /// </summary>
        /// <param name="slotId">slot number (0 to 15).</param>
        /// <param name="type">Type of module to create.</param>
        /// <param name="name">Name of the module.</param>
        /// <param name="x">X coordinate (0 to 1024, center: 512).</param>
        /// <param name="y">Y coordinate (0 to 1024, center: 512).</param>
        /// <param name="z">Layer number (0 to 7).</param>
        /// <returns>The identifier of the newly created module (0-based).</returns>
        /// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
        /// <remarks>
        /// <para>Requires <see cref="LockSlot"/> / <see cref="UnlockSlot"/>.</para>
        /// Calls <see cref="ISunVoxLibC.sv_new_module"/>.
        /// </remarks>
        public int CreateModule(int slotId, string type, string? name = null, int x = 0, int y = 0, int z = 0)
        {
            var typePtr = Marshal.StringToCoTaskMemUTF8(type);
            IntPtr namePtr = IntPtr.Zero;
            if (name != null)
            {
                namePtr = Marshal.StringToCoTaskMemUTF8(name);
            }
            int ret;
            try
            {
                ret = _lib.sv_new_module(slotId, typePtr, namePtr, x, y, z);
            }
            finally
            {
                Marshal.ZeroFreeCoTaskMemUTF8(typePtr);
                if (namePtr != IntPtr.Zero)
                {
                    Marshal.ZeroFreeCoTaskMemUTF8(namePtr);
                }
            }

            if (ret < 0)
            {
                var details = $"{nameof(slotId)}: {slotId}, {nameof(type)}: '{type}', {nameof(name)}: '{name ?? "<null>"}', {nameof(x)}: {x}, {nameof(y)}: {y}, {nameof(z)}: {z}.";
                throw new SunVoxException(ret, nameof(_lib.sv_new_module), details);
            }
            return ret;
        }

        /// <summary>
        /// Disconnect the source module from the destination module.
        /// </summary>
        /// <param name="slotId">slot number (0 to 15).</param>
        /// <param name="source">Source module number (0-based).</param>
        /// <param name="destination">Destination module number (0-based).</param>
        /// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
        /// <remarks>
        /// <para>Requires <see cref="LockSlot"/> / <see cref="UnlockSlot"/>.</para>
        /// Calls <see cref="ISunVoxLibC.sv_disconnect_module"/>.
        /// </remarks>
        public void DisconnectModule(int slotId, int source, int destination)
        {
            var ret = _lib.sv_disconnect_module(slotId, source, destination);
            if (ret != 0)
            {
                var details = $"{nameof(slotId)}: {slotId}, {nameof(source)}: {source}, {nameof(destination)}: {destination}.";
                throw new SunVoxException(ret, nameof(_lib.sv_disconnect_module), details);
            }
        }

        /// <summary>
        /// Find a module by name.
        /// </summary>
        /// <param name="slotId">slot number (0 to 15).</param>
        /// <param name="name">Module name to search for.</param>
        /// <returns>module number  (0-based) if found.</returns>
        /// <exception cref="SunVoxException">Thrown when an error occurs during the search.</exception>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_find_module"/>.</remarks>
        public int? FindModule(int slotId, string name)
        {
            var ptr = Marshal.StringToCoTaskMemUTF8(name);
            int ret;
            try
            {
                ret = _lib.sv_find_module(slotId, ptr);
            }
            finally
            {
                Marshal.ZeroFreeCoTaskMemUTF8(ptr);
            }

            if (ret < -1)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_find_module),
                    $"{nameof(slotId)}: {slotId}, {nameof(name)}: '{name ?? "<null>"}'.");
            }

            if (ret != -1)
                return ret;
            return null;
        }

        /// <summary>
        /// Get the module color.
        /// </summary>
        /// <param name="slotId">slot number (0 to 15).</param>
        /// <param name="moduleId">module number (0-based).</param>
        /// <returns>RGB color tuple (r, g, b).</returns>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_get_module_color"/>.</remarks>
        public (byte r, byte g, byte b) GetModuleColor(int slotId, int moduleId)
        {
            var ret = _lib.sv_get_module_color(slotId, moduleId);
            var red = (byte)(ret & 0xFF);
            var green = (byte)((ret >> 8) & 0xFF);
            var blue = (byte)((ret >> 16) & 0xFF);
            return (red, green, blue);
        }

        /// <summary>
        /// Get the number of controllers in the module.
        /// </summary>
        /// <param name="slotId">slot number (0 to 15).</param>
        /// <param name="moduleId">module number (0-based).</param>
        /// <returns>Number of controllers.</returns>
        /// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_get_number_of_module_ctls"/>.</remarks>
        public int GetModuleControllerCount(int slotId, int moduleId)
        {
            var ret = _lib.sv_get_number_of_module_ctls(slotId, moduleId);
            if (ret < 0)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_get_number_of_module_ctls),
                    $"{nameof(slotId)}: {slotId}, {nameof(moduleId)}: {moduleId}.");
            }
            return ret;
        }

        /// <summary>
        /// Get the controller group number.
        /// </summary>
        /// <param name="slotId">slot number (0 to 15).</param>
        /// <param name="moduleId">module number (0-based).</param>
        /// <param name="controllerId">controller number (0-based).</param>
        /// <returns>Controller group number.</returns>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_get_module_ctl_group"/>.</remarks>
        public int GetModuleControllerGroup(int slotId, int moduleId, int controllerId)
        {
            return _lib.sv_get_module_ctl_group(slotId, moduleId, controllerId);
        }

        /// <summary>
        /// Get the controller maximum value.
        /// </summary>
        /// <param name="slotId">slot number (0 to 15).</param>
        /// <param name="moduleId">module number (0-based).</param>
        /// <param name="controllerId">Controller number (0-based).</param>
        /// <param name="scalingMode">Value scaling mode.</param>
        /// <returns>Maximum controller value.</returns>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_get_module_ctl_max"/>.</remarks>
        public int GetModuleControllerMaxValue(int slotId, int moduleId, int controllerId, ValueScalingMode scalingMode)
        {
            return _lib.sv_get_module_ctl_max(slotId, moduleId, controllerId, (int)scalingMode);
        }

        /// <summary>
        /// Get the controller minimum value.
        /// </summary>
        /// <param name="slotId">slot number (0 to 15).</param>
        /// <param name="moduleId">module number (0-based).</param>
        /// <param name="controllerId">Controller number (0-based).</param>
        /// <param name="scalingMode">Value scaling mode.</param>
        /// <returns>Minimum controller value.</returns>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_get_module_ctl_min"/>.</remarks>
        public int GetModuleControllerMinValue(int slotId, int moduleId, int controllerId, ValueScalingMode scalingMode)
        {
            return _lib.sv_get_module_ctl_min(slotId, moduleId, controllerId, (int)scalingMode);
        }

        /// <summary>
        /// Get the controller name.
        /// </summary>
        /// <param name="slotId">slot number (0 to 15).</param>
        /// <param name="moduleId">module number (0-based).</param>
        /// <param name="controllerId">Controller number (0-based).</param>
        /// <returns>Controller name, or <see langword="null"/> if unavailable.</returns>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_get_module_ctl_name"/>.</remarks>
        public string? GetModuleControllerName(int slotId, int moduleId, int controllerId)
        {
            // memory managed by SunVox
            var ptr = _lib.sv_get_module_ctl_name(slotId, moduleId, controllerId);
            return Marshal.PtrToStringUTF8(ptr);
        }

        /// <summary>
        /// Get the controller display value offset.
        /// </summary>
        /// <param name="slotId">slot number (0 to 15).</param>
        /// <param name="moduleId">module number (0-based).</param>
        /// <param name="controllerId">Controller number (0-based).</param>
        /// <returns>Display value offset.</returns>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_get_module_ctl_offset"/>.</remarks>
        public int GetModuleControllerOffset(int slotId, int moduleId, int controllerId)
        {
            return _lib.sv_get_module_ctl_offset(slotId, moduleId, controllerId);
        }

        /// <summary>
        /// Get the controller type.
        /// </summary>
        /// <param name="slotId">slot number (0 to 15).</param>
        /// <param name="moduleId">module number (0-based).</param>
        /// <param name="controllerId">Controller number (0-based).</param>
        /// <returns>Controller type.</returns>
        /// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_get_module_ctl_type"/>.</remarks>
        public ControllerType GetModuleControllerType(int slotId, int moduleId, int controllerId)
        {
            var ret = _lib.sv_get_module_ctl_type(slotId, moduleId, controllerId);
            if (ret < 0 || ret > 1)
            {
                var details = $"{nameof(slotId)}: {slotId}, {nameof(moduleId)}: {moduleId}, {nameof(controllerId)}: {controllerId}.";
                throw new SunVoxException(ret, nameof(_lib.sv_get_module_ctl_type), details);
            }

            return (ControllerType)ret;
        }

        /// <summary>
        /// Get the controller value.
        /// </summary>
        /// <param name="slotId">slot number (0 to 15).</param>
        /// <param name="moduleId">module number (0-based).</param>
        /// <param name="controllerId">Controller number (0-based).</param>
        /// <param name="scalingMode">Value scaling mode.</param>
        /// <returns>Controller value.</returns>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_get_module_ctl_value"/>.</remarks>
        public int GetModuleControllerValue(int slotId, int moduleId, int controllerId, ValueScalingMode scalingMode)
        {
            return _lib.sv_get_module_ctl_value(slotId, moduleId, controllerId, (int)scalingMode);
        }

        /// <summary>
        /// Check if a module exists.
        /// </summary>
        /// <param name="slotId">slot number (0 to 15).</param>
        /// <param name="moduleId">module number (0-based).</param>
        /// <returns><see langword="true"/> if module exists.</returns>
        /// <remarks>
        /// Calls <see cref="ISunVoxLibC.sv_get_module_flags"/>.
        /// </remarks>
        public bool GetModuleExists(int slotId, int moduleId)
        {
            return GetModuleFlags(slotId, moduleId).Exists;
        }

        /// <summary>
        /// Get the module fine tune and relative note values.
        /// </summary>
        /// <param name="slotId">slot number (0 to 15).</param>
        /// <param name="moduleId">module number (0-based).</param>
        /// <returns>Fine tune pair containing fine tune value and relative note.</returns>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_get_module_finetune"/>.</remarks>
        public FineTunePair GetModuleFineTune(int slotId, int moduleId)
        {
            var (fineTune, relativeNote) = UtilityHelper.UnpackTwoSignedShorts(_lib.sv_get_module_finetune(slotId, moduleId));
            return new FineTunePair(fineTune, relativeNote);
        }

        /// <summary>
        /// Get the module flags.
        /// </summary>
        /// <param name="slotId">slot number (0 to 15).</param>
        /// <param name="moduleId">module number (0-based).</param>
        /// <returns>Module flags indicating existence, type, state, and connections.</returns>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_get_module_flags"/>.</remarks>
        public ModuleFlags GetModuleFlags(int slotId, int moduleId)
        {
            return _lib.sv_get_module_flags(slotId, moduleId);
        }

        /// <summary>
        /// Get the array of input module numbers connected to this module.
        /// </summary>
        /// <param name="slotId">slot number (0 to 15).</param>
        /// <param name="moduleId">module number (0-based).</param>
        /// <returns>Array of connected input module numbers.</returns>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_get_module_inputs"/>.</remarks>
        public int[] GetModuleInputs(int slotId, int moduleId)
        {
            var moduleFlags = GetModuleFlags(slotId, moduleId);
            var inputCount = moduleFlags.InputUpperCount;
            if (!moduleFlags.Exists || inputCount == 0)
            {
                return Array.Empty<int>();
            }

            // memory managed by SunVox
            var ptr = _lib.sv_get_module_inputs(slotId, moduleId);
            return UtilityHelper.CopyIntArraySkipNegativeOnes(ptr, inputCount);
        }

        /// <summary>
        /// Get the module name.
        /// </summary>
        /// <param name="slotId">slot number (0 to 15).</param>
        /// <param name="moduleId">module number (0-based).</param>
        /// <returns>Module name, or <see langword="null"/> if unavailable.</returns>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_get_module_name"/>.</remarks>
        public string? GetModuleName(int slotId, int moduleId)
        {
            // memory managed by SunVox
            var ptr = _lib.sv_get_module_name(slotId, moduleId);
            return Marshal.PtrToStringUTF8(ptr);
        }

        /// <summary>
        /// Get the array of output module numbers connected from this module.
        /// </summary>
        /// <param name="slotId">slot number (0 to 15).</param>
        /// <param name="moduleId">module number (0-based).</param>
        /// <returns>Array of connected output module numbers.</returns>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_get_module_outputs"/>.</remarks>
        public int[] GetModuleOutputs(int slotId, int moduleId)
        {
            var moduleFlags = GetModuleFlags(slotId, moduleId);
            var outputCount = moduleFlags.OutputUpperCount;
            if (!moduleFlags.Exists || outputCount == 0)
                return Array.Empty<int>();

            // memory managed by SunVox
            var ptr = _lib.sv_get_module_outputs(slotId, moduleId);
            return UtilityHelper.CopyIntArraySkipNegativeOnes(ptr, outputCount);
        }

        /// <summary>
        /// Get the module position on the canvas.
        /// </summary>
        /// <param name="slotId">slot number (0 to 15).</param>
        /// <param name="moduleId">module number (0-based).</param>
        /// <returns>Tuple containing X and Y coordinates.</returns>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_get_module_xy"/>.</remarks>
        public (int x, int y) GetModulePosition(int slotId, int moduleId)
        {
            return UtilityHelper.UnpackTwoSignedShorts(_lib.sv_get_module_xy(slotId, moduleId));
        }

        /// <summary>
        /// Get the module type string.
        /// </summary>
        /// <param name="slotId">slot number (0 to 15).</param>
        /// <param name="moduleId">module number (0-based).</param>
        /// <returns>Module type string, or <see langword="null"/> if unavailable.</returns>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_get_module_type"/>.</remarks>
        public string? GetModuleType(int slotId, int moduleId)
        {
            var ptr = _lib.sv_get_module_type(slotId, moduleId);
            return Marshal.PtrToStringUTF8(ptr);
        }

        /// <summary>
        /// Get the upper limit of module count (one more than the highest module number).
        /// </summary>
        /// <param name="slotId">slot number (0 to 15).</param>
        /// <returns>Upper limit of module count.</returns>
        /// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_get_number_of_modules"/>.</remarks>
        public int GetUpperModuleCount(int slotId)
        {
            var ret = _lib.sv_get_number_of_modules(slotId);
            if (ret < 0)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_get_number_of_modules), $"{nameof(slotId)}: {slotId}.");
            }
            return ret;
        }

        /// <summary>
        /// Load a file into a MetaModule.
        /// Supported file formats: sunvox, mod, xm, midi.
        /// </summary>
        /// <param name="slotId">slot number (0 to 15).</param>
        /// <param name="moduleId">Metamodule number (0-based).</param>
        /// <param name="path">File path (relative or absolute).</param>
        /// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_metamodule_load"/>.</remarks>
        public void LoadIntoMetaModule(int slotId, int moduleId, string path)
        {
            var ptr = Marshal.StringToCoTaskMemUTF8(path);
            int ret;
            try
            {
                ret = _lib.sv_metamodule_load(slotId, moduleId, ptr);
            }
            finally
            {
                Marshal.ZeroFreeCoTaskMemUTF8(ptr);
            }

            if (ret != 0)
            {
                var details = $"{nameof(slotId)}: {slotId}, {nameof(moduleId)}: {moduleId}, {nameof(path)}: '{path ?? "<null>"}'.";
                throw new SunVoxException(ret, nameof(_lib.sv_metamodule_load), details);
            }
        }

        /// <summary>
        /// Load a file into a MetaModule from memory.
        /// Supported file formats: sunvox, mod, xm, midi.
        /// </summary>
        /// <param name="slotId">slot number (0 to 15).</param>
        /// <param name="moduleId">Metamodule number (0-based).</param>
        /// <param name="data">Byte array with project data.</param>
        /// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_metamodule_load_from_memory"/>.</remarks>
        public void LoadIntoMetaModule(int slotId, int moduleId, byte[] data)
        {
            var handle = GCHandle.Alloc(data, GCHandleType.Pinned);
            int ret;
            try
            {
                ret = _lib.sv_metamodule_load_from_memory(slotId, moduleId, handle.AddrOfPinnedObject(), (uint)data.Length);
            }
            finally
            {
                handle.Free();
            }

            if (ret != 0)
            {
                var details = $"{nameof(slotId)}: {slotId}, {nameof(moduleId)}: {moduleId}, data length: {data.Length}.";
                throw new SunVoxException(ret, nameof(_lib.sv_metamodule_load_from_memory), details);
            }
        }

        /// <summary>
        /// Load a file into a Vorbis Player module.
        /// Supported file formats: ogg.
        /// </summary>
        /// <param name="slotId">slot number (0 to 15).</param>
        /// <param name="moduleId">Vorbis Player module number (0-based).</param>
        /// <param name="path">File path (relative or absolute).</param>
        /// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_vplayer_load"/>.</remarks>
        public void LoadIntoVorbisPlayer(int slotId, int moduleId, string path)
        {
            var ptr = Marshal.StringToCoTaskMemUTF8(path);
            int ret;
            try
            {
                ret = _lib.sv_vplayer_load(slotId, moduleId, ptr);
            }
            finally
            {
                Marshal.ZeroFreeCoTaskMemUTF8(ptr);
            }

            if (ret != 0)
            {
                var details = $"{nameof(slotId)}: {slotId}, {nameof(moduleId)}: {moduleId}, {nameof(path)}: '{path ?? "<null>"}'.";
                throw new SunVoxException(ret, nameof(_lib.sv_vplayer_load), details);
            }
        }

        /// <summary>
        /// Load a file into a Vorbis Player module from memory.
        /// Supported file formats: ogg.
        /// </summary>
        /// <param name="slotId">slot number (0 to 15).</param>
        /// <param name="moduleId">Vorbis Player module number (0-based).</param>
        /// <param name="data">Byte array with audio file data.</param>
        /// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_vplayer_load_from_memory"/>.</remarks>
        public void LoadIntoVorbisPlayer(int slotId, int moduleId, byte[] data)
        {
            var handle = GCHandle.Alloc(data, GCHandleType.Pinned);
            int ret;
            try
            {
                ret = _lib.sv_vplayer_load_from_memory(slotId, moduleId, handle.AddrOfPinnedObject(),
                    (uint)data.Length);
            }
            finally
            {
                handle.Free();
            }

            if (ret != 0)
            {
                var details = $"{nameof(slotId)}: {slotId}, {nameof(moduleId)}: {moduleId}, data length: {data.Length}.";
                throw new SunVoxException(ret, nameof(_lib.sv_vplayer_load_from_memory), details);
            }
        }

        /// <summary>
        /// Load a module or sample from file.
        /// Supported file formats: sunsynth, xi, wav, aiff.
        /// </summary>
        /// <param name="slotId">slot number (0 to 15).</param>
        /// <param name="path">File path (relative or absolute).</param>
        /// <param name="x">X coordinate (0 to 1024, center: 512).</param>
        /// <param name="y">Y coordinate (0 to 1024, center: 512).</param>
        /// <param name="z">Layer number (0 to 7).</param>
        /// <returns>The number of the loaded module.</returns>
        /// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_load_module"/>.</remarks>
        public int LoadModule(int slotId, string path, int x = 0, int y = 0, int z = 0)
        {
            var ptr = Marshal.StringToCoTaskMemUTF8(path);
            int ret;
            try
            {
                ret = _lib.sv_load_module(slotId, ptr, x, y, z);
            }
            finally
            {
                Marshal.ZeroFreeCoTaskMemUTF8(ptr);
            }

            if (ret < 0)
            {
                var details = $"{nameof(slotId)}: {slotId}, {nameof(path)}: '{path ?? "<null>"}', {nameof(x)}: {x}, {nameof(y)}: {y}, {nameof(z)}: {z}.";
                throw new SunVoxException(ret, nameof(_lib.sv_load_module), details);
            }
            return ret;
        }

        /// <summary>
        /// Load a module or sample from memory.
        /// Supported file formats: sunsynth, xi, wav, aiff.
        /// </summary>
        /// <param name="slotId">slot number (0 to 15).</param>
        /// <param name="data">Byte array with module data.</param>
        /// <param name="x">X coordinate (0 to 1024, center: 512).</param>
        /// <param name="y">Y coordinate (0 to 1024, center: 512).</param>
        /// <param name="z">Layer number (0 to 7).</param>
        /// <returns>The number of the loaded module.</returns>
        /// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_load_module_from_memory"/>.</remarks>
        public int LoadModule(int slotId, byte[] data, int x = 0, int y = 0, int z = 0)
        {
            var handle = GCHandle.Alloc(data, GCHandleType.Pinned);
            int ret;
            try
            {
                ret = _lib.sv_load_module_from_memory(slotId, handle.AddrOfPinnedObject(), (uint)data.Length, x, y, z);
            }
            finally
            {
                handle.Free();
            }

            if (ret < 0)
            {
                var details = $"{nameof(slotId)}: {slotId}, data length: {data.Length}, {nameof(x)}: {x}, {nameof(y)}: {y}, {nameof(z)}: {z}.";
                throw new SunVoxException(ret, nameof(_lib.sv_load_module_from_memory), details);
            }
            return ret;
        }

        /// <summary>
        /// Load a sample into a Sampler module.
        /// Supported file formats: xi, wav, aiff.
        /// Set <paramref name="sampleSlot"/> to <see langword="null"/> to apply the sample to all sample slots.
        /// </summary>
        /// <param name="slotId">slot number (0 to 15).</param>
        /// <param name="moduleId">Sampler module number (0-based).</param>
        /// <param name="path">File path (relative or absolute).</param>
        /// <param name="sampleSlot">Sample slot number (-1 for auto/all slots).</param>
        /// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_sampler_load"/>.</remarks>
        public void LoadSamplerSample(int slotId, int moduleId, string path, int? sampleSlot = null)
        {
            var ptr = Marshal.StringToCoTaskMemUTF8(path);
            int ret;
            try
            {
                ret = _lib.sv_sampler_load(slotId, moduleId, ptr, sampleSlot ?? -1);
            }
            finally
            {
                Marshal.ZeroFreeCoTaskMemUTF8(ptr);
            }

            if (ret != 0)
            {
                var details = $"{nameof(slotId)}: {slotId}, {nameof(moduleId)}: {moduleId}, {nameof(path)}: '{path ?? "<null>"}', {nameof(sampleSlot)}: {sampleSlot}.";
                throw new SunVoxException(ret, nameof(_lib.sv_sampler_load), details);
            }
        }

        /// <summary>
        /// Load a sample into a Sampler module from memory.
        /// Supported file formats: xi, wav, aiff.
        /// Set <paramref name="sampleSlot"/> to <see langword="null"/> to apply the sample to all sample slots.
        /// </summary>
        /// <param name="slotId">slot number (0 to 15).</param>
        /// <param name="moduleId">Sampler module number (0-based).</param>
        /// <param name="data">Byte array with sample data.</param>
        /// <param name="sampleSlot">Sample slot number (-1 for auto/all slots).</param>
        /// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_sampler_load_from_memory"/>.</remarks>
        public void LoadSamplerSample(int slotId, int moduleId, byte[] data, int? sampleSlot = null)
        {
            var handle = GCHandle.Alloc(data, GCHandleType.Pinned);
            int ret;
            try
            {
                var intPtr = handle.AddrOfPinnedObject();
                ret = _lib.sv_sampler_load_from_memory(slotId, moduleId, intPtr, (uint)data.Length, sampleSlot ?? -1);
            }
            finally
            {
                handle.Free();
            }

            if (ret != 0)
            {
                var details = $"{nameof(slotId)}: {slotId}, {nameof(moduleId)}: {moduleId}, data length: {data.Length}, {nameof(sampleSlot)}: {sampleSlot}.";
                throw new SunVoxException(ret, nameof(_lib.sv_sampler_load_from_memory), details);
            }
        }

        /// <summary>
        /// Read data from a module curve.
        /// </summary>
        /// <param name="slotId">slot number (0 to 15).</param>
        /// <param name="moduleId">module number (0-based).</param>
        /// <param name="curveId">Curve number.</param>
        /// <param name="data">Array to receive curveId data.</param>
        /// <returns>Number of values read.</returns>
        /// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_module_curve"/>.</remarks>
        public int ReadModuleCurve(int slotId, int moduleId, int curveId, float[] data)
        {
            var ret = ModuleCurveOperationInternal(slotId, moduleId, curveId, data, false);
            if (ret < 0)
            {
                var details = $"{nameof(slotId)}: {slotId}, {nameof(moduleId)}: {moduleId}, {nameof(curveId)}: {curveId}, data length: {data.Length}.";
                throw new SunVoxException(ret, nameof(_lib.sv_module_curve), details);
            }
            return ret;
        }

        /// <summary>
        /// Read oscilloscope data from a module.
        /// </summary>
        /// <param name="slotId">slot number (0 to 15).</param>
        /// <param name="moduleId">module number (0-based).</param>
        /// <param name="channel">Audio channel.</param>
        /// <param name="buffer">Buffer to receive scope data.</param>
        /// <returns>Number of samples read.</returns>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_get_module_scope2"/>.</remarks>
        public int ReadModuleScope(int slotId, int moduleId, AudioChannel channel, short[] buffer)
        {
            var handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            var ptr = handle.AddrOfPinnedObject();
            try
            {
                return (int)_lib.sv_get_module_scope2(slotId, moduleId, (int)channel, ptr, (uint)buffer.Length);
            }
            finally
            {
                handle.Free();
            }
        }

        /// <summary>
        /// Remove (delete) a module.
        /// </summary>
        /// <param name="slotId">slot number (0 to 15).</param>
        /// <param name="moduleId">module number (0-based).</param>
        /// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
        /// <remarks>
        /// <para>Requires <see cref="LockSlot"/> / <see cref="UnlockSlot"/>.</para>
        /// Calls <see cref="ISunVoxLibC.sv_remove_module"/>.
        /// </remarks>
        public void RemoveModule(int slotId, int moduleId)
        {
            var ret = _lib.sv_remove_module(slotId, moduleId);
            if (ret != 0)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_remove_module), $"{nameof(slotId)}: {slotId}, {nameof(moduleId)}: {moduleId}.");
            }
        }

        /// <summary>
        /// Set the module color.
        /// </summary>
        /// <param name="slotId">slot number (0 to 15).</param>
        /// <param name="moduleId">module number (0-based).</param>
        /// <param name="r">Red component (0 to 255).</param>
        /// <param name="g">Green component (0 to 255).</param>
        /// <param name="b">Blue component (0 to 255).</param>
        /// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_set_module_color"/>.</remarks>
        public void SetModuleColor(int slotId, int moduleId, byte r, byte g, byte b)
        {
            var color = r | (g << 8) | (b << 16);
            var ret = _lib.sv_set_module_color(slotId, moduleId, color);
            if (ret != 0)
            {
                var details = $"{nameof(slotId)}: {slotId}, {nameof(moduleId)}: {moduleId}, {nameof(r)}: {r}, {nameof(g)}: {g}, {nameof(b)}: {b}.";
                throw new SunVoxException(ret, nameof(_lib.sv_set_module_color), details);
            }
        }

        /// <summary>
        /// Set a controller value.
        /// Note: <see cref="SendEvent"/> will be used internally, which may introduce latency.
        /// </summary>
        /// <param name="slotId">slot number (0 to 15).</param>
        /// <param name="moduleId">module number (0-based).</param>
        /// <param name="controllerId">controller number (0-based).</param>
        /// <param name="value">Controller value.</param>
        /// <param name="scalingMode">Value scaling mode.</param>
        /// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_set_module_ctl_value"/>.</remarks>
        public void SetModuleControllerValue(int slotId, int moduleId, int controllerId, int value,
            ValueScalingMode scalingMode)
        {
            var ret = _lib.sv_set_module_ctl_value(slotId, moduleId, controllerId, value, (int)scalingMode);
            if (ret != 0)
            {
                var details = $"{nameof(slotId)}: {slotId}, {nameof(moduleId)}: {moduleId}, {nameof(controllerId)}: {controllerId}, {nameof(value)}: {value}, {nameof(scalingMode)}: {scalingMode}.";
                throw new SunVoxException(ret, nameof(_lib.sv_set_module_ctl_value), details);
            }
        }

        /// <summary>
        /// Set the module fine tune value.
        /// </summary>
        /// <param name="slotId">slot number (0 to 15).</param>
        /// <param name="moduleId">module number (0-based).</param>
        /// <param name="fineTune">Fine tune value (-256 to 256, 1/256 of a semitone).</param>
        /// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_set_module_finetune"/>.</remarks>
        public void SetModuleFineTune(int slotId, int moduleId, int fineTune)
        {
            var ret = _lib.sv_set_module_finetune(slotId, moduleId, fineTune);
            if (ret != 0)
            {
                var details = $"{nameof(slotId)}: {slotId}, {nameof(moduleId)}: {moduleId}, {nameof(fineTune)}: {fineTune}.";
                throw new SunVoxException(ret, nameof(_lib.sv_set_module_finetune), details);
            }
        }

        /// <summary>
        /// Set the module name.
        /// </summary>
        /// <param name="slotId">slot number (0 to 15).</param>
        /// <param name="moduleId">module number (0-based).</param>
        /// <param name="name">New module name.</param>
        /// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_set_module_name"/>.</remarks>
        public void SetModuleName(int slotId, int moduleId, string name)
        {
            var ptr = Marshal.StringToCoTaskMemUTF8(name);
            try
            {
                var ret = _lib.sv_set_module_name(slotId, moduleId, ptr);
                if (ret != 0)
                {
                    var details = $"{nameof(slotId)}: {slotId}, {nameof(moduleId)}: {moduleId}, {nameof(name)}: '{name ?? "<null>"}'.";
                    throw new SunVoxException(ret, nameof(_lib.sv_set_module_name), details);
                }
            }
            finally
            {
                Marshal.ZeroFreeCoTaskMemUTF8(ptr);
            }
        }

        /// <summary>
        /// Set the module position.
        /// </summary>
        /// <param name="slotId">slot number (0 to 15).</param>
        /// <param name="moduleId">module number (0-based).</param>
        /// <param name="x">X coordinate (center: 512, working area: 0 to 1024).</param>
        /// <param name="y">Y coordinate (center: 512, working area: 0 to 1024).</param>
        /// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_set_module_xy"/>.</remarks>
        public void SetModulePosition(int slotId, int moduleId, int x, int y)
        {
            var ret = _lib.sv_set_module_xy(slotId, moduleId, x, y);
            if (ret != 0)
            {
                var details = $"{nameof(slotId)}: {slotId}, {nameof(moduleId)}: {moduleId}, {nameof(x)}: {x}, {nameof(y)}: {y}.";
                throw new SunVoxException(ret, nameof(_lib.sv_set_module_xy), details);
            }
        }

        /// <summary>
        /// Set the module relative note value.
        /// </summary>
        /// <param name="slotId">slot number (0 to 15).</param>
        /// <param name="moduleId">module number (0-based).</param>
        /// <param name="relativeNote">Relative note in semitones.</param>
        /// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_set_module_relnote"/>.</remarks>
        public void SetModuleRelativeNote(int slotId, int moduleId, int relativeNote)
        {
            var ret = _lib.sv_set_module_relnote(slotId, moduleId, relativeNote);
            if (ret != 0)
            {
                var details = $"{nameof(slotId)}: {slotId}, {nameof(moduleId)}: {moduleId}, {nameof(relativeNote)}: {relativeNote}.";
                throw new SunVoxException(ret, nameof(_lib.sv_set_module_relnote), details);
            }
        }

        /// <summary>
        /// Get a Sampler sample parameter value.
        /// </summary>
        /// <param name="slotId">slot number (0 to 15).</param>
        /// <param name="moduleId">Sampler module number (0-based).</param>
        /// <param name="sampleSlot">Sample slot number.</param>
        /// <param name="parameter">Parameter number.</param>
        /// <returns>Parameter value.</returns>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_sampler_par"/>.</remarks>
        public int GetSamplerSampleParameter(int slotId, int moduleId, int sampleSlot, int parameter)
        {
            var ret = _lib.sv_sampler_par(slotId, moduleId, sampleSlot, parameter, 0, 0);
            return ret;
        }

        /// <summary>
        /// Set a Sampler sample parameter value.
        /// </summary>
        /// <param name="slotId">slot number (0 to 15).</param>
        /// <param name="moduleId">Sampler module number (0-based).</param>
        /// <param name="sampleSlot">Sample slot number.</param>
        /// <param name="parameter">Parameter number.</param>
        /// <param name="parameterValue">Parameter value.</param>
        /// <remarks>
        /// <para>
        /// This method does not throw exceptions on failure. Ensure that the provided parameters are valid.
        /// </para>
        /// Calls <see cref="ISunVoxLibC.sv_sampler_par"/>.</remarks>
        public void SetSamplerSampleParameter(int slotId, int moduleId, int sampleSlot, int parameter, int parameterValue)
        {
            // the library returns 0 on error, but that could be a valid parameter value, so we do not check the return value here
            // TODO maybe that could be changed to return 0xFFFFFFFF on error?
            _lib.sv_sampler_par(slotId, moduleId, sampleSlot, parameter, parameterValue, 1);
        }

        /// <summary>
        /// Write data to a module curve.
        /// </summary>
        /// <param name="slotId">slot number (0 to 15).</param>
        /// <param name="moduleId">module number (0-based).</param>
        /// <param name="curveId">Curve number.</param>
        /// <param name="data">Array containing curveId data to write.</param>
        /// <returns>Number of values written.</returns>
        /// <exception cref="SunVoxException">Thrown when the operation fails.</exception>
        /// <remarks>Calls <see cref="ISunVoxLibC.sv_module_curve"/>.</remarks>
        public int WriteModuleCurve(int slotId, int moduleId, int curveId, float[] data)
        {
            var ret = ModuleCurveOperationInternal(slotId, moduleId, curveId, data, true);
            if (ret < 0)
            {
                var details = $"{nameof(slotId)}: {slotId}, {nameof(moduleId)}: {moduleId}, {nameof(curveId)}: {curveId}, data length: {data.Length}.";
                throw new SunVoxException(ret, nameof(_lib.sv_module_curve), details);
            }
            return ret;
        }

        private int ModuleCurveOperationInternal(int slotId, int moduleId, int curve, float[] data, bool write)
        {
            var handle = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                return _lib.sv_module_curve(slotId, moduleId, curve, handle.AddrOfPinnedObject(), data.Length,
                    write ? 1 : 0);
            }
            finally
            {
                handle.Free();
            }
        }
    }
}
