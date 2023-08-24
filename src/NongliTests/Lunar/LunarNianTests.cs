using Microsoft.VisualStudio.TestTools.UnitTesting;
using L = Lunar;

namespace YiJingFramework.Nongli.Lunar.Tests;

[TestClass()]
public class LunarNianTests
{
    [TestMethod()]
    public void CorrectnessTest()
    {
        for (int year = LunarNian.MinSupportedNian.Year; year < LunarNian.MaxSupportedNian.Year; year++)
        {
            var nian = LunarNian.FromGregorian(year);

            {
                var oneDayL = L.Lunar.FromYmdHms(year, 6, 7);

                Assert.AreEqual(year, nian.Year);
                Assert.AreEqual(oneDayL.Year, nian.Year);

                Assert.AreEqual(oneDayL.YearGan, nian.Niangan.ToString("C"));
                Assert.AreEqual(oneDayL.YearZhi, nian.Nianzhi.ToString("C"));
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
                    Assert.AreEqual(Math.Abs(monthL.Month), yue.Yue);
                    Assert.AreEqual(monthL.DayCount, yue.RiCount);
                }
            }
        }
    }

    [TestMethod()]
    public void OtherTest()
    {
        Assert.Fail();
    }
}