using System.Diagnostics;
using YiJingFramework.PrimitiveTypes;

namespace YiJingFramework.Nongli.Solar;

/// <summary>
/// 农历（阳历部分）的日期和时间。
/// A date time of Nongli (solar part).
/// </summary>
public sealed partial class SolarDateTime : IComparable<SolarDateTime>, IEquatable<SolarDateTime>
{
    #region defining
    internal SolarDateTime(SolarYue yue, int riIndex, Dizhi shi)
    {
        this.solarNian = yue.Nian;
        this.SolarYue = yue;
        this.riIndex = riIndex;
        this.Ri = yue.GanzhiOfFirstRi.Next(riIndex);
        this.Shi = new((this.Ri.Tiangan.Index % 5) * 12 - 11 + shi.Index - 1);
    }

    private readonly SolarNian solarNian;
    /// <summary>
    /// 年，以 <seealso cref="Solar.SolarNian"/> 为结果类型。
    /// The Nian, with <seealso cref="Solar.SolarNian"/> as the result type.
    /// </summary>
    public SolarNian SolarNian => new(this.solarNian.NianIndex);
    /// <summary>
    /// 年首所在的公历年。
    /// 当前日期不一定位于此公历年。
    /// The Gregorian year in which the first day of the Nian is.
    /// The current date does not necessarily be in this Gregorian year.
    /// </summary>
    public int Year => this.solarNian.Year;
    /// <summary>
    /// 年。
    /// The Nian.
    /// </summary>
    public Ganzhi Nian => this.solarNian.Ganzhi;

    /// <summary>
    /// 月，以 <seealso cref="Solar.SolarYue"/> 为结果类型。
    /// The Yue, with <seealso cref="Solar.SolarYue"/> as the result type.
    /// </summary>
    public SolarYue SolarYue { get; }
    /// <summary>
    /// 月。
    /// The Yue.
    /// </summary>
    public Ganzhi Yue => this.SolarYue.Ganzhi;

    private readonly int riIndex;
    /// <summary>
    /// 日。
    /// The Ri.
    /// </summary>
    public Ganzhi Ri { get; }
    /// <summary>
    /// 时。
    /// The Shi.
    /// </summary>
    public Ganzhi Shi { get; }
    #endregion

    /*
    #region converting
    /// <summary>
    /// 从公历日期和时间创建表示相同时间的 <seealso cref="SolarDateTime"/> 的实例。
    /// 23 点后会被归为次日子时。
    /// Create an instance of <seealso cref="SolarDateTime"/> from a Gregorian date time which represent the same time.
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
    public static SolarDateTime FromGregorian(DateTime dateTime)
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
        foreach (var yue in nian.YueList)
        {
            var newRest = restDayCount - yue.RiCount;
            if (newRest < 0)
                return new(yue, restDayCount + 1, new((dateTime.Hour + 3) / 2));
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
        var nianIndex = this.solarNian.NianIndex;
        var dayNumber = LunarTables.NianStartDayNumberTable[nianIndex];
        foreach (var yue in new LunarNian(nianIndex).YueList)
        {
            if (yue.YueIndexInNian == this.LunarYue.YueIndexInNian)
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
        return $"N:{this.solarNian} " +
            $"Y:{(this.IsRunyue ? 'L' : 'C')}{this.Yue:00} " +
            $"R:{this.Ri:00} " +
            $"S:{this.Shi}";
    }
    #endregion
    */

    #region comparing
    /// <inheritdoc />
    public int CompareTo(SolarDateTime? other)
    {
        var result = this.SolarYue.CompareTo(other?.SolarYue);
        if (result is not 0)
            return result;
        Debug.Assert(other is not null);

        result = this.riIndex.CompareTo(other.riIndex);
        if (result is not 0)
            return result;

        return this.Shi.CompareTo(other.Shi);
    }

    /// <inheritdoc />
    public bool Equals(SolarDateTime? other)
    {
        if (!this.SolarYue.Equals(other?.SolarYue))
            return false;
        if (!this.riIndex.Equals(other.riIndex))
            return false;
        return this.Shi.Equals(other.Shi);
    }

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        if (obj is SolarDateTime other)
            return this.Equals(other);
        return false;
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        return HashCode.Combine(this.SolarYue, this.riIndex, this.Shi);
    }
    #endregion
}
