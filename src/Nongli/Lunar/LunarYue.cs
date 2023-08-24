using System.Diagnostics;
using YiJingFramework.PrimitiveTypes;

namespace YiJingFramework.Nongli.Lunar;

public sealed class LunarYue : IComparable<LunarYue>, IEquatable<LunarYue>
{
    #region defining
    internal LunarYue(int nianIndex, int yueIndexInNian)
    {
        this.nianIndex = nianIndex;
        this.YueIndexInNian = yueIndexInNian;
    }

    private readonly int nianIndex;
    public int YueIndexInNian { get; }

    public LunarNian Nian => new LunarNian(this.nianIndex);
    public int Yue
    {
        get
        {
            var runyue = LunarTables.RunyueIndexTable[this.nianIndex];
            if (runyue is 0 || this.YueIndexInNian < runyue)
                return this.YueIndexInNian + 1;
            else
                return this.YueIndexInNian;
        }
    }
    public bool IsRunyue => LunarTables.RunyueIndexTable[this.nianIndex] == this.YueIndexInNian;
    public int RiCount
    {
        get
        {
            var mask = 0b1_0000_0000_0000 >> this.YueIndexInNian;
            var big = (LunarTables.RiCountOfYueTable[this.nianIndex] & mask) > 0;
            return big ? 30 : 29;
        }
    }
    #endregion

    #region converting
    public LunarDateTime GetDateTime(int ri, Dizhi shi)
    {
        if (ri <= 0 || ri > this.RiCount)
            throw new ArgumentOutOfRangeException(nameof(ri));
        return new LunarDateTime(this, ri, shi);
    }

    /// <inheritdoc />
    public override string ToString()
    {
        var nian = this.Nian;
        return $"{(this.IsRunyue ? 'L' : 'C')}{this.Yue} " +
            $"({nian.Niangan}{nian.Nianzhi}{this.Nian.Year}[{this.YueIndexInNian}])";
    }
    #endregion

    #region comparing
    /// <inheritdoc />
    public int CompareTo(LunarYue? other)
    {
        var result = this.nianIndex.CompareTo(other?.nianIndex);
        if (result is 0)
        {
            Debug.Assert(other is not null);
            return this.YueIndexInNian.CompareTo(other.YueIndexInNian);
        }
        return result;
    }

    /// <inheritdoc />
    public bool Equals(LunarYue? other)
    {
        if (!this.nianIndex.Equals(other?.nianIndex))
            return false;
        return this.YueIndexInNian.Equals(other.YueIndexInNian);
    }

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        return this.Equals(obj as LunarYue);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        return HashCode.Combine(this.nianIndex, this.YueIndexInNian);
    }
    #endregion
}
