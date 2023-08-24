using System.Collections.Immutable;
using System.Diagnostics;
using YiJingFramework.PrimitiveTypes;

namespace YiJingFramework.Nongli.Lunar;

public sealed class LunarNian : IComparable<LunarNian>, IEquatable<LunarNian>
{
    internal LunarNian(int checkedNianIndex)
    {
        Debug.Assert(checkedNianIndex >= 0 && checkedNianIndex < LunarTables.NianStartDayNumberTable.Length);
        this.NianIndex = checkedNianIndex;
        this.yueListLazy = new(LoadYueList, true);
    }
    internal LunarNian(LunarNian nian) : this(nian.NianIndex) { }

    internal int NianIndex { get; }
    public int Year => NianIndex + LunarTables.STARTING_NIAN;
    public Tiangan Niangan => new(LunarTables.STARTING_NIAN_GAN_INDEX + NianIndex);
    public Dizhi Nianzhi => new(LunarTables.STARTING_NIAN_ZHI_INDEX + NianIndex);

    private readonly Lazy<IReadOnlyList<LunarYue>> yueListLazy;
    public IReadOnlyList<LunarYue> YueList => yueListLazy.Value;
    private IReadOnlyList<LunarYue> LoadYueList()
    {
        var yueCount = LunarTables.RunyueIndexTable[this.NianIndex] is 0 ? 12 : 13;
        return Enumerable.Range(0, yueCount)
             .Select(x => new LunarYue(this.NianIndex, x))
             .ToImmutableList();
    }

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

    /// <inheritdoc />
    public override string ToString()
    {
        return $"{Niangan}-{Nianzhi} ({Year})";
    }
}
