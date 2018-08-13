using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LCHBLDotNetCore.Models.BankModels
{
    public abstract class BaseBankModel
    {
        [Key]
        public int ID { get; set; }
        public string hbmc { get; set; }
        public string hbsx { get; set; }
        public string picUrl2x { get; set; }
        public string picUrl3x { get; set; }
        public DateTime updatetime { get; set; }
    }
}
