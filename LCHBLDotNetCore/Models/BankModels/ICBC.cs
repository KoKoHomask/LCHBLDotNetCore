﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LCHBLDotNetCore.Models.BankModels
{
    public class ICBC:BaseBankModel
    {
        public string hbmc { get; set; }
        public string hbsx { get; set; }
        public decimal xhmrj { get; set; }
        public decimal xcmrj { get; set; }
        public decimal xhmcj { get; set; }
        public decimal xcmcj { get; set; }

        public string picUrl2x { get; set; }
        public string picUrl3x { get; set; }
        public DateTime updatetime { get; set; }
    }
}
