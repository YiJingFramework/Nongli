using System.Diagnostics;
using YiJingFramework.PrimitiveTypes;

namespace YiJingFramework.Nongli.Lunar;

/// <summary>
/// 农历（阴历部分）的月。
/// A Yue of Nongli (lunar part).
/// </summary>
public sealed class LunarYue : IComparable<LunarYue>, IEquatable<LunarYue>
{
    #region defining
    internal LunarYue(int nianIndex, int yueIndexInNian)
    {
        this.nianIndex = nianIndex;
        this.YueIndexInNian = yueIndexInNian;
    }

    private readonly int nianIndex;
    /// <summary>
    /// 此月在 <seealso cref="LunarNian.YueList"/> 中的序号。
    /// The index of this Yue in <seealso cref="LunarNian.YueList"/>.
    /// </summary>
    public int YueIndexInNian { get; }

    /// <summary>
    /// 此月所属的年。
    /// The Nian to which this Yue belongs.
    /// </summary>
    public LunarNian Nian => new LunarNian(this.nianIndex);

    /// <summary>
    /// 月的序数。
    /// 与 <seealso cref="YueIndexInNian"/> 不同，这个属性从 <c>1</c> 开始且计数时跳过闰月。
    /// The index of this Yue.
    /// Unlike <seealso cref="YueIndexInNian"/>, this property starts from <c>1</c> and the Runyues are skipped when counting.
    /// </summary>
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

    /// <summary>
    /// 指示此月是否为闰月。
    /// Indicates whether this Yue is a Runye.
    /// </summary>
    public bool IsRunyue
    {
        get
        {
            // TODO: 这样的话是不是把闰月改成负一之类的会更好一些？
            return this.YueIndexInNian is not 0 &&
                LunarTables.RunyueIndexTable[this.nianIndex] == this.YueIndexInNian;
        }
    }

    /// <summary>
    /// 此月中日的数量。
    /// Count of the Ris in this Yue.
    /// </summary>
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
    /// <summary>
    /// 获取此月中的 <seealso cref="LunarDateTime"/> 。
    /// Get a <seealso cref="LunarDateTime"/> in this Yue.
    /// </summary>
    /// <param name="ri">
    /// 日。
    /// The Ri.
    /// </param>
    /// <param name="shi">
    /// 时。
    /// The Shi.
    /// </param>
    /// <returns>
    /// 结果。
    /// The result.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="ri"/> 不在 <c>1</c> 到 <seealso cref="RiCount"/> 的范围内。
    /// <paramref name="ri"/> is not in the range (from <c>1</c> to <seealso cref="RiCount"/>).
    /// </exception>
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
            $"({nian.Niangan}{nian.Nianzhi}{nian.Year}[{this.YueIndexInNian}])";
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
