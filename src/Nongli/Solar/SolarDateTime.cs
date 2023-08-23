using YiJingFramework.PrimitiveTypes;

namespace YiJingFramework.Nongli.Solar;

public sealed class SolarDateTime
{
    private SolarDateTime() { }

    public Tiangan Niangan { get; }
    public Dizhi Nianzhi { get; }

    public Tiangan Yuegan { get; }
    public Dizhi Yuezhi { get; }

    public Tiangan Rigan { get; }
    public Dizhi Rizhi { get; }

    public Tiangan Shigan { get; }
    public Dizhi Shizhi { get; }
}
