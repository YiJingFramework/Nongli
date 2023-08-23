namespace YiJingFramework.Nongli.Lunar;

public sealed class LunarYue
{
    internal LunarYue() { }

    public required LunarNian Nian { get; init; }
    public required int YueIndexInNian { get; init; }
    public required int Yue { get; init; }
    public required bool IsRunyue { get; init; }
    public required int RiCount { get; init; }
}
