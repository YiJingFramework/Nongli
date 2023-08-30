using Microsoft.VisualStudio.TestTools.UnitTesting;
using YiJingFramework.Nongli.Lunar;
using YiJingFramework.PrimitiveTypes;
using L = Lunar;

namespace YiJingFramework.Nongli.Solar.Tests;

[TestClass()]
public class SolarDateTimeTests
{
    [TestMethod()]
    public void CorrectnessTest()
    {
        static void AssertSolar(L.Lunar expected, SolarDateTime actual)
        {
            if (expected.YearGan == expected.YearGanByLiChun)
            {
                Assert.AreEqual(expected.Year, actual.Year);
                Assert.AreEqual(expected.Year, actual.SolarNian.Year);
            }
            Assert.AreEqual(expected.YearGanByLiChun, actual.Nian.Tiangan.ToString("C"));
            Assert.AreEqual(expected.YearZhiByLiChun, actual.Nian.Dizhi.ToString("C"));
            Assert.AreEqual(expected.YearGanByLiChun, actual.SolarNian.Ganzhi.Tiangan.ToString("C"));
            Assert.AreEqual(expected.YearZhiByLiChun, actual.SolarNian.Ganzhi.Dizhi.ToString("C"));

            Assert.AreEqual(expected.MonthGan, actual.Yue.Tiangan.ToString("C"));
            Assert.AreEqual(expected.MonthZhi, actual.Yue.Dizhi.ToString("C"));
            Assert.AreEqual(expected.Next(1).GetNextJieQi(true).Qi, actual.IsBeforeYueZhongqi);

            Assert.AreEqual(expected.DayGan, actual.Ri.Tiangan.ToString("C"));
            Assert.AreEqual(expected.DayZhi, actual.Ri.Dizhi.ToString("C"));

            Assert.AreEqual(expected.TimeGan, actual.Shi.Tiangan.ToString("C"));
            Assert.AreEqual(expected.TimeZhi, actual.Shi.Dizhi.ToString("C"));
        }

        var minDateTime = SolarNian.MinSupportedNian.Yues[0].GetDateTime(
            SolarNian.MinSupportedNian.Yues[0].GanzhiOfFirstRi,
            Dizhi.Zi).ToGregorian();
        {
            var minSolarL = L.Lunar.FromYmdHms(
                lunarYear: LunarNian.MinSupportedNian.Year,
                lunarMonth: 1,
                lunarDay: 1).JieQiTable["立春"];
            Assert.AreEqual(
                new DateTime(minSolarL.Year, minSolarL.Month, minSolarL.Day, 0, 0, 0),
                minDateTime);
        }

        var maxYue = SolarNian.MaxSupportedNian.Yues[11];
        var maxDateTime = maxYue.GetDateTime(
            maxYue.GanzhiOfFirstRi + maxYue.RiCount - 1,
            Dizhi.Hai).ToGregorian();
        {
            var maxSolarL = L.Lunar.FromYmdHms(
                lunarYear: LunarNian.MaxSupportedNian.Year + 1,
                lunarMonth: 1,
                lunarDay: 1,
                hour: 0).JieQiTable["立春"];
            Assert.AreEqual(
                new DateTime(maxSolarL.Year, maxSolarL.Month, maxSolarL.Day, 22, 0, 0).AddDays(-1),
                maxDateTime);
        }

        IEnumerable<DateTime> EnumerateTestingDateTime()
        {
            for (var dt = minDateTime; dt <= maxDateTime; dt = dt.AddHours(2))
            {
                yield return dt;
            }
        }

        var testings = EnumerateTestingDateTime();
        testings = testings.Take(10000).Concat(testings.Reverse().Take(10000));
        foreach (var dt in testings)
        {
            var solarDt = SolarDateTime.FromGregorian(dt);
            AssertSolar(L.Lunar.FromDate(dt), solarDt);
            Assert.AreEqual(dt, solarDt.ToGregorian());

            var newDt = dt.AddHours(-1);
            Assert.AreEqual(solarDt, SolarDateTime.FromGregorian(newDt));
        }

        _ = Assert.ThrowsException<NotSupportedException>(
            () => SolarDateTime.FromGregorian(minDateTime.AddHours(-2)));
        _ = Assert.ThrowsException<NotSupportedException>(
            () => SolarDateTime.FromGregorian(maxDateTime.AddHours(2)));
    }

    [TestMethod()]
    public void OtherTests()
    {
        {
            var dt1 = SolarDateTime.FromGregorian(new DateTime(2023, 8, 26, 11, 21, 10));
            var dt2 = SolarNian.FromGregorian(2023).Yues
                .Single(x => x.Ganzhi.Dizhi == Dizhi.Shen)
                .GetDateTime(Ganzhi.FromGanzhi(Tiangan.Bing, Dizhi.Chen), Dizhi.Wu);
            Assert.IsTrue(dt1.Equals(dt2));
            Assert.AreEqual(0, dt1.CompareTo(dt2));
            Assert.IsTrue(dt1.GetHashCode() == dt2.GetHashCode());
        }

        for (int i = 0; i < 100000; i++)
        {
            var nian1 = SolarNian.FromGregorian(Random.Shared.Next(
                SolarNian.MinSupportedNian.Year, SolarNian.MaxSupportedNian.Year + 1));
            var nian2 = SolarNian.FromGregorian(Random.Shared.Next(
                SolarNian.MinSupportedNian.Year, SolarNian.MaxSupportedNian.Year + 1));

            var yue1 = nian1.Yues[Random.Shared.Next(0, nian1.Yues.Count)];
            var yue2 = nian2.Yues[Random.Shared.Next(0, nian2.Yues.Count)];
            var compareResult = yue1.CompareTo(yue2);

            var ri1 = Random.Shared.Next(0, yue1.RiCount);
            var ri2 = Random.Shared.Next(0, yue2.RiCount);
            if (compareResult == 0)
                compareResult = ri1.CompareTo(ri2);

            var shi1 = (Dizhi)(Random.Shared.Next(1, 13));
            var shi2 = (Dizhi)(Random.Shared.Next(1, 13));
            if (compareResult == 0)
                compareResult = shi1.CompareTo(shi2);

            var dt1 = yue1.GetDateTime(yue1.GanzhiOfFirstRi + ri1, shi1);
            var dt2 = yue2.GetDateTime(yue2.GanzhiOfFirstRi + ri2, shi2);

            Assert.AreEqual(compareResult == 0, dt1.Equals(dt2));
            Assert.AreEqual(compareResult, dt1.CompareTo(dt2));
        };
    }
}