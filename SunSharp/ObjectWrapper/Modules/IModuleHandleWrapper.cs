namespace SunSharp.ObjectWrapper.Modules
{
    public interface IModuleHandleWrapper
    {
        ModuleHandle Module { get; }
    }

    public static class ModuleHandleWrapperExtensions
    {
        /// <inheritdoc cref="ModuleHandle.GetFlags"/>
        public static ModuleFlags GetFlags(this IModuleHandleWrapper wrapper) => wrapper.Module.GetFlags();

        /// <inheritdoc cref="ModuleHandle.GetModuleType"/>
        public static ModuleType GetModuleType(this IModuleHandleWrapper wrapper) => wrapper.Module.GetModuleType();

        /// <inheritdoc cref="ModuleHandle.GetExists"/>
        public static bool GetExists(this IModuleHandleWrapper wrapper) => wrapper.Module.GetExists();

        /// <inheritdoc cref="ModuleHandle.GetFinetune"/>
        public static (int finetune, int relativeNote) GetFinetune(this IModuleHandleWrapper wrapper) => wrapper.Module.GetFinetune();

        /// <inheritdoc cref="ModuleHandle.SetFinetune"/>
        public static void SetFinetune(this IModuleHandleWrapper wrapper, int finetune, int relativeNote) => wrapper.Module.SetFinetune(finetune, relativeNote);

        /// <inheritdoc cref="ModuleHandle.ReadScope"/>
        public static int ReadScope(this IModuleHandleWrapper wrapper, AudioChannel channel, short[] buffer) => wrapper.Module.ReadScope(channel, buffer);

        /// <inheritdoc cref="ModuleHandle.GetName"/>
        public static string GetName(this IModuleHandleWrapper wrapper) => wrapper.Module.GetName();

        /// <inheritdoc cref="ModuleHandle.SetName"/>
        public static void SetName(this IModuleHandleWrapper wrapper, string name) => wrapper.Module.SetName(name);

        /// <inheritdoc cref="ModuleHandle.GetPosition"/>
        public static (int x, int y) GetPosition(this IModuleHandleWrapper wrapper) => wrapper.Module.GetPosition();

        /// <inheritdoc cref="ModuleHandle.SetPosition"/>
        public static void SetPosition(this IModuleHandleWrapper wrapper, int x, int y) => wrapper.Module.SetPosition(x, y);

        /// <inheritdoc cref="ModuleHandle.GetColor"/>
        public static (byte R, byte G, byte B) GetColor(this IModuleHandleWrapper wrapper) => wrapper.Module.GetColor();

        /// <inheritdoc cref="ModuleHandle.SetColor"/>
        public static void SetColor(this IModuleHandleWrapper wrapper, byte R, byte G, byte B) => wrapper.Module.SetColor(R, G, B);

        /// <inheritdoc cref="ModuleHandle.GetInputs"/>
        public static int[] GetInputs(this IModuleHandleWrapper wrapper) => wrapper.Module.GetInputs();

        /// <inheritdoc cref="ModuleHandle.GetInputModules"/>
        public static ModuleHandle[] GetInputModules(this IModuleHandleWrapper wrapper) => wrapper.Module.GetInputModules();

        /// <inheritdoc cref="ModuleHandle.GetOutputs"/>
        public static int[] GetOutputs(this IModuleHandleWrapper wrapper) => wrapper.Module.GetOutputs();

        /// <inheritdoc cref="ModuleHandle.GetModuleOutputs"/>
        public static ModuleHandle[] GetModuleOutputs(this IModuleHandleWrapper wrapper) => wrapper.Module.GetModuleOutputs();

        /// <inheritdoc cref="ModuleHandle.GetControllerCount"/>
        public static int GetControllerCount(this IModuleHandleWrapper wrapper) => wrapper.Module.GetControllerCount();

        /// <inheritdoc cref="ModuleHandle.GetControllerName"/>
        public static string GetControllerName(this IModuleHandleWrapper wrapper, int controllerId) => wrapper.Module.GetControllerName(controllerId);

        /// <inheritdoc cref="ModuleHandle.GetControllerValue"/>
        public static int GetControllerValue(this IModuleHandleWrapper wrapper, int controllerId, ValueScalingType scaling = ValueScalingType.Displayed) => wrapper.GetControllerValue(controllerId, scaling);

        /// <inheritdoc cref="ModuleHandle.SetControllerValue"/>
        public static void SetControllerValue(this IModuleHandleWrapper wrapper, int controller, int value, ValueScalingType scaling = ValueScalingType.Displayed) => wrapper.SetControllerValue(controller, value, scaling);

        /// <inheritdoc cref="ModuleHandle.GetControllerMinValue"/>
        public static int GetControllerMinValue(this IModuleHandleWrapper wrapper, int controllerId, ValueScalingType scaling) => wrapper.Module.GetControllerMinValue(controllerId, scaling);

        /// <inheritdoc cref="ModuleHandle.GetControllerMaxValue"/>
        public static int GetControllerMaxValue(this IModuleHandleWrapper wrapper, int controllerId, ValueScalingType scaling) => wrapper.Module.GetControllerMaxValue(controllerId, scaling);

        /// <inheritdoc cref="ModuleHandle.GetControllerOffset"/>
        public static int GetControllerOffset(this IModuleHandleWrapper wrapper, int controllerId) => wrapper.Module.GetControllerOffset(controllerId);

        /// <inheritdoc cref="ModuleHandle.GetModuleControllerType"/>
        public static ControllerType GetModuleControllerType(this IModuleHandleWrapper wrapper, int controllerId) => wrapper.Module.GetControllerType(controllerId);

        /// <inheritdoc cref="ModuleHandle.GetModuleControllerGroup"/>
        public static int GetModuleControllerGroup(this IModuleHandleWrapper wrapper, int controllerId) => wrapper.Module.GetControllerGroup(controllerId);
    }
}
