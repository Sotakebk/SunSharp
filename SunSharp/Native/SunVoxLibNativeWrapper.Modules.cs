using System;
using System.Runtime.InteropServices;

namespace SunSharp.Native
{
    public partial class SunVoxLibNativeWrapper
    {
        /// <inheritdoc/>
        public void ConnectModule(int slotId, int source, int destination)
        {
            var ret = _lib.sv_connect_module(slotId, source, destination);
            if (ret != 0)
            {
                var details = $"{nameof(slotId)}: {slotId}, {nameof(source)}: {source}, {nameof(destination)}: {destination}.";
                throw new SunVoxException(ret, nameof(_lib.sv_connect_module), details);
            }
        }

        /// <inheritdoc/>
        public int CreateModule(int slotId, string type, string name, int x = 0, int y = 0,
            int z = 0)
        {
            var typePtr = Marshal.StringToCoTaskMemUTF8(type);
            var namePtr = Marshal.StringToCoTaskMemUTF8(name);
            int ret;
            try
            {
                ret = _lib.sv_new_module(slotId, typePtr, namePtr, x, y, z);
            }
            finally
            {
                Marshal.ZeroFreeCoTaskMemUTF8(typePtr);
                Marshal.ZeroFreeCoTaskMemUTF8(namePtr);
            }

            if (ret < 0)
            {
                var details = $"{nameof(slotId)}: {slotId}, {nameof(type)}: '{type ?? "<null>"}', {nameof(name)}: '{name ?? "<null>"}', {nameof(x)}: {x}, {nameof(y)}: {y}, {nameof(z)}: {z}.";
                throw new SunVoxException(ret, nameof(_lib.sv_new_module), details);
            }
            return ret;
        }

        /// <inheritdoc/>
        public void DisconnectModule(int slotId, int source, int destination)
        {
            var ret = _lib.sv_disconnect_module(slotId, source, destination);
            if (ret != 0)
            {
                var details = $"{nameof(slotId)}: {slotId}, {nameof(source)}: {source}, {nameof(destination)}: {destination}.";
                throw new SunVoxException(ret, nameof(_lib.sv_disconnect_module), details);
            }
        }

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public (byte r, byte g, byte b) GetModuleColor(int slotId, int moduleId)
        {
            var ret = _lib.sv_get_module_color(slotId, moduleId);
            var red = (byte)(ret & 0xFF);
            var green = (byte)((ret >> 8) & 0xFF);
            var blue = (byte)((ret >> 16) & 0xFF);
            return (red, green, blue);
        }

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public int GetModuleControllerGroup(int slotId, int moduleId, int controllerId)
        {
            return _lib.sv_get_module_ctl_group(slotId, moduleId, controllerId);
        }

        /// <inheritdoc/>
        public int GetModuleControllerMaxValue(int slotId, int moduleId, int controllerId, ValueScalingMode scalingMode)
        {
            return _lib.sv_get_module_ctl_max(slotId, moduleId, controllerId, (int)scalingMode);
        }

        /// <inheritdoc/>
        public int GetModuleControllerMinValue(int slotId, int moduleId, int controllerId, ValueScalingMode scalingMode)
        {
            return _lib.sv_get_module_ctl_min(slotId, moduleId, controllerId, (int)scalingMode);
        }

        /// <inheritdoc/>
        public string? GetModuleControllerName(int slotId, int moduleId, int controllerId)
        {
            // memory managed by SunVox
            var ptr = _lib.sv_get_module_ctl_name(slotId, moduleId, controllerId);
            return Marshal.PtrToStringUTF8(ptr);
        }

        /// <inheritdoc/>
        public int GetModuleControllerOffset(int slotId, int moduleId, int controllerId)
        {
            return _lib.sv_get_module_ctl_offset(slotId, moduleId, controllerId);
        }

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public int GetModuleControllerValue(int slotId, int moduleId, int controllerId, ValueScalingMode scalingMode)
        {
            return _lib.sv_get_module_ctl_value(slotId, moduleId, controllerId, (int)scalingMode);
        }

        /// <inheritdoc/>
        public bool GetModuleExists(int slotId, int moduleId)
        {
            return GetModuleFlags(slotId, moduleId).Exists;
        }

        /// <inheritdoc/>
        public FineTunePair GetModuleFineTune(int slotId, int moduleId)
        {
            var (fineTune, relativeNote) = Helper.UnpackTwoSignedShorts(_lib.sv_get_module_finetune(slotId, moduleId));
            return new FineTunePair(fineTune, relativeNote);
        }

        /// <inheritdoc/>
        public ModuleFlags GetModuleFlags(int slotId, int moduleId)
        {
            return _lib.sv_get_module_flags(slotId, moduleId);
        }

        /// <inheritdoc/>
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
            return Helper.CopyIntArraySkipNegativeOnes(ptr, inputCount);
        }

        /// <inheritdoc/>
        public string? GetModuleName(int slotId, int moduleId)
        {
            // memory managed by SunVox
            var ptr = _lib.sv_get_module_name(slotId, moduleId);
            return Marshal.PtrToStringUTF8(ptr);
        }

        /// <inheritdoc/>
        public int[] GetModuleOutputs(int slotId, int moduleId)
        {
            var moduleFlags = GetModuleFlags(slotId, moduleId);
            var outputCount = moduleFlags.OutputUpperCount;
            if (!moduleFlags.Exists || outputCount == 0)
                return Array.Empty<int>();

            // memory managed by SunVox
            var ptr = _lib.sv_get_module_outputs(slotId, moduleId);
            return Helper.CopyIntArraySkipNegativeOnes(ptr, outputCount);
        }

        /// <inheritdoc/>
        public (int x, int y) GetModulePosition(int slotId, int moduleId)
        {
            return Helper.UnpackTwoSignedShorts(_lib.sv_get_module_xy(slotId, moduleId));
        }

        /// <inheritdoc/>
        public string? GetModuleType(int slotId, int moduleId)
        {
            var ptr = _lib.sv_get_module_type(slotId, moduleId);
            return Marshal.PtrToStringUTF8(ptr);
        }

        /// <inheritdoc/>
        public int GetUpperModuleCount(int slotId)
        {
            var ret = _lib.sv_get_number_of_modules(slotId);
            if (ret < 0)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_get_number_of_modules), $"{nameof(slotId)}: {slotId}.");
            }
            return ret;
        }

        /// <inheritdoc/>
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

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public void LoadIntoVorbisPLayer(int slotId, int moduleId, string path)
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

        /// <inheritdoc/>
        public void LoadIntoVorbisPLayer(int slotId, int moduleId, byte[] data)
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

        /// <inheritdoc/>
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

        /// <inheritdoc/>
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

        /// <inheritdoc/>
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

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public int ReadModuleCurve(int slotId, int moduleId, int curve, float[] data)
        {
            var ret = ModuleCurveOperationInternal(slotId, moduleId, curve, data, false);
            if (ret < 0)
            {
                var details = $"{nameof(slotId)}: {slotId}, {nameof(moduleId)}: {moduleId}, {nameof(curve)}: {curve}, data length: {data.Length}.";
                throw new SunVoxException(ret, nameof(_lib.sv_module_curve), details);
            }
            return ret;
        }

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public void RemoveModule(int slotId, int moduleId)
        {
            var ret = _lib.sv_remove_module(slotId, moduleId);
            if (ret != 0)
            {
                throw new SunVoxException(ret, nameof(_lib.sv_remove_module), $"{nameof(slotId)}: {slotId}, {nameof(moduleId)}: {moduleId}.");
            }
        }

        /// <inheritdoc/>
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

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public void SetModuleFineTune(int slotId, int moduleId, int fineTune)
        {
            var ret = _lib.sv_set_module_finetune(slotId, moduleId, fineTune);
            if (ret != 0)
            {
                var details = $"{nameof(slotId)}: {slotId}, {nameof(moduleId)}: {moduleId}, {nameof(fineTune)}: {fineTune}.";
                throw new SunVoxException(ret, nameof(_lib.sv_set_module_finetune), details);
            }
        }

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public void SetModulePosition(int slotId, int moduleId, int x, int y)
        {
            var ret = _lib.sv_set_module_xy(slotId, moduleId, x, y);
            if (ret != 0)
            {
                var details = $"{nameof(slotId)}: {slotId}, {nameof(moduleId)}: {moduleId}, {nameof(x)}: {x}, {nameof(y)}: {y}.";
                throw new SunVoxException(ret, nameof(_lib.sv_set_module_xy), details);
            }
        }

        /// <inheritdoc/>
        public void SetModuleRelativeNote(int slotId, int moduleId, int relativeNote)
        {
            var ret = _lib.sv_set_module_relnote(slotId, moduleId, relativeNote);
            if (ret != 0)
            {
                var details = $"{nameof(slotId)}: {slotId}, {nameof(moduleId)}: {moduleId}, {nameof(relativeNote)}: {relativeNote}.";
                throw new SunVoxException(ret, nameof(_lib.sv_set_module_relnote), details);
            }
        }

        /// <inheritdoc/>
        public int WriteModuleCurve(int slotId, int moduleId, int curve, float[] data)
        {
            var ret = ModuleCurveOperationInternal(slotId, moduleId, curve, data, true);
            if (ret < 0)
            {
                var details = $"{nameof(slotId)}: {slotId}, {nameof(moduleId)}: {moduleId}, {nameof(curve)}: {curve}, data length: {data.Length}.";
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
