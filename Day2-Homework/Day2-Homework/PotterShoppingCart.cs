using System;
using System.Collections.Generic;
using System.Linq;

namespace Day2_Homework
{
    public class PotterShoppingCart
    {
        private Dictionary<Episode, int> _qtyRecords;
        private Dictionary<int, double> _discountRates;
        private const int _unitPrice = 100;

        public PotterShoppingCart()
        {
            this._qtyRecords = new Dictionary<Episode, int>();
            this.InitializeDiscountRates();
        }

        /// <summary>
        /// 初始化折扣率資料
        /// </summary>
        private void InitializeDiscountRates()
        {
            this._discountRates = new Dictionary<int, double>()
            {
                { 1, 1 },
                { 2, 0.95 },
                { 3, 0.9 },
                { 4, 0.8 },
                { 5, 0.75 }
            };
        }

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
            if (this._qtyRecords.ContainsKey(episode))
            {
                this._qtyRecords[episode] += qty;
            }
            else
            {
                this._qtyRecords.Add(episode, qty);
            }
        }

        /// <summary>
        /// 結帳
        /// </summary>
        public void Checkout()
        {
            if (!this._qtyRecords.Any()) return;

            bool hasUnchecked;

            do
            {
                int packageQty = this._qtyRecords.Keys.Count;
                double discount = this.GetDiscount(packageQty);

                int checkoutPackageCount = (this._qtyRecords.Keys.Count == 1) ? this._qtyRecords.Values.First() : this._qtyRecords.Values.Min();
                this.Amount += this.CalculateAmount(packageQty, discount) * checkoutPackageCount;

                this.RemoveCheckoutedQty(checkoutPackageCount);
                hasUnchecked = this._qtyRecords.Any();
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
            return Convert.ToInt32(Math.Round(qty * _unitPrice * discount));
        }

        /// <summary>
        /// 移除已結帳數量
        /// </summary>
        /// <param name="qty">已結帳數量</param>
        private void RemoveCheckoutedQty(int qty)
        {
            foreach (var key in this._qtyRecords.Keys.ToList())
            {
                this._qtyRecords[key] -= qty;
            }
            this._qtyRecords = this._qtyRecords.Where(v => v.Value > 0).ToDictionary(k => k.Key, v => v.Value);
        }

        /// <summary>
        /// 取得折扣
        /// </summary>
        /// <param name="packageQty">The package qty.</param>
        /// <returns>折扣趴數</returns>
        private double GetDiscount(int packageQty)
        {
            if (this._discountRates.ContainsKey(packageQty))
            {
                return this._discountRates[packageQty];
            }
            else
            {
                throw new NotImplementedException(string.Format("數量{0}折扣%數尚未定義", packageQty));
            }
        }
    }
}
