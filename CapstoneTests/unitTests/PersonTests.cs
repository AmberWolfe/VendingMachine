using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests.unitTests
{
    [TestClass]
    public class PersonTests
    {
        //These are the "Add Balance" tests
        [TestMethod]
        public void AddBalanceAdd1()
        {
            Person person = new Person();
            bool expected = true;
            bool actual = person.AddBalance("1");
            Assert.AreEqual(expected, actual); 
        }
        [TestMethod]
        public void AddBalanceAdd5()
        {
            Person person = new Person();
            bool expected = true;
            bool actual = person.AddBalance("5");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void AddBalanceAdd10()
        {
            Person person = new Person();
            bool expected = true;
            bool actual = person.AddBalance("10");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void AddBalanceAdd20()
        {
            Person person = new Person();
            bool expected = true;
            bool actual = person.AddBalance("20");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddBalanceAdd2()
        {
            Person person = new Person();
            bool expected = true;
            bool actual = person.AddBalance("2");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddBalanceIntOverFlow()
        {
            Person person = new Person();
            bool expected = false;
            bool actual = person.AddBalance("100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddBalanceAddDecimal1()
        {
            Person person = new Person();
            bool expected = false;
            bool actual = person.AddBalance("1.00");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddBalanceAddDecimalOverflow()
        {
            Person person = new Person();
            bool expected = false;
            bool actual = person.AddBalance("1.0000000000000000000000000000000000000000000000000000000000000000000000002");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddBalanceAddDecimal1AndCents()
        {
            Person person = new Person();
            bool expected = false;
            bool actual = person.AddBalance("1.05");
            Assert.AreEqual(expected, actual);
        }

        //These are the Select Product tests
        [TestMethod]
        public void SelectProductA1()
        {
            Person person = new Person();
            person.AddBalance("20");
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.StockInventory();

            string actual = person.SelectProduct("A1", vendingMachine);
            string expected = "Chip";
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SelectProductB2()
        {
            Person person = new Person();
            person.AddBalance("20");
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.StockInventory();

            string actual = person.SelectProduct("B2", vendingMachine);
            string expected = "Candy";
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SelectProductC4()
        {
            Person person = new Person();
            person.AddBalance("20");
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.StockInventory();

            string actual = person.SelectProduct("C4", vendingMachine);
            string expected = "Drink";
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SelectProductD5()
        {
            Person person = new Person();

            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.StockInventory();
            string actual = person.SelectProduct("D5", vendingMachine);
            string expected = "Error: Location does not exist."; 
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SelectProductA1SixTimes()
        {
            Person person = new Person();
            person.AddBalance("20");
            person.AddBalance("20");

            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.StockInventory();
            string actual = "";
            for (int i = 1; i <= 6; i++)
            {
                actual = person.SelectProduct("A1", vendingMachine);
            }
            string expected = "Sold Out"; 
            Assert.AreEqual(expected, actual); 
        }
    }
}
