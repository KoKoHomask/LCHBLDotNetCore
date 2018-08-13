using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LCHBLDotNetCore.Models.BankModels
{
    public class SPDB : BaseBankModel
    {
        
        public decimal xhmrj { get; set; }
        public decimal xcmrj { get; set; }
        public decimal mcj { get; set; }
        public decimal zjj { get; set; }
        
    }
    public class RowsItem
    {
        /// <summary>
        /// 人民币 RMB
        /// </summary>
        public string CurrencyName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SellPrc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MdlPrc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CashBuyPrc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CREATE_DATE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string BuyPrc { get; set; }
    }

    public class SPDBRoot
    {
        /// <summary>
        /// 
        /// </summary>
        public int total { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int pageTotal { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int pageSize { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<RowsItem> rows { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int pageIndex { get; set; }
    }
}
