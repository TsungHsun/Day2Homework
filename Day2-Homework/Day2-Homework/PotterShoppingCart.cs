using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day2_Homework
{
    public class PotterShoppingCart
    {
        private int[] _qty = new int[5];
        private int _unitPrice = 100;

        public int Amount { get; set; }

        public void AddItem(int episode, int qty)
        {
            this._qty[episode - 1] += qty;
        }

        public void Checkout()
        {
            int qty = _qty.Sum();
            int unitPrice = this._unitPrice;
            double discount = this.GetDiscount();

            this.Amount = Convert.ToInt32(Math.Round(qty * unitPrice * discount));
        }

        private double GetDiscount()
        {
            int differentCount = this._qty.Count(q => q > 0);

            switch (differentCount)
            {
                case 2:
                    return 0.95;
                default:
                    return 1;
            }
        }
    }
}
