using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day2_Homework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day2_Homework.Tests
{
    [TestClass()]
    public class PotterShoppingCartTests
    {
        [TestMethod()]
        public void CheckoutTest_第一集買了一本_其他都沒買_價格應為100()
        {
            PotterShoppingCart target = new PotterShoppingCart();
            int episode = 1;
            int qty = 1;
            target.AddItem(episode, qty);
            int expected = 100;

            target.Checkout();
            int actual = target.Amount;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CheckoutTest_第一集買了一本_第二集也買了一本_價格應為190()
        {
            PotterShoppingCart target = new PotterShoppingCart();
            int qty = 1;
            int episode;
            episode = 1;
            target.AddItem(episode, qty);
            episode = 2;
            target.AddItem(episode, qty);
            int expected = 190;

            target.Checkout();
            int actual = target.Amount;

            Assert.AreEqual(expected, actual);
        }
    }
}