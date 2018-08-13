using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LCHBLDotNetCore.Models.BankModels
{
    public class CIB:BaseBankModel
    {
        public decimal xhmrj { get; set; }
        public decimal xcmrj { get; set; }
        public decimal xhmcj { get; set; }
        public decimal xcmcj { get; set; }
    }
    public class CIBRowsItem
    {
        /// <summary>
        /// 
        /// </summary>
        public List<string> cell { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }
    }

    public class CIBRoot
    {
        /// <summary>
        /// 
        /// </summary>
        public string page { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string records { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string sidx { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string sord { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string total { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<CIBRowsItem> rows { get; set; }
    }
}
