using System.Numerics;

namespace YiJingFramework.PrimitiveTypes;

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
    /// <summary>
    /// 干支的序数。
    /// 如以 <c>1</c> 对应甲子。
    /// The index of the Ganzhi.
    /// For example, <c>1</c> represents Jiazi.
    /// </summary>
    public int Index { get; }

    /// <summary>
    /// 天干部分。
    /// The Tiangan part.
    /// </summary>
    public Tiangan Tiangan => new(this.Index);

    /// <summary>
    /// 地支部分。
    /// The Dizhi part.
    /// </summary>
    public Dizhi Dizhi => new(this.Index);

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
        tiangan = this.Tiangan;
        dizhi = this.Dizhi;
    }

    /// <summary>
    /// 初始化一个实例。
    /// Initialize an instance.
    /// </summary>
    /// <param name="index">
    /// 干支的序数。
    /// 如以 <c>1</c> 对应甲子。
    /// The index of the Ganzhi.
    /// For example, <c>1</c> represents Jiazi.
    /// </param>
    public Ganzhi(int index)
    {
        this.Index = ((index - 1) % 60 + 60) % 60 + 1;
    }

    /// <summary>
    /// 初始化一个实例。
    /// Initialize an instance.
    /// </summary>
    /// <param name="tiangan">
    /// 天干部分。
    /// The Tiangan part.
    /// </param>
    /// <param name="dizhi">
    /// 地支部分。
    /// The Dizhi part.
    /// </param>
    /// <exception cref="ArgumentException">
    /// 天干地支的阴阳属性不匹配。
    /// The Yinyangs of the Tiangan and the Dizhi do not match.
    /// </exception>
    public Ganzhi(Tiangan tiangan, Dizhi dizhi)
    {
        if (tiangan.Index % 2 != dizhi.Index % 2)
            throw new ArgumentException("The Yinyangs of the Tiangan and the Dizhi do not match.");
        this.Index = 6 * tiangan.Index - 5 * dizhi.Index;
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
        return new Ganzhi(this.Index + n);
    }

    /// <inheritdoc/>
    public static Ganzhi operator +(Ganzhi left, int right)
    {
        return left.Next(right);
    }

    /// <inheritdoc/>
    public static Ganzhi operator -(Ganzhi left, int right)
    {
        right = right % 60;
        return left.Next(-right);
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
    public string ToString(string? format, IFormatProvider? formatProvider)
    {
        return format switch
        {
            "G" or null => $"{this.Tiangan}{this.Dizhi.ToString().ToLowerInvariant()}",
            "C" => $"{this.Tiangan:C}{this.Dizhi:C}",
            _ => throw new FormatException()
        };
    }

    /// <inheritdoc/>
    public static explicit operator int(Ganzhi ganzhi)
    {
        return ganzhi.Index;
    }

    /// <inheritdoc/>
    public static explicit operator Ganzhi(int value)
    {
        return new Ganzhi(value);
    }
    #endregion

    #region comparing
    /// <inheritdoc/>
    public int CompareTo(Ganzhi other)
    {
        return this.Index.CompareTo(other.Index);
    }

    /// <inheritdoc/>
    public bool Equals(Ganzhi other)
    {
        return this.Index.Equals(other.Index);
    }

    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        if (obj is not Ganzhi other)
            return false;
        return this.Index.Equals(other.Index);
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        return this.Index.GetHashCode();
    }

    /// <inheritdoc/>
    public static bool operator ==(Ganzhi left, Ganzhi right)
    {
        return left.Index == right.Index;
    }

    /// <inheritdoc/>
    public static bool operator !=(Ganzhi left, Ganzhi right)
    {
        return left.Index != right.Index;
    }
    #endregion
}