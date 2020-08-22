using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyBot;

namespace ToyBotTest
{
    [TestClass]
    public class GeneralUtilitiesTest
    {
        /*
         * Unit Testing Mod.
         */
        [TestMethod]
        public void ModTest1()
        {
            Assert.AreEqual(GeneralUtilities.Mod(1,5), 1);
        }

        [TestMethod]
        public void ModTest2()
        {
            Assert.AreEqual(GeneralUtilities.Mod(-1, 5), 4);
        }

    }
}
