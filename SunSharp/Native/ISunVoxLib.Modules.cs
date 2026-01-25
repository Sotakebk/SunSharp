namespace SunSharp.Native
{
    public partial interface ISunVoxLib
    {
        /// <inheritdoc cref="SunVoxLibNativeWrapper.ConnectModule"/>
        void ConnectModule(int slotId, int source, int destination);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.DisconnectModule"/>
        void DisconnectModule(int slotId, int source, int destination);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.FindModule"/>
        int? FindModule(int slotId, string name);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.GetModuleColor"/>
        (byte r, byte g, byte b) GetModuleColor(int slotId, int moduleId);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.SetModuleColor"/>
        void SetModuleColor(int slotId, int moduleId, byte r, byte g, byte b);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.GetModuleControllerName"/>
        string? GetModuleControllerName(int slotId, int moduleId, int controllerId);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.GetModuleControllerValue"/>
        int GetModuleControllerValue(int slotId, int moduleId, int controllerId, ValueScalingMode scalingMode);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.GetModuleControllerMinValue"/>
        int GetModuleControllerMinValue(int slotId, int moduleId, int controllerId, ValueScalingMode scalingMode);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.GetModuleControllerMaxValue"/>
        int GetModuleControllerMaxValue(int slotId, int moduleId, int controllerId, ValueScalingMode scalingMode);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.GetModuleControllerOffset"/>
        int GetModuleControllerOffset(int slotId, int moduleId, int controllerId);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.GetModuleControllerType"/>
        ControllerType GetModuleControllerType(int slotId, int moduleId, int controllerId);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.GetModuleControllerGroup"/>
        int GetModuleControllerGroup(int slotId, int moduleId, int controllerId);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.SetModuleControllerValue"/>
        void SetModuleControllerValue(int slotId, int moduleId, int controllerId, int value,
            ValueScalingMode scalingMode);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.GetModuleFineTune"/>
        FineTunePair GetModuleFineTune(int slotId, int moduleId);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.SetModuleFineTune"/>
        void SetModuleFineTune(int slotId, int moduleId, int fineTune);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.SetModuleRelativeNote"/>
        void SetModuleRelativeNote(int slotId, int moduleId, int relativeNote);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.GetModuleFlags"/>
        ModuleFlags GetModuleFlags(int slotId, int moduleId);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.GetModuleExists"/>
        bool GetModuleExists(int slotId, int moduleId);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.GetModuleInputs"/>
        int[] GetModuleInputs(int slotId, int moduleId);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.GetModuleName"/>
        string? GetModuleName(int slotId, int moduleId);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.SetModuleName"/>
        void SetModuleName(int slotId, int moduleId, string name);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.GetModuleType"/>
        string? GetModuleType(int slotId, int moduleId);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.GetModuleOutputs"/>
        int[] GetModuleOutputs(int slotId, int moduleId);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.ReadModuleScope"/>
        int ReadModuleScope(int slotId, int moduleId, AudioChannel channel, short[] buffer);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.GetModulePosition"/>
        (int x, int y) GetModulePosition(int slotId, int moduleId);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.SetModulePosition"/>
        void SetModulePosition(int slotId, int moduleId, int x, int y);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.GetUpperModuleCount"/>
        int GetUpperModuleCount(int slotId);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.GetModuleControllerCount"/>
        int GetModuleControllerCount(int slotId, int moduleId);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.LoadModule(int, string, int, int, int)"/>
        int LoadModule(int slotId, string path, int x = 0, int y = 0, int z = 0);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.LoadModule(int, byte[], int, int, int)"/>
        int LoadModule(int slotId, byte[] data, int x = 0, int y = 0, int z = 0);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.WriteModuleCurve"/>
        int WriteModuleCurve(int slotId, int moduleId, int curveId, float[] data);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.ReadModuleCurve"/>
        int ReadModuleCurve(int slotId, int moduleId, int curveId, float[] data);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.CreateModule"/>
        int CreateModule(int slotId, SynthModuleType type, string? name = null, int x = 0, int y = 0, int z = 0);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.CreateModule"/>
        int CreateModule(int slotId, string type, string? name = null, int x = 0, int y = 0, int z = 0);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.RemoveModule"/>
        void RemoveModule(int slotId, int moduleId);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.LoadSamplerSample(int, int, string, int?)"/>
        void LoadSamplerSample(int slotId, int moduleId, string path, int? sampleSlot = null);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.LoadSamplerSample(int, int, byte[], int?)"/>
        void LoadSamplerSample(int slotId, int moduleId, byte[] data, int? sampleSlot = null);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.LoadIntoMetaModule(int, int, string)"/>
        void LoadIntoMetaModule(int slotId, int moduleId, string path);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.LoadIntoMetaModule(int, int, byte[])"/>
        void LoadIntoMetaModule(int slotId, int moduleId, byte[] data);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.LoadIntoVorbisPlayer(int, int, string)"/>
        void LoadIntoVorbisPlayer(int slotId, int moduleId, string path);

        /// <inheritdoc cref="SunVoxLibNativeWrapper.LoadIntoVorbisPlayer(int, int, byte[])"/>
        void LoadIntoVorbisPlayer(int slotId, int moduleId, byte[] data);
    }
}
