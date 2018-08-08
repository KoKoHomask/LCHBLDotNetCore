using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LCHBLDotNetCore.Models.BankModels
{
    public class PSBC:BaseBankModel
    {
        public string hbmc { get; set; }
        public string hbsx { get; set; }
        public decimal xhmrj { get; set; }
        public decimal xcmrj { get; set; }
        public decimal mcj { get; set; }//卖出价
        public decimal jzj { get; set; }//基准价
        public DateTime updatetime { get; set; }

        public string picUrl2x { get; set; }
        public string picUrl3x { get; set; }
    }
}
