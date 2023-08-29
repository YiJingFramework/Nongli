using System.Diagnostics;
using YiJingFramework.Nongli.Lunar;

namespace YiJingFramework.Nongli.Extensions;

/// <summary>
/// 帮助将 <seealso cref="LunarDateTime"/> 转为中文表示的扩展。
/// Extensions that helps to convert <seealso cref="LunarDateTime"/> to its Chinese representation.
/// </summary>
public static class LunarDateTimeInChineseExtensions
{
    internal static string YearInChinese(int yearNotNegative, char zero)
    {
        static IEnumerable<int> GetDigits(int valueNotNegative)
        {
            Debug.Assert(valueNotNegative >= 0);
            for (; valueNotNegative > 0;)
            {
                (valueNotNegative, var r) = Math.DivRem(valueNotNegative, 10);
                yield return r;
            }
        }

        char DigitCharacter(int iBetweenZeroAndTen)
        {
            Debug.Assert(iBetweenZeroAndTen is >= 0 and < 10);
            return iBetweenZeroAndTen switch
            {
                1 => '一',
                2 => '二',
                3 => '三',
                4 => '四',
                5 => '五',
                6 => '六',
                7 => '七',
                8 => '八',
                9 => '九',
                _ => zero
            };
        }

        Debug.Assert(yearNotNegative >= 0);
        var digits = GetDigits(yearNotNegative).Select(DigitCharacter);
        return string.Concat(digits.Reverse());
    }

    /// <summary>
    /// 取公历年的中文表示。
    /// Get the Chinese representation of the Gregorian year.
    /// </summary>
    /// <param name="lunar">
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
    public static string YearInChinese(this LunarDateTime lunar, char zero = '〇')
    {
        return YearInChinese(lunar.Year, zero);
    }

    /// <summary>
    /// 取月的中文表示。
    /// Get the Chinese representation of the Yue.
    /// </summary>
    /// <param name="lunar">
    /// <c>this</c> 。
    /// <c>this</c>.
    /// </param>
    /// <param name="useZhengFor1">
    /// 使用 <c>"正"</c> 表示一月。
    /// Use <c>"正"</c> for the first Yue.
    /// </param>
    /// <param name="useDongFor11">
    /// 使用 <c>"冬"</c> 表示十一月。
    /// Use <c>"冬"</c> for the eleventh Yue.
    /// </param>
    /// <param name="useLaFor12">
    /// 使用 <c>"腊"</c> 表示十二月。
    /// Use <c>"腊"</c> for the twelfth Yue.
    /// </param>
    /// <returns>
    /// 结果。
    /// The result.
    /// </returns>
    public static string YueInChinese(
        this LunarDateTime lunar,
        bool useZhengFor1 = true,
        bool useDongFor11 = true,
        bool useLaFor12 = true)
    {
        Debug.Assert(lunar.Yue is >= 1 and <= 12);
        var result = lunar.Yue switch
        {
            1 => useZhengFor1 ? "正" : "一",
            2 => "二",
            3 => "三",
            4 => "四",
            5 => "五",
            6 => "六",
            7 => "七",
            8 => "八",
            9 => "九",
            10 => "十",
            11 => useDongFor11 ? "冬" : "十一",
            _ => useLaFor12 ? "腊" : "十二"
        };
        return lunar.IsRunyue ? $"闰{result}" : result;
    }

    /// <summary>
    /// 取日的中文表示。
    /// Get the Chinese representation of the Ri.
    /// </summary>
    /// <param name="lunar">
    /// <c>this</c> 。
    /// <c>this</c>.
    /// </param>
    /// <param name="useNianFor20s">
    /// 使用 <c>"廿"</c> 表示二十几。
    /// Use <c>"廿"</c> for the twenties.
    /// </param>
    /// <returns>
    /// 结果。
    /// The result.
    /// </returns>
    public static string RiInChinese(
        this LunarDateTime lunar, 
        bool useNianFor20s = true)
    {
        var (tens, ones) = Math.DivRem(lunar.Ri, 10);
        if (ones is 0)
        {
            Debug.Assert(tens is >= 1 and <= 3);
            return tens switch
            {
                1 => $"初十",
                2 => $"二十",
                _ => $"三十",
            };
        }

        Debug.Assert(ones is >= 1 and <= 9);
        var onesCharacter = ones switch
        {
            1 => '一',
            2 => '二',
            3 => '三',
            4 => '四',
            5 => '五',
            6 => '六',
            7 => '七',
            8 => '八',
            _ => '九',
        };
        Debug.Assert(tens is 1 or 2);
        return tens switch
        {
            0 => $"初{onesCharacter}",
            1 => $"十{onesCharacter}",
            _ => useNianFor20s ? $"廿{onesCharacter}" : $"二十{onesCharacter}",
        };
    }
}
