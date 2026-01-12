using System.Runtime.InteropServices;
using SunSharp.Native;

namespace SunSharp.Tests.Native;

public class SunVoxLibNativeWrapperModulesTests
{
    public static readonly TestCaseData[] ModuleInputOutputAndResult =
    [
        new(new[] { -1 }, Array.Empty<int>()),
        new(new[] { 0 }, new[] { 0 }),
        new(new[] { -1, 0, 1, 2 }, new[] { 0, 1, 2 }),
        new(new[] { -1, -1, 1, -1, 2, -1, -1, 3 }, new[] { 1, 2, 3 })
    ];

    [Test, AutoData]
    public void ConnectModuleShouldCallExpectedMethod(int slotId, int source, int destination)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_connect_module(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()).Returns(0);

        // when
        wrapper.ConnectModule(slotId, source, destination);

        // then
        library.Received(1).sv_connect_module(slotId, source, destination);
    }

    [Test, AutoData]
    public void ConnectModuleShouldThrowOnNonZeroReturnCode(int slotId, int source, int destination)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_connect_module(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()).Returns(-1);

        // when - then
        wrapper.Invoking(w => w.ConnectModule(slotId, source, destination)).Should().Throw<SunVoxException>();

        // then
        library.Received(1).sv_connect_module(slotId, source, destination);
    }

    [Test, AutoData]
    public void CreateModuleShouldCallExpectedMethod(int newModuleId, string moduleName, string moduleType, int slotId, int x, int y, int z)
    {
        var receivedModuleName = string.Empty;
        var receivedModuleType = string.Empty;

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_new_module(Arg.Any<int>(), Arg.Any<IntPtr>(), Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(),
            Arg.Any<int>()).Returns(newModuleId);
        library.When(static l => l.sv_new_module(Arg.Any<int>(), Arg.Any<IntPtr>(), Arg.Any<IntPtr>(), Arg.Any<int>(),
                Arg.Any<int>(), Arg.Any<int>()))
            .Do(callInfo =>
            {
                receivedModuleType = Marshal.PtrToStringAnsi(callInfo.ArgAt<IntPtr>(1));
                receivedModuleName = Marshal.PtrToStringAnsi(callInfo.ArgAt<IntPtr>(2));
            });

        // when
        var value = wrapper.CreateModule(slotId, moduleType, moduleName, x, y, z);
        library.Received(1).sv_new_module(slotId, Arg.Any<IntPtr>(), Arg.Any<IntPtr>(), x, y, z);
        value.Should().Be(newModuleId);
        receivedModuleName.Should().Be(moduleName);
        receivedModuleType.Should().Be(moduleType);
    }

    [Test, AutoData]
    public void CreateModuleShouldThrowOnNegativeReturnedValue(string moduleName, string moduleType, int slotId, int x, int y, int z)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_new_module(Arg.Any<int>(), Arg.Any<IntPtr>(), Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(),
            Arg.Any<int>()).Returns(-1);

        // when
        wrapper.Invoking(w => w.CreateModule(slotId, moduleType, moduleName, x, y, z)).Should().Throw<SunVoxException>();

        // then
        library.Received(1).sv_new_module(slotId, Arg.Any<IntPtr>(), Arg.Any<IntPtr>(), x, y, z);
    }

    [Test, AutoData]
    public void DisconnectModuleShouldCallExpectedMethod(int slotId, int source, int destination)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_disconnect_module(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()).Returns(0);

        // when
        wrapper.DisconnectModule(slotId, source, destination);

        // then
        library.Received(1).sv_disconnect_module(slotId, source, destination);
    }

    [Test, AutoData]
    public void DisconnectModuleShouldThrowOnNonZeroReturnCode(int slotId, int source, int destination)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_disconnect_module(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()).Returns(-1);

        // when - then
        wrapper.Invoking(w => w.DisconnectModule(slotId, source, destination)).Should().Throw<SunVoxException>();

        // then
        library.Received(1).sv_disconnect_module(slotId, source, destination);
    }

    [Test, AutoData]
    public void FindModuleShouldCallExpectedMethod(int foundModuleId, string moduleName, int slotId)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_find_module(Arg.Any<int>(), Arg.Any<IntPtr>()).Returns(foundModuleId);
        var receivedString = string.Empty;
        library.When(static l => l.sv_find_module(Arg.Any<int>(), Arg.Any<IntPtr>()))
            .Do(callInfo => receivedString = Marshal.PtrToStringAnsi(callInfo.Arg<IntPtr>()));

        // when
        var value = wrapper.FindModule(slotId, moduleName);

        // then
        library.Received(1).sv_find_module(slotId, Arg.Any<IntPtr>());
        value.Should().Be(foundModuleId);
        receivedString.Should().Be(moduleName);
    }

    [Test, AutoData]
    public void FindModuleShouldCallExpectedMethodAndReturnNullWhenModuleNotFound(string moduleName, int slotId)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_find_module(Arg.Any<int>(), Arg.Any<IntPtr>()).Returns(-1);
        var receivedString = string.Empty;
        library.When(static l => l.sv_find_module(Arg.Any<int>(), Arg.Any<IntPtr>()))
            .Do(callInfo => receivedString = Marshal.PtrToStringAnsi(callInfo.Arg<IntPtr>()));

        // when
        var value = wrapper.FindModule(slotId, moduleName);

        // then
        library.Received(1).sv_find_module(slotId, Arg.Any<IntPtr>());
        value.Should().BeNull();
        receivedString.Should().Be(moduleName);
    }

    [Test, AutoData]
    public void FindModuleShouldThrowOnUnexpectedValue(string moduleName, int slotId)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_find_module(Arg.Any<int>(), Arg.Any<IntPtr>()).Returns(-2);

        // when
        wrapper.Invoking(w => w.FindModule(slotId, moduleName)).Should().Throw<SunVoxException>();

        // then
        library.Received(1).sv_find_module(slotId, Arg.Any<IntPtr>());
    }

    [Test, AutoData]
    public void GetModuleColorShouldCallExpectedMethodAndReturnValue(byte r, byte g, byte b, int moduleId, int slotId)
    {
        var code = r | (g << 8) | (b << 16);

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_module_color(Arg.Any<int>(), Arg.Any<int>()).Returns(code);

        // when
        var value = wrapper.GetModuleColor(slotId, moduleId);

        // then
        library.Received(1).sv_get_module_color(slotId, moduleId);
        value.Should().Be((r, g, b));
    }

    [Test, AutoData]
    public void GetModuleControllerCountShouldCallExpectedMethod(int moduleId, int slotId, int moduleCount)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_number_of_module_ctls(Arg.Any<int>(), Arg.Any<int>()).Returns(moduleCount);

        // when
        var value = wrapper.GetModuleControllerCount(slotId, moduleId);

        // then
        library.Received(1).sv_get_number_of_module_ctls(slotId, moduleId);
        value.Should().Be(moduleCount);
    }

    [Test, AutoData]
    public void GetModuleControllerCountShouldCallExpectedMethodAndThrowOnNegativeValue(int slotId, int moduleId)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_number_of_module_ctls(Arg.Any<int>(), Arg.Any<int>()).Returns(-1);

        // when
        wrapper.Invoking(w => w.GetModuleControllerCount(slotId, moduleId)).Should().Throw<SunVoxException>();

        // then
        library.Received(1).sv_get_number_of_module_ctls(slotId, moduleId);
    }

    [Test, AutoData]
    public void GetModuleControllerGroupShouldCallExpectedMethodAndReturnValue(int moduleId, int controllerId, int slotId, int returnedValue)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_module_ctl_group(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()).Returns(returnedValue);

        // when
        var value = wrapper.GetModuleControllerGroup(slotId, moduleId, controllerId);

        // then
        library.Received(1).sv_get_module_ctl_group(slotId, moduleId, controllerId);
        value.Should().Be(returnedValue);
    }

    [Test, AutoData]
    public void GetModuleControllerMaxValueShouldCallExpectedMethodAndReturnValue(int moduleId, int controllerId, int slotId, int returnedValue, ValueScalingMode scalingMode)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_module_ctl_max(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>())
            .Returns(returnedValue);

        // when
        var value = wrapper.GetModuleControllerMaxValue(slotId, moduleId, controllerId, scalingMode);

        // then
        library.Received(1).sv_get_module_ctl_max(slotId, moduleId, controllerId, (int)scalingMode);
        value.Should().Be(returnedValue);
    }

    [Test, AutoData]
    public void GetModuleControllerMinValueShouldCallExpectedMethodAndReturnValue(int moduleId, int controllerId, int slotId, int returnedValue, ValueScalingMode scalingMode)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_module_ctl_min(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>())
            .Returns(returnedValue);

        // when
        var value = wrapper.GetModuleControllerMinValue(slotId, moduleId, controllerId, scalingMode);

        // then
        library.Received(1).sv_get_module_ctl_min(slotId, moduleId, controllerId, (int)scalingMode);
        value.Should().Be(returnedValue);
    }

    [Test, AutoData]
    public void GetModuleControllerNameShouldCallExpectedMethodAndReturnNull(int moduleId, int controllerId, int slotId)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_module_ctl_name(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()).Returns(IntPtr.Zero);

        // when
        var receivedControllerName = wrapper.GetModuleControllerName(slotId, moduleId, controllerId);

        // then
        library.Received(1).sv_get_module_ctl_name(slotId, moduleId, controllerId);
        receivedControllerName.Should().BeNull();
    }

    [Test, AutoData]
    public void GetModuleControllerNameShouldCallExpectedMethodAndReturnString(string controllerName, int moduleId, int controllerId, int slotId)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var stringPointer = IntPtr.Zero;
        string? receivedControllerName;

        try
        {
            stringPointer = Marshal.StringToHGlobalAnsi(controllerName);
            library.sv_get_module_ctl_name(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()).Returns(stringPointer);

            // when
            receivedControllerName = wrapper.GetModuleControllerName(slotId, moduleId, controllerId);
        }
        finally
        {
            Marshal.FreeHGlobal(stringPointer);
        }

        // then
        library.Received(1).sv_get_module_ctl_name(slotId, moduleId, controllerId);
        receivedControllerName.Should().Be(controllerName);
    }

    [Test, AutoData]
    public void GetModuleControllerOffsetShouldCallExpectedMethodAndReturnValue(int moduleId, int controllerId, int slotId, int returnedValue)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_module_ctl_offset(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()).Returns(returnedValue);

        // when
        var value = wrapper.GetModuleControllerOffset(slotId, moduleId, controllerId);

        // then
        library.Received(1).sv_get_module_ctl_offset(slotId, moduleId, controllerId);
        value.Should().Be(returnedValue);
    }

    [Test, AutoData]
    public void GetModuleControllerTypeShouldCallExpectedMethodAndReturnValue(int moduleId, int controllerId, int slotId, ControllerType returnedValue)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_module_ctl_type(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()).Returns((int)returnedValue);

        // when
        var value = wrapper.GetModuleControllerType(slotId, moduleId, controllerId);

        // then
        library.Received(1).sv_get_module_ctl_type(slotId, moduleId, controllerId);
        value.Should().Be(returnedValue);
    }

    [Test, AutoData]
    public void GetModuleControllerTypeShouldCallExpectedMethodAndThrowOnUnexpectedValue(int moduleId, int controllerId, int slotId)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_module_ctl_type(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()).Returns(-1);

        // when
        wrapper.Invoking(w => w.GetModuleControllerType(slotId, moduleId, controllerId)).Should().Throw<SunVoxException>();

        // then
        library.Received(1).sv_get_module_ctl_type(slotId, moduleId, controllerId);
    }

    [Test, AutoData]
    public void GetModuleControllerValueShouldCallExpectedMethodAndReturnValue(int moduleId, int controllerId, int slotId, int returnedValue, ValueScalingMode scalingMode)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_module_ctl_value(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>())
            .Returns(returnedValue);

        // when
        var value = wrapper.GetModuleControllerValue(slotId, moduleId, controllerId, scalingMode);

        // then
        library.Received(1).sv_get_module_ctl_value(slotId, moduleId, controllerId, (int)scalingMode);
        value.Should().Be(returnedValue);
    }

    [TestCase(true)]
    [TestCase(false)]
    public void GetModuleExistsShouldCallExpectedMethodAndReturnValue(bool exists)
    {
        var fixture = new Fixture();
        var flagsValue = (uint)(ModuleFlags.SV_MODULE_FLAG_EXISTS * (exists ? 1 : 0));
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var moduleId = fixture.Create<int>();
        var slotId = fixture.Create<int>();
        library.sv_get_module_flags(Arg.Any<int>(), Arg.Any<int>()).Returns(flagsValue);

        // when
        var receivedExists = wrapper.GetModuleExists(slotId, moduleId);

        // then
        library.Received(1).sv_get_module_flags(slotId, moduleId);
        receivedExists.Should().Be(exists);
    }

    [Test, AutoData]
    public void GetModuleFineTuneShouldCallExpectedMethodAndReturnValue(FineTunePair moduleFineTune, int moduleId, int slotId)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_module_finetune(Arg.Any<int>(), Arg.Any<int>()).Returns(moduleFineTune.RawValue);

        // when
        var receivedFineTune = wrapper.GetModuleFineTune(slotId, moduleId);

        // then
        library.Received(1).sv_get_module_finetune(slotId, moduleId);
        receivedFineTune.Should().Be(moduleFineTune);
    }

    [Test, AutoData]
    public void GetModuleFlagsShouldCallExpectedMethodAndReturnValue(uint flagsValue, int moduleId, int slotId)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_module_flags(Arg.Any<int>(), Arg.Any<int>()).Returns(flagsValue);

        // when
        var flags = wrapper.GetModuleFlags(slotId, moduleId);

        // then
        library.Received(1).sv_get_module_flags(slotId, moduleId);
        flags.Should().Be((ModuleFlags)flagsValue);
    }

    [TestCaseSource(nameof(ModuleInputOutputAndResult))]
    public void GetModuleInputsShouldCallExpectedMethodsAndReturnValue(int[] nativeData, int[] expectedOutput)
    {
        var fixture = new Fixture();
        var flagsValue = unchecked((uint)((nativeData.Length << ModuleFlags.SV_MODULE_INPUTS_OFF) |
                                ModuleFlags.SV_MODULE_FLAG_EXISTS));
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var moduleId = fixture.Create<int>();
        var slotId = fixture.Create<int>();
        library.sv_get_module_flags(Arg.Any<int>(), Arg.Any<int>()).Returns(flagsValue);

        // assumes that GetModuleInputs frees this memory
        var ptr = Marshal.AllocHGlobal(sizeof(int) * nativeData.Length);
        Marshal.Copy(nativeData, 0, ptr, nativeData.Length);
        library.sv_get_module_inputs(Arg.Any<int>(), Arg.Any<int>()).Returns(ptr);

        // when
        var receivedInputs = wrapper.GetModuleInputs(slotId, moduleId);
        library.Received(1).sv_get_module_flags(slotId, moduleId);
        library.Received(1).sv_get_module_inputs(slotId, moduleId);
        receivedInputs.Should().BeEquivalentTo(expectedOutput);
    }

    [Test]
    public void GetModuleInputsShouldSkipCallsIfDoesNotExist()
    {
        const uint flagsValue = 0u;
        var fixture = new Fixture();
        new ModuleFlags(flagsValue).Exists.Should().BeFalse();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var moduleId = fixture.Create<int>();
        var slotId = fixture.Create<int>();
        library.sv_get_module_flags(Arg.Any<int>(), Arg.Any<int>()).Returns(flagsValue);

        // when
        var receivedInputs = wrapper.GetModuleInputs(slotId, moduleId);

        // then
        library.Received(1).sv_get_module_flags(slotId, moduleId);
        library.Received(0).sv_get_module_inputs(slotId, moduleId);
        receivedInputs.Should().BeEquivalentTo(Array.Empty<int>());
    }

    [Test]
    public void GetModuleInputsShouldSkipCallsIfZeroInputs()
    {
        const uint flagsValue = ModuleFlags.SV_MODULE_FLAG_EXISTS;
        var fixture = new Fixture();
        new ModuleFlags(flagsValue).InputUpperCount.Should().Be(0);

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var moduleId = fixture.Create<int>();
        var slotId = fixture.Create<int>();
        library.sv_get_module_flags(Arg.Any<int>(), Arg.Any<int>()).Returns(flagsValue);

        // when
        var receivedInputs = wrapper.GetModuleInputs(slotId, moduleId);

        // then
        library.Received(1).sv_get_module_flags(slotId, moduleId);
        library.Received(0).sv_get_module_inputs(slotId, moduleId);
        receivedInputs.Should().BeEquivalentTo(Array.Empty<int>());
    }

    [Test, AutoData]
    public void GetModuleNameShouldCallExpectedMethodAndReturnNullWhenNullPointer(int moduleId, int slotId)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_module_name(Arg.Any<int>(), Arg.Any<int>()).Returns(IntPtr.Zero);

        // when
        var receivedModuleName = wrapper.GetModuleName(slotId, moduleId);
        // then
        library.Received(1).sv_get_module_name(slotId, moduleId);
        receivedModuleName.Should().BeNull();
    }

    [Test, AutoData]
    public void GetModuleNameShouldCallExpectedMethodAndReturnString(int moduleId, int slotId, string moduleName)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var stringPointer = IntPtr.Zero;
        string? receivedModuleName;

        try
        {
            stringPointer = Marshal.StringToHGlobalAnsi(moduleName);
            library.sv_get_module_name(Arg.Any<int>(), Arg.Any<int>()).Returns(stringPointer);

            // when
            receivedModuleName = wrapper.GetModuleName(slotId, moduleId);
        }
        finally
        {
            Marshal.FreeHGlobal(stringPointer);
        }

        // then
        library.Received(1).sv_get_module_name(slotId, moduleId);
        receivedModuleName.Should().Be(moduleName);
    }

    [TestCaseSource(nameof(ModuleInputOutputAndResult))]
    public void GetModuleOutputsShouldCallExpectedMethodsAndReturnValue(int[] nativeData, int[] expectedOutput)
    {
        var fixture = new Fixture();
        var flagsValue = (uint)((nativeData.Length << ModuleFlags.SV_MODULE_OUTPUTS_OFF) |
                                ModuleFlags.SV_MODULE_FLAG_EXISTS);
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var moduleId = fixture.Create<int>();
        var slotId = fixture.Create<int>();
        library.sv_get_module_flags(Arg.Any<int>(), Arg.Any<int>()).Returns(flagsValue);

        // assumes that GetModuleOutputs frees this memory
        var ptr = Marshal.AllocHGlobal(sizeof(int) * nativeData.Length);
        Marshal.Copy(nativeData, 0, ptr, nativeData.Length);
        library.sv_get_module_outputs(Arg.Any<int>(), Arg.Any<int>()).Returns(ptr);

        // when
        var receivedOutputs = wrapper.GetModuleOutputs(slotId, moduleId);
        library.Received(1).sv_get_module_flags(slotId, moduleId);
        library.Received(1).sv_get_module_outputs(slotId, moduleId);
        receivedOutputs.Should().BeEquivalentTo(expectedOutput);
    }

    [Test, AutoData]
    public void GetModuleOutputsShouldSkipCallsIfDoesNotExist(int moduleId, int slotId)
    {
        const uint flagsValue = 0u;
        new ModuleFlags(flagsValue).Exists.Should().BeFalse();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_module_flags(Arg.Any<int>(), Arg.Any<int>()).Returns(flagsValue);

        // when
        var receivedOutputs = wrapper.GetModuleOutputs(slotId, moduleId);

        // then
        library.Received(1).sv_get_module_flags(slotId, moduleId);
        library.Received(0).sv_get_module_outputs(slotId, moduleId);
        receivedOutputs.Should().BeEmpty();
    }

    [Test, AutoData]
    public void GetModuleOutputsShouldSkipCallsIfZeroOutputs(int moduleId, int slotId)
    {
        const uint flagsValue = ModuleFlags.SV_MODULE_FLAG_EXISTS;
        new ModuleFlags(flagsValue).InputUpperCount.Should().Be(0);

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_module_flags(Arg.Any<int>(), Arg.Any<int>()).Returns(flagsValue);

        // when
        var receivedOutputs = wrapper.GetModuleOutputs(slotId, moduleId);

        // then
        library.Received(1).sv_get_module_flags(slotId, moduleId);
        library.Received(0).sv_get_module_outputs(slotId, moduleId);
        receivedOutputs.Should().BeEmpty();
    }

    [Test, AutoData]
    public void GetModulePositionShouldCallExpectedMethodAndReturnValue(int moduleId, int slotId, short x, short y)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_module_xy(Arg.Any<int>(), Arg.Any<int>()).Returns(Helper.PackTwoSignedShorts(x, y));
        // when
        var value = wrapper.GetModulePosition(slotId, moduleId);

        // then
        library.Received(1).sv_get_module_xy(slotId, moduleId);
        value.Should().Be((x, y));
    }

    [Test, AutoData]
    public void GetModuleTypeShouldCallExpectedMethodAndReturnNullWhenNullPointer(int moduleId, int slotId)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_module_type(Arg.Any<int>(), Arg.Any<int>()).Returns(IntPtr.Zero);

        // when
        var receivedModuleName = wrapper.GetModuleType(slotId, moduleId);
        // then
        library.Received(1).sv_get_module_type(slotId, moduleId);
        receivedModuleName.Should().BeNull();
    }

    [Test, AutoData]
    public void GetModuleTypeShouldCallExpectedMethodAndReturnString(int moduleId, int slotId, string moduleType)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var stringPointer = IntPtr.Zero;
        string? receivedModuleType;

        try
        {
            stringPointer = Marshal.StringToHGlobalAnsi(moduleType);
            library.sv_get_module_type(Arg.Any<int>(), Arg.Any<int>()).Returns(stringPointer);

            // when
            receivedModuleType = wrapper.GetModuleType(slotId, moduleId);
        }
        finally
        {
            Marshal.FreeHGlobal(stringPointer);
        }

        // then
        library.Received(1).sv_get_module_type(slotId, moduleId);
        receivedModuleType.Should().Be(moduleType);
    }

    [Test, AutoData]
    public void GetUpperModuleCountShouldCallExpectedMethod(int slotId, int moduleCount)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_number_of_modules(Arg.Any<int>()).Returns(moduleCount);

        // when
        var value = wrapper.GetUpperModuleCount(slotId);

        // then
        library.Received(1).sv_get_number_of_modules(slotId);
        value.Should().Be(moduleCount);
    }

    [Test, AutoData]
    public void GetUpperModuleCountShouldCallExpectedMethodAndThrowOnNegativeValue(int slotId)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_number_of_modules(Arg.Any<int>()).Returns(-1);

        // when
        wrapper.Invoking(w => w.GetUpperModuleCount(slotId)).Should().Throw<SunVoxException>();

        // then
        library.Received(1).sv_get_number_of_modules(slotId);
    }

    [Test, AutoData]
    public void LoadIntoMetaModuleFromMemoryShouldCallExpectedMethod(int slotId, int moduleId, byte[] buffer)
    {
        var receivedBuffer = Array.Empty<byte>();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_metamodule_load_from_memory(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>(), Arg.Any<uint>())
            .Returns(0);
        library.When(static l =>
                l.sv_metamodule_load_from_memory(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>(), Arg.Any<uint>()))
            .Do(callInfo =>
            {
                receivedBuffer = new byte[callInfo.Arg<uint>()];
                Marshal.Copy(callInfo.Arg<IntPtr>(), receivedBuffer, 0, (int)callInfo.Arg<uint>());
            });

        // when
        wrapper.LoadIntoMetaModule(slotId, moduleId, buffer);

        // then
        library.Received(1).sv_metamodule_load_from_memory(slotId, moduleId, Arg.Any<IntPtr>(), (uint)buffer.Length);
        receivedBuffer.Should().BeEquivalentTo(buffer);
    }

    [Test, AutoData]
    public void LoadIntoMetaModuleFromMemoryShouldThrowOnNonZeroReturnCode(int slotId, int moduleId, byte[] buffer)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_metamodule_load_from_memory(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>(), Arg.Any<uint>())
            .Returns(-1);

        // when
        wrapper.Invoking(w => w.LoadIntoMetaModule(slotId, moduleId, buffer)).Should().Throw<SunVoxException>();

        // then
        library.Received(1).sv_metamodule_load_from_memory(slotId, moduleId, Arg.Any<IntPtr>(), (uint)buffer.Length);
    }

    [Test, AutoData]
    public void LoadIntoMetaModuleShouldCallExpectedMethod(int slotId, int moduleId, string path)
    {
        var receivedString = string.Empty;

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.When(static l => l.sv_metamodule_load(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>()))
            .Do(callInfo => receivedString = Marshal.PtrToStringAnsi(callInfo.Arg<IntPtr>()));

        // when
        wrapper.LoadIntoMetaModule(slotId, moduleId, path);

        // then
        library.Received(1).sv_metamodule_load(slotId, moduleId, Arg.Any<IntPtr>());
        receivedString.Should().Be(path);
    }

    [Test, AutoData]
    public void LoadIntoMetaModuleShouldCallExpectedMethodAndThrowOnNonZeroReturnCode(int slotId, int moduleId, string path)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_metamodule_load(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>()).Returns(-1);

        // when
        wrapper.Invoking(w => w.LoadIntoMetaModule(slotId, moduleId, path)).Should().Throw<SunVoxException>();

        // then
        library.Received(1).sv_metamodule_load(slotId, moduleId, Arg.Any<IntPtr>());
    }

    [Test, AutoData]
    public void LoadIntoVorbisPLayerFromMemoryShouldCallExpectedMethod(int slotId, int moduleId, byte[] buffer)
    {
        var receivedBuffer = Array.Empty<byte>();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_metamodule_load_from_memory(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>(), Arg.Any<uint>())
            .Returns(0);
        library.When(static l =>
                l.sv_vplayer_load_from_memory(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>(), Arg.Any<uint>()))
            .Do(callInfo =>
            {
                receivedBuffer = new byte[callInfo.Arg<uint>()];
                Marshal.Copy(callInfo.Arg<IntPtr>(), receivedBuffer, 0, (int)callInfo.Arg<uint>());
            });

        // when
        wrapper.LoadIntoVorbisPLayer(slotId, moduleId, buffer);

        // then
        library.Received(1).sv_vplayer_load_from_memory(slotId, moduleId, Arg.Any<IntPtr>(), (uint)buffer.Length);
        receivedBuffer.Should().BeEquivalentTo(buffer);
    }

    [Test, AutoData]
    public void LoadIntoVorbisPLayerFromMemoryShouldThrowOnNonZeroReturnCode(int slotId, int moduleId, byte[] buffer)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_vplayer_load_from_memory(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>(), Arg.Any<uint>())
            .Returns(-1);

        // when
        wrapper.Invoking(w => w.LoadIntoVorbisPLayer(slotId, moduleId, buffer)).Should().Throw<SunVoxException>();

        // then
        library.Received(1).sv_vplayer_load_from_memory(slotId, moduleId, Arg.Any<IntPtr>(), (uint)buffer.Length);
    }

    [Test, AutoData]
    public void LoadIntoVorbisPLayerShouldCallExpectedMethod(int slotId, int moduleId, string path)
    {
        var receivedString = string.Empty;

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.When(static l => l.sv_vplayer_load(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>()))
            .Do(callInfo => receivedString = Marshal.PtrToStringAnsi(callInfo.Arg<IntPtr>()));

        // when
        wrapper.LoadIntoVorbisPLayer(slotId, moduleId, path);

        // then
        library.Received(1).sv_vplayer_load(slotId, moduleId, Arg.Any<IntPtr>());
        receivedString.Should().Be(path);
    }

    [Test, AutoData]
    public void LoadIntoVorbisPLayerShouldCallExpectedMethodAndThrowOnNonZeroReturnCode(int slotId, int moduleId, string path)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_vplayer_load(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>()).Returns(-1);

        // when
        wrapper.Invoking(w => w.LoadIntoVorbisPLayer(slotId, moduleId, path)).Should().Throw<SunVoxException>();

        // then
        library.Received(1).sv_vplayer_load(slotId, moduleId, Arg.Any<IntPtr>());
    }

    [Test, AutoData]
    public void LoadModuleFromMemoryShouldCallExpectedMethod(int x, int y, int z, int slotId, int newModuleId, byte[] buffer)
    {
        var receivedBuffer = Array.Empty<byte>();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_load_module_from_memory(Arg.Any<int>(), Arg.Any<IntPtr>(), Arg.Any<uint>(), Arg.Any<int>(),
            Arg.Any<int>(), Arg.Any<int>()).Returns(newModuleId);
        library.When(static l => l.sv_load_module_from_memory(Arg.Any<int>(), Arg.Any<IntPtr>(), Arg.Any<uint>(),
                Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()))
            .Do(callInfo =>
            {
                receivedBuffer = new byte[callInfo.Arg<uint>()];
                Marshal.Copy(callInfo.Arg<IntPtr>(), receivedBuffer, 0, (int)callInfo.Arg<uint>());
            });

        // when
        var value = wrapper.LoadModule(slotId, buffer, x, y, z);
        library.Received(1).sv_load_module_from_memory(slotId, Arg.Any<IntPtr>(), (uint)buffer.Length, x, y, z);
        value.Should().Be(newModuleId);
        receivedBuffer.Should().BeEquivalentTo(buffer);
    }

    [Test, AutoData]
    public void LoadModuleFromMemoryShouldThrowOnNonZeroReturnCode(int x, int y, int z, int slotId, byte[] buffer)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_load_module_from_memory(Arg.Any<int>(), Arg.Any<IntPtr>(), Arg.Any<uint>(), Arg.Any<int>(),
            Arg.Any<int>(), Arg.Any<int>()).Returns(-1);

        // when
        wrapper.Invoking(w => w.LoadModule(slotId, buffer, x, y, z)).Should().Throw<SunVoxException>();

        // then
        library.Received(1).sv_load_module_from_memory(slotId, Arg.Any<IntPtr>(), (uint)buffer.Length, x, y, z);
    }

    [Test, AutoData]
    public void LoadModuleShouldCallExpectedMethod(int x, int y, int z, int slotId, int newModuleId, string path)
    {
        var receivedString = string.Empty;

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_load_module(Arg.Any<int>(), Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>())
            .Returns(newModuleId);
        library.When(static l =>
                l.sv_load_module(Arg.Any<int>(), Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()))
            .Do(callInfo => receivedString = Marshal.PtrToStringAnsi(callInfo.Arg<IntPtr>()));

        // when
        var value = wrapper.LoadModule(slotId, path, x, y, z);
        library.Received(1).sv_load_module(slotId, Arg.Any<IntPtr>(), x, y, z);
        value.Should().Be(newModuleId);
        receivedString.Should().Be(path);
    }

    [Test, AutoData]
    public void LoadModuleShouldThrowOnNonZeroReturnCode(int x, int y, int z, int slotId, string path)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_load_module(Arg.Any<int>(), Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>())
            .Returns(-1);

        // when
        wrapper.Invoking(w => w.LoadModule(slotId, path, x, y, z)).Should().Throw<SunVoxException>();

        // then
        library.Received(1).sv_load_module(slotId, Arg.Any<IntPtr>(), x, y, z);
    }

    [Test, AutoData]
    public void LoadSamplerSampleFromMemoryShouldCallExpectedMethod(int slotId, int moduleId, int sampleSlot, byte[] buffer)
    {
        var receivedBuffer = Array.Empty<byte>();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_sampler_load_from_memory(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>(), Arg.Any<uint>(),
                Arg.Any<int>())
            .Returns(0);
        library.When(static l => l.sv_sampler_load_from_memory(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>(),
                Arg.Any<uint>(), Arg.Any<int>()))
            .Do(callInfo =>
            {
                receivedBuffer = new byte[callInfo.Arg<uint>()];
                Marshal.Copy(callInfo.Arg<IntPtr>(), receivedBuffer, 0, (int)callInfo.Arg<uint>());
            });

        // when
        wrapper.LoadSamplerSample(slotId, moduleId, buffer, sampleSlot);
        library.Received(1)
            .sv_sampler_load_from_memory(slotId, moduleId, Arg.Any<IntPtr>(), (uint)buffer.Length, sampleSlot);
        receivedBuffer.Should().BeEquivalentTo(buffer);
    }

    [Test, AutoData]
    public void LoadSamplerSampleFromMemoryShouldThrowOnNonZeroReturnCode(int slotId, int moduleId, int sampleSlot, byte[] buffer)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_sampler_load_from_memory(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>(), Arg.Any<uint>(),
                Arg.Any<int>())
            .Returns(-1);

        // when
        wrapper.Invoking(w => w.LoadSamplerSample(slotId, moduleId, buffer, sampleSlot)).Should().Throw<SunVoxException>();

        // then
        library.Received(1)
            .sv_sampler_load_from_memory(slotId, moduleId, Arg.Any<IntPtr>(), (uint)buffer.Length, sampleSlot);
    }

    [Test, AutoData]
    public void LoadSamplerSampleShouldCallExpectedMethod(int slotId, int moduleId, int sampleSlot, string path)
    {
        var receivedString = string.Empty;

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.When(static l => l.sv_sampler_load(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>(), Arg.Any<int>()))
            .Do(callInfo => receivedString = Marshal.PtrToStringAnsi(callInfo.Arg<IntPtr>()));

        // when
        wrapper.LoadSamplerSample(slotId, moduleId, path, sampleSlot);
        library.Received(1).sv_sampler_load(slotId, moduleId, Arg.Any<IntPtr>(), sampleSlot);
        receivedString.Should().Be(path);
    }

    [Test, AutoData]
    public void LoadSamplerSampleShouldCallExpectedMethodAndThrowOnNonZeroReturnCode(int slotId, int moduleId, int sampleSlot, string path)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_sampler_load(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>(), Arg.Any<int>()).Returns(-1);

        // when
        wrapper.Invoking(w => w.LoadSamplerSample(slotId, moduleId, path, sampleSlot)).Should().Throw<SunVoxException>();

        // then
        library.Received(1).sv_sampler_load(slotId, moduleId, Arg.Any<IntPtr>(), sampleSlot);
    }

    [Test, AutoData]
    public void ReadModuleCurveShouldCallExpectedMethod(int slotId, int moduleId, int curveId, float[] buffer)
    {
        var samplesWritten = buffer.Length;

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_module_curve(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>(), Arg.Any<int>(),
            Arg.Any<int>()).Returns(samplesWritten);
        library.When(static l => l.sv_module_curve(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>(),
                Arg.Any<int>(), Arg.Any<int>()))
            .Do(callInfo =>
            {
                var receivedBuffer = new int[callInfo.ArgAt<int>(4)];
                Marshal.Copy(callInfo.Arg<IntPtr>(), receivedBuffer, 0, callInfo.ArgAt<int>(4));
            });

        // when
        var value = wrapper.ReadModuleCurve(slotId, moduleId, curveId, buffer);
        library.Received(1).sv_module_curve(slotId, moduleId, curveId, Arg.Any<IntPtr>(), buffer.Length, 0);
        value.Should().Be(samplesWritten);
    }

    [Test, AutoData]
    public void ReadModuleCurveShouldThrowOnNonZeroReturnCode(int slotId, int moduleId, int curveId, float[] buffer)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_module_curve(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>(), Arg.Any<int>(),
            Arg.Any<int>()).Returns(-1);

        // when
        wrapper.Invoking(w => w.ReadModuleCurve(slotId, moduleId, curveId, buffer)).Should().Throw<SunVoxException>();

        // then
        library.Received(1).sv_module_curve(slotId, moduleId, curveId, Arg.Any<IntPtr>(), buffer.Length, 0);
    }

    [Test, AutoData]
    public void ReadModuleScopeShouldCallExpectedMethod(int moduleId, int slotId, short[] buffer, uint readSamples, AudioChannel channel)
    {
        var receivedBuffer = Array.Empty<short>();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_module_scope2(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>(), Arg.Any<uint>())
            .Returns(readSamples);

        library.When(static l =>
                l.sv_get_module_scope2(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>(),
                    Arg.Any<uint>()))
            .Do(callInfo =>
            {
                receivedBuffer = new short[callInfo.Arg<uint>()];
                Marshal.Copy(callInfo.Arg<IntPtr>(), receivedBuffer, 0, (int)callInfo.Arg<uint>());
            });

        // when
        var value = wrapper.ReadModuleScope(slotId, moduleId, channel, buffer);

        // then
        library.Received(1)
            .sv_get_module_scope2(slotId, moduleId, (int)channel, Arg.Any<IntPtr>(), (uint)buffer.Length);
        value.Should().Be((int)readSamples);
        receivedBuffer.Should().BeEquivalentTo(buffer);
    }

    [Test, AutoData]
    public void RemoveModuleShouldCallExpectedMethod(int slotId, int moduleId)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_remove_module(Arg.Any<int>(), Arg.Any<int>()).Returns(0);

        // when
        wrapper.RemoveModule(slotId, moduleId);

        // then
        library.Received(1).sv_remove_module(slotId, moduleId);
    }

    [Test, AutoData]
    public void RemoveModuleShouldCallExpectedMethodAndThrowOnNonZeroReturnCode(int slotId, int moduleId)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_remove_module(Arg.Any<int>(), Arg.Any<int>()).Returns(-1);

        // when
        wrapper.Invoking(w => w.RemoveModule(slotId, moduleId)).Should().Throw<SunVoxException>();

        // then
        library.Received(1).sv_remove_module(slotId, moduleId);
    }

    [Test, AutoData]
    public void SetModuleColorShouldCallExpectedMethod(byte r, byte g, byte b, int moduleId, int slotId)
    {
        var code = r | (g << 8) | (b << 16);

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_module_color(Arg.Any<int>(), Arg.Any<int>()).Returns(code);

        // when
        wrapper.SetModuleColor(slotId, moduleId, r, g, b);

        // then
        library.Received(1).sv_set_module_color(slotId, moduleId, code);
    }

    [Test, AutoData]
    public void SetModuleColorShouldThrowOnNonZeroReturnCode(byte r, byte g, byte b, int moduleId, int slotId)
    {
        var code = r | (g << 8) | (b << 16);

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_set_module_color(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()).Returns(-1);

        // when
        wrapper.Invoking(w => w.SetModuleColor(slotId, moduleId, r, g, b)).Should().Throw<SunVoxException>();

        // then
        library.Received(1).sv_set_module_color(slotId, moduleId, code);
    }

    [Test, AutoData]
    public void SetModuleControllerValueShouldCallExpectedMethod(int slotId, int moduleId, int controllerId, int valueToSet, ValueScalingMode scalingMode)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_set_module_ctl_value(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>())
            .Returns(0);

        // when
        wrapper.SetModuleControllerValue(slotId, moduleId, controllerId, valueToSet, scalingMode);

        // then
        library.Received(1).sv_set_module_ctl_value(slotId, moduleId, controllerId, valueToSet, (int)scalingMode);
    }

    [Test, AutoData]
    public void SetModuleControllerValueShouldCallExpectedMethodAndThrowOnNonZeroCode(int slotId, int moduleId, int controllerId, int valueToSet, ValueScalingMode scalingMode)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_set_module_ctl_value(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>())
            .Returns(-1);

        // when - then
        wrapper.Invoking(w => w.SetModuleControllerValue(slotId, moduleId, controllerId, valueToSet, scalingMode)).Should().Throw<SunVoxException>();

        // then
        library.Received(1).sv_set_module_ctl_value(slotId, moduleId, controllerId, valueToSet, (int)scalingMode);
    }

    [Test, AutoData]
    public void SetModuleFineTuneShouldCallExpectedMethod(int slotId, int moduleId, int fineTune)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_set_module_finetune(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()).Returns(0);

        // when
        wrapper.SetModuleFineTune(slotId, moduleId, fineTune);

        // then
        library.Received(1).sv_set_module_finetune(slotId, moduleId, fineTune);
    }

    [Test, AutoData]
    public void SetModuleFineTuneShouldCallExpectedMethodAndThrowOnNonZeroReturnCode(int slotId, int moduleId, int fineTune)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_set_module_finetune(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()).Returns(-1);

        // when
        wrapper.Invoking(w => w.SetModuleFineTune(slotId, moduleId, fineTune)).Should().Throw<SunVoxException>();

        // then
        library.Received(1).sv_set_module_finetune(slotId, moduleId, fineTune);
    }

    [Test, AutoData]
    public void SetModuleNameShouldCallExpectedMethod(int slotId, int moduleId, string nameToSet)
    {
        var receivedString = string.Empty;

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.When(static l => l.sv_set_module_name(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>()))
            .Do(callInfo => receivedString = Marshal.PtrToStringAnsi(callInfo.Arg<IntPtr>()));

        // when
        wrapper.SetModuleName(slotId, moduleId, nameToSet);

        // then
        library.Received(1).sv_set_module_name(slotId, moduleId, Arg.Any<IntPtr>());
        receivedString.Should().Be(nameToSet);
    }

    [Test, AutoData]
    public void SetModuleNameShouldCallExpectedMethodAndThrowOnNonZeroReturnCode(int slotId, int moduleId, string nameToSet)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_set_module_name(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>()).Returns(-1);

        // when
        wrapper.Invoking(w => w.SetModuleName(slotId, moduleId, nameToSet)).Should().Throw<SunVoxException>();

        // then
        library.Received(1).sv_set_module_name(slotId, moduleId, Arg.Any<IntPtr>());
    }

    [Test, AutoData]
    public void SetModulePositionShouldCallExpectedMethod(int moduleId, int slotId, short x, short y)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);

        // when
        wrapper.SetModulePosition(slotId, moduleId, x, y);

        // then
        library.Received(1).sv_set_module_xy(slotId, moduleId, x, y);
    }

    [Test, AutoData]
    public void SetModulePositionShouldCallExpectedMethodAndThrowOnNonZeroReturnCode(int moduleId, int slotId, short x, short y)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_set_module_xy(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()).Returns(-1);

        // when
        wrapper.Invoking(w => w.SetModulePosition(slotId, moduleId, x, y)).Should().Throw<SunVoxException>();

        // then
        library.Received(1).sv_set_module_xy(slotId, moduleId, x, y);
    }

    [Test, AutoData]
    public void SetModuleRelativeNoteShouldCallExpectedMethod(int slotId, int moduleId, int fineTune)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_set_module_relnote(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()).Returns(0);

        // when
        wrapper.SetModuleRelativeNote(slotId, moduleId, fineTune);

        // then
        library.Received(1).sv_set_module_relnote(slotId, moduleId, fineTune);
    }

    [Test, AutoData]
    public void SetModuleRelativeNoteShouldCallExpectedMethodAndThrowOnNonZeroReturnCode(int slotId, int moduleId, int fineTune)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_set_module_relnote(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()).Returns(-1);

        // when
        wrapper.Invoking(w => w.SetModuleRelativeNote(slotId, moduleId, fineTune)).Should().Throw<SunVoxException>();

        // then
        library.Received(1).sv_set_module_relnote(slotId, moduleId, fineTune);
    }

    [Test, AutoData]
    public void WriteModuleCurveShouldCallExpectedMethod(int slotId, int moduleId, int curveId, float[] buffer)
    {
        var samplesWritten = buffer.Length;

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_module_curve(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>(), Arg.Any<int>(),
            Arg.Any<int>()).Returns(samplesWritten);
        library.When(static l => l.sv_module_curve(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>(),
                Arg.Any<int>(), Arg.Any<int>()))
            .Do(callInfo =>
            {
                var receivedBuffer = new int[callInfo.ArgAt<int>(4)];
                Marshal.Copy(callInfo.Arg<IntPtr>(), receivedBuffer, 0, callInfo.ArgAt<int>(4));
            });

        // when
        var value = wrapper.WriteModuleCurve(slotId, moduleId, curveId, buffer);
        library.Received(1).sv_module_curve(slotId, moduleId, curveId, Arg.Any<IntPtr>(), buffer.Length, 1);
        value.Should().Be(samplesWritten);
    }

    [Test, AutoData]
    public void WriteModuleCurveShouldThrowOnNonZeroReturnCode(int slotId, int moduleId, int curveId, float[] buffer)
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_module_curve(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>(), Arg.Any<int>(),
            Arg.Any<int>()).Returns(-1);

        // when
        wrapper.Invoking(w => w.WriteModuleCurve(slotId, moduleId, curveId, buffer)).Should().Throw<SunVoxException>();

        // then
        library.Received(1).sv_module_curve(slotId, moduleId, curveId, Arg.Any<IntPtr>(), buffer.Length, 1);
    }
}
