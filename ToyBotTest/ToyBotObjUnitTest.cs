using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyBot;

namespace ToyBotTest
{
    [TestClass]
    public class ToyBotObjTest
    {
        /*
         * Unit Testing Get Methods.
         */
        [TestMethod]
        public void GetPositionTest1()
        {
            ToyBotObj tbot = new ToyBotObj(Tuple.Create<short,short>(0,0), 0, 0, Tuple.Create<short, short>(5, 5));
            Assert.AreEqual(tbot.Position, Tuple.Create<short, short>(0, 0));
        }

        [TestMethod]
        public void GetOrientationTest1()
        {
            // Testing modulo setting
            ToyBotObj tbot = new ToyBotObj(Tuple.Create<short, short>(0, 0), 4, 0, Tuple.Create<short, short>(5, 5));
            Assert.AreEqual(tbot.Orientation, 0);
        }

        [TestMethod]
        public void GetPlanIdTest1()
        {
            ToyBotObj tbot = new ToyBotObj(Tuple.Create<short, short>(0, 0), 0, 0, Tuple.Create<short, short>(5, 5));
            Assert.AreEqual(tbot.PlanId, 0);
        }

        [TestMethod]
        public void GetPlanSizeTest1()
        {
            ToyBotObj tbot = new ToyBotObj(Tuple.Create<short, short>(0, 0), 0, 0, Tuple.Create<short, short>(5, 5));
            Assert.AreEqual(tbot.PlanSize, Tuple.Create<short, short>(5, 5));
        }

        /*
         * Unit Testing Set Methods.
         */
        [TestMethod]
        public void SetPositionTest1()
        {
            // it would be better to have something in the set function that sets the values to a minimum of 0 when entering
            // the plan size and position, or a simple if statement that checks that the values aren't negative.
            ToyBotObj tbot = new ToyBotObj(Tuple.Create<short, short>(0, 0), 0, 0, Tuple.Create<short, short>(5, 5));
            tbot.Position = Tuple.Create<short, short>(3, 1);
            Assert.AreEqual(tbot.Position, Tuple.Create<short, short>(3, 1));
        }

        [TestMethod]
        public void SetOrientationTest1()
        {
            ToyBotObj tbot = new ToyBotObj(Tuple.Create<short, short>(0, 0), 4, 0, Tuple.Create<short, short>(5, 5));
            tbot.Orientation = 403;
            Assert.AreEqual(tbot.Orientation, 3);
        }

        [TestMethod]
        public void SetPlanIdTest1()
        {
            ToyBotObj tbot = new ToyBotObj(Tuple.Create<short, short>(0, 0), 0, 0, Tuple.Create<short, short>(5, 5));
            tbot.PlanId = 3;
            Assert.AreEqual(tbot.PlanId, 3);
        }

        [TestMethod]
        public void SetPlanSizeTest1()
        {
            ToyBotObj tbot = new ToyBotObj(Tuple.Create<short, short>(0, 0), 0, 0, Tuple.Create<short, short>(5, 5));
            tbot.PlanSize = Tuple.Create<short, short>(4, 4);
            Assert.AreEqual(tbot.PlanSize, Tuple.Create<short, short>(4, 4));
        }

        /*
         * Unit Testing Move
         */
        [TestMethod]
        public void MoveTest1()
        {
            // Testing North Movement
            ToyBotObj tbot = new ToyBotObj(Tuple.Create<short, short>(0, 0), 0, 0, Tuple.Create<short, short>(5, 5));
            tbot.Move();
            Assert.AreEqual(tbot.Position, Tuple.Create<short, short>(0, 1));
        }

        [TestMethod]
        public void MoveTest2()
        {
            // Testing East Movement
            ToyBotObj tbot = new ToyBotObj(Tuple.Create<short, short>(0, 0), 1, 0, Tuple.Create<short, short>(5, 5));
            tbot.Move();
            Assert.AreEqual(tbot.Position, Tuple.Create<short, short>(1, 0));
        }

        [TestMethod]
        public void MoveTest3()
        {
            // Testing South Movement
            ToyBotObj tbot = new ToyBotObj(Tuple.Create<short, short>(0, 1), 2, 0, Tuple.Create<short, short>(5, 5));
            tbot.Move();
            Assert.AreEqual(tbot.Position, Tuple.Create<short, short>(0, 0));
        }

        [TestMethod]
        public void MoveTest4()
        {
            // Testing West Movement
            ToyBotObj tbot = new ToyBotObj(Tuple.Create<short, short>(1, 0), 3, 0, Tuple.Create<short, short>(5, 5));
            tbot.Move();
            Assert.AreEqual(tbot.Position, Tuple.Create<short, short>(0, 0));
        }

        [TestMethod]
        public void MoveBoundaryTest1()
        {
            // Testing Northern Boundary Non-Movement
            ToyBotObj tbot = new ToyBotObj(Tuple.Create<short, short>(0, 4), 0, 0, Tuple.Create<short, short>(5, 5));
            tbot.Move();
            Assert.AreEqual(tbot.Position, Tuple.Create<short, short>(0, 4));
        }

        [TestMethod]
        public void MoveBoundaryTest2()
        {
            // Testing Eastern Boundary Non-Movement
            ToyBotObj tbot = new ToyBotObj(Tuple.Create<short, short>(4, 0), 1, 0, Tuple.Create<short, short>(5, 5));
            tbot.Move();
            Assert.AreEqual(tbot.Position, Tuple.Create<short, short>(4, 0));
        }

        [TestMethod]
        public void MoveBoundaryTest3()
        {
            // Testing Southern Boundary Non-Movement
            ToyBotObj tbot = new ToyBotObj(Tuple.Create<short, short>(0, 0), 2, 0, Tuple.Create<short, short>(5, 5));
            tbot.Move();
            Assert.AreEqual(tbot.Position, Tuple.Create<short, short>(0, 0));
        }

        [TestMethod]
        public void MoveBoundaryTest4()
        {
            // Testing Southern Boundary Non-Movement
            ToyBotObj tbot = new ToyBotObj(Tuple.Create<short, short>(0, 0), 3, 0, Tuple.Create<short, short>(5, 5));
            tbot.Move();
            Assert.AreEqual(tbot.Position, Tuple.Create<short, short>(0, 0));
        }

        /*
         * Unit Testing Rotate
         */
        [TestMethod]
        public void RotateTest1()
        {
            ToyBotObj tbot = new ToyBotObj(Tuple.Create<short, short>(0, 0), 0, 0, Tuple.Create<short, short>(5, 5));
            tbot.Rotate(1);
            Assert.AreEqual(tbot.Orientation, 1);
        }

        [TestMethod]
        public void RotateTest2()
        {
            ToyBotObj tbot = new ToyBotObj(Tuple.Create<short, short>(0, 0), 0, 0, Tuple.Create<short, short>(5, 5));
            tbot.Rotate(-1);
            Assert.AreEqual(tbot.Orientation, 3);
        }

        /*
         * Unit Testing Find Orientation
         */
        [TestMethod]
        public void FindOrientationTest1()
        {
            ToyBotObj tbot = new ToyBotObj(Tuple.Create<short, short>(0, 0), 0, 0, Tuple.Create<short, short>(5, 5));
            Assert.AreEqual(tbot.FindOrientation(tbot.Orientation), "North");
        }

        [TestMethod]
        public void FindOrientationTest2()
        {
            ToyBotObj tbot = new ToyBotObj(Tuple.Create<short, short>(0, 0), 1, 0, Tuple.Create<short, short>(5, 5));
            Assert.AreEqual(tbot.FindOrientation(tbot.Orientation), "East");
        }

        [TestMethod]
        public void FindOrientationTest3()
        {
            ToyBotObj tbot = new ToyBotObj(Tuple.Create<short, short>(0, 0), 2, 0, Tuple.Create<short, short>(5, 5));
            Assert.AreEqual(tbot.FindOrientation(tbot.Orientation), "South");
        }

        [TestMethod]
        public void FindOrientationTest4()
        {
            ToyBotObj tbot = new ToyBotObj(Tuple.Create<short, short>(0, 0), 3, 0, Tuple.Create<short, short>(5, 5));
            Assert.AreEqual(tbot.FindOrientation(tbot.Orientation), "West");
        }
    }
}
