using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LCHBLDotNetCore.Models.BankModels
{
    public class CMBC:BaseBankModel
    {
        public string hbmc { get; set; }
        public string hbsx { get; set; }
        public decimal xhmrj { get; set; }
        public decimal xhmcj { get; set; }
        public DateTime updatetime { get; set; }
    }
    public class ResultItem
    {
        /// <summary>
        /// 
        /// </summary>
        public double sellPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string foreignCurrency { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string cxfg { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string updateTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string extend1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double buyPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string extend2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string domesticCurrency { get; set; }
    }

    public class ReturnCode
    {
        /// <summary>
        /// 
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string type { get; set; }
    }

    public class CMBCRoot
    {
        /// <summary>
        /// 
        /// </summary>
        public List<ResultItem> result { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ReturnCode returnCode { get; set; }
    }
}
