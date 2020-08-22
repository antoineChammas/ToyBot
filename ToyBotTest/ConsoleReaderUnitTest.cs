using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyBot;

namespace ToyBotTest
{
    [TestClass]
    public class ConsoleReaderUnitTest
    {
        /*
         * Unit Testing InterpretInput.
         */

        [TestMethod]
        public void InterpretInputTest1()
        {
            ConsoleReader cr = new ConsoleReader();
            Assert.AreEqual(cr.InterpretInput("PLACE 1,2,North"),
                            Tuple.Create<short,short,short,short>(0, 1, 2, 0));
        }

        [TestMethod]
        public void InterpretInputTest2()
        {
            ConsoleReader cr = new ConsoleReader();
            Assert.AreEqual(cr.InterpretInput("PLACE 1,23"),
                            Tuple.Create<short, short, short, short>(-1, -1, -1, -1));
        }

        [TestMethod]
        public void InterpretInputTest3()
        {
            ConsoleReader cr = new ConsoleReader();
            Assert.AreEqual(cr.InterpretInput("PLACE 123"),
                            Tuple.Create<short, short, short, short>(-1, -1, -1, -1));
        }

        [TestMethod]
        public void InterpretInputTest4()
        {
            ConsoleReader cr = new ConsoleReader();
            Assert.AreEqual(cr.InterpretInput("PLACE 2,1,b"),
                            Tuple.Create<short, short, short, short>(-1, -1, -1, -1));
        }

        [TestMethod]
        public void InterpretInputTest5()
        {
            ConsoleReader cr = new ConsoleReader();
            Assert.AreEqual(cr.InterpretInput("MOvE"),
                            Tuple.Create<short, short, short, short>(1, -1, -1, -1));
        }

        [TestMethod]
        public void InterpretInputTest6()
        {
            ConsoleReader cr = new ConsoleReader();
            Assert.AreEqual(cr.InterpretInput("LeFt"),
                            Tuple.Create<short, short, short, short>(2, -1, -1, -1));
        }

        [TestMethod]
        public void InterpretInputTest7()
        {
            ConsoleReader cr = new ConsoleReader();
            Assert.AreEqual(cr.InterpretInput("rIgHt"),
                            Tuple.Create<short, short, short, short>(2, -1, -1, 1));
        }

        [TestMethod]
        public void InterpretInputTest8()
        {
            ConsoleReader cr = new ConsoleReader();
            Assert.AreEqual(cr.InterpretInput("Report"),
                            Tuple.Create<short, short, short, short>(3, -1, -1, -1));
        }

        [TestMethod]
        public void InterpretInputTest9()
        {
            ConsoleReader cr = new ConsoleReader();
            Assert.AreEqual(cr.InterpretInput("rIgHts"),
                            Tuple.Create<short, short, short, short>(-1, -1, -1, -1));
        }

        [TestMethod]
        public void InterpretInputTest10()
        {
            ConsoleReader cr = new ConsoleReader();
            Assert.AreEqual(cr.InterpretInput("quit"),
                            Tuple.Create<short, short, short, short>(4, -1, -1, -1));
        }

        /*
         * Unit Testing Find Orientation
         */
        [TestMethod]
        public void FindOrientationTest1()
        {
            ConsoleReader cr = new ConsoleReader();
            Assert.AreEqual(cr.FindOrientation("north"),
                            0);
        }

        [TestMethod]
        public void FindOrientationTest2()
        {
            ConsoleReader cr = new ConsoleReader();
            Assert.AreEqual(cr.FindOrientation("east"),
                            1);
        }

        [TestMethod]
        public void FindOrientationTest3()
        {
            ConsoleReader cr = new ConsoleReader();
            Assert.AreEqual(cr.FindOrientation("south"),
                            2);
        }

        [TestMethod]
        public void FindOrientationTest4()
        {
            ConsoleReader cr = new ConsoleReader();
            Assert.AreEqual(cr.FindOrientation("west"),
                            3);
        }

        [TestMethod]
        public void FindOrientationTest5()
        {
            ConsoleReader cr = new ConsoleReader();
            Assert.AreEqual(cr.FindOrientation("North"),
                            -1);
        }
    }
}
