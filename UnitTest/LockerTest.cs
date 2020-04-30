using Microsoft.VisualStudio.TestTools.UnitTesting;
using projectCS;
using projectCS.Tools_class;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class LockerTest
    {
        private bool flag;

        private Locker locker1;
        private Locker locker2;
        private Locker locker3;

        private CrossBar crossBar1;
        private CrossBar crossBar2;
        private CrossBar crossBar3;
        private CrossBar crossBar4;
        private CrossBar crossBar5;
        private CrossBar crossBar6;
        private CrossBar crossBar7;
        private CrossBar crossBar8;
        private CrossBar crossBarWithParam1;
        private CrossBar crossBarWithParam2;

        private Panels pannel1;
        private Panels pannel2;
        private Panels pannel3;
        private Panels pannel4;
        private Panels pannel5;

        private Cleat cleat1;
        private Cleat cleat2;
        private Cleat cleat3;
        private Cleat cleat4;
        private Cleat cleatWithParam1;
        private Cleat cleatWithParam2;

        private Door door1;
        private Door doorWithParam1;
        private Door doorWithParam2;

        private List<CatalogueComponents> catalogueComponentsListEmpty;
        private List<CatalogueComponents> catalogueComponentsListWith3;
        private List<CatalogueComponents> catalogueComponentsListWith6;
        private List<CatalogueComponents> catalogueComponentsListWith10;
        private List<CatalogueComponents> catalogueComponentsListWith14;
        private List<CatalogueComponents> catalogueComponentsListFull;
        private List<CatalogueComponents> catalogueComponentsListWith6WithParam;

        [TestInitialize()]
        public void testsInitialize()
        {
            flag = false;

            locker1 = new Locker();
            locker2 = new Locker();
            locker3 = new Locker();

            crossBar1 = new CrossBar();
            crossBar2 = new CrossBar();
            crossBar3 = new CrossBar();
            crossBar4 = new CrossBar();
            crossBar5 = new CrossBar();
            crossBar6 = new CrossBar();
            crossBar7 = new CrossBar();
            crossBar8 = new CrossBar();
            crossBarWithParam1 = new CrossBar(10, "referenceTest", "1", new ComponentSize(4, 10, 10), false, 0, CrossBarType.side);
            crossBarWithParam2 = new CrossBar(10, "referenceTest", "1", new ComponentSize(4, 20, 20), false, 0, CrossBarType.side);

            pannel1 = new Panels();
            pannel2 = new Panels();
            pannel3 = new Panels();
            pannel4 = new Panels();
            pannel5 = new Panels();

            cleat1 = new Cleat();
            cleat2 = new Cleat();
            cleat3 = new Cleat();
            cleat4 = new Cleat();
            cleatWithParam1 = new Cleat(50, "referenceTest", "1", new ComponentSize(11, 7, 8), false, 0);
            cleatWithParam2 = new Cleat(50, "referenceTest", "1", new ComponentSize(17, 3, 5), false, 0);

            door1 = new Door();
            doorWithParam1 = new Door(40, "referenceTest", "1", new ComponentSize(32, 0, 0), false, 0, ComponentColor.white);
            doorWithParam2 = new Door(40, "referenceTest", "1", new ComponentSize(4, 6, 5), false, 0, ComponentColor.white);

            catalogueComponentsListEmpty = new List<CatalogueComponents>();
            catalogueComponentsListWith3 = new List<CatalogueComponents>() { crossBar1, cleat1, door1 };
            catalogueComponentsListWith6 = new List<CatalogueComponents>() { crossBar1, crossBar2, crossBar3,
                                                                         cleat1,
                                                                         pannel1, pannel2};
            catalogueComponentsListWith10 = new List<CatalogueComponents>() { crossBar1, crossBar2, crossBar3, crossBar4, crossBar5,
                                                                         cleat1, cleat2, cleat3,
                                                                         pannel1, pannel2};
            catalogueComponentsListWith14 = new List<CatalogueComponents>() { crossBar1, crossBar2, crossBar3, crossBar4, crossBar5, crossBar6 ,crossBar7, crossBar8,
                                                                         cleat1,
                                                                         pannel1, pannel2, pannel3, pannel4, pannel5};
            catalogueComponentsListFull = new List<CatalogueComponents>(){ crossBar1, crossBar2, crossBar3, crossBar4, crossBar5, crossBar6 ,crossBar7, crossBar8,
                                                                            cleat1, cleat2, cleat3, cleat4,
                                                                            pannel1, pannel2, pannel3, pannel4, pannel5};

            catalogueComponentsListWith6WithParam = new List<CatalogueComponents>() { crossBarWithParam1, crossBarWithParam2, crossBar3,
                                                                         cleatWithParam1, cleatWithParam2,
                                                                         pannel1, pannel2,
                                                                         doorWithParam1, doorWithParam2};

        }

        [TestMethod]
        public void componentsAdditionTest()
        {
            flag = locker1.addComponent(catalogueComponentsListWith3);
            Assert.AreEqual(3, locker1.componentsList.Count);
            Assert.AreEqual(true, flag);

            flag = locker1.addComponent(catalogueComponentsListWith14);
            Assert.AreEqual(false, flag);

            locker1.addComponent(catalogueComponentsListWith3);
            Assert.AreEqual(false, flag);

            locker2.addComponent(pannel1);
            locker2.addComponent(pannel1);
            flag = locker2.addComponent(pannel1);
            Assert.AreEqual(true, flag);

            locker2.addComponent(pannel1);
            flag = locker2.addComponent(pannel1);
            Assert.AreEqual(true, flag);

            flag = locker2.addComponent(pannel1);
            Assert.AreEqual(false, flag);
        }

        /// <summary>
        ///     test if adding an lockerComponent beyond the size limit of locker for a component type 
        /// </summary>
        [TestMethod]
        public void componentsAdditionWithMaxTest()
        {
            locker1.addComponent(pannel1);
            locker1.addComponent(pannel1);
            locker1.addComponent(pannel1);
            locker1.addComponent(pannel1);
            locker1.addComponent(pannel1);

            Assert.AreEqual(5, locker1.componentsList.Count);

            locker1.addComponent(pannel1);
            locker1.addComponent(pannel1);
            locker1.addComponent(pannel1);

            Assert.AreEqual(5, locker1.componentsList.Count);

            locker1.addComponent(cleat1);
            locker1.addComponent(door1);

            Assert.AreEqual(7, locker1.componentsList.Count);

            locker1.addComponent(door1);
            locker1.addComponent(door1);
            locker1.addComponent(door1);

            Assert.AreEqual(8, locker1.componentsList.Count);
        }

        [TestMethod]
        public void price100Test()
        {
            locker1.addComponent(new List<CatalogueComponents>() { crossBarWithParam1, cleatWithParam1, doorWithParam1 });
            Assert.AreEqual(100, locker1.price);
        }

        /// <summary>
        ///     check if a locker has free emplacements or if it is full
        /// </summary>
        [TestMethod]
        public void isCompleteTest()
        {
            Assert.AreEqual(false, locker1.isComplete());

            locker1.addComponent(catalogueComponentsListFull);
            locker2.addComponent(catalogueComponentsListWith14);
            locker3.addComponent(catalogueComponentsListWith3);

            Assert.AreEqual(true, locker1.isComplete());
            Assert.AreEqual(false, locker2.isComplete());
            Assert.AreEqual(false, locker3.isComplete());
        }

        /// <summary>
        ///     check if the method returning the number of components for a type work fine 
        /// </summary>
        [TestMethod]
        public void maximumComponentTest()
        {
            locker1.addComponent(catalogueComponentsListWith6);
            locker2.addComponent(catalogueComponentsListWith14);

            var privlocker = new PrivateObject(locker1);
            var privlocker2 = new PrivateObject(locker2);

            Assert.AreEqual(3, privlocker.Invoke("numberOfComponentInList", locker1.componentsList, crossBar1));
            Assert.AreEqual(1, privlocker.Invoke("numberOfComponentInList", locker1.componentsList, cleat1));
            Assert.AreEqual(2, privlocker.Invoke("numberOfComponentInList", locker1.componentsList, pannel1));

            Assert.AreEqual(8, privlocker2.Invoke("numberOfComponentInList", locker2.componentsList, crossBar1));
            Assert.AreEqual(1, privlocker2.Invoke("numberOfComponentInList", locker2.componentsList, cleat1));
            Assert.AreEqual(5, privlocker2.Invoke("numberOfComponentInList", locker2.componentsList, pannel1));
        }

        [TestMethod]
        public void removeComponentTest()
        {
            locker1.addComponent(catalogueComponentsListWith6);

            Assert.AreEqual(true, locker1.componentsList.Contains(crossBar1));
            locker1.removeComponent(crossBar1);
            Assert.AreEqual(false, locker1.componentsList.Contains(crossBar1));

            locker1.removeComponent(crossBar1);
            Assert.AreEqual(false, locker1.componentsList.Contains(crossBar1));

            Assert.AreEqual(true, locker1.componentsList.Contains(pannel2));
            locker1.removeComponent(pannel2);
            Assert.AreEqual(false, locker1.componentsList.Contains(pannel2));
        }

        [TestMethod]
        public void numberOfComponentInListTest()
        {
            var privatelocker = new PrivateObject(locker1);

            Assert.AreEqual(0, privatelocker.Invoke("numberOfComponentInList", catalogueComponentsListEmpty, crossBar1));

            locker1.addComponent(catalogueComponentsListWith14);

            Assert.AreEqual(8, privatelocker.Invoke("numberOfComponentInList", catalogueComponentsListWith14, crossBar1));
            Assert.AreEqual(3, privatelocker.Invoke("numberOfComponentInList", catalogueComponentsListWith6, crossBar1));
            Assert.AreEqual(3, privatelocker.Invoke("numberOfComponentInList", catalogueComponentsListWith10, cleat1));
            Assert.AreEqual(5, privatelocker.Invoke("numberOfComponentInList", catalogueComponentsListWith14, pannel1));
        }

        [TestMethod]
        public void setDoorColorTest()
        {
            locker1.addComponent(doorWithParam1);
            locker1.doorsColor = ComponentColor.glass;
            foreach(CatalogueComponents catalCompo in locker1.componentsList)
            {
                if (catalCompo is Door)
                    doorWithParam1 = (Door)catalCompo;
            }
            Assert.AreEqual(ComponentColor.glass, doorWithParam1.color);
            Assert.AreNotEqual(ComponentColor.black, doorWithParam1.color);
        }

        [TestMethod]
        public void widthComputingTest()
        {
            locker1.addComponent(catalogueComponentsListWith6WithParam);
            Assert.AreEqual(46, locker1.width);
        }

        [TestMethod]
        public void depthComputingTest()
        {
            locker1.addComponent(catalogueComponentsListWith6WithParam);
            Assert.AreEqual(48, locker1.depth);
        }

        
        [TestMethod]
        public void interfaceTest()
        {
            Locker locker = new Locker();

            Cleat cleattest = new Cleat();
            Door doortest = new Door();

            Panels panelsHB = new Panels();
            Panels panelsGD = new Panels();
            Panels panelsAR = new Panels();

            CrossBar crossBarAV = new CrossBar();
            CrossBar crossBarAR = new CrossBar();
            CrossBar crossBarGD = new CrossBar();

            cleattest.size = new ComponentSize(0, 0, 0);
            doortest.size = new ComponentSize(0, 0, 0);

            panelsHB.size = new ComponentSize(0, 0, 0);
            panelsHB.type = PanelsType.top;
            panelsGD.size = new ComponentSize(0, 0, 0);
            panelsGD.type = PanelsType.side;
            panelsAR.size = new ComponentSize(0, 0, 0);
            panelsAR.type = PanelsType.back;

            crossBarAV.size = new ComponentSize(0, 0, 0);
            crossBarAV.type = CrossBarType.front_back;
            crossBarAR.size = new ComponentSize(0, 0, 0);
            crossBarAR.type = CrossBarType.front_back;
            crossBarGD.size = new ComponentSize(0, 0, 0);
            crossBarGD.type = CrossBarType.side;

            locker.addComponent(new List<CatalogueComponents>() { cleattest, cleattest, cleattest, cleattest,
                                                                        doortest, doortest,
                                                                        panelsHB, panelsHB, panelsGD,  panelsGD, panelsAR,
                                                                        crossBarAV, crossBarAV, crossBarAR, crossBarAR,
                                                                        crossBarGD, crossBarGD, crossBarGD, crossBarGD });
            Assert.AreEqual(true, locker.isComplete());
        }
    }
}
