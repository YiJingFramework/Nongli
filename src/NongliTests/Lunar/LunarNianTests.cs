using Microsoft.VisualStudio.TestTools.UnitTesting;
using YiJingFramework.PrimitiveTypes;
using L = Lunar;

namespace YiJingFramework.Nongli.Lunar.Tests;

[TestClass()]
public class LunarNianTests
{
    [TestMethod()]
    public void CorrectnessTest()
    {
        for (int year = LunarNian.MinSupportedNian.Year; year <= LunarNian.MaxSupportedNian.Year; year++)
        {
            var nian = LunarNian.FromGregorian(year);

            {
                var oneDayL = L.Lunar.FromYmdHms(year, 6, 7);

                Assert.AreEqual(year, nian.Year);
                Assert.AreEqual(oneDayL.Year, nian.Year);

                Assert.AreEqual(oneDayL.YearGan, nian.Ganzhi.Tiangan.ToString("C"));
                Assert.AreEqual(oneDayL.YearZhi, nian.Ganzhi.Dizhi.ToString("C"));
            }

            {
                var yearL = L.LunarYear.FromYear(year);
                Assert.AreEqual(yearL.Year, nian.Year);

                var monthsL = yearL.MonthsInYear;
                Assert.AreEqual(monthsL.Count, nian.YueList.Count);
                foreach (var (yue, monthL, i) in nian.YueList.Zip(monthsL, Enumerable.Range(0, 100)))
                {
                    Assert.AreEqual(nian, yue.Nian);
                    Assert.AreEqual(i, yue.YueIndexInNian);

                    Assert.AreEqual(monthL.Leap, yue.IsRunyue);
                    Assert.AreEqual(Math.Abs(monthL.Month), yue.Number);
                    Assert.AreEqual(1, yue.IndexOfFirstRi);
                    Assert.AreEqual(monthL.DayCount, yue.RiCount);
                }
            }
        }

        {
            _ = Assert.ThrowsException<NotSupportedException>(
                () => LunarNian.FromGregorian(LunarNian.MinSupportedNian.Year - 1));
            _ = Assert.ThrowsException<NotSupportedException>(
                () => LunarNian.FromGregorian(LunarNian.MaxSupportedNian.Year + 1));
        }
    }

    [TestMethod()]
    public void OtherTests()
    {
        var min = LunarNian.MinSupportedNian.Year;
        var max = LunarNian.MaxSupportedNian.Year + 1;

        for (int i = 0; i < 1000; i++)
        {
            var r1 = Random.Shared.Next(min, max);
            var nian1 = LunarNian.FromGregorian(r1);
            var nian2 = LunarNian.FromGregorian(r1);

            Assert.IsTrue(nian1.Equals(nian2));
            Assert.IsTrue(nian1.GetHashCode() == nian2.GetHashCode());
            Assert.AreEqual($"{nian1.Ganzhi}{nian1.Year}", nian1.ToString());

            foreach (var (yue1, yue2) in nian1.YueList.Zip(nian2.YueList))
            {
                Assert.IsTrue(yue1.Equals(yue2));
                Assert.AreEqual(0, yue1.CompareTo(yue2));
                Assert.IsTrue(yue1.GetHashCode() == yue2.GetHashCode());
                Assert.AreEqual(
                    $"{(yue1.IsRunyue ? 'L' : 'C')}{yue1.Number} ({yue1.Nian}[{yue1.YueIndexInNian}])",
                    yue1.ToString());

                _ = Assert.ThrowsException<ArgumentOutOfRangeException>(
                    () => yue1.GetDateTime(0, Dizhi.Zi));
                _ = Assert.ThrowsException<ArgumentOutOfRangeException>(
                    () => yue1.GetDateTime(yue1.RiCount + 1, Dizhi.Zi));

                var d = Random.Shared.Next(1, yue1.RiCount + 1);
                var t = new Dizhi(Random.Shared.Next(1, 13));
                var ri = yue1.GetDateTime(d, t);
                Assert.AreEqual(yue1, ri.LunarYue);
                Assert.AreEqual(nian1, ri.LunarNian);
                Assert.AreEqual(d, ri.Ri);
                Assert.AreEqual(t, ri.Shi);
            }

            foreach (var (yue1, yue2) in nian1.YueList.Zip(nian2.YueList.Skip(1)))
            {
                Assert.AreEqual(-1, yue1.CompareTo(yue2));
                Assert.AreEqual(1, yue2.CompareTo(yue1));
            }

            var r2 = Random.Shared.Next(min, max);
            var nian3 = LunarNian.FromGregorian(r2);

            Assert.AreEqual(r1.Equals(r2), nian1.Equals(nian3));
            Assert.AreEqual(nian1.Year.CompareTo(nian3.Year), nian1.CompareTo(nian3));

            var y1r = nian1.YueList.OrderBy(_ => Random.Shared.Next());
            var y3r = nian3.YueList.OrderBy(_ => Random.Shared.Next());
            foreach (var (yue1, yue3) in y1r.Zip(y3r))
            {
                if (nian1.CompareTo(nian3) is not 0)
                    Assert.AreEqual(nian1.CompareTo(nian3), yue1.CompareTo(yue3));
            }
        }
    }
}