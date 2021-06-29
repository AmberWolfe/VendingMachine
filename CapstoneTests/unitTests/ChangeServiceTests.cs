using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.classes.Tests
{
    [TestClass()]
    public class ChangeServiceTests
    {
        [TestMethod()]
        public void GetChangeTestQuater()
        {

            ChangeService changeDispenser = new ChangeService();

            int[] actualChangeList = new int[3]; 
            actualChangeList = changeDispenser.GetChange(1.00M);

            int[] expectedChangeList = new int[] { 4, 0, 0 };
            Assert.ReferenceEquals(expectedChangeList, actualChangeList);
        }

        [TestMethod()]
        public void GetChangeTestQuaterDime()
        {

            ChangeService changeDispenser = new ChangeService();

            int[] actualChangeList = new int[3];
            actualChangeList = changeDispenser.GetChange(0.85M);

            int[] expectedChangeList = new int[] { 3, 1, 0 };
            Assert.ReferenceEquals(expectedChangeList, actualChangeList);
        }

        [TestMethod()]
        public void GetChangeTestQuaterDimeNickel()
        {

            ChangeService changeDispenser = new ChangeService();

            int[] actualChangeList = new int[3];
            actualChangeList = changeDispenser.GetChange(0.90M);

            int[] expectedChangeList = new int[] { 3, 1, 1 };
            Assert.ReferenceEquals(expectedChangeList, actualChangeList);
        }
        [TestMethod]
        public void GetChangeTestWrongAmount()
        {
            ChangeService changeDispenser = new ChangeService();

            int[] actualChangeList = new int[3];
            actualChangeList = changeDispenser.GetChange(0.91M);

            int[] expectedChangeList = new int[] { 3, 1, 1 };
            Assert.ReferenceEquals(expectedChangeList, actualChangeList);
        }
        [TestMethod]
        public void GetChangeTestRandom()
        {
            ChangeService changeDispenser = new ChangeService();

            int[] actualChangeList = new int[3];
            actualChangeList = changeDispenser.GetChange(10.40M);

            int[] expectedChangeList = new int[] { 41, 1, 1 };
            Assert.ReferenceEquals(expectedChangeList, actualChangeList);
        }
    }
}