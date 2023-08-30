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
    internal LunarYue() { }

    private readonly int nianIndex;
    /// <summary>
    /// 此月所属的年。
    /// The Nian to which this Yue belongs.
    /// </summary>
    public required LunarNian Nian
    {
        get => new LunarNian(this.nianIndex);
        init => this.nianIndex = value.NianIndex;
    }

    /// <summary>
    /// 此月在 <seealso cref="LunarNian.Yues"/> 中的序号。
    /// The index of this Yue in <seealso cref="LunarNian.Yues"/>.
    /// </summary>
    public required int IndexInNian { get; init; }

    /// <summary>
    /// 月的序数。
    /// 与 <seealso cref="IndexInNian"/> 不同，这个属性从 <c>1</c> 开始且计数时跳过闰月。
    /// The index of this Yue.
    /// Unlike <seealso cref="IndexInNian"/>, this property starts from <c>1</c> and the Runyues are skipped when counting.
    /// </summary>
    public required int Index { get; init; }

    /// <summary>
    /// 指示此月是否为闰月。
    /// Indicates whether this Yue is a Runye.
    /// </summary>
    public required bool IsRunyue { get; init; }

    /// <summary>
    /// 此月中的第一日的序数。
    /// 此属性的值始终为 <c>1</c> 。
    /// Index of the first Ri in this Yue.
    /// This property will always return <c>1</c>.
    /// </summary>
    public required int IndexOfFirstRi { get; init; }

    /// <summary>
    /// 此月中日的数量。
    /// Count of the Ris in this Yue.
    /// </summary>
    public required int RiCount { get; init; }
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
    /// <paramref name="ri"/> 不在 <seealso cref="IndexOfFirstRi"/> 到 <seealso cref="RiCount"/> 的范围内。
    /// <paramref name="ri"/> is not in the range (from <seealso cref="IndexOfFirstRi"/> to <seealso cref="RiCount"/>).
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
        return $"{(this.IsRunyue ? 'L' : 'C')}{this.Index} ({this.Nian}[{this.IndexInNian}])";
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
            return this.IndexInNian.CompareTo(other.IndexInNian);
        }
        return result;
    }

    /// <inheritdoc />
    public bool Equals(LunarYue? other)
    {
        if (!this.nianIndex.Equals(other?.nianIndex))
            return false;
        return this.IndexInNian.Equals(other.IndexInNian);
    }

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        return this.Equals(obj as LunarYue);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        return HashCode.Combine(this.nianIndex, this.IndexInNian);
    }
    #endregion
}
