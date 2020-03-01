using Microsoft.VisualStudio.TestTools.UnitTesting;
using projectCS;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class LockerTest
    {
        [TestMethod]
        public void componentsAdditionTest()
        {
            Locker locker = new Locker();

            CrossBar lc1 = new CrossBar();
            Cleat lc2 = new Cleat();
            Door lc3 = new Door();

            locker.addComponent(new List<LockerComponents>() { lc1, lc2, lc3 });
            Assert.AreEqual(3, locker.componentsList.Count);
        }

        [TestMethod]
        public void price100Test()
        {
            Locker locker = new Locker();

            CrossBar lc1 = new CrossBar(10, "referenceTest", "1", 0, false, 0, "orientationTest");
            Cleat lc2 = new Cleat(50, "referenceTest", "1", 0, false, 0, "orientationTest");
            Door lc3 = new Door(40, "referenceTest", "1", 0, false, 0, "orientationTest", "");

            locker.addComponent(new List<LockerComponents>() { lc1, lc2, lc3 });
            Assert.AreEqual(100, locker.price);
        }

        [TestMethod]
        public void isCompleteTest()
        {
            Locker locker = new Locker();
            Locker locker2 = new Locker();
            Locker locker3 = new Locker();

            CrossBar c1 = new CrossBar();
            CrossBar c2 = new CrossBar();
            CrossBar c3 = new CrossBar();
            CrossBar c4 = new CrossBar();
            CrossBar c5 = new CrossBar();
            CrossBar c6 = new CrossBar();
            CrossBar c7 = new CrossBar();
            CrossBar c8 = new CrossBar();
            Pannel p1 = new Pannel();
            Pannel p2 = new Pannel();
            Pannel p3 = new Pannel();
            Pannel p4 = new Pannel();
            Pannel p5 = new Pannel();
            Cleat cl1 = new Cleat();
            Cleat cl2 = new Cleat();
            Cleat cl3 = new Cleat();
            Cleat cl4 = new Cleat();


            Assert.AreEqual(false, locker.isComplete());

            locker.addComponent(new List<LockerComponents>() { c1, c2, c3, c4, c5, c6 ,c7, c8,
                                                                cl1, cl2, cl3, cl4,
                                                                p1, p2, p3, p4, p5});
            
            locker2.addComponent(new List<LockerComponents>() { c1, c2, c3, c4, c5, c6 ,c7, c8,
                                                                cl1,
                                                                p1, p2, p3, p4, p5});
            
            locker3.addComponent(new List<LockerComponents>() {c1, c2, c3, c4, c5, c6 ,c7, c8,
                                                                cl1, cl2, cl3, cl4,
                                                                p1});
            Assert.AreEqual(true, locker.isComplete());
            Assert.AreEqual(false, locker2.isComplete());
            Assert.AreEqual(false, locker3.isComplete());
        }

    }
}
