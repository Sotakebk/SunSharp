using System.ComponentModel;
using System.Text.Json.Serialization;
using SunSharp;

namespace CodeGeneration.Logic;

public class KnownModuleData
{
    [Description("Internal Name, received from SunVox, is used as key.")]
    public required Dictionary<string, ModuleDescription> Modules { get; init; } = [];
}

public class ModuleDescription
{
    [Description("Id of the controller is used as key.")]
    public required Dictionary<int, ControllerDescription> Controllers { get; init; } = [];

    [Description("Id of the curve is used as key")]
    public required Dictionary<int, CurveDescription> Curves { get; init; } = [];
}

public class ControllerDescription
{
    [Description("Friendly Name of the controller. Set by hand or automatically on discovery.")]
    public required string FriendlyName { get; init; }

    [Description("Internal Name, received from SunVox, is used in code generation.")]
    public required string InternalName { get; init; }

    [Description("A short description of the controller.")]
    public string? Description { get; init; }

    public required int MinValue { get; init; }
    public required int MaxValue { get; init; }
    public required int MinDisplayedValue { get; init; }
    public required int MaxDisplayedValue { get; init; }
    public required int Offset { get; init; }

    [Description("The type of controller this is, as defined in the SunVox API.")]
    [JsonConverter(typeof(JsonStringEnumConverter<ControllerType>))]
    public required ControllerType ControllerType { get; init; }

    [Description("Whether the selector is an enum.")]
    public bool? SelectorIsNotEnum { get; init; }

    [Description("The name of the enum this controller uses.")]
    public string? EnumName { get; init; }
}

public class CurveDescription
{
    public required string FriendlyName { get; init; }

    [Description("The number of points in the curve, received from SunVox.")]
    public required int Size { get; init; }

    [Description("The minimum value of the curve points. Set by hand.")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public float? MinValue { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Description("The maximum value of the curve points. Set by hand.")]
    public float? MaxValue { get; init; }

    [Description("A short description of the curve.")]
    public string? Description { get; init; }
}
