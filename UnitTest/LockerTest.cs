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

            locker.addComponent(new List<CatalogueComponents>() { lc1, lc2, lc3 });
            Assert.AreEqual(3, locker.componentsList.Count);
        }
        
        /// <summary>
        ///     test if adding an lockerComponent beyond the size limit of locker for a component type 
        /// </summary>
        [TestMethod]
        public void componentsAdditionWithMaxTest()
        {
            Locker locker = new Locker();

            Pannel p = new Pannel();
            Cleat l = new Cleat();
            Door d = new Door();

            locker.addComponent(p);
            locker.addComponent(p);
            locker.addComponent(p);
            locker.addComponent(p);
            locker.addComponent(p);
            
            Assert.AreEqual(5, locker.componentsList.Count);

            locker.addComponent(p);
            locker.addComponent(p);
            locker.addComponent(p);

            Assert.AreEqual(5, locker.componentsList.Count);

            locker.addComponent(l);
            locker.addComponent(d);

            Assert.AreEqual(7, locker.componentsList.Count);

            locker.addComponent(d);
            locker.addComponent(d);
            locker.addComponent(d);

            Assert.AreEqual(8, locker.componentsList.Count);
        }

        [TestMethod]
        public void price100Test()
        {
            Locker locker = new Locker();

            CrossBar lc1 = new CrossBar(10, "referenceTest", "1", 0, false, 0, Color.white);
            Cleat lc2 = new Cleat(50, "referenceTest", "1", 0, false, 0, Color.white);
            Door lc3 = new Door(40, "referenceTest", "1", 0, false, 0, Color.white);

            locker.addComponent(new List<CatalogueComponents>() { lc1, lc2, lc3 });
            Assert.AreEqual(100, locker.price);
        }

        /// <summary>
        ///     check if a locker has free emplacements or if it is full
        /// </summary>
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

            locker.addComponent(new List<CatalogueComponents>() { c1, c2, c3, c4, c5, c6 ,c7, c8,
                                                                cl1, cl2, cl3, cl4,
                                                                p1, p2, p3, p4, p5});
            
            locker2.addComponent(new List<CatalogueComponents>() { c1, c2, c3, c4, c5, c6 ,c7, c8,
                                                                cl1,
                                                                p1, p2, p3, p4, p5});
            
            locker3.addComponent(new List<CatalogueComponents>() {c1, c2, c3, c4, c5, c6 ,c7, c8,
                                                                cl1, cl2, cl3, cl4,
                                                                p1});
            Assert.AreEqual(true, locker.isComplete());
            Assert.AreEqual(false, locker2.isComplete());
            Assert.AreEqual(false, locker3.isComplete());
        }

        /// <summary>
        ///     check if the method returning the number of components for a type work fine 
        /// </summary>
        [TestMethod]
        public void maximumComponentTest()
        {
            Locker locker = new Locker();
            Locker locker2 = new Locker();

            CrossBar c1 = new CrossBar();
            CrossBar c2 = new CrossBar();
            CrossBar c3 = new CrossBar();
            CrossBar c4 = new CrossBar();
            Pannel p1 = new Pannel();
            Pannel p2 = new Pannel();
            Cleat cl1 = new Cleat();
            Cleat cl2 = new Cleat();
            Cleat cl3 = new Cleat();
            Cleat cl4 = new Cleat();

            locker.addComponent(new List<CatalogueComponents>() { c1, c2, c3,
                                                                cl1,
                                                                p1, p2});

            locker2.addComponent(new List<CatalogueComponents>() {c1, c2, c3, c4,
                                                                cl1, cl2, cl3, cl4,
                                                                p1});
            var privlocker = new PrivateObject(locker);
            var privlocker2 = new PrivateObject(locker2);

            Assert.AreEqual(3, privlocker.Invoke("numberOfGivenComponentInList", c1));
            Assert.AreEqual(1, privlocker.Invoke("numberOfGivenComponentInList", cl1));
            Assert.AreEqual(2, privlocker.Invoke("numberOfGivenComponentInList", p1));

            Assert.AreEqual(4, privlocker2.Invoke("numberOfGivenComponentInList", c1));
            Assert.AreEqual(4, privlocker2.Invoke("numberOfGivenComponentInList", cl1));
            Assert.AreEqual(1, privlocker2.Invoke("numberOfGivenComponentInList", p1));
        }
    }
}
