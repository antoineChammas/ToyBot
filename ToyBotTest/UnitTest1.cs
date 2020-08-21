using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyBot;

namespace ToyBotTest
{
    [TestClass]
    public class ToyBotTest
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
            Assert.AreEqual(tbot.PlanSize, Tuple.Create<short, short>(0, 1));
        }
    }
}
