using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LCHBLDotNetCore.Models.BankModels
{
    public class AllHuiLv
    {
        public string bankName { get; set; }
        public string bankPicUrl2x { get; set; }
        public string bankPicUrl3x { get; set; }
        public IEnumerable<BaseBankModel> bankPoperty { get; set; }
    }
}
