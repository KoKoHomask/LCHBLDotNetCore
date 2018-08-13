using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LCHBLDotNetCore.Models.BankModels
{
    public class BOC:BaseBankModel
    {
        
       
       
        public decimal xhmrj { get; set; }
        public decimal xcmrj { get; set; }
        public decimal xhmcj { get; set; }
        public decimal xcmcj { get; set; }//xcmcj
        public decimal zhzsj { get; set; }//中行折算价
    }
}
