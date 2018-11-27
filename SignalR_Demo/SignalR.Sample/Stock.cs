using System;

namespace Microsoft.AspNet.SignalR.StockTicker
{
    /// <summary>
    /// 股票实体类
    /// </summary>
    public class Stock
    {
        /// <summary>
        /// 价格字段
        /// </summary>
        private decimal _price;

        /// <summary>
        /// 符号,象征
        /// </summary>
        public string Symbol { get; set; }
        
        /// <summary>
        /// 开启时间
        /// </summary>
        public decimal DayOpen { get; private set; }
        
        public decimal DayLow { get; private set; }
        
        public decimal DayHigh { get; private set; }

        public decimal LastChange { get; private set; }

        public decimal Change
        {
            get
            {
                return Price - DayOpen;
            }
        }

        public double PercentChange
        {
            get
            {
                return (double)Math.Round(Change / Price, 4);
            }
        }

        public decimal Price
        {
            get
            {
                return _price;
            }
            set
            {
                if (_price == value)
                {
                    return;
                }
                
                LastChange = value - _price;
                _price = value;
                
                if (DayOpen == 0)
                {
                    DayOpen = _price;
                }
                if (_price < DayLow || DayLow == 0)
                {
                    DayLow = _price;
                }
                if (_price > DayHigh)
                {
                    DayHigh = _price;
                }
            }
        }
    }
}
