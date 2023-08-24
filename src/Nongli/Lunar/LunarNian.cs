using System;
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
        this.yueListLazy = new(this.LoadYueList, true);
    }
    internal LunarNian(LunarNian nian) : this(nian.NianIndex) { }

    internal int NianIndex { get; }
    /// <summary>
    /// 年首所在的公历年。
    /// 不是全年都在此公历年内。
    /// The Gregorian year in which the first day of the Nian is.
    /// Not all the days in the Nian are in this Gregorian year.
    /// </summary>
    public int Year => this.NianIndex + LunarTables.STARTING_NIAN;
    /// <summary>
    /// 年干。
    /// The Nian's Tiangan.
    /// </summary>
    public Tiangan Niangan => new(LunarTables.STARTING_NIAN_GAN_INDEX + this.NianIndex);
    /// <summary>
    /// 年支。
    /// The Nian's Dizhi.
    /// </summary>
    public Dizhi Nianzhi => new(LunarTables.STARTING_NIAN_ZHI_INDEX + this.NianIndex);

    private readonly Lazy<IReadOnlyList<LunarYue>> yueListLazy;
    /// <summary>
    /// 此年中的月。
    /// Yues in the Nian.
    /// </summary>
    public IReadOnlyList<LunarYue> YueList => this.yueListLazy.Value;
    private IReadOnlyList<LunarYue> LoadYueList()
    {
        var yueCount = LunarTables.RunyueIndexTable[this.NianIndex] is 0 ? 12 : 13;
        return Enumerable.Range(0, yueCount)
             .Select(x => new LunarYue(this.NianIndex, x))
             .ToImmutableList();
    }
    #endregion

    #region converting
    public static LunarNian FromGregorian(int year)
    {
        var nianIndex = year - LunarTables.STARTING_NIAN;
        if(nianIndex < 0 || nianIndex >= LunarTables.NianStartDayNumberTable.Length)
            throw new NotSupportedException($"The year ({year}) is not in the supported range.");
        return new LunarNian(nianIndex);
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return $"{this.Niangan}-{this.Nianzhi} ({this.Year})";
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
