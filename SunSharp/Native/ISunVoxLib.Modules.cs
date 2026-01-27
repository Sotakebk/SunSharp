namespace SunSharp.Native
{
    public partial interface ISunVoxLib
    {
        /// <inheritdoc cref="SunVoxLib.ConnectModule"/>
        void ConnectModule(int slotId, int source, int destination);

        /// <inheritdoc cref="SunVoxLib.DisconnectModule"/>
        void DisconnectModule(int slotId, int source, int destination);

        /// <inheritdoc cref="SunVoxLib.FindModule"/>
        int? FindModule(int slotId, string name);

        /// <inheritdoc cref="SunVoxLib.GetModuleColor"/>
        (byte r, byte g, byte b) GetModuleColor(int slotId, int moduleId);

        /// <inheritdoc cref="SunVoxLib.SetModuleColor"/>
        void SetModuleColor(int slotId, int moduleId, byte r, byte g, byte b);

        /// <inheritdoc cref="SunVoxLib.GetModuleControllerName"/>
        string? GetModuleControllerName(int slotId, int moduleId, int controllerId);

        /// <inheritdoc cref="SunVoxLib.GetModuleControllerValue"/>
        int GetModuleControllerValue(int slotId, int moduleId, int controllerId, ValueScalingMode scalingMode);

        /// <inheritdoc cref="SunVoxLib.GetModuleControllerMinValue"/>
        int GetModuleControllerMinValue(int slotId, int moduleId, int controllerId, ValueScalingMode scalingMode);

        /// <inheritdoc cref="SunVoxLib.GetModuleControllerMaxValue"/>
        int GetModuleControllerMaxValue(int slotId, int moduleId, int controllerId, ValueScalingMode scalingMode);

        /// <inheritdoc cref="SunVoxLib.GetModuleControllerOffset"/>
        int GetModuleControllerOffset(int slotId, int moduleId, int controllerId);

        /// <inheritdoc cref="SunVoxLib.GetModuleControllerType"/>
        ControllerType GetModuleControllerType(int slotId, int moduleId, int controllerId);

        /// <inheritdoc cref="SunVoxLib.GetModuleControllerGroup"/>
        int GetModuleControllerGroup(int slotId, int moduleId, int controllerId);

        /// <inheritdoc cref="SunVoxLib.SetModuleControllerValue"/>
        void SetModuleControllerValue(int slotId, int moduleId, int controllerId, int value,
            ValueScalingMode scalingMode);

        /// <inheritdoc cref="SunVoxLib.GetModuleFineTune"/>
        FineTunePair GetModuleFineTune(int slotId, int moduleId);

        /// <inheritdoc cref="SunVoxLib.SetModuleFineTune"/>
        void SetModuleFineTune(int slotId, int moduleId, int fineTune);

        /// <inheritdoc cref="SunVoxLib.SetModuleRelativeNote"/>
        void SetModuleRelativeNote(int slotId, int moduleId, int relativeNote);

        /// <inheritdoc cref="SunVoxLib.GetModuleFlags"/>
        ModuleFlags GetModuleFlags(int slotId, int moduleId);

        /// <inheritdoc cref="SunVoxLib.GetModuleExists"/>
        bool GetModuleExists(int slotId, int moduleId);

        /// <inheritdoc cref="SunVoxLib.GetModuleInputs"/>
        int[] GetModuleInputs(int slotId, int moduleId);

        /// <inheritdoc cref="SunVoxLib.GetModuleName"/>
        string? GetModuleName(int slotId, int moduleId);

        /// <inheritdoc cref="SunVoxLib.SetModuleName"/>
        void SetModuleName(int slotId, int moduleId, string name);

        /// <inheritdoc cref="SunVoxLib.GetModuleType"/>
        string? GetModuleType(int slotId, int moduleId);

        /// <inheritdoc cref="SunVoxLib.GetModuleOutputs"/>
        int[] GetModuleOutputs(int slotId, int moduleId);

        /// <inheritdoc cref="SunVoxLib.ReadModuleScope"/>
        int ReadModuleScope(int slotId, int moduleId, AudioChannel channel, short[] buffer);

        /// <inheritdoc cref="SunVoxLib.GetModulePosition"/>
        (int x, int y) GetModulePosition(int slotId, int moduleId);

        /// <inheritdoc cref="SunVoxLib.SetModulePosition"/>
        void SetModulePosition(int slotId, int moduleId, int x, int y);

        /// <inheritdoc cref="SunVoxLib.GetUpperModuleCount"/>
        int GetUpperModuleCount(int slotId);

        /// <inheritdoc cref="SunVoxLib.GetModuleControllerCount"/>
        int GetModuleControllerCount(int slotId, int moduleId);

        /// <inheritdoc cref="SunVoxLib.LoadModule(int, string, int, int, int)"/>
        int LoadModule(int slotId, string path, int x = 0, int y = 0, int z = 0);

        /// <inheritdoc cref="SunVoxLib.LoadModule(int, byte[], int, int, int)"/>
        int LoadModule(int slotId, byte[] data, int x = 0, int y = 0, int z = 0);

        /// <inheritdoc cref="SunVoxLib.WriteModuleCurve"/>
        int WriteModuleCurve(int slotId, int moduleId, int curveId, float[] data);

        /// <inheritdoc cref="SunVoxLib.ReadModuleCurve"/>
        int ReadModuleCurve(int slotId, int moduleId, int curveId, float[] data);

        /// <inheritdoc cref="SunVoxLib.CreateModule"/>
        int CreateModule(int slotId, SynthModuleType type, string? name = null, int x = 0, int y = 0, int z = 0);

        /// <inheritdoc cref="SunVoxLib.CreateModule"/>
        int CreateModule(int slotId, string type, string? name = null, int x = 0, int y = 0, int z = 0);

        /// <inheritdoc cref="SunVoxLib.RemoveModule"/>
        void RemoveModule(int slotId, int moduleId);

        /// <inheritdoc cref="SunVoxLib.LoadSamplerSample(int, int, string, int?)"/>
        void LoadSamplerSample(int slotId, int moduleId, string path, int? sampleSlot = null);

        /// <inheritdoc cref="SunVoxLib.LoadSamplerSample(int, int, byte[], int?)"/>
        void LoadSamplerSample(int slotId, int moduleId, byte[] data, int? sampleSlot = null);

        /// <inheritdoc cref="SunVoxLib.LoadIntoMetaModule(int, int, string)"/>
        void LoadIntoMetaModule(int slotId, int moduleId, string path);

        /// <inheritdoc cref="SunVoxLib.LoadIntoMetaModule(int, int, byte[])"/>
        void LoadIntoMetaModule(int slotId, int moduleId, byte[] data);

        /// <inheritdoc cref="SunVoxLib.LoadIntoVorbisPlayer(int, int, string)"/>
        void LoadIntoVorbisPlayer(int slotId, int moduleId, string path);

        /// <inheritdoc cref="SunVoxLib.LoadIntoVorbisPlayer(int, int, byte[])"/>
        void LoadIntoVorbisPlayer(int slotId, int moduleId, byte[] data);
    }
}
