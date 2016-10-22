using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day2_Homework
{
    public class PotterShoppingCart
    {
        private int[] _qty = new int[5];

        public int Amount { get; set; }

        public void AddItem(int episode, int qty)
        {
            this._qty[episode - 1] += qty;
        }

        public void Checkout()
        {
            this.Amount = _qty.Sum() * 100;
        }
    }
}
