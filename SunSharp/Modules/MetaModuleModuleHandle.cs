#if !GENERATION

using System;

namespace SunSharp.Modules
{
    public partial interface IMetaModuleModuleHandle
    {
        /// <inheritdoc cref="ISynthModuleHandle.LoadIntoMetaModule(string)"/>
        void LoadFile(string path);

        /// <inheritdoc cref="ISynthModuleHandle.LoadIntoMetaModule(byte[])"/>
        void LoadFile(byte[] data);

        /// <summary>
        /// <para>
        /// Set the value of a user-defined controller. User-defined controllers start at index 5.
        /// </para>
        /// <inheritdoc cref="ISynthModuleHandle.SetControllerValue(int, int, ValueScalingMode)"/>
        /// </summary>
        /// <inheritdoc cref="ISynthModuleHandle.SetControllerValue(int, int, ValueScalingMode)"/>
        void SetUserControllerValue(int index, int value, ValueScalingMode scalingMode);

        /// <summary>
        /// <para>
        /// Get the value of a user-defined controller. User-defined controllers start at index 5.
        /// </para>
        /// <inheritdoc cref="ISynthModuleHandle.GetControllerValue(int, ValueScalingMode)"/>
        /// </summary>
        /// <inheritdoc cref="ISynthModuleHandle.GetControllerValue(int, ValueScalingMode)"/>
        void GetUserControllerValue(int index, ValueScalingMode scalingMode);

        /// <summary>
        /// <para>
        /// Get the minimum value of a user-defined controller. User-defined controllers start at index 5.
        /// </para>
        /// <inheritdoc cref="ISynthModuleHandle.GetControllerMinValue(int, ValueScalingMode)"/>
        /// </summary>
        /// <inheritdoc cref="ISynthModuleHandle.GetControllerMinValue(int, ValueScalingMode)"/>
        void GetUserControllerMinValue(int index, ValueScalingMode scalingMode);

        /// <summary>
        /// <para>
        /// Get the maximum value of a user-defined controller. User-defined controllers start at index 5.
        /// </para>
        /// <inheritdoc cref="ISynthModuleHandle.GetControllerMaxValue(int, ValueScalingMode)"/>
        /// </summary>
        /// <inheritdoc cref="ISynthModuleHandle.GetControllerMaxValue(int, ValueScalingMode)"/>
        void GetUserControllerMaxValue(int index, ValueScalingMode scalingMode);

        /// <summary>
        /// <para>
        /// Get the offset value of a user-defined controller. User-defined controllers start at index 5.
        /// </para>
        /// <inheritdoc cref="ISynthModuleHandle.GetControllerOffset(int)"/>
        /// </summary>
        /// <inheritdoc cref="ISynthModuleHandle.GetControllerOffset(int)"/>
        void GetUserControllerOffset(int index);

        /// <summary>
        /// <para>
        /// Get the name of a user-defined controller. User-defined controllers start at index 5.
        /// </para>
        /// <inheritdoc cref="ISynthModuleHandle.GetControllerName(int)"/>
        /// </summary>
        /// <inheritdoc cref="ISynthModuleHandle.GetControllerName(int)"/>
        string? GetUserControllerName(int index);

        /// <summary>
        /// <para>
        /// Get the type of a user-defined controller. User-defined controllers start at index 5.
        /// </para>
        /// <inheritdoc cref="ISynthModuleHandle.GetControllerType(int)"/>
        /// </summary>
        /// <inheritdoc cref="ISynthModuleHandle.GetControllerType(int)"/>
        ControllerType GetUserControllerType(int index);

        /// <summary>
        /// <para>
        /// Get the count of a user-defined controllers. User-defined controllers start at index 5.
        /// </para>
        /// <inheritdoc cref="ISynthModuleHandle.GetControllerCount"/>
        /// </summary>
        /// <inheritdoc cref="ISynthModuleHandle.GetControllerCount"/>
        int GetUserControllerCount();

        /// <summary>
        /// Make a pattern event that sets a user-defined controller value. User-defined controllers start at index 5.
        /// <para>This overload allows for any enum value to be used.</para>
        /// </summary>
        PatternEvent MakeUserControllerEvent<T>(int index, T value) where T : Enum, IConvertible;

        /// <summary>
        /// Make a pattern event that sets a user-defined controller value. User-defined controllers start at index 5.
        /// <para>This overload allows for raw column values to be used. Values are clamped to the 0x0 to 0x8000 range.</para>
        /// </summary>
        PatternEvent MakeUserControllerEvent(int index, ushort value);

        /// <summary>
        /// Make a pattern event that sets a user-defined controller value. User-defined controllers start at index 5.
        /// <para>This overload allows for using display-values, as long as offset, min and max values of the controller are known..</para>
        /// </summary>
        PatternEvent MakeUserControllerEvent(int index, int value, int offset, int minValue, int maxValue);
    }

    public partial struct MetaModuleModuleHandle : IMetaModuleModuleHandle
    {
        /// <inheritdoc/>
        public void LoadFile(string path) => ModuleHandle.LoadIntoMetaModule(path);

        /// <inheritdoc/>
        public void LoadFile(byte[] data) => ModuleHandle.LoadIntoMetaModule(data);

        /// <inheritdoc/>
        public void SetUserControllerValue(int index, int value, ValueScalingMode scalingMode) => ModuleHandle.SetControllerValue(5 + index, value, scalingMode);

        /// <inheritdoc/>
        public void GetUserControllerValue(int index, ValueScalingMode scalingMode) => ModuleHandle.GetControllerValue(5 + index, scalingMode);

        /// <inheritdoc/>
        public void GetUserControllerMinValue(int index, ValueScalingMode scalingMode) => ModuleHandle.GetControllerMinValue(5 + index, scalingMode);

        /// <inheritdoc/>
        public void GetUserControllerMaxValue(int index, ValueScalingMode scalingMode) => ModuleHandle.GetControllerMaxValue(5 + index, scalingMode);

        /// <inheritdoc/>
        public void GetUserControllerOffset(int index) => ModuleHandle.GetControllerOffset(5 + index);

        /// <inheritdoc/>
        public int GetUserControllerCount() => ModuleHandle.GetControllerCount() - 5;

        /// <inheritdoc/>
        public string? GetUserControllerName(int index) => ModuleHandle.GetControllerName(5 + index);

        /// <inheritdoc/>
        public ControllerType GetUserControllerType(int index) => ModuleHandle.GetControllerType(5 + index);

        /// <inheritdoc/>
        public PatternEvent MakeUserControllerEvent<T>(int index, T value)
            where T : Enum, IConvertible
        {
            return PatternEvent.ControllerEvent(
                moduleId: ModuleHandle.Id,
                controller: (byte)(5 + index),
                value: value.ToUInt16(null)
            );
        }

        /// <inheritdoc/>
        public PatternEvent MakeUserControllerEvent(int index, ushort value)
        {
            return PatternEvent.ControllerEvent(
                moduleId: ModuleHandle.Id,
                controller: (byte)(5 + index),
                value: value
            );
        }

        /// <inheritdoc/>
        public PatternEvent MakeUserControllerEvent(int index, int value, int offset, int minValue, int maxValue)
        {
            value = (value - offset) * 0x8000 / (maxValue - minValue);
            return PatternEvent.ControllerEvent(
                moduleId: ModuleHandle.Id,
                controller: (byte)(5 + index),
                value: (ushort)Math.Clamp(value, 0, 0x8000)
            );
        }
    }
}

#endif
