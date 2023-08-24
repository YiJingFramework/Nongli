using YiJingFramework.Nongli.Extensions;
using YiJingFramework.PrimitiveTypes;

namespace YiJingFramework.Nongli.Lunar;

public sealed partial class LunarDateTime
{
    internal LunarDateTime(LunarYue yue, int ri, Dizhi shi)
    {
        if (ri <= 0 || ri > yue.RiCount)
            throw new ArgumentOutOfRangeException(nameof(ri));
        this.lunarNian = yue.Nian;
        this.LunarYue = yue;
        this.Ri = ri;
        this.Shi = shi;
    }

    private readonly LunarNian lunarNian;
    public LunarNian LunarNian => new(this.lunarNian);
    public int GregorianYear => this.lunarNian.Year;
    public Tiangan Niangan => this.lunarNian.Niangan;
    public Dizhi Nianzhi => this.lunarNian.Nianzhi;

    public LunarYue LunarYue { get; }
    public int Yue => this.LunarYue.Yue;
    public bool IsRunyue => this.LunarYue.IsRunyue;

    public int Ri { get; }
    public Dizhi Shi { get; }

    public static LunarDateTime FromGregorian(DateTime dateTime)
    {
        static NotSupportedException NotSupportedDateTime(DateTime dateTime)
        {
            return new NotSupportedException(
                $"The date time ({dateTime:yyyy/MM/dd HH:mm}) is not in the supported range.");
        }

        var originalDateTime = dateTime;
        if (dateTime.Hour is 23)
            dateTime = dateTime.Add(new TimeSpan(1, 0, 0));

        var dayNumber = DateOnly.FromDateTime(dateTime).DayNumber;
        var nianIndex = LunarTables.NianStartDayNumberTable.SortedFindFloor(dayNumber);
        if (nianIndex is -1)
            throw NotSupportedDateTime(originalDateTime);

        var restDayCount = dayNumber - LunarTables.NianStartDayNumberTable[nianIndex];
        var nian = new LunarNian(nianIndex);
        foreach (var yue in nian.YueList)
        {
            if (restDayCount < yue.RiCount)
                return new(yue, restDayCount + 1, new((dateTime.Hour + 3) / 2));
        }
        throw NotSupportedDateTime(originalDateTime);
    }
    public DateTime ToGregorian()
    {
        var nianIndex = this.lunarNian.NianIndex;
        var dayNumber = LunarTables.NianStartDayNumberTable[nianIndex];
        foreach (var yue in new LunarNian(nianIndex).YueList)
        {
            if (yue.YueIndexInNian == this.LunarYue.YueIndexInNian)
            {
                dayNumber += this.Ri - 1;
                break;
            }
            dayNumber += yue.RiCount;
        }
        var dateOnly = DateOnly.FromDayNumber(dayNumber);
        return dateOnly.ToDateTime(new TimeOnly((this.Shi.Index - 1) * 2, 0, 0));
    }
}
