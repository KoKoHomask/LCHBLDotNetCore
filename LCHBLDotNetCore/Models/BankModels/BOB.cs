using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LCHBLDotNetCore.Models.BankModels
{
    public class BOB : BaseBankModel
    {
        public string hbmc { get; set; }
        public string hbsx { get; set; }
        public decimal xhmrj { get; set; }
        public decimal xcmrj { get; set; }
        public decimal mcj { get; set; }
        public decimal zjj { get; set; }
        public DateTime updatetime { get; set; }
    }
}
