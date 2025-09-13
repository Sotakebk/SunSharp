using System.Linq;
using SunSharp.Data;

namespace SunSharp.Tests.Mocks;

public class SunVoxLibMockProvider
{
    private readonly ISunVoxLib _mock = Substitute.For<ISunVoxLib>();

    public static SunVoxLibMockProvider BuildMock()
    {
        return new SunVoxLibMockProvider();
    }

    public SunVoxLibMockProvider WithSongData(int slotId, SongData songData)
    {
        _mock.GetSongName(slotId).Returns(songData.Name);
        _mock.GetSongBpm(slotId).Returns(songData.BPM);
        _mock.GetSongTpl(slotId).Returns(songData.TPL);
        _mock.GetCurrentLine(slotId).Returns(songData.CurrentLine);
        _mock.GetCurrentLineWithTenthPart(slotId).Returns(songData.CurrentLine * 10);
        _mock.GetSongLengthInLines(slotId).Returns(songData.Lines);

        WithModuleData(slotId, [.. songData.Modules]);

        WithPatternData(slotId, [.. songData.Patterns]);

        return this;
    }

    public SunVoxLibMockProvider WithPatternData(int slotId, PatternData[] patternData)
    {
        _mock.GetPatternExists(Arg.Any<int>(), Arg.Any<int>()).ReturnsForAnyArgs(false);
        _mock.GetUpperPatternCount(slotId).Returns(patternData.Max(static p => p.Id) + 1);

        foreach (var pattern in patternData)
        {
            _mock.GetPatternExists(slotId, pattern.Id).Returns(true);
            _mock.GetPatternName(slotId, pattern.Id).Returns(pattern.Name);
            _mock.GetPatternPosition(slotId, pattern.Id).Returns(pattern.Position);
            _mock.GetPatternX(slotId, pattern.Id).Returns(pattern.Position.X);
            _mock.GetPatternY(slotId, pattern.Id).Returns(pattern.Position.Y);
            _mock.GetPatternData(slotId, pattern.Id).Returns((pattern.Data.ToArray(), pattern.Tracks, pattern.Lines));
            _mock.GetPatternMuted(slotId, pattern.Id).Returns(pattern.IsMuted);
        }

        return this;
    }

    public SunVoxLibMockProvider WithModuleData(int slotId, ModuleData[] moduleData)
    {
        _mock.GetModuleExists(Arg.Any<int>(), Arg.Any<int>()).ReturnsForAnyArgs(false);
        _mock.GetUpperModuleCount(slotId).Returns(moduleData.Max(static m => m.Id) + 1);

        foreach (var module in moduleData)
        {
            _mock.GetModuleExists(slotId, module.Id).Returns(true);
            _mock.GetModuleName(slotId, module.Id).Returns(module.Name);
            _mock.GetModuleColor(slotId, module.Id).Returns(module.Color);
            _mock.GetModuleFineTune(slotId, module.Id).Returns(module.FineTune);
            _mock.GetModulePosition(slotId, module.Id).Returns(module.Position);
            _mock.GetModuleFlags(slotId, module.Id).Returns(new ModuleFlags(module.Flags));
            _mock.GetModuleType(slotId, module.Id).Returns(module.Type);
            _mock.GetModuleInputs(slotId, module.Id).Returns([.. module.Inputs]);
            _mock.GetModuleOutputs(slotId, module.Id).Returns([.. module.Outputs]);

            _mock.GetModuleControllerCount(slotId, module.Id).Returns(module.Controllers.Count);
            foreach (var controller in module.Controllers)
            {
                _mock.GetModuleControllerName(slotId, module.Id, controller.Id).Returns(controller.Name);
                _mock.GetModuleControllerGroup(slotId, module.Id, controller.Id).Returns(controller.Group);
                _mock.GetModuleControllerValue(slotId, module.Id, controller.Id, ValueScalingMode.Real)
                    .Returns(controller.Value);
                _mock.GetModuleControllerMaxValue(slotId, module.Id, controller.Id, ValueScalingMode.Real)
                    .Returns(controller.MaxValue);
                _mock.GetModuleControllerMinValue(slotId, module.Id, controller.Id, ValueScalingMode.Real)
                    .Returns(controller.MinValue);
                _mock.GetModuleControllerType(slotId, module.Id, controller.Id).Returns(controller.ControllerType);
                _mock.GetModuleControllerOffset(slotId, module.Id, controller.Id).Returns(controller.Offset);
            }
        }

        return this;
    }

    public ISunVoxLib Build()
    {
        return _mock;
    }
}
