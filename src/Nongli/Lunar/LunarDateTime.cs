using YiJingFramework.PrimitiveTypes;

namespace YiJingFramework.Nongli.Lunar;

public sealed partial class LunarDateTime
{
    private LunarDateTime(LunarYue yue, int ri, Dizhi shi)
    {
        this.LunarYue = yue;
        this.Ri = ri;
        this.Shi = shi;
    }

    public LunarNian LunarNian => LunarYue.Nian;
    public int GregorianYear => LunarNian.GregorianYear;
    public Tiangan Niangan => LunarNian.Niangan;
    public Dizhi Nianzhi => LunarNian.Nianzhi;

    public LunarYue LunarYue { get; }
    public int Yue => LunarYue.Yue;
    public bool IsRunyue => LunarYue.IsRunyue;

    public int Ri { get; }
    public Dizhi Shi { get; }
}
