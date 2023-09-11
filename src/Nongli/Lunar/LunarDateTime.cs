using System.Diagnostics;
using YiJingFramework.Nongli.Extensions;
using YiJingFramework.Nongli.Solar;
using YiJingFramework.PrimitiveTypes;

namespace YiJingFramework.Nongli.Lunar;

/// <summary>
/// 农历（阴历部分）的日期和时间。
/// A date time of Nongli (lunar part).
/// </summary>
public sealed partial class LunarDateTime : IComparable<LunarDateTime>, IEquatable<LunarDateTime>
{
    #region defining
    internal LunarDateTime(LunarYue yue, int riChecked, Dizhi shi)
    {
        Debug.Assert(riChecked > 0 || riChecked <= yue.RiCount);
        this.lunarNian = yue.Nian;
        this.LunarYue = yue;
        this.Ri = riChecked;
        this.Shi = shi;
    }

    private readonly LunarNian lunarNian;
    /// <summary>
    /// 年，以 <seealso cref="Lunar.LunarNian"/> 为结果类型。
    /// The Nian, with <seealso cref="Lunar.LunarNian"/> as the result type.
    /// </summary>
    public LunarNian LunarNian => new(this.lunarNian.NianIndex);
    /// <summary>
    /// 年首所在的公历年。
    /// 当前日期不一定位于此公历年。
    /// The Gregorian year in which the first day of the Nian is.
    /// The current date does not necessarily be in this Gregorian year.
    /// </summary>
    public int Year => this.lunarNian.Year;
    /// <summary>
    /// 年干支。
    /// The Nian's Ganzhi.
    /// </summary>
    public Ganzhi Nian => this.lunarNian.Ganzhi;

    /// <summary>
    /// 月，以 <seealso cref="Lunar.LunarYue"/> 为结果类型。
    /// The Yue, with <seealso cref="Lunar.LunarYue"/> as the result type.
    /// </summary>
    public LunarYue LunarYue { get; }
    /// <summary>
    /// 月。
    /// The Yue.
    /// </summary>
    public int Yue => this.LunarYue.Index;
    /// <summary>
    /// 指示月是否为闰月。
    /// Indicate whether the Yue is a Runyue.
    /// </summary>
    public bool IsRunyue => this.LunarYue.IsRunyue;

    /// <summary>
    /// 日。
    /// The Ri.
    /// </summary>
    public int Ri { get; }
    /// <summary>
    /// 时。
    /// The Shi.
    /// </summary>
    public Dizhi Shi { get; }
    #endregion

    #region converting
    /// <summary>
    /// 从公历日期和时间创建表示相同时间的 <seealso cref="LunarDateTime"/> 的实例。
    /// 23 点后会被归为次日子时。
    /// Create an instance of <seealso cref="LunarDateTime"/> from a Gregorian date time which represent the same time.
    /// The time after 23 o'clock will be considered as the next day's Zishi.
    /// </summary>
    /// <param name="dateTime">
    /// 公历日期和时间。
    /// The Gregorian date time.
    /// </param>
    /// <returns>
    /// 转换结果。
    /// The conversion result.
    /// </returns>
    /// <exception cref="NotSupportedException">
    /// 传入的公历日期和时间不在支持范围内。
    /// The given Gregorian date time is not in the supported range.
    /// </exception>
    public static LunarDateTime FromGregorian(DateTime dateTime)
    {
        static NotSupportedException NotSupportedDateTime(DateTime dateTime)
        {
            return new NotSupportedException(
                $"The date time ({dateTime:yyyy/MM/dd HH:mm}) is not in the supported range.");
        }

        var originalDateTime = dateTime;
        if (dateTime.Hour is 23)
            dateTime = dateTime.Add(new TimeSpan(1, 0, 0));

        var dayNumber = DateOnly.FromDateTime(dateTime).DayNumber;
        var nianIndex = LunarTables.NianStartDayNumberTable.SortedFindFloor(dayNumber);
        if (nianIndex is -1)
            throw NotSupportedDateTime(originalDateTime);

        var restDayCount = dayNumber - LunarTables.NianStartDayNumberTable[nianIndex];
        var nian = new LunarNian(nianIndex);
        foreach (var yue in nian.Yues)
        {
            var newRest = restDayCount - yue.RiCount;
            if (newRest < 0)
                return new(yue, restDayCount + 1, Dizhi.FromIndex((dateTime.Hour + 3) / 2));
            restDayCount = newRest;
        }
        throw NotSupportedDateTime(originalDateTime);
    }

    /// <summary>
    /// 创建表示相同时间的公历日期和时间。
    /// 会使用时辰中间的时间作为小时数，如子时会返回零点。
    /// Create a Gregorian date time which represents the same time.
    /// The value of hour will be the the middle time of Shi, for example Zishi will be 0 o'clock.
    /// </summary>
    /// <returns>
    /// 转换结果。
    /// The conversion result.
    /// </returns>
    public DateTime ToGregorian()
    {
        var nianIndex = this.lunarNian.NianIndex;
        var dayNumber = LunarTables.NianStartDayNumberTable[nianIndex];
        foreach (var yue in new LunarNian(nianIndex).Yues)
        {
            if (yue.IndexInNian == this.LunarYue.IndexInNian)
            {
                dayNumber += this.Ri - 1;
                break;
            }
            dayNumber += yue.RiCount;
        }
        var dateOnly = DateOnly.FromDayNumber(dayNumber);
        return dateOnly.ToDateTime(new TimeOnly((this.Shi.Index - 1) * 2, 0, 0));
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return $"N:{this.lunarNian} " +
            $"Y:{(this.IsRunyue ? 'L' : 'C')}{this.Yue:00} " +
            $"R:{this.Ri:00} " +
            $"S:{this.Shi}";
    }
    #endregion

    #region comparing
    /// <inheritdoc />
    public int CompareTo(LunarDateTime? other)
    {
        var result = this.LunarYue.CompareTo(other?.LunarYue);
        if (result is not 0)
            return result;
        Debug.Assert(other is not null);

        result = this.Ri.CompareTo(other.Ri);
        if (result is not 0)
            return result;

        return this.Shi.CompareTo(other.Shi);
    }

    /// <inheritdoc />
    public bool Equals(LunarDateTime? other)
    {
        if (!this.LunarYue.Equals(other?.LunarYue))
            return false;
        if (!this.Ri.Equals(other.Ri))
            return false;
        return this.Shi.Equals(other.Shi);
    }

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        if (obj is LunarDateTime other)
            return this.Equals(other);
        return false;
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        return HashCode.Combine(this.LunarYue, this.Ri, this.Shi);
    }
    #endregion
}
