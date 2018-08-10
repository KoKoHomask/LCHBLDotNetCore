using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AngleSharp.Parser.Html;
using LCHBLDotNetCore.Models.BankModels;
using LCHBLDotNetCore.Other;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Xml;

namespace LCHBLDotNetCore.Controllers
{
    //[Route("api/[controller]/[action]")]
    [ApiController]
    public class HuiLvController : ControllerBase
    {
        [Route("api/exchangeRate/GetER")]
        public List<AllHuiLv> GetER()
        {
            List<AllHuiLv> lst = new List<AllHuiLv>();
            lst.Add(new AllHuiLv(){
                 bankName="建设银行",
                  bankPoperty=CCB(),
            });
            lst.Add(new AllHuiLv(){
                bankName = "工商银行",
                bankPoperty = ICBC(),
            });
            lst.Add(new AllHuiLv(){
                bankName = "邮政银行",
                bankPoperty = PSBC(),
            });
            lst.Add(new AllHuiLv(){
                bankName = "中国银行",
                bankPoperty = BOC(),
            });
            lst.Add(new AllHuiLv(){
                bankName = "农业银行",
                bankPoperty = ABC(),
            });
            lst.Add(new AllHuiLv()
            {
                bankName = "交通银行",
                bankPoperty = BCM(),
            });
            return lst;
        }
        [Route("api/BCM/GetAllProducts")]
        public List<BCM> BCM()
        {
            var cache = GetCacheObject<BCM>("BCM", 20);
            var data = cache.GetData();
            if (data != null)
                return data.Data;
            HttpHelper httpHelper = new HttpHelper();
            var htmlResult = httpHelper.GetHtml(new HttpItem() { URL = "http://www.bankcomm.com/BankCommSite/simple/cn/whpj/queryExchangeResult.do?type=simple" });
            HtmlParser htmlParser = new HtmlParser();
            DateTime dt = DateTime.Now;
            var result = htmlParser.Parse(htmlResult.Html).QuerySelectorAll("tr.data").Select(t => new BCM()
                {
                    hbmc = t.QuerySelectorAll("td")[0].TextContent.Substring(0, t.QuerySelectorAll("td")[0].TextContent.IndexOf("(")),
                    hbsx = CurrencyAcronyms.getKHAcronyms(t.QuerySelectorAll("td")[0].TextContent.Substring(0, t.QuerySelectorAll("td")[0].TextContent.IndexOf("(")).Substring(0,2)),
                    xhmrj = decimal.Parse(t.QuerySelectorAll("td")[1].TextContent=="-" ? "0": t.QuerySelectorAll("td")[1].TextContent),
                    xhmcj= decimal.Parse(t.QuerySelectorAll("td")[2].TextContent == "-" ? "0" : t.QuerySelectorAll("td")[2].TextContent),
                    xcmrj = decimal.Parse(t.QuerySelectorAll("td")[3].TextContent == "-" ? "0" : t.QuerySelectorAll("td")[3].TextContent),
                    xcmcj= decimal.Parse(t.QuerySelectorAll("td")[4].TextContent == "-" ? "0" : t.QuerySelectorAll("td")[4].TextContent),
                    updatetime = dt,
                }).ToList();
            cache.AddData(result);//添加缓存
            return result;
        }
        [Route("api/CCB/GetAllProducts")]
        public List<CCB> CCB()
        {
            var cache = GetCacheObject<CCB>("CCB",20);
            var data = cache.GetData();
            if (data != null)
                return data.Data;
            HttpHelper httpHelper = new HttpHelper();
            var htmlResult = httpHelper.GetHtml(new HttpItem() { URL = "http://forex1.ccb.com/cn/home/news/jshckpj_new.xml", Accept = "application/json, text/javascript, */*; q=0.01" });
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(htmlResult.Html.Replace("-name", "name"));
            string jsonStr= JsonConvert.SerializeXmlNode(doc);
            var jsonResult = JsonConvert.DeserializeObject<CCBRoot>(jsonStr);
            DateTime dateTime = DateTime.Now;
            var result = jsonResult.ReferencePriceSettlements.ReferencePriceSettlement.Select(t => new CCB()
            { 
                hbmc= CurrencyAcronyms.getCCBHBMC( t.Ofrd_Ccy_CcyCd),
                hbsx=CurrencyAcronyms.getKHAcronyms(CurrencyAcronyms.getCCBHBMC(t.Ofrd_Ccy_CcyCd).Substring(0,2)),
                xhmrj=decimal.Parse(t.BidRateOfCcy),
                xhmcj= decimal.Parse(t.OfrRateOfCcy),
                xcmrj=decimal.Parse(t.BidRateOfCash),
                xcmcj=decimal.Parse(t.OfrRateOfCcy),
                updatetime = dateTime,
            }).ToList();
            cache.AddData(result);//添加缓存
            return result;
        }

        [Route("api/PSBC/GetAllProducts")]
        public List<PSBC> PSBC()
        {
            var cache = GetCacheObject<PSBC>("PSBC",20);
            var data = cache.GetData();
            if (data != null)
                return data.Data;
            HttpHelper httpHelper = new HttpHelper();
            var htmlResult = httpHelper.GetHtml(new HttpItem() { URL = "http://www.psbc.com/cms/queryExchange.do" });
            HtmlParser htmlParser = new HtmlParser();
            DateTime dt = DateTime.Now;
            var result = htmlParser.Parse(htmlResult.Html).QuerySelectorAll("tbody").
                Where(t => t.TextContent.IndexOf("货币名称") > 0).LastOrDefault().QuerySelectorAll("tr").
                Where(t => t.TextContent.IndexOf("货币名称") < 0).Take(7).Select(t => new PSBC()
                {
                    hbmc = t.QuerySelectorAll("td")[0].TextContent.Replace("\n","").Replace(" ",""),
                    hbsx = CurrencyAcronyms.getKHAcronyms(t.QuerySelectorAll("td")[0].TextContent.Substring(0,2)).Replace("\n", "").Replace(" ", ""),
                    xhmrj = decimal.Parse(t.QuerySelectorAll("td")[1].TextContent),
                    xcmrj = decimal.Parse(t.QuerySelectorAll("td")[2].TextContent),
                    mcj= decimal.Parse(t.QuerySelectorAll("td")[3].TextContent),
                    jzj = decimal.Parse(t.QuerySelectorAll("td")[4].TextContent),
                    updatetime = dt,
                }).ToList();
            cache.AddData(result);//添加缓存
            return result;
        }
        [Route("api/ICBC/GetAllProducts")]
        public List<ICBC> ICBC()
        {
            var cache = GetCacheObject<ICBC>("ICBC",20);
            var data = cache.GetData();
            if (data != null)
                return data.Data;
            HttpHelper httpHelper = new HttpHelper();
            var htmlResult = httpHelper.GetHtml(new HttpItem() { URL = "http://www.icbc.com.cn/ICBCDynamicSite/Optimize/Quotation/QuotationListIframe.aspx" });
            HtmlParser htmlParser = new HtmlParser();
            DateTime dt = DateTime.Now;
            var result = htmlParser.Parse(htmlResult.Html).QuerySelectorAll("tbody").
                Where(t => t.TextContent.IndexOf("币种") > 0).LastOrDefault().QuerySelectorAll("tr").
                Where(t => t.TextContent.IndexOf("币种") < 0).Select(t => new ICBC()
                {
                    hbmc = t.QuerySelectorAll("td")[0].TextContent.Substring(0, t.QuerySelectorAll("td")[0].TextContent.IndexOf("(")),
                    hbsx = t.QuerySelectorAll("td")[0].TextContent.Substring(t.QuerySelectorAll("td")[0].TextContent.IndexOf("(")),
                    xhmrj = decimal.Parse(t.QuerySelectorAll("td")[1].TextContent == "--" ? "0" : t.QuerySelectorAll("td")[1].TextContent),
                    xcmrj = decimal.Parse(t.QuerySelectorAll("td")[2].TextContent == "--" ? "0" : t.QuerySelectorAll("td")[2].TextContent),
                    xhmcj = decimal.Parse(t.QuerySelectorAll("td")[3].TextContent == "--" ? "0" : t.QuerySelectorAll("td")[3].TextContent),
                    xcmcj = decimal.Parse(t.QuerySelectorAll("td")[4].TextContent == "--" ? "0" : t.QuerySelectorAll("td")[4].TextContent),
                    updatetime=dt,
                }).ToList();
            cache.AddData(result);//添加缓存
            return result;
        }
        [Route("api/BOC/GetAllProducts")]
        public List<BOC> BOC()
        {
            var cache = GetCacheObject<BOC>("BOC",20);
            var data = cache.GetData();
            if (data != null)
                return data.Data;
            HttpHelper httpHelper = new HttpHelper();
            var htmlResult = httpHelper.GetHtml(new HttpItem() { URL = "http://www.boc.cn/sourcedb/whpj/index.html" });
            HtmlParser htmlParser = new HtmlParser();
            DateTime dt = DateTime.Now;
            var result = htmlParser.Parse(htmlResult.Html).QuerySelectorAll("tbody").
                Where(t => t.TextContent.IndexOf("货币名称") > 0).FirstOrDefault().QuerySelectorAll("tr").
                Where(t => t.TextContent.IndexOf("货币名称") < 0).Select(t => new BOC()
                {
                    hbmc = t.QuerySelectorAll("td")[0].TextContent,
                    xhmrj = decimal.Parse(t.QuerySelectorAll("td")[1].TextContent == "" ? "0" : t.QuerySelectorAll("td")[1].TextContent),
                    xcmrj = decimal.Parse(t.QuerySelectorAll("td")[2].TextContent == "" ? "0" : t.QuerySelectorAll("td")[2].TextContent),
                    xhmcj = decimal.Parse(t.QuerySelectorAll("td")[3].TextContent == "" ? "0" : t.QuerySelectorAll("td")[3].TextContent),
                    xcmcj = decimal.Parse(t.QuerySelectorAll("td")[4].TextContent == "" ? "0" : t.QuerySelectorAll("td")[4].TextContent),
                    zhzsj = decimal.Parse(t.QuerySelectorAll("td")[5].TextContent == "" ? "0" : t.QuerySelectorAll("td")[5].TextContent),
                    hbsx=CurrencyAcronyms.getKHAcronyms(t.QuerySelectorAll("td")[0].TextContent.Substring(0,2)),
                    updatetime = dt,
                }).ToList();
            cache.AddData(result);//添加缓存
            return result;
        }
        [Route("api/ABC/GetAllProducts")]
        public List<ABC> ABC()
        {
            var cache = GetCacheObject<ABC>("ABC",20);
            var data = cache.GetData();
            if (data != null)
                return data.Data;
            HttpHelper httpHelper = new HttpHelper();
            var htmlResult = httpHelper.GetHtml(new HttpItem() { URL = "http://ewealth.abchina.com/app/data/api/DataService/ExchangeRateV2", Accept = "application/json, text/javascript, */*; q=0.01" });
            var jsonResult = JsonConvert.DeserializeObject<ABCRoot>(htmlResult.Html);
            DateTime dateTime = DateTime.Now;
            var result= jsonResult.Data.Table.Select(t => new ABC()
            {
                hbmc = t.CurrName.Substring(0, t.CurrName.IndexOf("(")),
                hbsx = t.CurrName.Substring(t.CurrName.IndexOf("(")),
                mrhl=t.BuyingPrice,
                mchl=t.SellPrice,
                xcmrhl=t.CashBuyingPrice,
                updatetime= dateTime,
            }).ToList();
            cache.AddData(result);//添加缓存
            return result;
        }
        
        /// <summary>
        /// 获取缓存对象
        /// </summary>
        /// <returns></returns>
        public EasyCache<List<T>> GetCacheObject<T>(string key,int? minutes = null)
        {
            //var key = Request.Path.Value + Request.QueryString.Value;
            var time = DateTime.Now.AddMinutes(minutes ?? 10) - DateTime.Now;//缓存10分钟
            EasyCache<List<T>> obj = new EasyCache<List<T>>(key, time);
            return obj;
        }
    }
}