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

        [TestMethod()]
        public void CheckoutTest_一二三集各買了一本_價格應為270()
        {
            PotterShoppingCart target = new PotterShoppingCart();
            int qty = 1;

            int episode;
            episode = 1;
            target.AddItem(episode, qty);
            episode = 2;
            target.AddItem(episode, qty);
            episode = 3;
            target.AddItem(episode, qty);
            int expected = 270;

            target.Checkout();
            int actual = target.Amount;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CheckoutTest_一二三四集各買了一本_價格應為320()
        {
            PotterShoppingCart target = new PotterShoppingCart();
            int qty = 1;

            int episode;
            episode = 1;
            target.AddItem(episode, qty);
            episode = 2;
            target.AddItem(episode, qty);
            episode = 3;
            target.AddItem(episode, qty);
            episode = 4;
            target.AddItem(episode, qty);
            int expected = 320;

            target.Checkout();
            int actual = target.Amount;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CheckoutTest_一次買了整套_一二三四五集各買了一本_價格應為375()
        {
            PotterShoppingCart target = new PotterShoppingCart();
            int qty = 1;

            int episode;
            episode = 1;
            target.AddItem(episode, qty);
            episode = 2;
            target.AddItem(episode, qty);
            episode = 3;
            target.AddItem(episode, qty);
            episode = 4;
            target.AddItem(episode, qty);
            episode = 5;
            target.AddItem(episode, qty);
            int expected = 375;

            target.Checkout();
            int actual = target.Amount;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CheckoutTest_一二集各買了一本_第三集買了兩本_價格應為370()
        {
            PotterShoppingCart target = new PotterShoppingCart();
            int qty = 1;

            int episode;
            episode = 1;
            target.AddItem(episode, qty);
            episode = 2;
            target.AddItem(episode, qty);
            episode = 3;
            qty = 2;
            target.AddItem(episode, qty);
            int expected = 370;

            target.Checkout();
            int actual = target.Amount;

            Assert.AreEqual(expected, actual);
        }
    }
}