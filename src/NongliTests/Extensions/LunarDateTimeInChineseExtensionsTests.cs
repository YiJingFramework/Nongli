using Microsoft.VisualStudio.TestTools.UnitTesting;
using YiJingFramework.Nongli.Lunar;

namespace YiJingFramework.Nongli.Extensions.Tests;

[TestClass()]
public class LunarDateTimeInChineseExtensionsTests
{
    [TestMethod()]
    public void YearInChineseTest()
    {
        var dateTime = new DateTime(2023, 8, 16, 12, 41, 23);
        var lunar = LunarDateTime.FromGregorian(dateTime);

        Assert.AreEqual("二〇二三", lunar.YearInChinese());
        Assert.AreEqual("二零二三", lunar.YearInChinese('零'));
    }

    [TestMethod()]
    public void YueInChineseTest()
    {
        var dateTime = new DateTime(2023, 8, 16, 12, 41, 23);
        var lunar = LunarDateTime.FromGregorian(dateTime);
        Assert.AreEqual("七", lunar.YueInChinese());

        dateTime = new DateTime(2023, 4, 19, 12, 41, 23);
        lunar = LunarDateTime.FromGregorian(dateTime);
        Assert.AreEqual("闰二", lunar.YueInChinese());

        dateTime = new DateTime(2022, 8, 5, 12, 41, 23);
        lunar = LunarDateTime.FromGregorian(dateTime);
        Assert.AreEqual("七", lunar.YueInChinese());

        dateTime = new DateTime(2023, 2, 17, 12, 41, 23);
        lunar = LunarDateTime.FromGregorian(dateTime);
        Assert.AreEqual("正", lunar.YueInChinese());
        Assert.AreEqual("一", lunar.YueInChinese(useZhengFor1: false));

        dateTime = new DateTime(2023, 12, 15, 12, 41, 23);
        lunar = LunarDateTime.FromGregorian(dateTime);
        Assert.AreEqual("冬", lunar.YueInChinese());
        Assert.AreEqual("十一", lunar.YueInChinese(useDongFor11: false));

        dateTime = new DateTime(2024, 1, 17, 12, 41, 23);
        lunar = LunarDateTime.FromGregorian(dateTime);
        Assert.AreEqual("腊", lunar.YueInChinese());
        Assert.AreEqual("十二", lunar.YueInChinese(useLaFor12: false));
    }

    [TestMethod()]
    public void RiInChineseTest()
    {
        var dateTime = new DateTime(2023, 8, 15, 12, 41, 23);
        var lunar = LunarDateTime.FromGregorian(dateTime);
        Assert.AreEqual("廿九", lunar.RiInChinese());
        Assert.AreEqual("二十九", lunar.RiInChinese(false));
    }
}