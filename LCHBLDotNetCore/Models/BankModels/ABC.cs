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
    }
}
