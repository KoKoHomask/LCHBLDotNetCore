using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LCHBLDotNetCore.Models.BankModels
{
    public class CMB : BaseBankModel
    {
        public string hbmc { get; set; }
        public string hbsx { get; set; }
        public decimal xhmrj { get; set; }
        public decimal xhmcj { get; set; }
        public decimal xcmrj { get; set; }
        public decimal xcmcj { get; set; }
        public DateTime updatetime { get; set; }
    }
}
