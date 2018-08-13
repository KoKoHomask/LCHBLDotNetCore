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
    [ApiController]
    public class HuiLvController : ControllerBase
    {
        [Route("api/exchangeRate/GetER")]
        public List<AllHuiLv> GetER()
        {
            List<AllHuiLv> lst = new List<AllHuiLv>();
            lst.Add(new AllHuiLv() { bankName = "建设银行", bankPoperty = CCB(), });
            lst.Add(new AllHuiLv() { bankName = "工商银行", bankPoperty = ICBC(), });
            lst.Add(new AllHuiLv() { bankName = "邮政银行", bankPoperty = PSBC(), });
            lst.Add(new AllHuiLv() { bankName = "中国银行", bankPoperty = BOC(), });
            lst.Add(new AllHuiLv() { bankName = "农业银行", bankPoperty = ABC(), });
            lst.Add(new AllHuiLv() { bankName = "交通银行", bankPoperty = BCM(), });
            lst.Add(new AllHuiLv() { bankName = "民生银行", bankPoperty = CMBC(), });
            lst.Add(new AllHuiLv() { bankName = "招商银行", bankPoperty = CMB(), });
            lst.Add(new AllHuiLv() { bankName = "北京银行", bankPoperty = BOB(), });
            lst.Add(new AllHuiLv() { bankName = "浦发银行", bankPoperty = SPDB(), });
            lst.Add(new AllHuiLv() { bankName = "中信银行", bankPoperty = CITICIB(), });
            lst.Add(new AllHuiLv() { bankName = "光大银行", bankPoperty = CEB(), });
            lst.Add(new AllHuiLv() { bankName = "华夏银行", bankPoperty = HB(), });
            lst.Add(new AllHuiLv() { bankName = "广发银行", bankPoperty = GDB(), });
            lst.Add(new AllHuiLv() { bankName = "平安银行", bankPoperty = PABC(), });
            lst.Add(new AllHuiLv() { bankName = "兴业银行", bankPoperty = CIB(), });
            lst.Add(new AllHuiLv() { bankName = "丰瑞银行", bankPoperty = EVERGROWING(), });
            return lst;
        }
        [Route("api/CZB/GetAllProducts")]
        public List<CZB> CZB()
        {
            var cache = GetCacheObject<CZB>("CZB", 20);
            var data = cache.GetData();
            if (data != null)
                return data.Data;
            HttpHelper httpHelper = new HttpHelper();
            var htmlResult = httpHelper.GetHtml(new HttpItem() { URL = "https://perbank.czbank.com/PERBANK/system/whpjInfoService_req_dispatch.jsp",
                UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36",
                Encoding =System.Text.Encoding.UTF8 });
            HtmlParser htmlParser = new HtmlParser();
            var getPostData = htmlParser.Parse(htmlResult.Html).QuerySelectorAll("input").FirstOrDefault();
            string post = getPostData.GetAttribute("name") +"="+ getPostData.GetAttribute("value");
            string cookie = htmlResult.Cookie;
            htmlResult = httpHelper.GetHtml(new HttpItem() { URL = "https://perbank.czbank.com/PERBANK/WebBank",
                Encoding = System.Text.Encoding.UTF8,Referer= "https://perbank.czbank.com/PERBANK/system/whpjInfoService_req_dispatch.jsp",
                ContentType = "application/x-www-form-urlencoded",
                UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36",
                Cookie = cookie, Method="post", Postdata=post });
            DateTime dt = DateTime.Now;
            //var result = htmlParser.Parse(htmlResult.Html).QuerySelectorAll("tbody").LastOrDefault()
            //    .QuerySelectorAll("tr")
            //    .Select(t => new CZB()
            //    {
            //        hbmc = t.QuerySelectorAll("td")[0].TextContent,
            //        hbsx = CurrencyAcronyms.getKHAcronyms(t.QuerySelectorAll("td")[0].TextContent.Substring(0, 2)),
            //        xcmrj = decimal.Parse(t.QuerySelectorAll("td")[2].TextContent),
            //        xhmrj = decimal.Parse(t.QuerySelectorAll("td")[3].TextContent),
            //        xhmcj = decimal.Parse(t.QuerySelectorAll("td")[4].TextContent),
            //        zjj = decimal.Parse(t.QuerySelectorAll("td")[5].TextContent),
            //        updatetime = dt,
            //    }).ToList();
            //cache.AddData(result);//添加缓存
            //return result;
            return null;
        }
        [Route("api/EVERGROWING/GetAllProducts")]
        public List<EVERGROWING> EVERGROWING()
        {
            var cache = GetCacheObject<EVERGROWING>("EVERGROWING", 20);
            var data = cache.GetData();
            if (data != null)
                return data.Data;
            HttpHelper httpHelper = new HttpHelper();
            var htmlResult = httpHelper.GetHtml(new HttpItem() { URL = "http://www.hfbank.com.cn/ucms/hfyh/jsp/gryw/whpj.jsp", });
            HtmlParser htmlParser = new HtmlParser();
            DateTime dt = DateTime.Now;
            var result = htmlParser.Parse(htmlResult.Html).QuerySelectorAll("tbody").LastOrDefault()
                .QuerySelectorAll("tr")
                .Select(t => new EVERGROWING()
                {
                    hbmc = t.QuerySelectorAll("td")[0].TextContent,
                    hbsx = CurrencyAcronyms.getKHAcronyms(t.QuerySelectorAll("td")[0].TextContent.Substring(0, 2)),
                    xcmrj = decimal.Parse(t.QuerySelectorAll("td")[2].TextContent),
                    xhmrj = decimal.Parse(t.QuerySelectorAll("td")[3].TextContent),
                    xhmcj= decimal.Parse(t.QuerySelectorAll("td")[4].TextContent),
                    zjj = decimal.Parse(t.QuerySelectorAll("td")[5].TextContent),
                    updatetime = dt,
                }).ToList();
            cache.AddData(result);//添加缓存
            return result;
        }
        [Route("api/CIB/GetAllProducts")]
        public List<CIB> CIB()
        {
            var cache = GetCacheObject<CIB>("CIB", 20);
            var data = cache.GetData();
            if (data != null)
                return data.Data;
            HttpHelper httpHelper = new HttpHelper();
            var htmlResult = httpHelper.GetHtml(new HttpItem() { URL = "https://personalbank.cib.com.cn/pers/main/pubinfo/ifxQuotationQuery.do", });
            htmlResult= httpHelper.GetHtml(new HttpItem() { URL = "https://personalbank.cib.com.cn/pers/main/pubinfo/ifxQuotationQuery!list.do?_search=false&dataSet.rows=80&dataSet.page=1&dataSet.sidx=&dataSet.sord=asc",
                Cookie =htmlResult.Cookie,});
            HtmlParser htmlParser = new HtmlParser();
            DateTime dt = DateTime.Now;
            var jsonResult = JsonConvert.DeserializeObject<CIBRoot>(htmlResult.Html);
            DateTime dateTime = DateTime.Now;
            var result = jsonResult.rows.Select(t => new CIB()
            {
                hbmc = t.cell[0],
                hbsx = CurrencyAcronyms.getKHAcronyms(t.cell[0].Substring(0, 2)),
                xhmrj = decimal.Parse(t.cell[3]),
                xcmrj = decimal.Parse(t.cell[5]),
                xhmcj = decimal.Parse(t.cell[4]),
                xcmcj = decimal.Parse(t.cell[6]),
                updatetime = dateTime,
            }).ToList();
            cache.AddData(result);//添加缓存
            return result;
        }
        [Route("api/PABC/GetAllProducts")]
        public List<PABC> PABC()
        {
            var cache = GetCacheObject<PABC>("PABC", 20);
            var data = cache.GetData();
            if (data != null)
                return data.Data;
            HttpHelper httpHelper = new HttpHelper();
            var htmlResult = httpHelper.GetHtml(new HttpItem() { URL = "https://bank.pingan.com.cn/ibp/portal/exchange/qryExchangeList.do", });
            HtmlParser htmlParser = new HtmlParser();
            DateTime dt = DateTime.Now;
            var result = htmlParser.Parse(htmlResult.Html).QuerySelectorAll("table.table").FirstOrDefault().QuerySelectorAll("tbody").FirstOrDefault()
                .QuerySelectorAll("tr").Where(t => t.TextContent.IndexOf("����ȫ��") < 0 && t.TextContent.IndexOf("货币") < 0)
                .Select(t => new PABC()
                {
                    hbmc = t.QuerySelectorAll("td")[0].TextContent,
                    hbsx = CurrencyAcronyms.getKHAcronyms(t.QuerySelectorAll("td")[0].TextContent.Substring(0,2)),
                    zjj = decimal.Parse(t.QuerySelectorAll("td")[1].TextContent),
                    xhmrj = decimal.Parse(t.QuerySelectorAll("td")[2].TextContent),
                    xcmrj = decimal.Parse(t.QuerySelectorAll("td")[3].TextContent),
                    mcj = decimal.Parse(t.QuerySelectorAll("td")[4].TextContent),
                    yhzjj = decimal.Parse(t.QuerySelectorAll("td")[5].TextContent),
                    updatetime = dt,
                }).ToList();
            cache.AddData(result);//添加缓存
            return result;
        }
        [Route("api/GDB/GetAllProducts")]
        public List<GDB> GDB()
        {
            var cache = GetCacheObject<GDB>("GDB", 20);
            var data = cache.GetData();
            if (data != null)
                return data.Data;
            HttpHelper httpHelper = new HttpHelper();
            var htmlResult = httpHelper.GetHtml(new HttpItem() { URL = "http://www.cgbchina.com.cn/searchExchangePrice.gsp", Encoding= System.Text.Encoding.UTF8});
            HtmlParser htmlParser = new HtmlParser();
            DateTime dt = DateTime.Now;
            var result = htmlParser.Parse(htmlResult.Html).QuerySelectorAll("tbody").FirstOrDefault()
                .QuerySelectorAll("tr").Where(t => t.TextContent.IndexOf("����ȫ��") < 0&& t.TextContent.IndexOf("货币") < 0)
                .Select(t => new GDB()
                {
                    hbmc = CurrencyAcronyms.缩写转货币名(t.QuerySelectorAll("td")[1].TextContent),
                    hbsx = "(" + t.QuerySelectorAll("td")[1].TextContent + ")",
                    zjj= decimal.Parse(t.QuerySelectorAll("td")[3].TextContent),
                    xhmrj = decimal.Parse(t.QuerySelectorAll("td")[4].TextContent),
                    xcmrj = decimal.Parse(t.QuerySelectorAll("td")[5].TextContent),
                    xhmcj= decimal.Parse(t.QuerySelectorAll("td")[6].TextContent),
                    xcmcj= decimal.Parse(t.QuerySelectorAll("td")[7].TextContent),
                    updatetime = dt,
                }).ToList();
            cache.AddData(result);//添加缓存
            return result;
        }
        [Route("api/HB/GetAllProducts")]
        public List<HB> HB()
        {
            var cache = GetCacheObject<HB>("HB", 20);
            var data = cache.GetData();
            if (data != null)
                return data.Data;
            HttpHelper httpHelper = new HttpHelper();
            var htmlResult = httpHelper.GetHtml(new HttpItem() { URL = "https://sbank.hxb.com.cn/gateway/forexquote.jsp" });
            HtmlParser htmlParser = new HtmlParser();
            DateTime dt = DateTime.Now;
            var result = htmlParser.Parse(htmlResult.Html).QuerySelectorAll("table.table_list").FirstOrDefault()
                .QuerySelectorAll("tbody").FirstOrDefault().QuerySelectorAll("tr")
                .Select(t => new HB()
                {
                    hbmc = CurrencyAcronyms.缩写转货币名(t.QuerySelectorAll("td")[0].TextContent.Replace("CNY", "")),
                    hbsx = "("+ t.QuerySelectorAll("td")[0].TextContent.Replace("CNY", "")+")",
                    xhmrj = decimal.Parse(t.QuerySelectorAll("td")[1].TextContent),
                    xcmrj = decimal.Parse(t.QuerySelectorAll("td")[2].TextContent),
                    mcj = decimal.Parse(t.QuerySelectorAll("td")[3].TextContent),
                    xhzjj = decimal.Parse(t.QuerySelectorAll("td")[4].TextContent),
                    updatetime = dt,
                }).ToList();
            cache.AddData(result);//添加缓存
            return result;
        }
        [Route("api/CEB/GetAllProducts")]
        public List<CEB> CEB()
        {
            var cache = GetCacheObject<CEB>("CEB", 20);
            var data = cache.GetData();
            if (data != null)
                return data.Data;
            HttpHelper httpHelper = new HttpHelper();
            var htmlResult = httpHelper.GetHtml(new HttpItem() { URL = "http://www.cebbank.com/eportal/ui?pageId=477257" });
            HtmlParser htmlParser = new HtmlParser();
            DateTime dt = DateTime.Now;
            var result = htmlParser.Parse(htmlResult.Html).QuerySelectorAll("table.lczj_box").FirstOrDefault()
                .QuerySelectorAll("tr").Where(t=>t.TextContent.IndexOf("货币")<0 && t.TextContent.IndexOf("购汇") < 0)
                .Select(t => new CEB()
                {
                    hbmc = t.QuerySelectorAll("td")[0].TextContent.Substring(0, t.QuerySelectorAll("td")[0].TextContent.IndexOf("(")),
                    hbsx = CurrencyAcronyms.getKHAcronyms(t.QuerySelectorAll("td")[0].TextContent.Substring(0, t.QuerySelectorAll("td")[0].TextContent.IndexOf("(")).Substring(0, 2)),
                    xhmrj = decimal.Parse(t.QuerySelectorAll("td")[1].TextContent),
                    xcmrj = decimal.Parse(t.QuerySelectorAll("td")[2].TextContent),
                    xhmcj= decimal.Parse(t.QuerySelectorAll("td")[3].TextContent),
                    xcmcj= decimal.Parse(t.QuerySelectorAll("td")[4].TextContent),
                    updatetime = dt,
                }).ToList();
            cache.AddData(result);//添加缓存
            return result;
        }
        [Route("api/CITICIB/GetAllProducts")]
        public List<CITICIB> CITICIB()
        {
            var cache = GetCacheObject<CITICIB>("CITICIB", 20);
            var data = cache.GetData();
            if (data != null)
                return data.Data;
            HttpHelper httpHelper = new HttpHelper();
            var htmlResult = httpHelper.GetHtml(new HttpItem(){URL = "https://etrade.citicbank.com/portalweb/cms/getForeignExchRate.htm", });
            var jsonResult = JsonConvert.DeserializeObject<CITICIBRoot>(htmlResult.Html);
            DateTime dateTime = DateTime.Now;
            var result = jsonResult.content.resultList.Select(t => new CITICIB()
            {
                hbmc = t.curName,
                hbsx = CurrencyAcronyms.getKHAcronyms(t.curName.Substring(0,2)),
                xhmrj = decimal.Parse(t.cstexcBuyPrice),
                xcmrj = decimal.Parse(t.cstpurBuyPrice),
                xhmcj=decimal.Parse(t.cstexcSellPrice),
                xcmcj=decimal.Parse(t.cstpurSellPrice),
                zjj = decimal.Parse(t.midPrice),
                updatetime = dateTime,
            }).ToList();
            cache.AddData(result);//添加缓存
            return result;
        }
        [Route("api/SPDB/GetAllProducts")]
        public List<SPDB> SPDB()
        {
            var cache = GetCacheObject<SPDB>("SPDB", 20);
            var data = cache.GetData();
            if (data != null)
                return data.Data;
            HttpHelper httpHelper = new HttpHelper();
            var htmlResult = httpHelper.GetHtml(new HttpItem()
            {
                URL = "http://per.spdb.com.cn/was5/web/search",
                Method = "POST",
                Postdata = "metadata=CurrencyName%7CMdlPrc%7CBuyPrc%7CCashBuyPrc%7CSellPrc%7CCREATE_DATE&perpage=100&channelid=207567&searchword=",
                ContentType = "application/x-www-form-urlencoded",
            });
            var jsonResult = JsonConvert.DeserializeObject<SPDBRoot>(htmlResult.Html);
            DateTime dateTime = DateTime.Now;
            var result = jsonResult.rows.Where(t=>t.CurrencyName.Length>2).Select(t => new SPDB()
            {
                hbmc = t.CurrencyName.Substring(0, t.CurrencyName.IndexOf(" ")),
                hbsx = CurrencyAcronyms.getKHAcronyms(t.CurrencyName.Substring(0, t.CurrencyName.IndexOf(" ")).Substring(0,2)),
                xhmrj = decimal.Parse(t.BuyPrc),
                xcmrj = decimal.Parse(t.CashBuyPrc),
                mcj=decimal.Parse(t.SellPrc),
                zjj=decimal.Parse(t.MdlPrc),
                updatetime = dateTime,
            }).ToList();
            cache.AddData(result);//添加缓存
            return result;
        }
        [Route("api/BOB/GetAllProducts")]
        public List<BOB> BOB()
        {
            var cache = GetCacheObject<BOB>("BOB", 20);
            var data = cache.GetData();
            if (data != null)
                return data.Data;
            HttpHelper httpHelper = new HttpHelper();
            var htmlResult = httpHelper.GetHtml(new HttpItem() { URL = "http://www.bankofbeijing.com.cn/personal/whpj.aspx" });
            HtmlParser htmlParser = new HtmlParser();
            DateTime dt = DateTime.Now;
            var result = htmlParser.Parse(htmlResult.Html).QuerySelectorAll("tbody")
                .Where(t => t.TextContent.IndexOf("现汇买入价") > 0).LastOrDefault().QuerySelectorAll("tr")
                .Where(t => t.TextContent.IndexOf("现汇买入价") < 0)
                .Select(t => new BOB()
                {
                    hbmc = t.QuerySelectorAll("td")[1].TextContent.Replace("/人民币", ""),
                    hbsx = CurrencyAcronyms.getKHAcronyms(t.QuerySelectorAll("td")[1].TextContent.Replace("/人民币", "").Substring(0, 2)),
                    xhmrj = decimal.Parse(t.QuerySelectorAll("td")[3].TextContent),
                    xcmrj = decimal.Parse(t.QuerySelectorAll("td")[4].TextContent),
                    mcj = decimal.Parse(t.QuerySelectorAll("td")[5].TextContent),
                    zjj = decimal.Parse(t.QuerySelectorAll("td")[6].TextContent),
                    updatetime = dt,
                }).ToList();
            cache.AddData(result);//添加缓存
            return result;
        }
        [Route("api/CMB/GetAllProducts")]
        public List<CMB> CMB()
        {
            var cache = GetCacheObject<CMB>("CMB", 20);
            var data = cache.GetData();
            if (data != null)
                return data.Data;
            HttpHelper httpHelper = new HttpHelper();
            var htmlResult = httpHelper.GetHtml(new HttpItem() { URL = "http://fx.cmbchina.com/hq/" });
            HtmlParser htmlParser = new HtmlParser();
            DateTime dt = DateTime.Now;
            var result = htmlParser.Parse(htmlResult.Html).QuerySelectorAll("table.data").FirstOrDefault().QuerySelectorAll("tr")
                .Where(t => t.TextContent.IndexOf("交易") < 0)
                .Select(t => new CMB()
                 {
                     hbmc = t.QuerySelectorAll("td")[0].TextContent.Replace("\n","").Replace(" ",""),
                     hbsx = CurrencyAcronyms.getKHAcronyms(t.QuerySelectorAll("td")[0].TextContent.Replace("\n", "").Replace(" ", "").Substring(0, 2)),
                     xhmcj = decimal.Parse(t.QuerySelectorAll("td")[3].TextContent),
                     xcmcj = decimal.Parse(t.QuerySelectorAll("td")[4].TextContent),
                     xhmrj = decimal.Parse(t.QuerySelectorAll("td")[5].TextContent),
                     xcmrj = decimal.Parse(t.QuerySelectorAll("td")[6].TextContent),
                     updatetime = dt,
                 }).ToList();
            cache.AddData(result);//添加缓存
            return result;
        }
        [Route("api/CMBC/GetAllProducts")]
        public List<CMBC> CMBC()
        {
            var cache = GetCacheObject<CMBC>("CMBC", 20);
            var data = cache.GetData();
            if (data != null)
                return data.Data;
            HttpHelper httpHelper = new HttpHelper();
            var htmlResult = httpHelper.GetHtml(new HttpItem() { URL = "http://www.cmbc.com.cn/gw/po_web/queryExRateByForex.do",
                Method = "POST", Postdata= "cxfg=1&domesticCurrency=RMB",
                ContentType = "application/x-www-form-urlencoded",
            });
            var jsonResult = JsonConvert.DeserializeObject<CMBCRoot>(htmlResult.Html);
            DateTime dateTime = DateTime.Now;
            var result = jsonResult.result.Select(t => new CMBC()
            {
                hbmc = CurrencyAcronyms.缩写转货币名(t.foreignCurrency),
                hbsx = "("+t.foreignCurrency+")",
                xhmrj = (decimal)( t.buyPrice),
                xhmcj = (decimal)(t.sellPrice),
                updatetime = dateTime,
            }).ToList();
            cache.AddData(result);//添加缓存
            return result;
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