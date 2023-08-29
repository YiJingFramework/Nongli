using YiJingFramework.Nongli.Solar;

namespace YiJingFramework.Nongli.Extensions;

/// <summary>
/// 帮助将 <seealso cref="SolarDateTime"/> 转为中文表示的扩展。
/// Extensions that helps to convert <seealso cref="SolarDateTime"/> to its Chinese representation.
/// </summary>
public static class SolarDateTimeInChineseExtensions
{
    /// <summary>
    /// 取公历年的中文表示。
    /// Get the Chinese representation of the Gregorian year.
    /// </summary>
    /// <param name="solar">
    /// <c>this</c> 。
    /// <c>this</c>.
    /// </param>
    /// <param name="zero">
    /// 零的表示方法。
    /// The representation of zeros.
    /// </param>
    /// <returns>
    /// 结果。
    /// The result.
    /// </returns>
    public static string YearInChinese(this SolarDateTime solar, char zero = '〇')
    {
        return LunarDateTimeInChineseExtensions.YearInChinese(solar.Year, zero);
    }
}
