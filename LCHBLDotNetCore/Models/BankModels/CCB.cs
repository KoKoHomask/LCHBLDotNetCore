using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LCHBLDotNetCore.Models.BankModels
{
    public class CCB : BaseBankModel
    {
        public string hbmc { get; set; }
        public string hbsx { get; set; }
        public decimal xhmrj { get; set; }
        public decimal xhmcj { get; set; }
        public decimal xcmrj { get; set; }
        public decimal xcmcj { get; set; }
        public string picUrl2x { get; set; }
        public string picUrl3x { get; set; }
        public DateTime updatetime { get; set; }
    }
    public class ReferencePriceSettlementItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Ofrd_Ccy_CcyCd { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Ofr_Ccy_CcyCd { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string BidRateOfCash { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string OfrRateOfCash { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string BidRateOfCcy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string OfrRateOfCcy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string HBBnk_Bss_Buy_Prc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string HBBnk_Bss_Sell_Prc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Mdl_ExRt_Prc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LstPr_Dt { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LstPr_Tm { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ExRt_StCd { get; set; }
    }

    public class ReferencePriceSettlements
    {
        /// <summary>
        /// 
        /// </summary>
        public string ExRt_Ctlg_ID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ExRt_Ctlg_ShrtNm { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CCBIns_ID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<ReferencePriceSettlementItem> ReferencePriceSettlement { get; set; }
    }

    public class CCBRoot
    {
        /// <summary>
        /// 
        /// </summary>
        public ReferencePriceSettlements ReferencePriceSettlements { get; set; }
    }

}
