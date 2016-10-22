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

        /// <summary>
        /// 發行集數
        /// </summary>
        public enum Episode
        {
            /// <summary>
            /// 第一集
            /// </summary>
            One,
            /// <summary>
            /// 第二集
            /// </summary>
            Two,
            /// <summary>
            /// 第三集
            /// </summary>
            Three,
            /// <summary>
            /// 第四集
            /// </summary>
            Four,
            /// <summary>
            /// 第五集
            /// </summary>
            Five
        }

        /// <summary>
        /// 金額
        /// </summary>
        public int Amount { get; private set; }
        
        /// <summary>
        /// 新增品項
        /// </summary>
        /// <param name="episode">發行集數</param>
        /// <param name="qty">數量</param>
        public void AddItem(Episode episode, int qty)
        {
            this._qty[(int)episode] += qty;
        }

        /// <summary>
        /// 結帳
        /// </summary>
        public void Checkout()
        {
            bool hasUnchecked;

            do
            {
                int packageQty = _qty.Count(q => q > 0);
                double discount = this.GetDiscount(packageQty);

                this.Amount += CalculateAmount(packageQty, discount);

                this.RemoveCheckoutedQty();
                hasUnchecked = this._qty.Any(q => q > 0);
            } while (hasUnchecked);
        }

        /// <summary>
        /// 計算金額
        /// </summary>
        /// <param name="qty">數量</param>
        /// <param name="discount">折扣</param>
        /// <returns>金額</returns>
        private int CalculateAmount(int qty, double discount)
        {
            return Convert.ToInt32(Math.Round(qty * this._unitPrice * discount));
        }

        /// <summary>
        /// 移除已結帳數量
        /// </summary>
        private void RemoveCheckoutedQty()
        {
            for (int i = 0; i < this._qty.Length; i++)
            {
                if (this._qty[i] > 0)
                {
                    this._qty[i]--;
                }
            }
        }

        /// <summary>
        /// 取得折扣
        /// </summary>
        /// <param name="packageQty">The package qty.</param>
        /// <returns>折扣趴數</returns>
        private double GetDiscount(int packageQty)
        {
            switch (packageQty)
            {
                case 1:
                    return 1;
                case 2:
                    return 0.95;
                case 3:
                    return 0.9;
                case 4:
                    return 0.8;
                case 5:
                default:
                    return 0.75;
            }
        }
    }
}
