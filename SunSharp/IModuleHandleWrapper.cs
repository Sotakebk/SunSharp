namespace SunSharp
{
    public interface IModuleHandleWrapper
    {
        ModuleHandle ModuleHandle { get; }
    }

    public static class ModuleHandleWrapperExtensions
    {
        /// <inheritdoc cref="ModuleHandle.GetFlags"/>
        public static ModuleFlags GetFlags(this IModuleHandleWrapper wrapper) => wrapper.ModuleHandle.GetFlags();

        /// <inheritdoc cref="ModuleHandle.GetModuleType"/>
        public static ModuleType GetModuleType(this IModuleHandleWrapper wrapper) => wrapper.ModuleHandle.GetModuleType();

        /// <inheritdoc cref="ModuleHandle.GetExists"/>
        public static bool GetExists(this IModuleHandleWrapper wrapper) => wrapper.ModuleHandle.GetExists();

        /// <inheritdoc cref="ModuleHandle.GetFineTune"/>
        public static FineTunePair GetFineTune(this IModuleHandleWrapper wrapper) => wrapper.ModuleHandle.GetFineTune();

        /// <inheritdoc cref="ModuleHandle.SetFineTune"/>
        public static void SetFinetune(this IModuleHandleWrapper wrapper, FineTunePair fineTune) => wrapper.ModuleHandle.SetFineTune(fineTune);

        /// <inheritdoc cref="ModuleHandle.ReadScope"/>
        public static int ReadScope(this IModuleHandleWrapper wrapper, AudioChannel channel, short[] buffer) => wrapper.ModuleHandle.ReadScope(channel, buffer);

        /// <inheritdoc cref="ModuleHandle.GetName"/>
        public static string? GetName(this IModuleHandleWrapper wrapper) => wrapper.ModuleHandle.GetName();

        /// <inheritdoc cref="ModuleHandle.SetName"/>
        public static void SetName(this IModuleHandleWrapper wrapper, string name) => wrapper.ModuleHandle.SetName(name);

        /// <inheritdoc cref="ModuleHandle.GetPosition"/>
        public static (int x, int y) GetPosition(this IModuleHandleWrapper wrapper) => wrapper.ModuleHandle.GetPosition();

        /// <inheritdoc cref="ModuleHandle.SetPosition"/>
        public static void SetPosition(this IModuleHandleWrapper wrapper, int x, int y) => wrapper.ModuleHandle.SetPosition(x, y);

        /// <inheritdoc cref="ModuleHandle.GetColor"/>
        public static (byte R, byte G, byte B) GetColor(this IModuleHandleWrapper wrapper) => wrapper.ModuleHandle.GetColor();

        /// <inheritdoc cref="ModuleHandle.SetColor"/>
        public static void SetColor(this IModuleHandleWrapper wrapper, byte R, byte G, byte B) => wrapper.ModuleHandle.SetColor(R, G, B);

        /// <inheritdoc cref="ModuleHandle.GetInputs"/>
        public static int[] GetInputs(this IModuleHandleWrapper wrapper) => wrapper.ModuleHandle.GetInputs();

        /// <inheritdoc cref="ModuleHandle.GetInputModules"/>
        public static ModuleHandle[] GetInputModules(this IModuleHandleWrapper wrapper) => wrapper.ModuleHandle.GetInputModules();

        /// <inheritdoc cref="ModuleHandle.GetOutputs"/>
        public static int[] GetOutputs(this IModuleHandleWrapper wrapper) => wrapper.ModuleHandle.GetOutputs();

        /// <inheritdoc cref="ModuleHandle.GetModuleOutputs"/>
        public static ModuleHandle[] GetModuleOutputs(this IModuleHandleWrapper wrapper) => wrapper.ModuleHandle.GetModuleOutputs();

        /// <inheritdoc cref="ModuleHandle.GetControllerCount"/>
        public static int GetControllerCount(this IModuleHandleWrapper wrapper) => wrapper.ModuleHandle.GetControllerCount();

        /// <inheritdoc cref="ModuleHandle.GetControllerName"/>
        public static string? GetControllerName(this IModuleHandleWrapper wrapper, int controllerId) => wrapper.ModuleHandle.GetControllerName(controllerId);

        /// <inheritdoc cref="ModuleHandle.GetControllerValue"/>
        public static int GetControllerValue(this IModuleHandleWrapper wrapper, int controllerId, ValueScalingMode scaling = ValueScalingMode.Displayed) => wrapper.ModuleHandle.GetControllerValue(controllerId, scaling);

        /// <inheritdoc cref="ModuleHandle.SetControllerValue"/>
        public static void SetControllerValue(this IModuleHandleWrapper wrapper, int controller, int value, ValueScalingMode scaling = ValueScalingMode.Displayed) => wrapper.ModuleHandle.SetControllerValue(controller, value, scaling);

        /// <inheritdoc cref="ModuleHandle.GetControllerMinValue"/>
        public static int GetControllerMinValue(this IModuleHandleWrapper wrapper, int controllerId, ValueScalingMode scaling) => wrapper.ModuleHandle.GetControllerMinValue(controllerId, scaling);

        /// <inheritdoc cref="ModuleHandle.GetControllerMaxValue"/>
        public static int GetControllerMaxValue(this IModuleHandleWrapper wrapper, int controllerId, ValueScalingMode scaling) => wrapper.ModuleHandle.GetControllerMaxValue(controllerId, scaling);

        /// <inheritdoc cref="ModuleHandle.GetControllerOffset"/>
        public static int GetControllerOffset(this IModuleHandleWrapper wrapper, int controllerId) => wrapper.ModuleHandle.GetControllerOffset(controllerId);

        /// <inheritdoc cref="ModuleHandle.GetControllerType"/>
        public static ControllerType GetModuleControllerType(this IModuleHandleWrapper wrapper, int controllerId) => wrapper.ModuleHandle.GetControllerType(controllerId);

        /// <inheritdoc cref="ModuleHandle.GetControllerGroup"/>
        public static int GetModuleControllerGroup(this IModuleHandleWrapper wrapper, int controllerId) => wrapper.ModuleHandle.GetControllerGroup(controllerId);
    }
}
