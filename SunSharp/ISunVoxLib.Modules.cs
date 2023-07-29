namespace SunSharp
{
    public partial interface ISunVoxLib
    {
        /// <summary>
        /// Connect two specified modules.
        /// <para>Use <see cref="ISunVoxLib.LockSlot"/> or an alternative!</para>
        /// </summary>
        /// <exception cref="SunVoxException"></exception>
        void ConnectModule(int slotId, int source, int destination);

        /// <summary>
        /// Disconnect two specified modules.
        /// <para>Use <see cref="ISunVoxLib.LockSlot"/> or an alternative!</para>
        /// </summary>
        /// <exception cref="SunVoxException"></exception>
        void DisconnectModule(int slotId, int source, int destination);

        /// <summary>
        /// Find module by name.
        /// </summary>
        /// <returns>Id of found module, -1 if it was not found.</returns>
        /// <exception cref="SunVoxException"></exception>
        int FindModule(int slotId, string name);

        (byte r, byte g, byte b) GetModuleColor(int slotId, int moduleId);

        void SetModuleColor(int slotId, int moduleId, byte r, byte g, byte b);

        string? GetModuleControllerName(int slotId, int moduleId, int controllerId);

        /// <summary>
        /// Get module controller value.
        /// </summary>
        int GetModuleControllerValue(int slotId, int moduleId, int controllerId, ValueScalingMode scalingMode);

        int GetModuleControllerMinValue(int slotId, int moduleId, int controllerId, ValueScalingMode scalingMode);

        int GetModuleControllerMaxValue(int slotId, int moduleId, int controllerId, ValueScalingMode scalingMode);

        int GetModuleControllerOffset(int slotId, int moduleId, int controllerId);

        ControllerType GetModuleControllerType(int slotId, int moduleId, int controllerId);

        int GetModuleControllerGroup(int slotId, int moduleId, int controllerId);

        /// <summary>
        /// Send the value to the specified module controller. (sv_send_event() will be used internally, which may introduce latency).
        /// </summary>
        void SetModuleControllerValue(int slotId, int moduleId, int controllerId, int value, ValueScalingMode scalingMode);

        FineTunePair GetModuleFineTune(int slotId, int moduleId);

        void SetModuleFineTune(int slotId, int moduleId, int fineTune);

        void SetModuleRelativeNote(int slotId, int moduleId, int relativeNote);

        ModuleFlags GetModuleFlags(int slotId, int moduleId);

        bool GetModuleExists(int slotId, int moduleId);

        /// <summary>
        /// Get an array of Ids of modules that are connected as inputs.
        /// Does NOT return -1 for empty connection slots.
        /// </summary>
        /// <returns></returns>
        int[] GetModuleInputs(int slotId, int moduleId);

        string? GetModuleName(int slotId, int moduleId);

        void SetModuleName(int slotId, int moduleId, string name);

        string? GetModuleType(int slotId, int moduleId);

        /// <summary>
        /// Get an array of Ids of modules.
        /// Does NOT return -1 for empty connection slots.
        /// </summary>
        int[] GetModuleOutputs(int slotId, int moduleId);

        /// <summary>
        /// Read module scope view, and write it to a buffer.
        /// </summary>
        /// <returns>Number of samples successfully read.</returns>
        int ReadModuleScope(int slotId, int moduleId, int channel, short[] buffer);

        (int x, int y) GetModulePosition(int slotId, int moduleId);

        void SetModulePosition(int slotId, int moduleId, int x, int y);

        /// <summary>
        /// Get the upper module count, which may be greater than the module count.
        /// </summary>
        /// <exception cref="SunVoxException"></exception>
        int GetUpperModuleCount(int slotId);

        int GetModuleControllerCount(int slotId, int moduleId);

        /// <summary>
        /// load a module or a sample. Supported file formats: sunsynth, xi, wav, aiff.
        /// </summary>
        /// <returns>CreatedmoduleId Id.</returns>
        /// <exception cref="SunVoxException"></exception>
        int LoadModule(int slotId, string path, int x = 0, int y = 0, int z = 0);

        /// <summary>
        /// load a module or a sample from memory. Supported file formats: sunsynth, xi, wav, aiff.
        /// </summary>
        /// <returns>Created module id.</returns>
        /// <exception cref="SunVoxException"></exception>
        int LoadModule(int slotId, byte[] data, int x = 0, int y = 0, int z = 0);

        int WriteModuleCurve(int slotId, int moduleId, int curve, float[] data);

        int ReadModuleCurve(int slotId, int moduleId, int curve, float[] data);

        /// <summary>
        /// Create a new module. Type refers to the name visible on new module creation window.
        /// <para>Use <see cref="ISunVoxLib.LockSlot"/> or an alternative!</para>
        /// </summary>
        /// <returns>Created module id.</returns>
        /// <exception cref="SunVoxException"></exception>
        int CreateModule(int slotId, string type, string name, int x = 0, int y = 0, int z = 0);

        /// <summary>
        /// Remove an existing module.
        /// <para>Use <see cref="ISunVoxLib.LockSlot"/> or an alternative!</para>
        /// </summary>
        /// <exception cref="SunVoxException"></exception>
        void RemoveModule(int slotId, int moduleId);

        /// <summary>
        /// Load a sample (xi, wav, aiff) to an existing module from file.
        /// Set <paramref name="sampleSlot"/> to -1 to apply the sample to all sample slots.
        /// </summary>
        /// <exception cref="SunVoxException"></exception>
        void LoadSamplerSample(int slotId, int moduleId, string path, int sampleSlot = -1);

        /// <summary>
        /// Load a sample (xi, wav, aiff) to an existing module from memory.
        /// Set <paramref name="sampleSlot"/> to -1 to apply the sample to all sample slots.
        /// </summary>
        /// <exception cref="SunVoxException"></exception>
        void LoadSamplerSample(int slotId, int moduleId, byte[] data, int sampleSlot = -1);

        /// <summary>
        /// load a file into the MetaModule. Supported file formats: sunvox, mod, xm, midi.
        /// </summary>
        /// <exception cref="SunVoxException"></exception>
        void LoadIntoMetaModule(int slotId, int moduleId, string path);

        /// <summary>
        /// load a file into the MetaModule from memory. Supported file formats: sunvox, mod, xm, midi.
        /// </summary>
        /// <exception cref="SunVoxException"></exception>
        void LoadIntoMetaModule(int slotId, int moduleId, byte[] data);

        /// <summary>
        /// load a file into the Vorbis Player. Supported file formats: ogg.
        /// </summary>
        /// <exception cref="SunVoxException"></exception>
        void LoadIntoVorbisPLayer(int slotId, int moduleId, string path);

        /// <summary>
        /// load a file into the Vorbis Player. Supported file formats: ogg.
        /// </summary>
        /// <exception cref="SunVoxException"></exception>
        void LoadIntoVorbisPLayer(int slotId, int moduleId, byte[] data);
    }
}
