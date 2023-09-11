using System.Collections.Immutable;
using System.Diagnostics;

namespace YiJingFramework.Nongli.Solar;

/// <summary>
/// 农历（阳历部分）的年。
/// 以立春（寅月）为年首。
/// A Nian of Nongli (solar part).
/// The first Ri will be the Lichun Ri (Yinyue).
/// </summary>
public sealed class SolarNian : IComparable<SolarNian>, IEquatable<SolarNian>
{
    #region defining
    internal SolarNian(int nianIndex)
    {
        Debug.Assert(nianIndex >= 0 && nianIndex < SolarTables.JieQiTickTable.Length / 24);

        this.NianIndex = nianIndex;
        this.Year = this.NianIndex + SolarTables.STARTING_NIAN;
        this.Ganzhi = Ganzhi.FromIndex(SolarTables.STARTING_NIAN_GANZHI + this.NianIndex);

        this.yuesLazy = new(this.LoadYueList, true);
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
    private readonly Lazy<IReadOnlyList<SolarYue>> yuesLazy;
    /// <summary>
    /// 此年中的月。
    /// Yues in this Nian.
    /// </summary>
    public IReadOnlyList<SolarYue> Yues => this.yuesLazy.Value;
    private IReadOnlyList<SolarYue> LoadYueList()
    {
        var builder = ImmutableArray.CreateBuilder<SolarYue>(12);
        var jieqiIndex = this.NianIndex * 24;
        var nextJie = new DateTime(SolarTables.JieQiTickTable[jieqiIndex]);
        jieqiIndex++;
        var nextJieDayNumber = DateOnly.FromDateTime(nextJie).DayNumber;

        var ganzhi = Ganzhi.FromIndex((this.Ganzhi.Tiangan.Index % 5) * 12 - 9);

        for (int i = 0; i < 12; i++)
        {
            var qi = new DateTime(SolarTables.JieQiTickTable[jieqiIndex]);
            jieqiIndex++;

            var jie = nextJie;
            var jieDayNumber = nextJieDayNumber;
            nextJie = new DateTime(SolarTables.JieQiTickTable[jieqiIndex]);
            jieqiIndex++;
            nextJieDayNumber = DateOnly.FromDateTime(nextJie).DayNumber;

            builder.Add(new SolarYue()
            {
                Nian = this,
                IndexInNian = i,
                Jieling = jie,
                Zhongqi = qi,
                RiCount = nextJieDayNumber - jieDayNumber,
                GanzhiOfFirstRi = Ganzhi.FromIndex(jieDayNumber - SolarTables.RI_GANZHI_GUIHAI),
                Ganzhi = ganzhi
            });
            ganzhi = ganzhi.Next();
        }
        return builder.MoveToImmutable();
    }
    #endregion

    #region converting
    /// <summary>
    /// 最小支持到的年（含）。
    /// The minimum supported Nian (included).
    /// </summary>
    public static SolarNian MinSupportedNian => new(0);
    /// <summary>
    /// 最大支持到的年（含）。
    /// The maximum supported Nian (included).
    /// </summary>
    public static SolarNian MaxSupportedNian => new(SolarTables.JieQiTickTable.Length / 24 - 1);

    /// <summary>
    /// 根据此年年首所在的公历年创建 <seealso cref="SolarNian"/> 的实例。
    /// Create an instance of <seealso cref="SolarNian"/> from the Gregorian year in which the first day of this Nian is.
    /// </summary>
    public static SolarNian FromGregorian(int year)
    {
        var nianIndex = year - SolarTables.STARTING_NIAN;
        if (nianIndex < 0 || nianIndex >= SolarTables.JieQiTickTable.Length / 24)
            throw new NotSupportedException($"The year ({year}) is not in the supported range.");
        return new SolarNian(nianIndex);
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return $"{this.Ganzhi}{this.Year}";
    }
    #endregion

    #region comparing
    /// <inheritdoc />
    public int CompareTo(SolarNian? other)
    {
        return this.NianIndex.CompareTo(other?.NianIndex);
    }

    /// <inheritdoc />
    public bool Equals(SolarNian? other)
    {
        return this.NianIndex.Equals(other?.NianIndex);
    }

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        if (obj is SolarNian other)
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
