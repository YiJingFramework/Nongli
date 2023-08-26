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
        static void AssertGregorian(L.Solar expected, DateTime actual)
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
            Assert.AreEqual(expected.YearGan, actual.Nian.Tiangan.ToString("C"));
            Assert.AreEqual(expected.YearZhi, actual.Nian.Dizhi.ToString("C"));
            Assert.AreEqual(expected.Year, actual.LunarNian.Year);
            Assert.AreEqual(expected.YearGan, actual.LunarNian.Ganzhi.Tiangan.ToString("C"));
            Assert.AreEqual(expected.YearZhi, actual.LunarNian.Ganzhi.Dizhi.ToString("C"));

            Assert.AreEqual(expected.Month,
                actual.IsRunyue ? -actual.Yue : actual.Yue);
            Assert.AreEqual(expected.Month,
                actual.LunarYue.IsRunyue ? -actual.LunarYue.Number : actual.LunarYue.Number);

            Assert.AreEqual(expected.Day, actual.Ri);
            Assert.AreEqual(expected.TimeZhi, actual.Shi.ToString("C"));
        }

        var minDateTime = LunarNian.MinSupportedNian.YueList[0].GetDateTime(1, Dizhi.Zi).ToGregorian();
        var minSolarL = L.Lunar.FromYmdHms(
            lunarYear: LunarNian.MinSupportedNian.Year,
            lunarMonth: 1,
            lunarDay: 1,
            hour: 0).Solar;
        AssertGregorian(minSolarL, minDateTime);

        var maxDateTime = LunarNian.MaxSupportedNian.YueList[^1].GetDateTime(
            LunarNian.MaxSupportedNian.YueList[^1].RiCount, Dizhi.Hai)
            .ToGregorian();
        var maxSolarL = L.Lunar.FromYmdHms(
            lunarYear: LunarNian.MaxSupportedNian.Year,
            lunarMonth: 12,
            lunarDay: LunarYear.FromYear(LunarNian.MaxSupportedNian.Year).MonthsInYear[^1].DayCount,
            hour: 22).Solar;
        AssertGregorian(maxSolarL, maxDateTime);

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

            dt = dt.AddHours(-1);
            Assert.AreEqual(lunarDt, LunarDateTime.FromGregorian(dt));
        });
    }

    [TestMethod()]
    public void OtherTests()
    {
        var dt1 = LunarDateTime.FromGregorian(new DateTime(2023, 8, 26, 11, 21, 10));
        var dt2 = LunarNian.FromGregorian(2023).YueList[7].GetDateTime(11, Dizhi.Wu);
        Assert.IsTrue(dt1.Equals(dt2));
        Assert.AreEqual(0, dt1.CompareTo(dt2));
        Assert.IsTrue(dt1.GetHashCode() == dt2.GetHashCode());

        Enumerable.Range(0, 100000).AsParallel().ForAll((_) =>
        {
            var nian1 = LunarNian.FromGregorian(Random.Shared.Next(
                LunarNian.MinSupportedNian.Year, LunarNian.MaxSupportedNian.Year + 1));
            var nian2 = LunarNian.FromGregorian(Random.Shared.Next(
                LunarNian.MinSupportedNian.Year, LunarNian.MaxSupportedNian.Year + 1));

            var yue1 = nian1.YueList[Random.Shared.Next(0, nian1.YueList.Count)];
            var yue2 = nian2.YueList[Random.Shared.Next(0, nian2.YueList.Count)];
            var compareResult = yue1.CompareTo(yue2);

            var ri1 = Random.Shared.Next(1, yue1.RiCount + 1);
            var ri2 = Random.Shared.Next(1, yue2.RiCount + 1);
            if (compareResult == 0)
                compareResult = ri1.CompareTo(ri2);

            var shi1 = new Dizhi(Random.Shared.Next(1, 13));
            var shi2 = new Dizhi(Random.Shared.Next(1, 13));
            if (compareResult == 0)
                compareResult = shi1.CompareTo(shi2);

            var dt1 = yue1.GetDateTime(ri1, shi1);
            var dt2 = yue2.GetDateTime(ri2, shi2);

            Assert.AreEqual(compareResult == 0, dt1.Equals(dt2));
            Assert.AreEqual(compareResult, dt1.CompareTo(dt2));
        });
    }
}