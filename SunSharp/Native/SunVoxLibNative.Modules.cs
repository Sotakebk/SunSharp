using System;
using System.Runtime.InteropServices;

namespace SunSharp.Native
{
    public partial class SunVoxLibNative
    {
        /// <inheritdoc/>
        public void ConnectModule(int slotId, int source, int destination)
        {
            var ret = _lib.sv_connect_module(slotId, source, destination);
            if (ret != 0)
                throw new SunVoxException(ret, nameof(_lib.sv_connect_module));
        }

        /// <inheritdoc/>
        public void DisconnectModule(int slotId, int source, int destination)
        {
            var ret = _lib.sv_disconnect_module(slotId, source, destination);
            if (ret != 0)
                throw new SunVoxException(ret, nameof(_lib.sv_disconnect_module));
        }

        /// <inheritdoc/>
        public int FindModule(int slotId, string name)
        {
            var ptr = Marshal.StringToHGlobalAnsi(name);
            int ret;
            try
            {
                ret = _lib.sv_find_module(slotId, ptr);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }

            if (ret < -1)
                throw new SunVoxException(ret, nameof(_lib.sv_find_module));

            return ret;
        }

        /// <inheritdoc/>
        public (byte r, byte g, byte b) GetModuleColor(int slotId, int moduleId)
        {
            var ret = _lib.sv_get_module_color(slotId, moduleId);
            var red = (byte)((ret) & 0xFF);
            var green = (byte)((ret >> 8) & 0xFF);
            var blue = (byte)((ret >> 16) & 0xFF);
            return (red, green, blue);
        }

        /// <inheritdoc/>
        public void SetModuleColor(int slotId, int moduleId, byte r, byte g, byte b)
        {
            var color = r & (g << 8) & (b << 16);
            var ret = _lib.sv_set_module_color(slotId, moduleId, color);
            if (ret != 0)
                throw new SunVoxException(ret, nameof(_lib.sv_set_module_color));
        }

        /// <inheritdoc/>
        public string? GetModuleControllerName(int slotId, int moduleId, int controllerId)
        {
            var ptr = _lib.sv_get_module_ctl_name(slotId, moduleId, controllerId);
            return Marshal.PtrToStringAnsi(ptr);
        }

        /// <inheritdoc/>
        public int GetModuleControllerValue(int slotId, int moduleId, int controllerId, ValueScalingMode scalingMode)
        {
            return _lib.sv_get_module_ctl_value(slotId, moduleId, controllerId, (int)scalingMode);
        }

        /// <inheritdoc/>
        public int GetModuleControllerMinValue(int slotId, int moduleId, int controllerId, ValueScalingMode scalingMode)
        {
            return _lib.sv_get_module_ctl_min(slotId, moduleId, controllerId, (int)scalingMode);
        }

        /// <inheritdoc/>
        public int GetModuleControllerMaxValue(int slotId, int moduleId, int controllerId, ValueScalingMode scalingMode)
        {
            return _lib.sv_get_module_ctl_max(slotId, moduleId, controllerId, (int)scalingMode);
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
                throw new SunVoxException(ret, nameof(_lib.sv_get_module_ctl_type));

            return (ControllerType)ret;
        }

        /// <inheritdoc/>
        public int GetModuleControllerGroup(int slotId, int moduleId, int controllerId)
        {
            return _lib.sv_get_module_ctl_group(slotId, moduleId, controllerId);
        }

        /// <inheritdoc/>
        public void SetModuleControllerValue(int slotId, int moduleId, int controllerId, int value, ValueScalingMode scalingMode)
        {
            var ret = _lib.sv_set_module_ctl_value(slotId, moduleId, controllerId, value, (int)scalingMode);
            if (ret != 0)
                throw new SunVoxException(0, nameof(_lib.sv_set_module_ctl_value));
        }

        /// <inheritdoc/>
        public FineTunePair GetModuleFineTune(int slotId, int moduleId)
        {
            var (fineTune, relativeNote) = Helper.SplitValueToFineTune(_lib.sv_get_module_finetune(slotId, moduleId));
            return new FineTunePair(fineTune, relativeNote);
        }

        /// <inheritdoc/>
        public void SetModuleFineTune(int slotId, int moduleId, int fineTune)
        {
            var ret = _lib.sv_set_module_finetune(slotId, moduleId, fineTune);
            if (ret != 0)
                throw new SunVoxException(ret, nameof(_lib.sv_set_module_finetune));
        }

        /// <inheritdoc/>
        public void SetModuleRelativeNote(int slotId, int moduleId, int relativeNote)
        {
            var ret = _lib.sv_set_module_relnote(slotId, moduleId, relativeNote);
            if (ret != 0)
                throw new SunVoxException(ret, nameof(_lib.sv_set_module_relnote));
        }

        /// <inheritdoc/>
        public ModuleFlags GetModuleFlags(int slotId, int moduleId)
        {
            return _lib.sv_get_module_flags(slotId, moduleId);
        }

        /// <inheritdoc/>
        public bool GetModuleExists(int slotId, int moduleId)
        {
            return GetModuleFlags(slotId, moduleId).Exists;
        }

        /// <inheritdoc/>
        public int[] GetModuleInputs(int slotId, int moduleId)
        {
            var count = GetModuleFlags(slotId, moduleId).InputUpperCount;
            if (count == 0)
                return Array.Empty<int>();

            var ptr = _lib.sv_get_module_inputs(slotId, moduleId);
            try
            {
                return Helper.CopyIntArraySkipNegativeOnes(ptr, count);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <inheritdoc/>
        public string? GetModuleName(int slotId, int moduleId)
        {
            var ptr = _lib.sv_get_module_name(slotId, moduleId);
            return Marshal.PtrToStringAnsi(ptr);
        }

        /// <inheritdoc/>
        public void SetModuleName(int slotId, int moduleId, string name)
        {
            var ptr = Marshal.StringToHGlobalAnsi(name);
            try
            {
                var ret = _lib.sv_set_module_name(slotId, moduleId, ptr);
                if (ret != 0)
                    throw new SunVoxException(ret, nameof(_lib.sv_set_module_name));
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <inheritdoc/>
        public string? GetModuleType(int slotId, int moduleId)
        {
            var ptr = _lib.sv_get_module_type(slotId, moduleId);
            return Marshal.PtrToStringAnsi(ptr);
        }

        /// <inheritdoc/>
        public int[] GetModuleOutputs(int slotId, int moduleId)
        {
            var count = GetModuleFlags(slotId, moduleId).OutputUpperCount;
            if (count == 0)
                return Array.Empty<int>();

            var ptr = _lib.sv_get_module_outputs(slotId, moduleId);
            try
            {
                return Helper.CopyIntArraySkipNegativeOnes(ptr, count);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <inheritdoc/>
        public int ReadModuleScope(int slotId, int moduleId, int channel, short[] buffer)
        {
            var handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            var ptr = handle.AddrOfPinnedObject();
            try
            {
                return (int)_lib.sv_get_module_scope2(slotId, moduleId, channel, ptr, (uint)buffer.Length);
            }
            finally
            {
                handle.Free();
            }
        }

        /// <inheritdoc/>
        public (int x, int y) GetModulePosition(int slotId, int moduleId)
        {
            return Helper.SplitValueTo2DPosition(_lib.sv_get_module_xy(slotId, moduleId));
        }

        /// <inheritdoc/>
        public void SetModulePosition(int slotId, int moduleId, int x, int y)
        {
            var ret = _lib.sv_set_module_xy(slotId, moduleId, x, y);
            if (ret != 0)
                throw new SunVoxException(ret, nameof(_lib.sv_set_module_xy));
        }

        /// <inheritdoc/>
        public int GetUpperModuleCount(int slotId)
        {
            var ret = _lib.sv_get_number_of_modules(slotId);
            if (ret < 0)
                throw new SunVoxException(ret, nameof(_lib.sv_get_number_of_modules));
            return ret;
        }

        /// <inheritdoc/>
        public int GetModuleControllerCount(int slotId, int moduleId)
        {
            var ret = _lib.sv_get_number_of_module_ctls(slotId, moduleId);
            if (ret < 0)
                throw new SunVoxException(ret, nameof(_lib.sv_get_number_of_module_ctls));
            return ret;
        }

        /// <inheritdoc/>
        public int LoadModule(int slotId, string path, int x = 0, int y = 0, int z = 0)
        {
            var ptr = Marshal.StringToHGlobalAnsi(path);
            int ret;
            try
            {
                ret = _lib.sv_load_module(slotId, ptr, x, y, z);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }

            if (ret < 0)
                throw new SunVoxException(ret, nameof(_lib.sv_load_module));
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
                throw new SunVoxException(ret, nameof(_lib.sv_load_module_from_memory));
            return ret;
        }

        /// <inheritdoc/>
        public int WriteModuleCurve(int slotId, int moduleId, int curve, float[] data)
        {
            var handle = GCHandle.Alloc(data, GCHandleType.Pinned);
            int ret;
            try
            {
                ret = _lib.sv_module_curve(slotId, moduleId, curve, handle.AddrOfPinnedObject(), data.Length, 1);
            }
            finally
            {
                handle.Free();
            }

            if (ret < 0)
                throw new SunVoxException(ret, nameof(_lib.sv_module_curve));
            return ret;
        }

        /// <inheritdoc/>
        public int ReadModuleCurve(int slotId, int moduleId, int curve, float[] data)
        {
            var handle = GCHandle.Alloc(data, GCHandleType.Pinned);
            int ret;
            try
            {
                ret = _lib.sv_module_curve(slotId, moduleId, curve, handle.AddrOfPinnedObject(), data.Length, 0);
            }
            finally
            {
                handle.Free();
            }

            if (ret < 0)
                throw new SunVoxException(ret, nameof(_lib.sv_module_curve));
            return ret;
        }

        /// <inheritdoc/>
        public int CreateModule(int slotId, string type, string name, int x = 0, int y = 0,
            int z = 0)
        {
            var typePtr = Marshal.StringToHGlobalAnsi(type);
            var namePtr = Marshal.StringToHGlobalAnsi(name);
            int ret;
            try
            {
                ret = _lib.sv_new_module(slotId, typePtr, namePtr, x, y, z);
            }
            finally
            {
                Marshal.FreeHGlobal(typePtr);
                Marshal.FreeHGlobal(namePtr);
            }

            if (ret < 0)
                throw new SunVoxException(ret, nameof(_lib.sv_new_module));
            return ret;
        }

        /// <inheritdoc/>
        public void RemoveModule(int slotId, int moduleId)
        {
            var ret = _lib.sv_remove_module(slotId, moduleId);
            if (ret != 0)
                throw new SunVoxException(ret, nameof(_lib.sv_remove_module));
        }

        /// <inheritdoc/>
        public void LoadSamplerSample(int slotId, int moduleId, string path,
            int sampleSlot = -1)
        {
            var ptr = Marshal.StringToHGlobalAnsi(path);
            int ret;
            try
            {
                ret = _lib.sv_sampler_load(slotId, moduleId, ptr, sampleSlot);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }

            if (ret != 0)
                throw new SunVoxException(ret, nameof(_lib.sv_sampler_load));
        }

        /// <inheritdoc/>
        public void LoadSamplerSample(int slotId, int moduleId, byte[] data,
            int sampleSlot = -1)
        {
            var handle = GCHandle.Alloc(data, GCHandleType.Pinned);
            int ret;
            try
            {
                ret = _lib.sv_sampler_load_from_memory(slotId, moduleId, handle.AddrOfPinnedObject(), (uint)data.Length,
                    sampleSlot);
            }
            finally
            {
                handle.Free();
            }

            if (ret != 0)
                throw new SunVoxException(ret, nameof(_lib.sv_sampler_load_from_memory));
        }

        /// <inheritdoc/>
        public void LoadIntoMetaModule(int slotId, int moduleId, string path)
        {
            var ptr = Marshal.StringToHGlobalAnsi(path);
            int ret;
            try
            {
                ret = _lib.sv_metamodule_load(slotId, moduleId, ptr);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }

            if (ret != 0)
                throw new SunVoxException(ret, nameof(_lib.sv_metamodule_load));
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
                throw new SunVoxException(ret, nameof(_lib.sv_metamodule_load_from_memory));
        }

        /// <inheritdoc/>
        public void LoadIntoVorbisPLayer(int slotId, int moduleId, string path)
        {
            var ptr = Marshal.StringToHGlobalAnsi(path);
            int ret;
            try
            {
                ret = _lib.sv_vplayer_load(slotId, moduleId, ptr);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }

            if (ret != 0)
                throw new SunVoxException(ret, nameof(_lib.sv_vplayer_load));
        }

        /// <inheritdoc/>
        public void LoadIntoVorbisPLayer(int slotId, int moduleId, byte[] data)
        {
            var handle = GCHandle.Alloc(data, GCHandleType.Pinned);
            int ret;
            try
            {
                ret = _lib.sv_vplayer_load_from_memory(slotId, moduleId, handle.AddrOfPinnedObject(), (uint)data.Length);
            }
            finally
            {
                handle.Free();
            }

            if (ret != 0)
                throw new SunVoxException(ret, nameof(_lib.sv_vplayer_load_from_memory));
        }
    }
}
