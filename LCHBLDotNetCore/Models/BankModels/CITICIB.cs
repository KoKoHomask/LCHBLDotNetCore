using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LCHBLDotNetCore.Models.BankModels
{
    public class CITICIB : BaseBankModel
    {
        public decimal zjj { get; set; }
        public decimal xhmrj { get; set; }
        public decimal xhmcj { get; set; }
        public decimal xcmrj { get; set; }
        public decimal xcmcj { get; set; }
    }
    public class ResultListItem
    {
        /// <summary>
        /// 2018年08月13日
        /// </summary>
        public string quotePriceDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string quotePriceTime { get; set; }
        /// <summary>
        /// 港币
        /// </summary>
        public string curName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string curCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string totalPidPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string totalSellPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string cstexcBuyPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string cstexcSellPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string cstpurBuyPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string cstpurSellPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string midPrice { get; set; }
    }

    public class Content
    {
        /// <summary>
        /// 
        /// </summary>
        public List<ResultListItem> resultList { get; set; }
    }

    public class CITICIBRoot
    {
        /// <summary>
        /// 
        /// </summary>
        public int totalCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int pageCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string retCode { get; set; }
        /// <summary>
        /// 查询成功
        /// </summary>
        public string retMsg { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Content content { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string optFlag { get; set; }
    }
}
