using Microsoft.VisualStudio.TestTools.UnitTesting;
using YiJingFramework.Nongli.Solar;

namespace YiJingFramework.Nongli.Extensions.Tests;

[TestClass()]
public class SolarDateTimeInChineseExtensionsTests
{
    [TestMethod()]
    public void YearInChineseTest()
    {
        var dateTime = new DateTime(2023, 8, 16, 12, 41, 23);
        var lunar = SolarDateTime.FromGregorian(dateTime);

        Assert.AreEqual("二〇二三", lunar.YearInChinese());
        Assert.AreEqual("二零二三", lunar.YearInChinese('零'));
    }
}