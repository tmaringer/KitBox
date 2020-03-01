using Microsoft.VisualStudio.TestTools.UnitTesting;
using projectCS;
using projectCS.physic_components;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class CupboardTest
    {
        [TestMethod]
        public void cutAnglesTest()
        {
            Cupboard cup = new Cupboard();

            AngleBracket an = new AngleBracket(10, "referenceTest", "1", 0, false, 45);

            cup.addCupboardComponent(an);
            cup.cutAnglesBracket(25);

            Assert.AreEqual(20, an.height);
            Assert.AreEqual(20, cup.getAngleBracket().height);
            Assert.AreNotEqual(2, cup.getAngleBracket().height);
        }

        [TestMethod]
        public void findAnglesTest()
        {
            Cupboard cup = new Cupboard();

            AngleBracket an = new AngleBracket(10, "referenceTest", "1", 0, false, 45);
            Locker l1 = new Locker();
            Locker l2 = new Locker();
            Locker l3 = new Locker();
            Locker l4 = new Locker();

            cup.addCupboardComponent(an);
            cup.addCupboardComponent(l1);
            cup.addCupboardComponent(l2);
            cup.addCupboardComponent(l3);
            cup.addCupboardComponent(l4);

            var privateCupboard = new PrivateObject(cup);

            Assert.AreEqual(0, privateCupboard.Invoke("locationOfAngleInList"));

            cup = new Cupboard();
            cup.addCupboardComponent(l3);
            cup.addCupboardComponent(l1);
            cup.addCupboardComponent(l2);
            cup.addCupboardComponent(an);
            cup.addCupboardComponent(l4);

            privateCupboard = new PrivateObject(cup);

            Assert.AreEqual(3, privateCupboard.Invoke("locationOfAngleInList"));

            cup = new Cupboard();
            cup.addCupboardComponent(l2);
            cup.addCupboardComponent(l1);
            cup.addCupboardComponent(an);
            cup.addCupboardComponent(l3);
            cup.addCupboardComponent(l4);

            privateCupboard = new PrivateObject(cup);

            Assert.AreEqual(2, privateCupboard.Invoke("locationOfAngleInList"));
        }

        [TestMethod]
        public void getPriceTest()
        {
            Cupboard cup = new Cupboard();

            AngleBracket an = new AngleBracket(25, "referenceTest", "1", 0, false, 45);

            cup.addCupboardComponent(an);


            Locker t = new Locker();

            CrossBar t1 = new CrossBar(10, "referenceTest", "1", 0, false, 0, "orientationTest");
            CrossBar t2 = new CrossBar(20, "referenceTest", "2", 0, false, 0, "orientationTest");
            CrossBar t3 = new CrossBar(20, "referenceTest", "3", 0, false, 0, "orientationTest");

            t.addComponent(t1);
            t.addComponent(t2);
            t.addComponent(t3);

            cup.addCupboardComponent(t);

            Assert.AreEqual(75, cup.getPrice());
        } 
        
        [TestMethod]
        public void isCompleteTest()
        {
            Cupboard cup = new Cupboard();
            Cupboard cup2 = new Cupboard();

            AngleBracket an = new AngleBracket(25, "referenceTest", "1", 0, false, 45);

            cup.addCupboardComponent(an);
            cup2.addCupboardComponent(an);

            Locker locker = new Locker();
            Locker locker2 = new Locker();

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


            locker.addComponent(new List<LockerComponents>() { c1, c2, c3, c4, c5, c6 ,c7, c8,
                                                                cl1, cl2, cl3, cl4,
                                                                p1, p2, p3, p4, p5});
            
            locker2.addComponent(new List<LockerComponents>() { c1, c2, c3, c4, c5, c6 ,c7, c8,
                                                                cl1, cl2, cl3, cl4,
                                                                p1});

            cup.addCupboardComponent(locker);
            cup2.addCupboardComponent(locker2);

            Assert.AreEqual(true, cup.isComplete());
            Assert.AreEqual(false, cup2.isComplete());
        }

        [TestMethod]
        public void allLockerIsCompleteTest()
        {
            Cupboard cup = new Cupboard();
            Cupboard cup2 = new Cupboard();

            Locker locker = new Locker();
            Locker locker2 = new Locker();

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

            locker.addComponent(new List<LockerComponents>() { c1, c2, c3, c4, c5, c6 ,c7, c8,
                                                                cl1, cl2, cl3, cl4,
                                                                p1, p2, p3, p4, p5});

            cup.addCupboardComponent(locker);
            cup2.addCupboardComponent(locker2);

            var privateCupboard = new PrivateObject(cup);
            var privateCupboard2 = new PrivateObject(cup2);

            Assert.AreEqual(true, privateCupboard.Invoke("allLockerIsComplete"));
            Assert.AreEqual(false, privateCupboard2.Invoke("allLockerIsComplete"));
        }
    }
}
