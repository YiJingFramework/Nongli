using System.Diagnostics;
using System.Numerics;
using YiJingFramework.PrimitiveTypes;

namespace YiJingFramework.Nongli.Solar;

/// <summary>
/// 干支。
/// Ganzhi.
/// </summary>
public readonly struct Ganzhi :
    IComparable<Ganzhi>, IEquatable<Ganzhi>,
    IEqualityOperators<Ganzhi, Ganzhi, bool>,
    IAdditionOperators<Ganzhi, int, Ganzhi>,
    ISubtractionOperators<Ganzhi, int, Ganzhi>,
    IFormattable
{
    private readonly int indexMinusOne;

    /// <summary>
    /// 干支的序数。
    /// 如甲子为一。
    /// The index of the Ganzhi.
    /// For example, Jiazi's index is one.
    /// </summary>
    public int Index => this.indexMinusOne + 1;

    /// <summary>
    /// 天干部分。
    /// The Tiangan part.
    /// </summary>
    public Tiangan Tiangan => (Tiangan)this.Index;

    /// <summary>
    /// 地支部分。
    /// The Dizhi part.
    /// </summary>
    public Dizhi Dizhi => (Dizhi)this.Index;

    /// <summary>
    /// 析构此实体到天干和地支。
    /// Deconstruct the instance to a Tiangan and a Dizhi.
    /// </summary>
    /// <param name="tiangan">
    /// 天干部分。
    /// The Tiangan part.
    /// </param>
    /// <param name="dizhi">
    /// 地支部分。
    /// The Dizhi part.
    /// </param>
    public void Deconstruct(out Tiangan tiangan, out Dizhi dizhi)
    {
        var index = this.Index;
        tiangan = (Tiangan)index;
        dizhi = (Dizhi)index;
    }

    private Ganzhi(int indexMinusOneChecked)
    {
        Debug.Assert(indexMinusOneChecked is >= 0 and < 60);
        this.indexMinusOne = indexMinusOneChecked;
    }

    /// <summary>
    /// 通过序数创建一个 <seealso cref="Ganzhi"/> 。
    /// Create a <seealso cref="Ganzhi"/> with a Tiangan and a Dizhi.
    /// </summary>
    /// <param name="index">
    /// 序数。
    /// The index.
    /// </param>
    /// <returns>
    /// 干支。
    /// The Ganzhi.
    /// </returns>
    public static Ganzhi FromIndex(int index)
    {
        index %= 60;
        index += 60 - 1;
        return new Ganzhi(index % 60);
    }

    /// <summary>
    /// 通过天干地支创建一个 <seealso cref="Ganzhi"/> 。
    /// Create a <seealso cref="Ganzhi"/> with a Tiangan and a Dizhi.
    /// </summary>
    /// <param name="tiangan">
    /// 天干部分。
    /// The Tiangan part.
    /// </param>
    /// <param name="dizhi">
    /// 地支部分。
    /// The Dizhi part.
    /// </param>
    /// <returns>
    /// 干支。
    /// The Ganzhi.
    /// </returns>
    /// <exception cref="ArgumentException">
    /// 天干地支的阴阳属性不匹配。
    /// The Yinyangs of the Tiangan and the Dizhi do not match.
    /// </exception>
    public static Ganzhi FromGanzhi(Tiangan tiangan, Dizhi dizhi)
    {
        var tianganI = (int)tiangan;
        var dizhiI = (int)dizhi;
        if (tianganI % 2 != dizhiI % 2)
            throw new ArgumentException(
                $"The Yinyangs of the Tiangan {tiangan} and the Dizhi {dizhi} do not match.");
        return FromIndex(6 * tianganI - 5 * dizhiI);
    }


    /// <summary>
    /// 获取此干支的前下 <paramref name="n"/> 个干支。
    /// Get the <paramref name="n"/>th Ganzhi next to this instance.
    /// </summary>
    /// <param name="n">
    /// 数字 <paramref name="n"/> 。
    /// 可以小于零以表示另一个方向。
    /// The number <paramref name="n"/>.
    /// It could be smaller than zero which means the other direction.
    /// </param>
    /// <returns>
    /// 指定干支。
    /// The Ganzhi.
    /// </returns>
    public Ganzhi Next(int n = 1)
    {
        n %= 60;
        n += 60;
        n += this.indexMinusOne;
        return new Ganzhi(n % 60);
    }

    /// <inheritdoc/>
    public static Ganzhi operator +(Ganzhi left, int right)
    {
        right %= 60;
        right += 60;
        right += left.indexMinusOne;
        return new Ganzhi(right % 60);
    }

    /// <inheritdoc/>
    public static Ganzhi operator -(Ganzhi left, int right)
    {
        right %= 60;
        right = -right;
        right += 60;
        right += left.indexMinusOne;
        return new Ganzhi(right % 60);
    }

    #region converting
    /// <inheritdoc/>
    public override string ToString()
    {
        return this.ToString(null, null);
    }

    /// <summary>
    /// 按照指定格式转换为字符串。
    /// Convert to a string with the given format.
    /// </summary>
    /// <param name="format">
    /// 要使用的格式。
    /// <c>"G"</c> 表示拼音字母； <c>"C"</c> 表示中文。
    /// The format to be used.
    /// <c>"G"</c> represents the phonetic alphabets and <c>"C"</c> represents chinese characters.
    /// </param>
    /// <param name="formatProvider">
    /// 不会使用此参数。
    /// This parameter will won't be used.
    /// </param>
    /// <returns>
    /// 结果。
    /// The result.
    /// </returns>
    /// <exception cref="FormatException">
    /// 给出的格式化字符串不受支持。
    /// The given format is not supported.
    /// </exception>
    public string ToString(string? format, IFormatProvider? formatProvider = null)
    {
        var (tiangan, dizhi) = this;
        return format switch
        {
            "G" or null => $"{tiangan}{dizhi.ToString().ToLowerInvariant()}",
            "C" => $"{tiangan:C}{dizhi:C}",
            _ => throw new FormatException()
        };
    }

    /// <inheritdoc/>
    public static explicit operator int(Ganzhi ganzhi)
    {
        return ganzhi.indexMinusOne + 1;
    }

    /// <inheritdoc/>
    public static explicit operator Ganzhi(int value)
    {
        value %= 60;
        value += 60 - 1;
        return new Ganzhi(value % 60);
    }
    #endregion

    #region comparing
    /// <inheritdoc/>
    public int CompareTo(Ganzhi other)
    {
        return this.indexMinusOne.CompareTo(other.indexMinusOne);
    }

    /// <inheritdoc/>
    public bool Equals(Ganzhi other)
    {
        return this.indexMinusOne.Equals(other.indexMinusOne);
    }

    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        if (obj is not Ganzhi other)
            return false;
        return this.indexMinusOne.Equals(other.indexMinusOne);
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        return this.indexMinusOne.GetHashCode();
    }

    /// <inheritdoc/>
    public static bool operator ==(Ganzhi left, Ganzhi right)
    {
        return left.indexMinusOne == right.indexMinusOne;
    }

    /// <inheritdoc/>
    public static bool operator !=(Ganzhi left, Ganzhi right)
    {
        return left.indexMinusOne != right.indexMinusOne;
    }
    #endregion
}