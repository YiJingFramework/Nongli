using Lunar;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YiJingFramework.PrimitiveTypes;
using L = Lunar;

namespace YiJingFramework.Nongli.Lunar.Tests;

[TestClass()]
public class LunarDateTimeTests
{
    [TestMethod()]
    public void CorrectnessTest()
    {
        static void AssertSolar(Solar expected, DateTime actual)
        {
            Assert.AreEqual(expected.Year, actual.Year);
            Assert.AreEqual(expected.Month, actual.Month);
            Assert.AreEqual(expected.Day, actual.Day);
            Assert.AreEqual(expected.Hour, actual.Hour);
            Assert.AreEqual(expected.Minute, actual.Minute);
            Assert.AreEqual(expected.Second, actual.Second);
        }

        static void AssertLunar(L.Lunar expected, LunarDateTime actual)
        {
            Assert.AreEqual(expected.Year, actual.Year);
            Assert.AreEqual(expected.YearGan, actual.Niangan.ToString("C"));
            Assert.AreEqual(expected.YearZhi, actual.Nianzhi.ToString("C"));
            Assert.AreEqual(expected.Year, actual.LunarNian.Year);
            Assert.AreEqual(expected.YearGan, actual.LunarNian.Niangan.ToString("C"));
            Assert.AreEqual(expected.YearZhi, actual.LunarNian.Nianzhi.ToString("C"));

            Assert.AreEqual(expected.Month,
                actual.IsRunyue ? -actual.Yue : actual.Yue);
            Assert.AreEqual(expected.Month,
                actual.LunarYue.IsRunyue ? -actual.LunarYue.Yue : actual.LunarYue.Yue);

            Assert.AreEqual(expected.Day, actual.Ri);
            Assert.AreEqual(expected.TimeZhi, actual.Shi.ToString("C"));
        }

        var minDateTime = LunarNian.MinSupportedNian.YueList[0].GetDateTime(1, Dizhi.Zi).ToGregorian();
        var minSolarL = L.Lunar.FromYmdHms(
            lunarYear: LunarNian.MinSupportedNian.Year,
            lunarMonth: 1,
            lunarDay: 1,
            hour: 0).Solar;
        AssertSolar(minSolarL, minDateTime);

        var maxDateTime = LunarNian.MaxSupportedNian.YueList[^1].GetDateTime(
            LunarNian.MaxSupportedNian.YueList[^1].RiCount, Dizhi.Hai)
            .ToGregorian();
        var maxSolarL = L.Lunar.FromYmdHms(
            lunarYear: LunarNian.MaxSupportedNian.Year,
            lunarMonth: 12,
            lunarDay: LunarYear.FromYear(LunarNian.MaxSupportedNian.Year).MonthsInYear[^1].DayCount,
            hour: 22).Solar;
        AssertSolar(maxSolarL, maxDateTime);

        IEnumerable<DateTime> EnumerateTestingDateTime()
        {
            for (var dt = minDateTime; dt <= maxDateTime; dt = dt.AddHours(2))
                yield return dt;
        }
        EnumerateTestingDateTime().AsParallel().ForAll(dt =>
        {
            var lunarDt = LunarDateTime.FromGregorian(dt);
            AssertLunar(L.Lunar.FromDate(dt), lunarDt);
            Assert.AreEqual(dt, lunarDt.ToGregorian());
        });
    }

    [TestMethod()]
    public void OtherTests()
    {
        Assert.Fail();
    }
}