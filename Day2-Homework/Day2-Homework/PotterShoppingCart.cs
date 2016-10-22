using System;
using System.Linq;

namespace Day2_Homework
{
    public class PotterShoppingCart
    {
        private int[] _qtyRecords = new int[5];
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
            this._qtyRecords[(int)episode] += qty;
        }

        /// <summary>
        /// 結帳
        /// </summary>
        public void Checkout()
        {
            bool hasUnchecked;

            do
            {
                int packageQty = this._qtyRecords.Count(q => q > 0);
                double discount = this.GetDiscount(packageQty);

                this.Amount += this.CalculateAmount(packageQty, discount);

                this.RemoveCheckoutedQty();
                hasUnchecked = this._qtyRecords.Any(q => q > 0);
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
            for (int i = 0; i < this._qtyRecords.Length; i++)
            {
                if (this._qtyRecords[i] > 0)
                {
                    this._qtyRecords[i]--;
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
