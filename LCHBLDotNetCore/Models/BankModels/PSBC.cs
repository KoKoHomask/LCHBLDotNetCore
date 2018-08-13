using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LCHBLDotNetCore.Models.BankModels
{
    public class PSBC:BaseBankModel
    {
       
        public decimal xhmrj { get; set; }
        public decimal xcmrj { get; set; }
        public decimal mcj { get; set; }//卖出价
        public decimal jzj { get; set; }//基准价
       
    }
}
