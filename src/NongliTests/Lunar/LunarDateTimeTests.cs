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
                actual.LunarYue.IsRunyue ? -actual.LunarYue.Index : actual.LunarYue.Index);

            Assert.AreEqual(expected.Day, actual.Ri);
            Assert.AreEqual(expected.TimeZhi, actual.Shi.ToString("C"));
        }

        var minDateTime = LunarNian.MinSupportedNian.Yues[0].GetDateTime(1, Dizhi.Zi).ToGregorian();
        var minSolarL = L.Lunar.FromYmdHms(
            lunarYear: LunarNian.MinSupportedNian.Year,
            lunarMonth: 1,
            lunarDay: 1,
            hour: 0).Solar;
        AssertGregorian(minSolarL, minDateTime);

        var maxDateTime = LunarNian.MaxSupportedNian.Yues[^1].GetDateTime(
            LunarNian.MaxSupportedNian.Yues[^1].RiCount, Dizhi.Hai)
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

        var testings = EnumerateTestingDateTime();
        testings = testings.Take(100000).Concat(testings.Reverse().Take(100000));
        foreach (var dt in testings)
        {
            var lunarDt = LunarDateTime.FromGregorian(dt);
            AssertLunar(L.Lunar.FromDate(dt), lunarDt);
            Assert.AreEqual(dt, lunarDt.ToGregorian());

            var newDt = dt.AddHours(-1);
            Assert.AreEqual(lunarDt, LunarDateTime.FromGregorian(newDt));
        }

        _ = Assert.ThrowsException<NotSupportedException>(
            () => LunarDateTime.FromGregorian(minDateTime.AddHours(-2)));
        _ = Assert.ThrowsException<NotSupportedException>(
            () => LunarDateTime.FromGregorian(maxDateTime.AddHours(2)));
    }

    [TestMethod()]
    public void OtherTests()
    {
        {
            var dt1 = LunarDateTime.FromGregorian(new DateTime(2023, 8, 26, 11, 21, 10));
            var dt2 = LunarNian.FromGregorian(2023).Yues[7].GetDateTime(11, Dizhi.Wu);
            Assert.IsTrue(dt1.Equals(dt2));
            Assert.AreEqual(0, dt1.CompareTo(dt2));
            Assert.IsTrue(dt1.GetHashCode() == dt2.GetHashCode());
        }

        for (int i = 0; i < 1000000; i++)
        {
            var nian1 = LunarNian.FromGregorian(Random.Shared.Next(
                LunarNian.MinSupportedNian.Year, LunarNian.MaxSupportedNian.Year + 1));
            var nian2 = LunarNian.FromGregorian(Random.Shared.Next(
                LunarNian.MinSupportedNian.Year, LunarNian.MaxSupportedNian.Year + 1));

            var yue1 = nian1.Yues[Random.Shared.Next(0, nian1.Yues.Count)];
            var yue2 = nian2.Yues[Random.Shared.Next(0, nian2.Yues.Count)];
            var compareResult = yue1.CompareTo(yue2);

            var ri1 = Random.Shared.Next(1, yue1.RiCount + 1);
            var ri2 = Random.Shared.Next(1, yue2.RiCount + 1);
            if (compareResult == 0)
                compareResult = ri1.CompareTo(ri2);

            var shi1 = Dizhi.FromIndex((Random.Shared.Next(1, 13)));
            var shi2 = Dizhi.FromIndex((Random.Shared.Next(1, 13)));
            if (compareResult == 0)
                compareResult = shi1.CompareTo(shi2);

            var dt1 = yue1.GetDateTime(ri1, shi1);
            var dt2 = yue2.GetDateTime(ri2, shi2);

            Assert.AreEqual(compareResult == 0, dt1.Equals(dt2));
            Assert.AreEqual(compareResult, dt1.CompareTo(dt2));
        };
    }
}