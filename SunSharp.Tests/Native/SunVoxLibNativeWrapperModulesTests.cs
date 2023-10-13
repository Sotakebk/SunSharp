using System;
using System.Runtime.InteropServices;
using NSubstitute;
using NUnit.Framework;
using SunSharp.Native;
using TddXt.AnyRoot.Collections;
using TddXt.AnyRoot.Numbers;
using TddXt.AnyRoot.Strings;
using static TddXt.AnyRoot.Root;

namespace SunSharp.Tests.Native;

public class SunVoxLibNativeWrapperModulesTests
{
    public static TestCaseData[] ModuleInputOutputAndResult => new TestCaseData[]
    {
        new(new[] { -1 }, Array.Empty<int>()),
        new(new[] { 0 }, new[] { 0 }),
        new(new[] { -1, 0, 1, 2 }, new[] { 0, 1, 2 }),
        new(new[] { -1, -1, 1, -1, 2, -1, -1, 3 }, new[] { 1, 2, 3 })
    };

    [Test]
    public void ConnectModuleShouldCallExpectedMethod()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_connect_module(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()).Returns(0);
        var slotId = Any.Integer();
        var source = Any.Integer();
        var destination = Any.Integer();

        // when
        wrapper.ConnectModule(slotId, source, destination);

        // then
        library.Received(1).sv_connect_module(slotId, source, destination);
    }

    [Test]
    public void ConnectModuleShouldThrowOnNonZeroReturnCode()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_connect_module(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()).Returns(-1);
        var slotId = Any.Integer();
        var source = Any.Integer();
        var destination = Any.Integer();

        // when - then
        Assert.That(() => wrapper.ConnectModule(slotId, source, destination),
            Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1).sv_connect_module(slotId, source, destination);
    }

    [Test]
    public void CreateModuleShouldCallExpectedMethod()
    {
        var newModuleId = Any.Integer();
        var moduleName = Any.String();
        var moduleType = Any.String();
        var slotId = Any.Integer();
        var x = Any.Integer();
        var y = Any.Integer();
        var z = Any.Integer();
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

        // then
        library.Received(1).sv_new_module(slotId, Arg.Any<IntPtr>(), Arg.Any<IntPtr>(), x, y, z);
        Assert.Multiple(() =>
        {
            Assert.That(value, Is.EqualTo(newModuleId));
            Assert.That(receivedModuleName, Is.EqualTo(moduleName));
            Assert.That(receivedModuleType, Is.EqualTo(moduleType));
        });
    }

    [Test]
    public void CreateModuleShouldThrowOnNegativeReturnedValue()
    {
        var moduleName = Any.String();
        var moduleType = Any.String();
        var slotId = Any.Integer();
        var x = Any.Integer();
        var y = Any.Integer();
        var z = Any.Integer();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_new_module(Arg.Any<int>(), Arg.Any<IntPtr>(), Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(),
            Arg.Any<int>()).Returns(-1);

        // when
        Assert.That(() => wrapper.CreateModule(slotId, moduleType, moduleName, x, y, z),
            Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1).sv_new_module(slotId, Arg.Any<IntPtr>(), Arg.Any<IntPtr>(), x, y, z);
    }

    [Test]
    public void DisconnectModuleShouldCallExpectedMethod()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_disconnect_module(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()).Returns(0);
        var slotId = Any.Integer();
        var source = Any.Integer();
        var destination = Any.Integer();

        // when
        wrapper.DisconnectModule(slotId, source, destination);

        // then
        library.Received(1).sv_disconnect_module(slotId, source, destination);
    }

    [Test]
    public void DisconnectModuleShouldThrowOnNonZeroReturnCode()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_disconnect_module(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()).Returns(-1);
        var slotId = Any.Integer();
        var source = Any.Integer();
        var destination = Any.Integer();

        // when - then
        Assert.That(() => wrapper.DisconnectModule(slotId, source, destination),
            Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1).sv_disconnect_module(slotId, source, destination);
    }

    [Test]
    public void FindModuleShouldCallExpectedMethod()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var foundModuleId = Any.Integer();
        library.sv_find_module(Arg.Any<int>(), Arg.Any<IntPtr>()).Returns(foundModuleId);
        var moduleName = Any.String();
        var receivedString = string.Empty;
        var slotId = Any.Integer();
        library.When(static l => l.sv_find_module(Arg.Any<int>(), Arg.Any<IntPtr>()))
            .Do(callInfo => receivedString = Marshal.PtrToStringAnsi(callInfo.Arg<IntPtr>()));

        // when
        var value = wrapper.FindModule(slotId, moduleName);

        // then
        library.Received(1).sv_find_module(slotId, Arg.Any<IntPtr>());
        Assert.Multiple(() =>
        {
            Assert.That(value, Is.EqualTo(foundModuleId));
            Assert.That(receivedString, Is.EqualTo(moduleName));
        });
    }

    [Test]
    public void FindModuleShouldCallExpectedMethodAndReturnNullWhenModuleNotFound()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_find_module(Arg.Any<int>(), Arg.Any<IntPtr>()).Returns(-1);
        var moduleName = Any.String();
        var receivedString = string.Empty;
        var slotId = Any.Integer();
        library.When(static l => l.sv_find_module(Arg.Any<int>(), Arg.Any<IntPtr>()))
            .Do(callInfo => receivedString = Marshal.PtrToStringAnsi(callInfo.Arg<IntPtr>()));

        // when
        var value = wrapper.FindModule(slotId, moduleName);

        // then
        library.Received(1).sv_find_module(slotId, Arg.Any<IntPtr>());
        Assert.Multiple(() =>
        {
            Assert.That(value, Is.EqualTo(null));
            Assert.That(receivedString, Is.EqualTo(moduleName));
        });
    }

    [Test]
    public void FindModuleShouldThrowOnUnexpectedValue()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_find_module(Arg.Any<int>(), Arg.Any<IntPtr>()).Returns(-2);
        var moduleName = Any.String();
        var slotId = Any.Integer();

        // when
        Assert.That(() => wrapper.FindModule(slotId, moduleName), Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1).sv_find_module(slotId, Arg.Any<IntPtr>());
    }

    [Test]
    public void GetModuleColorShouldCallExpectedMethodAndReturnValue()
    {
        var r = Any.Byte();
        var g = Any.Byte();
        var b = Any.Byte();
        var code = r | (g << 8) | (b << 16);

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_module_color(Arg.Any<int>(), Arg.Any<int>()).Returns(code);
        var moduleId = Any.Integer();
        var slotId = Any.Integer();

        // when
        var value = wrapper.GetModuleColor(slotId, moduleId);

        // then
        library.Received(1).sv_get_module_color(slotId, moduleId);
        Assert.Multiple(() => { Assert.That(value, Is.EqualTo((r, g, b))); });
    }

    [Test]
    public void GetModuleControllerCountShouldCallExpectedMethod()
    {
        var slotId = Any.Integer();
        var moduleId = Any.Integer();
        var moduleCount = Any.Integer();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_number_of_module_ctls(Arg.Any<int>(), Arg.Any<int>()).Returns(moduleCount);

        // when
        var value = wrapper.GetModuleControllerCount(slotId, moduleId);

        // then
        library.Received(1).sv_get_number_of_module_ctls(slotId, moduleId);
        Assert.That(value, Is.EqualTo(moduleCount));
    }

    [Test]
    public void GetModuleControllerCountShouldCallExpectedMethodAndThrowOnNegativeValue()
    {
        var slotId = Any.Integer();
        var moduleId = Any.Integer();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_number_of_module_ctls(Arg.Any<int>(), Arg.Any<int>()).Returns(-1);

        // when
        Assert.That(() => wrapper.GetModuleControllerCount(slotId, moduleId),
            Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1).sv_get_number_of_module_ctls(slotId, moduleId);
    }

    [Test]
    public void GetModuleControllerGroupShouldCallExpectedMethodAndReturnValue()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var moduleId = Any.Integer();
        var controllerId = Any.Integer();
        var slotId = Any.Integer();
        var returnedValue = Any.Integer();
        library.sv_get_module_ctl_group(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()).Returns(returnedValue);

        // when
        var value = wrapper.GetModuleControllerGroup(slotId, moduleId, controllerId);

        // then
        library.Received(1).sv_get_module_ctl_group(slotId, moduleId, controllerId);
        Assert.That(value, Is.EqualTo(returnedValue));
    }

    [Test]
    public void GetModuleControllerMaxValueShouldCallExpectedMethodAndReturnValue()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var moduleId = Any.Integer();
        var controllerId = Any.Integer();
        var slotId = Any.Integer();
        var returnedValue = Any.Integer();
        var scalingMode = Any.Instance<ValueScalingMode>();
        library.sv_get_module_ctl_max(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>())
            .Returns(returnedValue);

        // when
        var value = wrapper.GetModuleControllerMaxValue(slotId, moduleId, controllerId, scalingMode);

        // then
        library.Received(1).sv_get_module_ctl_max(slotId, moduleId, controllerId, (int)scalingMode);
        Assert.That(value, Is.EqualTo(returnedValue));
    }

    [Test]
    public void GetModuleControllerMinValueShouldCallExpectedMethodAndReturnValue()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var moduleId = Any.Integer();
        var controllerId = Any.Integer();
        var slotId = Any.Integer();
        var returnedValue = Any.Integer();
        var scalingMode = Any.Instance<ValueScalingMode>();
        library.sv_get_module_ctl_min(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>())
            .Returns(returnedValue);

        // when
        var value = wrapper.GetModuleControllerMinValue(slotId, moduleId, controllerId, scalingMode);

        // then
        library.Received(1).sv_get_module_ctl_min(slotId, moduleId, controllerId, (int)scalingMode);
        Assert.That(value, Is.EqualTo(returnedValue));
    }

    [Test]
    public void GetModuleControllerNameShouldCallExpectedMethodAndReturnNull()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var moduleId = Any.Integer();
        var controllerId = Any.Integer();
        var slotId = Any.Integer();
        library.sv_get_module_ctl_name(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()).Returns(IntPtr.Zero);

        // when
        var receivedControllerName = wrapper.GetModuleControllerName(slotId, moduleId, controllerId);

        // then
        library.Received(1).sv_get_module_ctl_name(slotId, moduleId, controllerId);
        Assert.That(receivedControllerName, Is.EqualTo(null));
    }

    [Test]
    public void GetModuleControllerNameShouldCallExpectedMethodAndReturnString()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var controllerName = Any.String();
        var moduleId = Any.Integer();
        var controllerId = Any.Integer();
        var slotId = Any.Integer();
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
        Assert.That(receivedControllerName, Is.EqualTo(controllerName));
    }

    [Test]
    public void GetModuleControllerOffsetShouldCallExpectedMethodAndReturnValue()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var moduleId = Any.Integer();
        var controllerId = Any.Integer();
        var slotId = Any.Integer();
        var returnedValue = Any.Integer();
        library.sv_get_module_ctl_offset(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()).Returns(returnedValue);

        // when
        var value = wrapper.GetModuleControllerOffset(slotId, moduleId, controllerId);

        // then
        library.Received(1).sv_get_module_ctl_offset(slotId, moduleId, controllerId);
        Assert.That(value, Is.EqualTo(returnedValue));
    }

    [Test]
    public void GetModuleControllerTypeShouldCallExpectedMethodAndReturnValue()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var moduleId = Any.Integer();
        var controllerId = Any.Integer();
        var slotId = Any.Integer();
        var returnedValue = Any.Instance<ControllerType>();
        library.sv_get_module_ctl_type(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()).Returns((int)returnedValue);

        // when
        var value = wrapper.GetModuleControllerType(slotId, moduleId, controllerId);

        // then
        library.Received(1).sv_get_module_ctl_type(slotId, moduleId, controllerId);
        Assert.That(value, Is.EqualTo(returnedValue));
    }

    [Test]
    public void GetModuleControllerTypeShouldCallExpectedMethodAndThrowOnUnexpectedValue()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var moduleId = Any.Integer();
        var controllerId = Any.Integer();
        var slotId = Any.Integer();
        library.sv_get_module_ctl_type(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()).Returns(-1);

        // when
        Assert.That(() => wrapper.GetModuleControllerType(slotId, moduleId, controllerId),
            Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1).sv_get_module_ctl_type(slotId, moduleId, controllerId);
    }

    [Test]
    public void GetModuleControllerValueShouldCallExpectedMethodAndReturnValue()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var moduleId = Any.Integer();
        var controllerId = Any.Integer();
        var slotId = Any.Integer();
        var returnedValue = Any.Integer();
        var scalingMode = Any.Instance<ValueScalingMode>();
        library.sv_get_module_ctl_value(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>())
            .Returns(returnedValue);

        // when
        var value = wrapper.GetModuleControllerValue(slotId, moduleId, controllerId, scalingMode);

        // then
        library.Received(1).sv_get_module_ctl_value(slotId, moduleId, controllerId, (int)scalingMode);
        Assert.That(value, Is.EqualTo(returnedValue));
    }

    [TestCase(true)]
    [TestCase(false)]
    public void GetModuleExistsShouldCallExpectedMethodAndReturnValue(bool exists)
    {
        var flagsValue = (uint)(ModuleFlags.SV_MODULE_FLAG_EXISTS * (exists ? 1 : 0));
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var moduleId = Any.Integer();
        var slotId = Any.Integer();
        library.sv_get_module_flags(Arg.Any<int>(), Arg.Any<int>()).Returns(flagsValue);

        // when
        var receivedExists = wrapper.GetModuleExists(slotId, moduleId);

        // then
        library.Received(1).sv_get_module_flags(slotId, moduleId);
        Assert.That(receivedExists, Is.EqualTo(exists));
    }

    [Test]
    public void GetModuleFineTuneShouldCallExpectedMethodAndReturnValue()
    {
        var moduleFineTune = Any.Instance<FineTunePair>();
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var moduleId = Any.Integer();
        var slotId = Any.Integer();
        library.sv_get_module_finetune(Arg.Any<int>(), Arg.Any<int>()).Returns(moduleFineTune.Value);

        // when
        var receivedFineTune = wrapper.GetModuleFineTune(slotId, moduleId);

        // then
        library.Received(1).sv_get_module_finetune(slotId, moduleId);
        Assert.That(receivedFineTune, Is.EqualTo(moduleFineTune));
    }

    [Test]
    public void GetModuleFlagsShouldCallExpectedMethodAndReturnValue()
    {
        var flagsValue = Any.UnsignedInt();
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var moduleId = Any.Integer();
        var slotId = Any.Integer();
        library.sv_get_module_flags(Arg.Any<int>(), Arg.Any<int>()).Returns(flagsValue);

        // when
        var flags = wrapper.GetModuleFlags(slotId, moduleId);

        // then
        library.Received(1).sv_get_module_flags(slotId, moduleId);
        Assert.That(flags, Is.EqualTo((ModuleFlags)flagsValue));
    }

    [TestCaseSource(nameof(ModuleInputOutputAndResult))]
    public void GetModuleInputsShouldCallExpectedMethodsAndReturnValue(int[] nativeData, int[] expectedOutput)
    {
        var flagsValue = (uint)((nativeData.Length << ModuleFlags.SV_MODULE_INPUTS_OFF) |
                                ModuleFlags.SV_MODULE_FLAG_EXISTS);
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var moduleId = Any.Integer();
        var slotId = Any.Integer();
        library.sv_get_module_flags(Arg.Any<int>(), Arg.Any<int>()).Returns(flagsValue);

        // assumes that GetModuleInputs frees this memory
        var ptr = Marshal.AllocHGlobal(sizeof(int) * nativeData.Length);
        Marshal.Copy(nativeData, 0, ptr, nativeData.Length);
        library.sv_get_module_inputs(Arg.Any<int>(), Arg.Any<int>()).Returns(ptr);

        // when
        var receivedInputs = wrapper.GetModuleInputs(slotId, moduleId);

        // then
        library.Received(1).sv_get_module_flags(slotId, moduleId);
        library.Received(1).sv_get_module_inputs(slotId, moduleId);
        Assert.That(receivedInputs, Is.EquivalentTo(expectedOutput));
    }

    [Test]
    public void GetModuleInputsShouldSkipCallsIfDoesNotExist()
    {
        const uint flagsValue = 0u;
        Assert.That(new ModuleFlags(flagsValue).Exists, Is.False);

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var moduleId = Any.Integer();
        var slotId = Any.Integer();
        library.sv_get_module_flags(Arg.Any<int>(), Arg.Any<int>()).Returns(flagsValue);

        // when
        var receivedInputs = wrapper.GetModuleInputs(slotId, moduleId);

        // then
        library.Received(1).sv_get_module_flags(slotId, moduleId);
        library.Received(0).sv_get_module_inputs(slotId, moduleId);
        Assert.That(receivedInputs, Is.EquivalentTo(Array.Empty<int>()));
    }

    [Test]
    public void GetModuleInputsShouldSkipCallsIfZeroInputs()
    {
        const uint flagsValue = ModuleFlags.SV_MODULE_FLAG_EXISTS;
        Assert.That(new ModuleFlags(flagsValue).InputUpperCount, Is.EqualTo(0));

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var moduleId = Any.Integer();
        var slotId = Any.Integer();
        library.sv_get_module_flags(Arg.Any<int>(), Arg.Any<int>()).Returns(flagsValue);

        // when
        var receivedInputs = wrapper.GetModuleInputs(slotId, moduleId);

        // then
        library.Received(1).sv_get_module_flags(slotId, moduleId);
        library.Received(0).sv_get_module_inputs(slotId, moduleId);
        Assert.That(receivedInputs, Is.EquivalentTo(Array.Empty<int>()));
    }

    [Test]
    public void GetModuleNameShouldCallExpectedMethodAndReturnNullWhenNullPointer()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var moduleId = Any.Integer();
        var slotId = Any.Integer();
        library.sv_get_module_name(Arg.Any<int>(), Arg.Any<int>()).Returns(IntPtr.Zero);

        // when
        var receivedModuleName = wrapper.GetModuleName(slotId, moduleId);
        // then
        library.Received(1).sv_get_module_name(slotId, moduleId);
        Assert.That(receivedModuleName, Is.EqualTo(null));
    }

    [Test]
    public void GetModuleNameShouldCallExpectedMethodAndReturnString()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var moduleName = Any.String();
        var moduleId = Any.Integer();
        var slotId = Any.Integer();
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
        Assert.That(receivedModuleName, Is.EqualTo(moduleName));
    }

    [TestCaseSource(nameof(ModuleInputOutputAndResult))]
    public void GetModuleOutputsShouldCallExpectedMethodsAndReturnValue(int[] nativeData, int[] expectedOutput)
    {
        var flagsValue = (uint)((nativeData.Length << ModuleFlags.SV_MODULE_OUTPUTS_OFF) |
                                ModuleFlags.SV_MODULE_FLAG_EXISTS);
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var moduleId = Any.Integer();
        var slotId = Any.Integer();
        library.sv_get_module_flags(Arg.Any<int>(), Arg.Any<int>()).Returns(flagsValue);

        // assumes that GetModuleOutputs frees this memory
        var ptr = Marshal.AllocHGlobal(sizeof(int) * nativeData.Length);
        Marshal.Copy(nativeData, 0, ptr, nativeData.Length);
        library.sv_get_module_outputs(Arg.Any<int>(), Arg.Any<int>()).Returns(ptr);

        // when
        var receivedOutputs = wrapper.GetModuleOutputs(slotId, moduleId);

        // then
        library.Received(1).sv_get_module_flags(slotId, moduleId);
        library.Received(1).sv_get_module_outputs(slotId, moduleId);
        Assert.That(receivedOutputs, Is.EquivalentTo(expectedOutput));
    }

    [Test]
    public void GetModuleOutputsShouldSkipCallsIfDoesNotExist()
    {
        const uint flagsValue = 0u;
        Assert.That(new ModuleFlags(flagsValue).Exists, Is.False);

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var moduleId = Any.Integer();
        var slotId = Any.Integer();
        library.sv_get_module_flags(Arg.Any<int>(), Arg.Any<int>()).Returns(flagsValue);

        // when
        var receivedOutputs = wrapper.GetModuleOutputs(slotId, moduleId);

        // then
        library.Received(1).sv_get_module_flags(slotId, moduleId);
        library.Received(0).sv_get_module_outputs(slotId, moduleId);
        Assert.That(receivedOutputs, Is.EquivalentTo(Array.Empty<int>()));
    }

    [Test]
    public void GetModuleOutputsShouldSkipCallsIfZeroOutputs()
    {
        const uint flagsValue = ModuleFlags.SV_MODULE_FLAG_EXISTS;
        Assert.That(new ModuleFlags(flagsValue).InputUpperCount, Is.EqualTo(0));

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var moduleId = Any.Integer();
        var slotId = Any.Integer();
        library.sv_get_module_flags(Arg.Any<int>(), Arg.Any<int>()).Returns(flagsValue);

        // when
        var receivedOutputs = wrapper.GetModuleOutputs(slotId, moduleId);

        // then
        library.Received(1).sv_get_module_flags(slotId, moduleId);
        library.Received(0).sv_get_module_outputs(slotId, moduleId);
        Assert.That(receivedOutputs, Is.EquivalentTo(Array.Empty<int>()));
    }

    [Test]
    public void GetModulePositionShouldCallExpectedMethodAndReturnValue()
    {
        var moduleId = Any.Integer();
        var slotId = Any.Integer();
        var x = Any.Short();
        var y = Any.Short();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_module_xy(Arg.Any<int>(), Arg.Any<int>()).Returns(Helper.PackTwoSignedShorts(x, y));
        // when
        var value = wrapper.GetModulePosition(slotId, moduleId);

        // then
        library.Received(1).sv_get_module_xy(slotId, moduleId);
        Assert.That(value, Is.EqualTo((x, y)));
    }

    [Test]
    public void GetModuleTypeShouldCallExpectedMethodAndReturnNullWhenNullPointer()
    {
        var moduleId = Any.Integer();
        var slotId = Any.Integer();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_module_type(Arg.Any<int>(), Arg.Any<int>()).Returns(IntPtr.Zero);

        // when
        var receivedModuleName = wrapper.GetModuleType(slotId, moduleId);
        // then
        library.Received(1).sv_get_module_type(slotId, moduleId);
        Assert.That(receivedModuleName, Is.EqualTo(null));
    }

    [Test]
    public void GetModuleTypeShouldCallExpectedMethodAndReturnString()
    {
        var moduleType = Any.String();
        var moduleId = Any.Integer();
        var slotId = Any.Integer();
        var stringPointer = IntPtr.Zero;
        string? receivedModuleType;

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);

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
        Assert.That(receivedModuleType, Is.EqualTo(moduleType));
    }

    [Test]
    public void GetUpperModuleCountShouldCallExpectedMethod()
    {
        var slotId = Any.Integer();
        var moduleCount = Any.Integer();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_number_of_modules(Arg.Any<int>()).Returns(moduleCount);

        // when
        var value = wrapper.GetUpperModuleCount(slotId);

        // then
        library.Received(1).sv_get_number_of_modules(slotId);
        Assert.That(value, Is.EqualTo(moduleCount));
    }

    [Test]
    public void GetUpperModuleCountShouldCallExpectedMethodAndThrowOnNegativeValue()
    {
        var slotId = Any.Integer();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_number_of_modules(Arg.Any<int>()).Returns(-1);

        // when
        Assert.That(() => wrapper.GetUpperModuleCount(slotId), Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1).sv_get_number_of_modules(slotId);
    }

    [Test]
    public void LoadIntoMetaModuleFromMemoryShouldCallExpectedMethod()
    {
        var slotId = Any.Integer();
        var moduleId = Any.Integer();
        var buffer = Any.Array<byte>();
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
        Assert.That(receivedBuffer, Is.EqualTo(buffer));
    }

    [Test]
    public void LoadIntoMetaModuleFromMemoryShouldThrowOnNonZeroReturnCode()
    {
        var slotId = Any.Integer();
        var moduleId = Any.Integer();
        var buffer = Any.Array<byte>();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_metamodule_load_from_memory(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>(), Arg.Any<uint>())
            .Returns(-1);

        // when
        Assert.That(() => wrapper.LoadIntoMetaModule(slotId, moduleId, buffer),
            Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1).sv_metamodule_load_from_memory(slotId, moduleId, Arg.Any<IntPtr>(), (uint)buffer.Length);
    }

    [Test]
    public void LoadIntoMetaModuleShouldCallExpectedMethod()
    {
        var path = Any.String();
        var slotId = Any.Integer();
        var moduleId = Any.Integer();
        var receivedString = string.Empty;

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.When(static l => l.sv_metamodule_load(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>()))
            .Do(callInfo => receivedString = Marshal.PtrToStringAnsi(callInfo.Arg<IntPtr>()));

        // when
        wrapper.LoadIntoMetaModule(slotId, moduleId, path);

        // then
        library.Received(1).sv_metamodule_load(slotId, moduleId, Arg.Any<IntPtr>());
        Assert.That(receivedString, Is.EqualTo(path));
    }

    [Test]
    public void LoadIntoMetaModuleShouldCallExpectedMethodAndThrowOnNonZeroReturnCode()
    {
        var path = Any.String();
        var slotId = Any.Integer();
        var moduleId = Any.Integer();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_metamodule_load(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>()).Returns(-1);

        // when
        Assert.That(() => wrapper.LoadIntoMetaModule(slotId, moduleId, path),
            Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1).sv_metamodule_load(slotId, moduleId, Arg.Any<IntPtr>());
    }

    [Test]
    public void LoadIntoVorbisPLayerFromMemoryShouldCallExpectedMethod()
    {
        var slotId = Any.Integer();
        var moduleId = Any.Integer();
        var buffer = Any.Array<byte>();
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
        Assert.That(receivedBuffer, Is.EqualTo(buffer));
    }

    [Test]
    public void LoadIntoVorbisPLayerFromMemoryShouldThrowOnNonZeroReturnCode()
    {
        var slotId = Any.Integer();
        var moduleId = Any.Integer();
        var buffer = Any.Array<byte>();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_vplayer_load_from_memory(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>(), Arg.Any<uint>())
            .Returns(-1);

        // when
        Assert.That(() => wrapper.LoadIntoVorbisPLayer(slotId, moduleId, buffer),
            Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1).sv_vplayer_load_from_memory(slotId, moduleId, Arg.Any<IntPtr>(), (uint)buffer.Length);
    }

    [Test]
    public void LoadIntoVorbisPLayerShouldCallExpectedMethod()
    {
        var path = Any.String();
        var slotId = Any.Integer();
        var moduleId = Any.Integer();
        var receivedString = string.Empty;

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.When(static l => l.sv_vplayer_load(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>()))
            .Do(callInfo => receivedString = Marshal.PtrToStringAnsi(callInfo.Arg<IntPtr>()));

        // when
        wrapper.LoadIntoVorbisPLayer(slotId, moduleId, path);

        // then
        library.Received(1).sv_vplayer_load(slotId, moduleId, Arg.Any<IntPtr>());
        Assert.That(receivedString, Is.EqualTo(path));
    }

    [Test]
    public void LoadIntoVorbisPLayerShouldCallExpectedMethodAndThrowOnNonZeroReturnCode()
    {
        var path = Any.String();
        var slotId = Any.Integer();
        var moduleId = Any.Integer();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_vplayer_load(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>()).Returns(-1);

        // when
        Assert.That(() => wrapper.LoadIntoVorbisPLayer(slotId, moduleId, path),
            Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1).sv_vplayer_load(slotId, moduleId, Arg.Any<IntPtr>());
    }

    [Test]
    public void LoadModuleFromMemoryShouldCallExpectedMethod()
    {
        var x = Any.Integer();
        var y = Any.Integer();
        var z = Any.Integer();
        var slotId = Any.Integer();
        var newModuleId = Any.Integer();
        var buffer = Any.Array<byte>();
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

        // then
        library.Received(1).sv_load_module_from_memory(slotId, Arg.Any<IntPtr>(), (uint)buffer.Length, x, y, z);
        Assert.Multiple(() =>
        {
            Assert.That(value, Is.EqualTo(newModuleId));
            Assert.That(receivedBuffer, Is.EqualTo(buffer));
        });
    }

    [Test]
    public void LoadModuleFromMemoryShouldThrowOnNonZeroReturnCode()
    {
        var x = Any.Integer();
        var y = Any.Integer();
        var z = Any.Integer();
        var slotId = Any.Integer();
        var buffer = Any.Array<byte>();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_load_module_from_memory(Arg.Any<int>(), Arg.Any<IntPtr>(), Arg.Any<uint>(), Arg.Any<int>(),
            Arg.Any<int>(), Arg.Any<int>()).Returns(-1);

        // when
        Assert.That(() => wrapper.LoadModule(slotId, buffer, x, y, z), Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1).sv_load_module_from_memory(slotId, Arg.Any<IntPtr>(), (uint)buffer.Length, x, y, z);
    }

    [Test]
    public void LoadModuleShouldCallExpectedMethod()
    {
        var x = Any.Integer();
        var y = Any.Integer();
        var z = Any.Integer();
        var slotId = Any.Integer();
        var newModuleId = Any.Integer();
        var path = Any.String();
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

        // then
        library.Received(1).sv_load_module(slotId, Arg.Any<IntPtr>(), x, y, z);
        Assert.Multiple(() =>
        {
            Assert.That(value, Is.EqualTo(newModuleId));
            Assert.That(receivedString, Is.EqualTo(path));
        });
    }

    [Test]
    public void LoadModuleShouldThrowOnNonZeroReturnCode()
    {
        var x = Any.Integer();
        var y = Any.Integer();
        var z = Any.Integer();
        var slotId = Any.Integer();
        var path = Any.String();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_load_module(Arg.Any<int>(), Arg.Any<IntPtr>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>())
            .Returns(-1);

        // when
        Assert.That(() => wrapper.LoadModule(slotId, path, x, y, z), Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1).sv_load_module(slotId, Arg.Any<IntPtr>(), x, y, z);
    }

    [Test]
    public void LoadSamplerSampleFromMemoryShouldCallExpectedMethod()
    {
        var slotId = Any.Integer();
        var moduleId = Any.Integer();
        var sampleSlot = Any.Integer();
        var buffer = Any.Array<byte>();
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

        // then
        library.Received(1)
            .sv_sampler_load_from_memory(slotId, moduleId, Arg.Any<IntPtr>(), (uint)buffer.Length, sampleSlot);
        Assert.That(receivedBuffer, Is.EqualTo(buffer));
    }

    [Test]
    public void LoadSamplerSampleFromMemoryShouldThrowOnNonZeroReturnCode()
    {
        var slotId = Any.Integer();
        var moduleId = Any.Integer();
        var sampleSlot = Any.Integer();
        var buffer = Any.Array<byte>();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_sampler_load_from_memory(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>(), Arg.Any<uint>(),
                Arg.Any<int>())
            .Returns(-1);

        // when
        Assert.That(() => wrapper.LoadSamplerSample(slotId, moduleId, buffer, sampleSlot),
            Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1)
            .sv_sampler_load_from_memory(slotId, moduleId, Arg.Any<IntPtr>(), (uint)buffer.Length, sampleSlot);
    }

    [Test]
    public void LoadSamplerSampleShouldCallExpectedMethod()
    {
        var path = Any.String();
        var slotId = Any.Integer();
        var moduleId = Any.Integer();
        var sampleSlot = Any.Integer();
        var receivedString = string.Empty;

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.When(static l => l.sv_sampler_load(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>(), Arg.Any<int>()))
            .Do(callInfo => receivedString = Marshal.PtrToStringAnsi(callInfo.Arg<IntPtr>()));

        // when
        wrapper.LoadSamplerSample(slotId, moduleId, path, sampleSlot);

        // then
        library.Received(1).sv_sampler_load(slotId, moduleId, Arg.Any<IntPtr>(), sampleSlot);
        Assert.That(receivedString, Is.EqualTo(path));
    }

    [Test]
    public void LoadSamplerSampleShouldCallExpectedMethodAndThrowOnNonZeroReturnCode()
    {
        var path = Any.String();
        var slotId = Any.Integer();
        var moduleId = Any.Integer();
        var sampleSlot = Any.Integer();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_sampler_load(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>(), Arg.Any<int>()).Returns(-1);

        // when
        Assert.That(() => wrapper.LoadSamplerSample(slotId, moduleId, path, sampleSlot),
            Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1).sv_sampler_load(slotId, moduleId, Arg.Any<IntPtr>(), sampleSlot);
    }

    [Test]
    public void ReadModuleCurveShouldCallExpectedMethod()
    {
        var slotId = Any.Integer();
        var moduleId = Any.Integer();
        var samplesWritten = Any.Integer();
        var curveId = Any.Integer();
        var buffer = Any.Array<float>();
        var receivedBuffer = Array.Empty<float>();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_module_curve(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>(), Arg.Any<int>(),
            Arg.Any<int>()).Returns(samplesWritten);
        library.When(static l => l.sv_module_curve(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>(),
                Arg.Any<int>(), Arg.Any<int>()))
            .Do(callInfo =>
            {
                receivedBuffer = new float[callInfo.ArgAt<int>(4)];
                Marshal.Copy(callInfo.Arg<IntPtr>(), receivedBuffer, 0, callInfo.ArgAt<int>(4));
            });

        // when
        var value = wrapper.ReadModuleCurve(slotId, moduleId, curveId, buffer);

        // then
        library.Received(1).sv_module_curve(slotId, moduleId, curveId, Arg.Any<IntPtr>(), buffer.Length, 0);
        Assert.Multiple(() =>
        {
            Assert.That(value, Is.EqualTo(samplesWritten));
            Assert.That(receivedBuffer, Is.EqualTo(buffer));
        });
    }

    [Test]
    public void ReadModuleCurveShouldThrowOnNonZeroReturnCode()
    {
        var slotId = Any.Integer();
        var moduleId = Any.Integer();
        var curveId = Any.Integer();
        var buffer = Any.Array<float>();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_module_curve(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>(), Arg.Any<int>(),
            Arg.Any<int>()).Returns(-1);

        // when
        Assert.That(() => wrapper.ReadModuleCurve(slotId, moduleId, curveId, buffer),
            Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1).sv_module_curve(slotId, moduleId, curveId, Arg.Any<IntPtr>(), buffer.Length, 0);
    }

    [Test]
    public void ReadModuleScopeShouldCallExpectedMethod()
    {
        var moduleId = Any.Integer();
        var slotId = Any.Integer();
        var readSamples = Any.UnsignedInt();
        var buffer = Any.Array<short>(16);
        var receivedBuffer = Array.Empty<short>();
        var channel = Any.Instance<AudioChannel>();

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
        Assert.Multiple(() =>
        {
            Assert.That(receivedBuffer, Is.EquivalentTo(buffer));
            Assert.That(value, Is.EqualTo(readSamples));
        });
    }

    [Test]
    public void RemoveModuleShouldCallExpectedMethod()
    {
        var slotId = Any.Integer();
        var moduleId = Any.Integer();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_remove_module(Arg.Any<int>(), Arg.Any<int>()).Returns(0);

        // when
        wrapper.RemoveModule(slotId, moduleId);

        // then
        library.Received(1).sv_remove_module(slotId, moduleId);
    }

    [Test]
    public void RemoveModuleShouldCallExpectedMethodAndThrowOnNonZeroReturnCode()
    {
        var slotId = Any.Integer();
        var moduleId = Any.Integer();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_remove_module(Arg.Any<int>(), Arg.Any<int>()).Returns(-1);

        // when
        Assert.That(() => wrapper.RemoveModule(slotId, moduleId), Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1).sv_remove_module(slotId, moduleId);
    }

    [Test]
    public void SetModuleColorShouldCallExpectedMethod()
    {
        var r = Any.Byte();
        var g = Any.Byte();
        var b = Any.Byte();
        var code = r | (g << 8) | (b << 16);

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_get_module_color(Arg.Any<int>(), Arg.Any<int>()).Returns(code);
        var moduleId = Any.Integer();
        var slotId = Any.Integer();

        // when
        wrapper.SetModuleColor(slotId, moduleId, r, g, b);

        // then
        library.Received(1).sv_set_module_color(slotId, moduleId, code);
    }

    [Test]
    public void SetModuleColorShouldThrowOnNonZeroReturnCode()
    {
        var r = Any.Byte();
        var g = Any.Byte();
        var b = Any.Byte();
        var code = r | (g << 8) | (b << 16);

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_set_module_color(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()).Returns(-1);
        var moduleId = Any.Integer();
        var slotId = Any.Integer();

        // when
        Assert.That(() => wrapper.SetModuleColor(slotId, moduleId, r, g, b),
            Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1).sv_set_module_color(slotId, moduleId, code);
    }

    [Test]
    public void SetModuleControllerValueShouldCallExpectedMethod()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var moduleId = Any.Integer();
        var controllerId = Any.Integer();
        var slotId = Any.Integer();
        var scalingMode = Any.Instance<ValueScalingMode>();
        var valueToSet = Any.Integer();
        library.sv_set_module_ctl_value(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>())
            .Returns(0);

        // when
        wrapper.SetModuleControllerValue(slotId, moduleId, controllerId, valueToSet, scalingMode);

        // then
        library.Received(1).sv_set_module_ctl_value(slotId, moduleId, controllerId, valueToSet, (int)scalingMode);
    }

    [Test]
    public void SetModuleControllerValueShouldCallExpectedMethodAndThrowOnNonZeroCode()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var moduleId = Any.Integer();
        var controllerId = Any.Integer();
        var slotId = Any.Integer();
        var scalingMode = Any.Instance<ValueScalingMode>();
        var valueToSet = Any.Integer();
        library.sv_set_module_ctl_value(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>())
            .Returns(-1);

        // when - then
        Assert.That(() => wrapper.SetModuleControllerValue(slotId, moduleId, controllerId, valueToSet, scalingMode),
            Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1).sv_set_module_ctl_value(slotId, moduleId, controllerId, valueToSet, (int)scalingMode);
    }

    [Test]
    public void SetModuleFineTuneShouldCallExpectedMethod()
    {
        var fineTune = Any.Integer();
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var moduleId = Any.Integer();
        var slotId = Any.Integer();
        library.sv_set_module_finetune(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()).Returns(0);

        // when
        wrapper.SetModuleFineTune(slotId, moduleId, fineTune);

        // then
        library.Received(1).sv_set_module_finetune(slotId, moduleId, fineTune);
    }

    [Test]
    public void SetModuleFineTuneShouldCallExpectedMethodAndThrowOnNonZeroReturnCode()
    {
        var fineTune = Any.Integer();
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var moduleId = Any.Integer();
        var slotId = Any.Integer();
        library.sv_set_module_finetune(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()).Returns(-1);

        // when
        Assert.That(() => wrapper.SetModuleFineTune(slotId, moduleId, fineTune),
            Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1).sv_set_module_finetune(slotId, moduleId, fineTune);
    }

    [Test]
    public void SetModuleNameShouldCallExpectedMethod()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var nameToSet = Any.String();
        var receivedString = string.Empty;
        var slotId = Any.Integer();
        var moduleId = Any.Integer();
        library.When(static l => l.sv_set_module_name(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>()))
            .Do(callInfo => receivedString = Marshal.PtrToStringAnsi(callInfo.Arg<IntPtr>()));

        // when
        wrapper.SetModuleName(slotId, moduleId, nameToSet);

        // then
        library.Received(1).sv_set_module_name(slotId, moduleId, Arg.Any<IntPtr>());
        Assert.Multiple(() => { Assert.That(receivedString, Is.EqualTo(nameToSet)); });
    }

    [Test]
    public void SetModuleNameShouldCallExpectedMethodAndThrowOnNonZeroReturnCode()
    {
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var nameToSet = Any.String();
        var slotId = Any.Integer();
        var moduleId = Any.Integer();
        library.sv_set_module_name(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>()).Returns(-1);

        // when
        Assert.That(() => wrapper.SetModuleName(slotId, moduleId, nameToSet),
            Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1).sv_set_module_name(slotId, moduleId, Arg.Any<IntPtr>());
    }

    [Test]
    public void SetModulePositionShouldCallExpectedMethod()
    {
        var moduleId = Any.Integer();
        var slotId = Any.Integer();
        var x = Any.Short();
        var y = Any.Short();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);

        // when
        wrapper.SetModulePosition(slotId, moduleId, x, y);

        // then
        library.Received(1).sv_set_module_xy(slotId, moduleId, x, y);
    }

    [Test]
    public void SetModulePositionShouldCallExpectedMethodAndThrowOnNonZeroReturnCode()
    {
        var moduleId = Any.Integer();
        var slotId = Any.Integer();
        var x = Any.Short();
        var y = Any.Short();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_set_module_xy(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()).Returns(-1);

        // when
        Assert.That(() => wrapper.SetModulePosition(slotId, moduleId, x, y),
            Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1).sv_set_module_xy(slotId, moduleId, x, y);
    }

    [Test]
    public void SetModuleRelativeNoteShouldCallExpectedMethod()
    {
        var fineTune = Any.Integer();
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var moduleId = Any.Integer();
        var slotId = Any.Integer();
        library.sv_set_module_relnote(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()).Returns(0);

        // when
        wrapper.SetModuleRelativeNote(slotId, moduleId, fineTune);

        // then
        library.Received(1).sv_set_module_relnote(slotId, moduleId, fineTune);
    }

    [Test]
    public void SetModuleRelativeNoteShouldCallExpectedMethodAndThrowOnNonZeroReturnCode()
    {
        var fineTune = Any.Integer();
        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        var moduleId = Any.Integer();
        var slotId = Any.Integer();
        library.sv_set_module_relnote(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()).Returns(-1);

        // when
        Assert.That(() => wrapper.SetModuleRelativeNote(slotId, moduleId, fineTune),
            Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1).sv_set_module_relnote(slotId, moduleId, fineTune);
    }

    [Test]
    public void WriteModuleCurveShouldCallExpectedMethod()
    {
        var slotId = Any.Integer();
        var moduleId = Any.Integer();
        var samplesWritten = Any.Integer();
        var curveId = Any.Integer();
        var buffer = Any.Array<float>();
        var receivedBuffer = Array.Empty<float>();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_module_curve(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>(), Arg.Any<int>(),
            Arg.Any<int>()).Returns(samplesWritten);
        library.When(static l => l.sv_module_curve(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>(),
                Arg.Any<int>(), Arg.Any<int>()))
            .Do(callInfo =>
            {
                receivedBuffer = new float[callInfo.ArgAt<int>(4)];
                Marshal.Copy(callInfo.Arg<IntPtr>(), receivedBuffer, 0, callInfo.ArgAt<int>(4));
            });

        // when
        var value = wrapper.WriteModuleCurve(slotId, moduleId, curveId, buffer);

        // then
        library.Received(1).sv_module_curve(slotId, moduleId, curveId, Arg.Any<IntPtr>(), buffer.Length, 1);
        Assert.Multiple(() =>
        {
            Assert.That(value, Is.EqualTo(samplesWritten));
            Assert.That(receivedBuffer, Is.EqualTo(buffer));
        });
    }

    [Test]
    public void WriteModuleCurveShouldThrowOnNonZeroReturnCode()
    {
        var slotId = Any.Integer();
        var moduleId = Any.Integer();
        var curveId = Any.Integer();
        var buffer = Any.Array<float>();

        var library = Substitute.For<ISunVoxLibC>();
        var wrapper = new SunVoxLibNativeWrapper(library);
        library.sv_module_curve(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<IntPtr>(), Arg.Any<int>(),
            Arg.Any<int>()).Returns(-1);

        // when
        Assert.That(() => wrapper.WriteModuleCurve(slotId, moduleId, curveId, buffer),
            Throws.Exception.TypeOf<SunVoxException>());

        // then
        library.Received(1).sv_module_curve(slotId, moduleId, curveId, Arg.Any<IntPtr>(), buffer.Length, 1);
    }
}
