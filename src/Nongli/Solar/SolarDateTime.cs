using System.Diagnostics;
using YiJingFramework.Nongli.Extensions;
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

        var jielingDayNumber = DateOnly.FromDateTime(yue.Jieling).DayNumber;
        var zhongqiDayNumber = DateOnly.FromDateTime(yue.Zhongqi).DayNumber;
        this.IsBeforeYueZhongqi = jielingDayNumber + riIndex < zhongqiDayNumber;
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
    /// <summary>
    /// 指示当日是否还没有到月的中气。
    /// 此属性只按日期判断，不考虑时间。
    /// Indicate whether the date is before the Yue's Zhongqi or not.
    /// The property is determined only by the date, without considering the exact time.
    /// </summary>
    public bool IsBeforeYueZhongqi { get; }

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

    #region converting
    /// <summary>
    /// 从公历日期和时间创建表示相同时间的 <seealso cref="SolarDateTime"/> 的实例。
    /// 按交节当天换月，不考虑具体时间。
    /// 23 点后会被归为次日子时。
    /// Create an instance of <seealso cref="SolarDateTime"/> from a Gregorian date time which represent the same time.
    /// The Yue goes with the date of Jieling, without considering its exact time.
    /// And The time after 23 o'clock will be considered as the next day's Zishi.
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
            dateTime = dateTime.AddHours(1);

        var nextDay = dateTime.AddDays(1);
        var jieqiIndex = SolarTables.JieQiTickTable.SortedFindFloor(nextDay.Ticks);
        if (jieqiIndex is -1)
            throw NotSupportedDateTime(originalDateTime);

        var nextDayJieqi = new DateTime(SolarTables.JieQiTickTable[jieqiIndex]);
        if (DateOnly.FromDateTime(nextDayJieqi) == DateOnly.FromDateTime(nextDay))
            jieqiIndex--;
        if (jieqiIndex is -1 || jieqiIndex == SolarTables.JieQiTickTable.Length - 1)
            throw NotSupportedDateTime(originalDateTime);

        var nian = new SolarNian(jieqiIndex / 24);
        var yue = nian.YueList[(jieqiIndex % 24) / 2];
        var jie = yue.Jieling;
        var jieDayNumber = DateOnly.FromDateTime(jie).DayNumber;
        var daydifference = DateOnly.FromDateTime(dateTime).DayNumber - jieDayNumber;
        if (daydifference >= yue.RiCount)
            throw NotSupportedDateTime(originalDateTime);
        return new(yue, daydifference, new((dateTime.Hour + 3) / 2));
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
        var ri = DateOnly.FromDateTime(this.SolarYue.Jieling);
        ri = ri.AddDays(this.riIndex);
        return ri.ToDateTime(new TimeOnly((this.Shi.Index - 1) * 2, 0, 0));
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return $"N:{this.solarNian} " +
            $"Y:{this.Yue} " +
            $"R:{this.Ri} " +
            $"S:{this.Shi}";
    }
    #endregion

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
