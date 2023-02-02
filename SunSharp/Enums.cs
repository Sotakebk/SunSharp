namespace SunSharp
{
    public enum AudioChannel : int
    {
        Mono = 0,
        Left = Mono,
        Right = 1,
    }

    public enum AudioChannels : int
    {
        Mono = 1,
        Stereo = 2
    }

    public enum Column : int
    {
        NN = 0,
        VV = 1,
        MM = 2,
        CCEE = 3,
        XXYY = 4
    }

    public enum TimeMapType : int
    {
        Speed = Constants.SV_TIME_MAP_SPEED,
        FrameCount = Constants.SV_TIME_MAP_FRAMECNT,
    }

    public enum ValueScalingType : int
    {
        Real = 0,
        Column = 1,
        Displayed = 2,
    }

    public enum ControllerType
    {
        Real = 0,
        Enum = 1,
    }
}
