using Microsoft.VisualStudio.TestTools.UnitTesting;
using YiJingFramework.PrimitiveTypes;
using L = Lunar;

namespace YiJingFramework.Nongli.Solar.Tests;

[TestClass()]
public class SolarNianTests
{
    [TestMethod()]
    public void CorrectnessTest()
    {
        static DateTime ToDateTime(L.Solar solar)
        {
            return new DateTime(solar.Year, solar.Month, solar.Day, solar.Hour, solar.Minute, solar.Second);
        }
        static void AssertGregorianSimilar(L.Solar expected, DateTime actual)
        {
            var dt = ToDateTime(expected);
            var difference = Math.Abs(dt.Ticks - actual.Ticks);
            if (difference > new TimeSpan(0, 0, 20).Ticks)
                Assert.Fail();
        }

        for (int year = SolarNian.MinSupportedNian.Year; year <= SolarNian.MaxSupportedNian.Year; year++)
        {
            var nian = SolarNian.FromGregorian(year);

            {
                var oneDayL = L.Lunar.FromYmdHms(year, 6, 7);

                Assert.AreEqual(year, nian.Year);
                Assert.AreEqual(oneDayL.Year, nian.Year);

                Assert.AreEqual(oneDayL.YearGan, nian.Ganzhi.Tiangan.ToString("C"));
                Assert.AreEqual(oneDayL.YearZhi, nian.Ganzhi.Dizhi.ToString("C"));
            }

            {
                Assert.AreEqual(12, nian.Yues.Count);

                var yearL = L.LunarYear.FromYear(year);
                Assert.AreEqual(yearL.Year, nian.Year);

                var lunarL = L.Solar.FromJulianDay(yearL.Months[0].FirstJulianDay).Lunar;
                for (; lunarL.CurrentJieQi?.Name != "立春";)
                {
                    var newLunarL = lunarL.GetNextJieQi(true).Solar.Lunar;
                    if (ToDateTime(newLunarL.Solar) == ToDateTime(lunarL.Solar))
                    {
                        lunarL = newLunarL.Next(1);
                    }
                    else
                    {
                        lunarL = newLunarL;
                    }
                }

                foreach (var (yue, i) in nian.Yues.Zip(Enumerable.Range(0, 30)))
                {
                    Assert.AreEqual(nian, yue.Nian);
                    Assert.AreEqual(i, yue.IndexInNian);

                    Assert.AreEqual(lunarL.MonthGan, yue.Ganzhi.Tiangan.ToString("C"));
                    Assert.AreEqual(lunarL.MonthZhi, yue.Ganzhi.Dizhi.ToString("C"));

                    Assert.AreEqual(lunarL.DayGan, yue.GanzhiOfFirstRi.Tiangan.ToString("C"));
                    Assert.AreEqual(lunarL.DayZhi, yue.GanzhiOfFirstRi.Dizhi.ToString("C"));

                    AssertGregorianSimilar(lunarL.Solar, yue.Jieling);

                    lunarL = lunarL.Next(1);
                    lunarL = lunarL.GetNextJieQi(true).Solar.Lunar;
                    AssertGregorianSimilar(lunarL.Solar, yue.Zhongqi);

                    lunarL = lunarL.Next(1);
                    lunarL = lunarL.GetNextJieQi(true).Solar.Lunar;
                    Assert.AreEqual(
                        (ToDateTime(lunarL.Solar).Date - yue.Jieling.Date).Days,
                        yue.RiCount);
                }
            }
        }

        {
            _ = Assert.ThrowsException<NotSupportedException>(
                () => SolarNian.FromGregorian(SolarNian.MinSupportedNian.Year - 1));
            _ = Assert.ThrowsException<NotSupportedException>(
                () => SolarNian.FromGregorian(SolarNian.MaxSupportedNian.Year + 1));
        }
    }

    [TestMethod()]
    public void OtherTests()
    {
        var min = SolarNian.MinSupportedNian.Year;
        var max = SolarNian.MaxSupportedNian.Year + 1;

        for (int i = 0; i < 1000; i++)
        {
            var r1 = Random.Shared.Next(min, max);
            var nian1 = SolarNian.FromGregorian(r1);
            var nian2 = SolarNian.FromGregorian(r1);

            Assert.IsTrue(nian1.Equals(nian2));
            Assert.IsTrue(nian1.GetHashCode() == nian2.GetHashCode());
            Assert.AreEqual($"{nian1.Ganzhi}{nian1.Year}", nian1.ToString());

            foreach (var (yue1, yue2) in nian1.Yues.Zip(nian2.Yues))
            {
                Assert.IsTrue(yue1.Equals(yue2));
                Assert.AreEqual(0, yue1.CompareTo(yue2));
                Assert.IsTrue(yue1.GetHashCode() == yue2.GetHashCode());
                Assert.AreEqual(
                    $"{yue1.Ganzhi} ({yue1.Nian}[{yue1.IndexInNian}])",
                    yue1.ToString());

                _ = Assert.ThrowsException<ArgumentOutOfRangeException>(
                    () => yue1.GetDateTime(yue1.GanzhiOfFirstRi - 1, Dizhi.Zi));
                _ = Assert.ThrowsException<ArgumentOutOfRangeException>(
                    () => yue1.GetDateTime(yue1.GanzhiOfFirstRi + yue1.RiCount, Dizhi.Zi));

                var d = yue1.GanzhiOfFirstRi + Random.Shared.Next(0, yue1.RiCount);
                var t = Dizhi.FromIndex((Random.Shared.Next(1, 13)));
                var ri = yue1.GetDateTime(d, t);
                Assert.AreEqual(yue1, ri.SolarYue);
                Assert.AreEqual(nian1, ri.SolarNian);
                Assert.AreEqual(d, ri.Ri);
                Assert.AreEqual(t, ri.Shi.Dizhi);
            }

            foreach (var (yue1, yue2) in nian1.Yues.Zip(nian2.Yues.Skip(1)))
            {
                Assert.AreEqual(-1, yue1.CompareTo(yue2));
                Assert.AreEqual(1, yue2.CompareTo(yue1));
            }

            var r2 = Random.Shared.Next(min, max);
            var nian3 = SolarNian.FromGregorian(r2);

            Assert.AreEqual(r1.Equals(r2), nian1.Equals(nian3));
            Assert.AreEqual(nian1.Year.CompareTo(nian3.Year), nian1.CompareTo(nian3));

            var y1r = nian1.Yues.OrderBy(_ => Random.Shared.Next());
            var y3r = nian3.Yues.OrderBy(_ => Random.Shared.Next());
            foreach (var (yue1, yue3) in y1r.Zip(y3r))
            {
                if (nian1.CompareTo(nian3) is not 0)
                    Assert.AreEqual(nian1.CompareTo(nian3), yue1.CompareTo(yue3));
            }
        }
    }
}