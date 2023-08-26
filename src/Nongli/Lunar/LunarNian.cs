using System.Collections.Immutable;
using System.Diagnostics;
using YiJingFramework.PrimitiveTypes;

namespace YiJingFramework.Nongli.Lunar;

/// <summary>
/// 农历（阴历部分）的年。
/// A Nian of Nongli (lunar part).
/// </summary>
public sealed class LunarNian : IComparable<LunarNian>, IEquatable<LunarNian>
{
    #region defining
    internal LunarNian(int checkedNianIndex)
    {
        Debug.Assert(checkedNianIndex >= 0 && checkedNianIndex < LunarTables.NianStartDayNumberTable.Length);

        this.NianIndex = checkedNianIndex;
        this.Year = this.NianIndex + LunarTables.STARTING_NIAN;
        this.Ganzhi = new(LunarTables.STARTING_NIAN_GANZHI + this.NianIndex);

        this.yueListLazy = new(this.LoadYueList, true);
    }

    internal int NianIndex { get; }
    /// <summary>
    /// 此年年首所在的公历年。
    /// 不是全年都在此公历年内。
    /// The Gregorian year in which the first day of this Nian is.
    /// Not all the days in this Nian are in this Gregorian year.
    /// </summary>
    public int Year { get; }
    /// <summary>
    /// 此年干支。
    /// This Nian's Ganzhi.
    /// </summary>
    public Ganzhi Ganzhi { get; }

    private readonly Lazy<IReadOnlyList<LunarYue>> yueListLazy;
    /// <summary>
    /// 此年中的月。
    /// Yues in this Nian.
    /// </summary>
    public IReadOnlyList<LunarYue> YueList => this.yueListLazy.Value;
    private IReadOnlyList<LunarYue> LoadYueList()
    {
        var yueCount = LunarTables.RunyueIndexTable[this.NianIndex] is 0 ? 12 : 13;
        var builder = ImmutableArray.CreateBuilder<LunarYue>(yueCount);

        var riCount = LunarTables.RiCountOfYueTable[this.NianIndex];
        var runyue = LunarTables.RunyueIndexTable[this.NianIndex];
        if (runyue is 0)
        {
            var mask = 0b1_0000_0000_0000;
            for (int i = 0; i < yueCount;)
            {
                var yue = i + 1;
                builder.Add(new LunarYue()
                {
                    Nian = this,
                    YueIndexInNian = i,
                    Number = yue,
                    IsRunyue = false,
                    IndexOfFirstRi = 1,
                    RiCount = (riCount & mask) > 0 ? 30 : 29
                });
                i = yue;
                mask >>= 1;
            }
        }
        else
        {
            int i = 0;
            var mask = 0b1_0000_0000_0000;
            for (; i < runyue;)
            {
                var yue = i + 1;
                builder.Add(new LunarYue()
                {
                    Nian = this,
                    YueIndexInNian = i,
                    Number = yue,
                    IsRunyue = false,
                    IndexOfFirstRi = 1,
                    RiCount = (riCount & mask) > 0 ? 30 : 29
                });
                i = yue;
                mask >>= 1;
            }
            {
                builder.Add(new LunarYue()
                {
                    Nian = this,
                    YueIndexInNian = i,
                    Number = i,
                    IsRunyue = true,
                    IndexOfFirstRi = 1,
                    RiCount = (riCount & mask) > 0 ? 30 : 29
                });
                i++;
                mask >>= 1;
            }
            for (; i < yueCount; i++)
            {
                builder.Add(new LunarYue()
                {
                    Nian = this,
                    YueIndexInNian = i,
                    Number = i,
                    IsRunyue = false,
                    IndexOfFirstRi = 1,
                    RiCount = (riCount & mask) > 0 ? 30 : 29
                });
                mask >>= 1;
            }
        }
        return builder.MoveToImmutable();
    }
    #endregion

    #region converting
    /// <summary>
    /// 最小支持到的年（含）。
    /// The minimum supported Nian (included).
    /// </summary>
    public static LunarNian MinSupportedNian => new(0);
    /// <summary>
    /// 最大支持到的年（含）。
    /// The maximum supported Nian (included).
    /// </summary>
    public static LunarNian MaxSupportedNian => new(LunarTables.NianStartDayNumberTable.Length - 1);

    /// <summary>
    /// 根据此年年首所在的公历年创建 <seealso cref="LunarNian"/> 的实例。
    /// Create an instance of <seealso cref="LunarNian"/> from the Gregorian year in which the first day of this Nian is.
    /// </summary>
    public static LunarNian FromGregorian(int year)
    {
        var nianIndex = year - LunarTables.STARTING_NIAN;
        if (nianIndex < 0 || nianIndex >= LunarTables.NianStartDayNumberTable.Length)
            throw new NotSupportedException($"The year ({year}) is not in the supported range.");
        return new LunarNian(nianIndex);
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return $"{this.Ganzhi}{this.Year}";
    }
    #endregion

    #region comparing
    /// <inheritdoc />
    public int CompareTo(LunarNian? other)
    {
        return this.NianIndex.CompareTo(other?.NianIndex);
    }

    /// <inheritdoc />
    public bool Equals(LunarNian? other)
    {
        return this.NianIndex.Equals(other?.NianIndex);
    }

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        if (obj is LunarNian other)
            return this.NianIndex.Equals(other.NianIndex);
        return false;
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        return this.NianIndex.GetHashCode();
    }
    #endregion
}
