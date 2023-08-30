using Microsoft.VisualStudio.TestTools.UnitTesting;
using YiJingFramework.PrimitiveTypes;

namespace YiJingFramework.Nongli.Solar.Tests;

[TestClass()]
public class GanzhiTests
{
    [TestMethod()]
    public void ConvertingTest()
    {
        Assert.AreEqual(1, (int)Ganzhi.FromGanzhi(Tiangan.Jia, Dizhi.Zi));
        Assert.AreEqual(4, (int)Ganzhi.FromIndex(4));
        Assert.AreEqual(2, (int)Ganzhi.FromIndex(62));

        Assert.AreEqual("Yimao", Ganzhi.FromGanzhi(Tiangan.Yi, Dizhi.Mao).ToString());
        Assert.AreEqual("乙卯", Ganzhi.FromGanzhi(Tiangan.Yi, Dizhi.Mao).ToString("C"));

        Assert.AreEqual("癸亥", ((Ganzhi)0).ToString("C"));
        Assert.AreEqual("辛酉", ((Ganzhi)(-2)).ToString("C"));

        for (int i = -1019, j = 1; i < 1000; i++)
        {
            Assert.AreEqual((Ganzhi)j, (Ganzhi)i);
            j++;
            if (j == 61)
                j = 1;
        }

        Assert.AreEqual(Ganzhi.FromIndex(15 + 212), Ganzhi.FromIndex(15).Next(212));
        Assert.AreEqual(Ganzhi.FromIndex(15 - 28222), Ganzhi.FromIndex(15).Next(-28222));

        Assert.AreEqual(Ganzhi.FromIndex(15).Next(212), Ganzhi.FromIndex(15) + 212);
        Assert.AreEqual(Ganzhi.FromIndex(15).Next(-28222), Ganzhi.FromIndex(15) - 28222);
    }

    [TestMethod()]
    public void ComparingTest()
    {
        Random r = new Random();
        for (int i = 0; i < 20000; i++)
        {
            var fir = r.Next(1, 13);
            var sec = r.Next(1, 13);
            var firF = (Ganzhi)fir;
            var secF = Ganzhi.FromIndex(sec);
            if (fir == sec)
            {
                Assert.AreEqual(0, firF.CompareTo(secF));
                Assert.AreEqual(0, secF.CompareTo(firF));
                Assert.AreEqual(true, firF.Equals(secF));
                Assert.AreEqual(true, secF.Equals(firF));
                Assert.AreEqual(true, firF.Equals((object)secF));
                Assert.AreEqual(true, secF.Equals((object)firF));
                Assert.AreEqual(firF.GetHashCode(), secF.GetHashCode());
                Assert.AreEqual(true, firF == secF);
                Assert.AreEqual(true, secF == firF);
                Assert.AreEqual(false, firF != secF);
                Assert.AreEqual(false, secF != firF);
            }

            else if (fir < sec)
            {
                Assert.AreEqual(-1, firF.CompareTo(secF));
                Assert.AreEqual(1, secF.CompareTo(firF));
                Assert.AreEqual(false, firF.Equals(secF));
                Assert.AreEqual(false, secF.Equals(firF));
                Assert.AreEqual(false, firF.Equals((object)secF));
                Assert.AreEqual(false, secF.Equals((object)firF));
                Assert.AreNotEqual(firF.GetHashCode(), secF.GetHashCode());
                Assert.AreEqual(false, firF == secF);
                Assert.AreEqual(false, secF == firF);
                Assert.AreEqual(true, firF != secF);
                Assert.AreEqual(true, secF != firF);
            }

            else // fir > sec
            {
                Assert.AreEqual(1, firF.CompareTo(secF));
                Assert.AreEqual(-1, secF.CompareTo(firF));
                Assert.AreEqual(false, firF.Equals(secF));
                Assert.AreEqual(false, secF.Equals(firF));
                Assert.AreEqual(false, firF.Equals((object)secF));
                Assert.AreEqual(false, secF.Equals((object)firF));
                Assert.AreNotEqual(firF.GetHashCode(), secF.GetHashCode());
                Assert.AreEqual(false, firF == secF);
                Assert.AreEqual(false, secF == firF);
                Assert.AreEqual(true, firF != secF);
                Assert.AreEqual(true, secF != firF);
            }
            Assert.AreEqual(false, firF.Equals(null));
            Assert.AreEqual(false, secF.Equals(new object()));
        }
    }
}