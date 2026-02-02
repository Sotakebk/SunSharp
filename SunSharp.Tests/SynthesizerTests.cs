namespace SunSharp.Tests;

public class SynthesizerTests
{
#if !RELEASE
#if !GENERATION

    private static (Synthesizer synthesizer, ISunVoxLib mockLib, Slot slot) CreateTestSynthesizer(int slotId = 0)
    {
        var mockLib = Substitute.For<ISunVoxLib>();
        var mockSunVox = Substitute.For<ISunVox>();
        mockSunVox.Library.Returns(mockLib);
        var slotManagementLock = new object();
        var slot = new Slot(slotId, slotManagementLock, mockSunVox);
        var synthesizer = slot.Synthesizer;
        return (synthesizer, mockLib, slot);
    }

    #region Constructor

    [Test]
    public void Constructor_ShouldInitializeCorrectly()
    {
        // Arrange & Act
        var (synthesizer, _, slot) = CreateTestSynthesizer(3);

        // Assert
        synthesizer.Should().NotBeNull();
        synthesizer.Slot.Should().Be(slot);
    }

    #endregion Constructor

    #region GetUpperModuleCount

    [Test]
    public void GetUpperModuleCount_ShouldReturnLibraryValue()
    {
        // Arrange
        var (synthesizer, mockLib, _) = CreateTestSynthesizer(1);
        mockLib.GetUpperModuleCount(1).Returns(10);

        // Act
        var result = synthesizer.GetUpperModuleCount();

        // Assert
        result.Should().Be(10);
        mockLib.Received(1).GetUpperModuleCount(1);
    }

    #endregion GetUpperModuleCount

    #region GetModuleExists

    [Test]
    public void GetModuleExists_WithExistingModule_ShouldReturnTrue()
    {
        // Arrange
        var (synthesizer, mockLib, _) = CreateTestSynthesizer(1);
        mockLib.GetModuleExists(1, 5).Returns(true);

        // Act
        var result = synthesizer.GetModuleExists(5);

        // Assert
        result.Should().BeTrue();
        mockLib.Received(1).GetModuleExists(1, 5);
    }

    [Test]
    public void GetModuleExists_WithNonExistingModule_ShouldReturnFalse()
    {
        // Arrange
        var (synthesizer, mockLib, _) = CreateTestSynthesizer(1);
        mockLib.GetModuleExists(1, 99).Returns(false);

        // Act
        var result = synthesizer.GetModuleExists(99);

        // Assert
        result.Should().BeFalse();
        mockLib.Received(1).GetModuleExists(1, 99);
    }

    #endregion GetModuleExists

    #region GetModuleFlags

    [Test]
    public void GetModuleFlags_ShouldReturnLibraryValue()
    {
        // Arrange
        var (synthesizer, mockLib, _) = CreateTestSynthesizer(1);
        var expectedFlags = new ModuleFlags((int)ModuleFlags.SV_MODULE_FLAG_GENERATOR | (int)ModuleFlags.SV_MODULE_FLAG_BYPASS);
        mockLib.GetModuleFlags(1, 3).Returns(expectedFlags);

        // Act
        var result = synthesizer.GetModuleFlags(3);

        // Assert
        result.Should().Be(expectedFlags);
        mockLib.Received(1).GetModuleFlags(1, 3);
    }

    #endregion GetModuleFlags

    #region GetModule

    [Test]
    public void GetModule_ShouldReturnModuleHandle()
    {
        // Arrange
        var (synthesizer, _, slot) = CreateTestSynthesizer(1);

        // Act
        var result = synthesizer.GetModule(7);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(7);
        result.Slot.Should().Be(slot);
    }

    [Test]
    public void GetModule_AsInterface_ShouldReturnModuleHandle()
    {
        // Arrange
        var (synthesizer, _, _) = CreateTestSynthesizer(1);
        ISynthesizer iSynthesizer = synthesizer;

        // Act
        var result = iSynthesizer.GetModule(7);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(7);
    }

    #endregion GetModule

    #region TryGetModule

    [Test]
    public void TryGetModule_WithExistingModuleById_ShouldReturnTrueAndHandle()
    {
        // Arrange
        var (synthesizer, mockLib, _) = CreateTestSynthesizer(1);
        mockLib.GetModuleExists(1, 5).Returns(true);

        // Act
        var result = synthesizer.TryGetModule(5, out var moduleHandle);

        // Assert
        result.Should().BeTrue();
        moduleHandle.Should().NotBeNull();
        moduleHandle!.Value.Id.Should().Be(5);
        mockLib.Received(1).GetModuleExists(1, 5);
    }

    [Test]
    public void TryGetModule_WithNonExistingModuleById_ShouldReturnFalse()
    {
        // Arrange
        var (synthesizer, mockLib, _) = CreateTestSynthesizer(1);
        mockLib.GetModuleExists(1, 99).Returns(false);

        // Act
        var result = synthesizer.TryGetModule(99, out var moduleHandle);

        // Assert
        result.Should().BeFalse();
        moduleHandle.Should().BeNull();
    }

    [Test]
    public void TryGetModule_WithExistingModuleByName_ShouldReturnTrueAndHandle()
    {
        // Arrange
        var (synthesizer, mockLib, _) = CreateTestSynthesizer(1);
        mockLib.FindModule(1, "TestModule").Returns(42);

        // Act
        var result = synthesizer.TryGetModule("TestModule", out var moduleHandle);

        // Assert
        result.Should().BeTrue();
        moduleHandle.Should().NotBeNull();
        moduleHandle!.Value.Id.Should().Be(42);
        mockLib.Received(1).FindModule(1, "TestModule");
    }

    [Test]
    public void TryGetModule_WithNonExistingModuleByName_ShouldReturnFalse()
    {
        // Arrange
        var (synthesizer, mockLib, _) = CreateTestSynthesizer(1);
        mockLib.FindModule(1, "NonExistent").Returns((int?)null);

        // Act
        var result = synthesizer.TryGetModule("NonExistent", out var moduleHandle);

        // Assert
        result.Should().BeFalse();
        moduleHandle.Should().BeNull();
    }

    [Test]
    public void TryGetModule_AsInterface_WithExistingModuleById_ShouldReturnTrueAndHandle()
    {
        // Arrange
        var (synthesizer, mockLib, _) = CreateTestSynthesizer(1);
        ISynthesizer iSynthesizer = synthesizer;
        mockLib.GetModuleExists(1, 5).Returns(true);

        // Act
        var result = iSynthesizer.TryGetModule(5, out var moduleHandle);

        // Assert
        result.Should().BeTrue();
        moduleHandle.Should().NotBeNull();
        moduleHandle!.Id.Should().Be(5);
    }

    [Test]
    public void TryGetModule_AsInterface_WithExistingModuleByName_ShouldReturnTrueAndHandle()
    {
        // Arrange
        var (synthesizer, mockLib, _) = CreateTestSynthesizer(1);
        ISynthesizer iSynthesizer = synthesizer;
        mockLib.FindModule(1, "TestModule").Returns(42);

        // Act
        var result = iSynthesizer.TryGetModule("TestModule", out var moduleHandle);

        // Assert
        result.Should().BeTrue();
        moduleHandle.Should().NotBeNull();
        moduleHandle!.Id.Should().Be(42);
    }

    #endregion TryGetModule

    #region CreateModule

    [Test]
    public void CreateModule_ShouldCallLibraryAndReturnHandle()
    {
        // Arrange
        var (synthesizer, mockLib, _) = CreateTestSynthesizer(1);
        mockLib.CreateModule(1, SynthModuleType.AnalogGenerator, "TestGen", 10, 20, 30).Returns(15);

        // Act
        var result = synthesizer.CreateModule(SynthModuleType.AnalogGenerator, "TestGen", 10, 20, 30);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(15);
        mockLib.Received(1).LockSlot(1);
        mockLib.Received(1).CreateModule(1, SynthModuleType.AnalogGenerator, "TestGen", 10, 20, 30);
        mockLib.Received(1).UnlockSlot(1);
    }

    [Test]
    public void CreateModule_WithDefaults_ShouldCallLibraryWithDefaultCoordinates()
    {
        // Arrange
        var (synthesizer, mockLib, _) = CreateTestSynthesizer(1);
        mockLib.CreateModule(1, SynthModuleType.Amplifier, "TestAmp", 0, 0, 0).Returns(20);

        // Act
        var result = synthesizer.CreateModule(SynthModuleType.Amplifier, "TestAmp");

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(20);
        mockLib.Received(1).CreateModule(1, SynthModuleType.Amplifier, "TestAmp", 0, 0, 0);
    }

    [Test]
    public void CreateModule_AsInterface_ShouldReturnHandle()
    {
        // Arrange
        var (synthesizer, mockLib, _) = CreateTestSynthesizer(1);
        ISynthesizer iSynthesizer = synthesizer;
        mockLib.CreateModule(1, SynthModuleType.Filter, "TestFilter", 5, 10, 15).Returns(25);

        // Act
        var result = iSynthesizer.CreateModule(SynthModuleType.Filter, "TestFilter", 5, 10, 15);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(25);
    }

    #endregion CreateModule

    #region LoadModule

    [Test]
    public void LoadModule_WithByteArray_ShouldCallLibraryAndReturnHandle()
    {
        // Arrange
        var (synthesizer, mockLib, _) = CreateTestSynthesizer(1);
        var data = new byte[] { 1, 2, 3, 4 };
        mockLib.LoadModule(1, data, 10, 20, 30).Returns(50);

        // Act
        var result = synthesizer.LoadModule(data, 10, 20, 30);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(50);
        mockLib.Received(1).LoadModule(1, data, 10, 20, 30);
    }

    [Test]
    public void LoadModule_WithByteArrayDefaults_ShouldCallLibraryWithDefaultCoordinates()
    {
        // Arrange
        var (synthesizer, mockLib, _) = CreateTestSynthesizer(1);
        var data = new byte[] { 5, 6, 7, 8 };
        mockLib.LoadModule(1, data, 0, 0, 0).Returns(51);

        // Act
        var result = synthesizer.LoadModule(data);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(51);
        mockLib.Received(1).LoadModule(1, data, 0, 0, 0);
    }

    [Test]
    public void LoadModule_WithPath_ShouldCallLibraryAndReturnHandle()
    {
        // Arrange
        var (synthesizer, mockLib, _) = CreateTestSynthesizer(1);
        const string path = "module.sunsynth";
        mockLib.LoadModule(1, path, 10, 20, 30).Returns(52);

        // Act
        var result = synthesizer.LoadModule(path, 10, 20, 30);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(52);
        mockLib.Received(1).LoadModule(1, path, 10, 20, 30);
    }

    [Test]
    public void LoadModule_WithPathDefaults_ShouldCallLibraryWithDefaultCoordinates()
    {
        // Arrange
        var (synthesizer, mockLib, _) = CreateTestSynthesizer(1);
        const string path = "module2.sunsynth";
        mockLib.LoadModule(1, path, 0, 0, 0).Returns(53);

        // Act
        var result = synthesizer.LoadModule(path);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(53);
        mockLib.Received(1).LoadModule(1, path, 0, 0, 0);
    }

    [Test]
    public void LoadModule_AsInterface_WithByteArray_ShouldReturnHandle()
    {
        // Arrange
        var (synthesizer, mockLib, _) = CreateTestSynthesizer(1);
        ISynthesizer iSynthesizer = synthesizer;
        var data = new byte[] { 9, 10, 11, 12 };
        mockLib.LoadModule(1, data, 5, 10, 15).Returns(54);

        // Act
        var result = iSynthesizer.LoadModule(data, 5, 10, 15);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(54);
    }

    [Test]
    public void LoadModule_AsInterface_WithPath_ShouldReturnHandle()
    {
        // Arrange
        var (synthesizer, mockLib, _) = CreateTestSynthesizer(1);
        ISynthesizer iSynthesizer = synthesizer;
        const string path = "module3.sunsynth";
        mockLib.LoadModule(1, path, 5, 10, 15).Returns(55);

        // Act
        var result = iSynthesizer.LoadModule(path, 5, 10, 15);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(55);
    }

    #endregion LoadModule

    #region RemoveModule

    [Test]
    public void RemoveModule_ById_ShouldCallLibrary()
    {
        // Arrange
        var (synthesizer, mockLib, _) = CreateTestSynthesizer(1);

        // Act
        synthesizer.RemoveModule(10);

        // Assert
        mockLib.Received(1).RemoveModule(1, 10);
    }

    [Test]
    public void RemoveModule_ByHandle_ShouldCallLibrary()
    {
        // Arrange
        var (synthesizer, mockLib, slot) = CreateTestSynthesizer(1);
        var moduleHandle = new SynthModuleHandle(slot, 15);

        // Act
        synthesizer.RemoveModule(moduleHandle);

        // Assert
        mockLib.Received(1).RemoveModule(1, 15);
    }

    [Test]
    public void RemoveModule_AsInterface_ByHandle_ShouldCallLibrary()
    {
        // Arrange
        var (synthesizer, mockLib, slot) = CreateTestSynthesizer(1);
        ISynthesizer iSynthesizer = synthesizer;
        ISynthModuleHandle moduleHandle = new SynthModuleHandle(slot, 20);

        // Act
        iSynthesizer.RemoveModule(moduleHandle);

        // Assert
        mockLib.Received(1).RemoveModule(1, 20);
    }

    #endregion RemoveModule

    #region ConnectModule

    [Test]
    public void ConnectModule_ByIds_ShouldCallLibrary()
    {
        // Arrange
        var (synthesizer, mockLib, _) = CreateTestSynthesizer(1);

        // Act
        synthesizer.ConnectModule(5, 10);

        // Assert
        mockLib.Received(1).ConnectModules(1, 5, 10);
    }

    [Test]
    public void ConnectModule_ByHandles_ShouldCallLibrary()
    {
        // Arrange
        var (synthesizer, mockLib, slot) = CreateTestSynthesizer(1);
        var source = new SynthModuleHandle(slot, 3);
        var destination = new SynthModuleHandle(slot, 7);

        // Act
        synthesizer.ConnectModule(source, destination);

        // Assert
        mockLib.Received(1).ConnectModules(1, 3, 7);
    }

    [Test]
    public void ConnectModule_AsInterface_ByHandles_ShouldCallLibrary()
    {
        // Arrange
        var (synthesizer, mockLib, slot) = CreateTestSynthesizer(1);
        ISynthesizer iSynthesizer = synthesizer;
        ISynthModuleHandle source = new SynthModuleHandle(slot, 8);
        ISynthModuleHandle destination = new SynthModuleHandle(slot, 12);

        // Act
        iSynthesizer.ConnectModule(source, destination);

        // Assert
        mockLib.Received(1).ConnectModules(1, 8, 12);
    }

    #endregion ConnectModule

    #region DisconnectModule

    [Test]
    public void DisconnectModule_ByIds_ShouldCallLibrary()
    {
        // Arrange
        var (synthesizer, mockLib, _) = CreateTestSynthesizer(1);

        // Act
        synthesizer.DisconnectModule(5, 10);

        // Assert
        mockLib.Received(1).DisconnectModules(1, 5, 10);
    }

    [Test]
    public void DisconnectModule_ByHandles_ShouldCallLibrary()
    {
        // Arrange
        var (synthesizer, mockLib, slot) = CreateTestSynthesizer(1);
        var source = new SynthModuleHandle(slot, 3);
        var destination = new SynthModuleHandle(slot, 7);

        // Act
        synthesizer.DisconnectModule(source, destination);

        // Assert
        mockLib.Received(1).DisconnectModules(1, 3, 7);
    }

    [Test]
    public void DisconnectModule_AsInterface_ByHandles_ShouldCallLibrary()
    {
        // Arrange
        var (synthesizer, mockLib, slot) = CreateTestSynthesizer(1);
        ISynthesizer iSynthesizer = synthesizer;
        ISynthModuleHandle source = new SynthModuleHandle(slot, 8);
        ISynthModuleHandle destination = new SynthModuleHandle(slot, 12);

        // Act
        iSynthesizer.DisconnectModule(source, destination);

        // Assert
        mockLib.Received(1).DisconnectModules(1, 8, 12);
    }

    #endregion DisconnectModule

    #region Enumeration

    [Test]
    public void GetEnumerator_WithModules_ShouldEnumerateExistingModules()
    {
        // Arrange
        var (synthesizer, mockLib, _) = CreateTestSynthesizer(1);
        mockLib.GetUpperModuleCount(1).Returns(5);
        mockLib.GetModuleExists(1, 0).Returns(true);
        mockLib.GetModuleExists(1, 1).Returns(false);
        mockLib.GetModuleExists(1, 2).Returns(true);
        mockLib.GetModuleExists(1, 3).Returns(false);
        mockLib.GetModuleExists(1, 4).Returns(true);

        // Act
        var modules = synthesizer.ToList<SynthModuleHandle>();

        // Assert
        modules.Should().HaveCount(3);
        modules[0].Id.Should().Be(0);
        modules[1].Id.Should().Be(2);
        modules[2].Id.Should().Be(4);
    }

    [Test]
    public void GetEnumerator_WithNoModules_ShouldReturnEmpty()
    {
        // Arrange
        var (synthesizer, mockLib, _) = CreateTestSynthesizer(1);
        mockLib.GetUpperModuleCount(1).Returns(0);

        // Act
        var modules = synthesizer.ToList<SynthModuleHandle>();

        // Assert
        modules.Should().BeEmpty();
    }

    [Test]
    public void GetEnumerator_AsInterface_ShouldEnumerateExistingModules()
    {
        // Arrange
        var (synthesizer, mockLib, _) = CreateTestSynthesizer(1);
        ISynthesizer iSynthesizer = synthesizer;
        mockLib.GetUpperModuleCount(1).Returns(3);
        mockLib.GetModuleExists(1, 0).Returns(true);
        mockLib.GetModuleExists(1, 1).Returns(true);
        mockLib.GetModuleExists(1, 2).Returns(false);

        // Act
        var modules = iSynthesizer.ToList();

        // Assert
        modules.Should().HaveCount(2);
        modules[0].Id.Should().Be(0);
        modules[1].Id.Should().Be(1);
    }

    #endregion Enumeration

    #region Interface Implementation

    [Test]
    public void ISynthesizer_Slot_ShouldReturnSlot()
    {
        // Arrange
        var (synthesizer, _, slot) = CreateTestSynthesizer(5);
        ISynthesizer iSynthesizer = synthesizer;

        // Act & Assert
        iSynthesizer.Slot.Should().Be(slot);
        iSynthesizer.Slot.Id.Should().Be(5);
    }

    #endregion Interface Implementation
#endif
#endif
}
