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

namespace LCHBLDotNetCore.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class HuiLvController : ControllerBase
    {
        [Route("api/BOC/GetAllProducts")]
        public List<BOC> GetAllProducts()
        {
            var cache = GetCacheObject<BOC>(20);
            var data = cache.GetData();
            if (data != null)
                return data.Data;
            HttpHelper httpHelper = new HttpHelper();
            var htmlResult = httpHelper.GetHtml(new HttpItem() { URL = "http://www.boc.cn/sourcedb/whpj/index.html" });
            HtmlParser htmlParser = new HtmlParser();
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
                    updatetime=DateTime.Now,
                }).ToList();
            cache.AddData(result);//添加缓存
            return result;
        }
        /// <summary>
        /// 获取缓存对象
        /// </summary>
        /// <returns></returns>
        public EasyCache<List<T>> GetCacheObject<T>(int? minutes = null)
        {
            var key = Request.Path.Value + Request.QueryString.Value;
            var time = DateTime.Now.AddMinutes(minutes ?? 10) - DateTime.Now;//缓存10分钟
            EasyCache<List<T>> obj = new EasyCache<List<T>>(key, time);
            return obj;
        }
    }
}