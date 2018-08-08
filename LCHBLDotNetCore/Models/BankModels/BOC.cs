using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LCHBLDotNetCore.Models.BankModels
{
    public class BOC:BaseBankModel
    {
        
        [Key]
        public int ID { get; set; }
        public string hbmc { get; set; }
        // public string currency { get; set; }
        public string hbsx { get; set; }
        public decimal xhmrj { get; set; }
        public decimal xcmrj { get; set; }
        public decimal xhmcj { get; set; }
        public decimal xcmcj { get; set; }//xcmcj
        public decimal zhzsj { get; set; }//中行折算价

        public string picUrl2x { get; set; }
        public string picUrl3x { get; set; }
        public DateTime updatetime { get; set; }
    }
}
