using YiJingFramework.PrimitiveTypes;

namespace YiJingFramework.Nongli.Lunar;

public sealed class LunarNian : IComparable<LunarNian>, IEquatable<LunarNian>
{
    public LunarNian(int gregorianYear)
    {
        this.yearIndex = gregorianYear - LunarTables.STARTING_NIAN;
        if (yearIndex < 0 || yearIndex >= LunarTables.NianStartDateTable.Length)
            throw new NotSupportedException($"The year {gregorianYear} is not in the supported range.");

        this.yueListLazy = new(LoadYueList, true);
    }

    private readonly int yearIndex;
    public int GregorianYear => yearIndex + LunarTables.STARTING_NIAN;
    public Tiangan Niangan => new(LunarTables.STARTING_NIAN_GAN_INDEX + yearIndex);
    public Dizhi Nianzhi => new(LunarTables.STARTING_NIAN_ZHI_INDEX + yearIndex);

    private readonly Lazy<IReadOnlyList<LunarYue>> yueListLazy;
    public IReadOnlyList<LunarYue> YueList => yueListLazy.Value;
    private IReadOnlyList<LunarYue> LoadYueList()
    {
        int runyue = LunarTables.RunyueIndexTable[yearIndex];
        int yueDayCount = LunarTables.RiCountInYueTable[yearIndex];
        var result = new List<LunarYue>();

        if(runyue is 0)
        {
            var mask = 0b1_0000_0000_0000;
            for (int yueIndex = 0; yueIndex < 12; yueIndex++)
            {
                var riCount = (yueDayCount & mask) > 0 ? 30 : 29;
                result.Add(new LunarYue()
                {
                    Nian = this,
                    RiCount = riCount,
                    YueIndexInNian = yueIndex,
                    IsRunyue = false,
                    Yue = yueIndex + 1
                });
                mask >>= 1;
            }
        }
        else
        {
            var mask = 0b1_0000_0000_0000;
            for (int yueIndex = 0; yueIndex < 13; yueIndex++)
            {
                var riCount = (yueDayCount & mask) > 0 ? 30 : 29;
                result.Add(new LunarYue()
                {
                    Nian = this,
                    RiCount = riCount,
                    YueIndexInNian = yueIndex,
                    IsRunyue = yueIndex == runyue,
                    Yue = yueIndex < runyue ? yueIndex + 1 : yueIndex
                });
                mask >>= 1;
            }
        }

        return result.AsReadOnly();
    }

    public int CompareTo(LunarNian? other)
    {
        return this.GregorianYear.CompareTo(other?.GregorianYear);
    }

    public bool Equals(LunarNian? other)
    {
        return this.GregorianYear.Equals(other?.GregorianYear);
    }

    public override bool Equals(object? obj)
    {
        if(obj is LunarNian other)
            return this.GregorianYear.Equals(other.GregorianYear);
        return false;
    }

    public override int GetHashCode()
    {
        return this.GregorianYear.GetHashCode();
    }

    public override string ToString()
    {
        return $"Nian {Niangan}-{Nianzhi} ({GregorianYear})";
    }
}
