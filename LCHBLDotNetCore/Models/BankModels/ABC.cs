using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LCHBLDotNetCore.Models.BankModels
{
    public class ABC:BaseBankModel
    {
        public string hbmc { get; set; }
        public string hbsx { get; set; }
        public string mrhl { get; set; }
        public string mchl { get; set; }
        public string xcmrhl { get; set; }//mchl
        public string picUrl2x { get; set; }
        public string picUrl3x { get; set; }
        public DateTime updatetime { get; set; }
    }
    public class TableItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string BenchMarkPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string BuyingPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SellPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CashBuyingPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PublishTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CurrId { get; set; }
        /// <summary>
        /// 挪威克朗(NOK)
        /// </summary>
        public string CurrName { get; set; }
    }

    public class Data
    {
        /// <summary>
        /// 
        /// </summary>
        public List<TableItem> Table { get; set; }
    }

    public class ABCRoot
    {
        /// <summary>
        /// 
        /// </summary>
        public Data Data { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ErrorCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ErrorMsg { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Url { get; set; }
    }
}
