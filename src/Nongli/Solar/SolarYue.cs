using System.Diagnostics;
using YiJingFramework.PrimitiveTypes;

namespace YiJingFramework.Nongli.Solar;

/// <summary>
/// 农历（阳历部分）的月。
/// A Yue of Nongli (solar part).
/// </summary>
public sealed class SolarYue : IComparable<SolarYue>, IEquatable<SolarYue>
{
    #region defining
    internal SolarYue() { }

    private readonly int nianIndex;
    /// <summary>
    /// 此月所属的年。
    /// The Nian to which this Yue belongs.
    /// </summary>
    public required SolarNian Nian
    {
        get => new SolarNian(this.nianIndex);
        init => this.nianIndex = value.NianIndex;
    }

    /// <summary>
    /// 此月在 <seealso cref="SolarNian.YueList"/> 中的序号。
    /// The index of this Yue in <seealso cref="SolarNian.YueList"/>.
    /// </summary>
    public required int YueIndexInNian { get; init; }

    /// <summary>
    /// 月干支。
    /// This Yue's Ganzhi.
    /// </summary>
    public required Ganzhi Ganzhi { get; init; }

    /// <summary>
    /// 此月中的第一日的干支。
    /// Ganzhi of the first Ri in this Yue.
    /// </summary>
    public required Ganzhi GanzhiOfFirstRi { get; init; }

    /// <summary>
    /// 此月中日的数量。
    /// Count of the Ris in this Yue.
    /// </summary>
    public required int RiCount { get; init; }

    /// <summary>
    /// 此月节令时间。
    /// Time of this Yue's Jieling.
    /// </summary>
    public required DateTime Jieling { get; init; }

    /// <summary>
    /// 此月中气时间。
    /// Time of this Yue's Zhongqi.
    /// </summary>
    public required DateTime Zhongqi { get; init; }
    #endregion

    #region converting
    /// <summary>
    /// 获取此月中的 <seealso cref="SolarDateTime"/> 。
    /// Get a <seealso cref="SolarDateTime"/> in this Yue.
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
    /// <paramref name="ri"/> 不存在于此月中。
    /// <paramref name="ri"/> does not exist in this Yue.
    /// </exception>
    public SolarDateTime GetDateTime(Ganzhi ri, Dizhi shi)
    {
        var difference = ri.Index - this.GanzhiOfFirstRi.Index;
        if (difference < 0)
            difference += 60;
        if (difference >= this.RiCount)
            throw new ArgumentOutOfRangeException(nameof(ri));
        return new SolarDateTime(this, difference, shi);
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return $"{this.Ganzhi} ({this.Nian}[{this.YueIndexInNian}])";
    }
    #endregion

    #region comparing
    /// <inheritdoc />
    public int CompareTo(SolarYue? other)
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
    public bool Equals(SolarYue? other)
    {
        if (!this.nianIndex.Equals(other?.nianIndex))
            return false;
        return this.YueIndexInNian.Equals(other.YueIndexInNian);
    }

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        return this.Equals(obj as SolarYue);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        return HashCode.Combine(this.nianIndex, this.YueIndexInNian);
    }
    #endregion
}
