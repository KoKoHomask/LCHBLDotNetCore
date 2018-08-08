using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace LCHBLDotNetCore.Other
{
    #region ============获取汇率========
    class hl
    {
        private const string _data = "//table[@class='list']/tr[1]";
        private const string _hl = "//table[@class='list']/tr[2]";
        private static string URL = "http://www.safe.gov.cn/AppStructured/view/project_RMBQuery.action";
        public static DataTable GETHL()
        {
            string time = System.DateTime.Now.ToString("yyyy-MM-dd");
            DataTable dt = new DataTable();

            int paritiesCount = 17;
            string data = null;
            string str = null;
            try
            {
                str = GetHttpID.GETSTR(URL, _data);
                str = str.Replace("\t", " ");
                str = str.Replace("\r\n", " ");
                str = str.Replace("&nbsp", " ");
                str = str.Replace(";", " ");
                str = new System.Text.RegularExpressions.Regex("[\\s]+").Replace(str, " ");
                string[] split = str.Split(new Char[] { ' ' });
                foreach (string s in split)
                {

                    if (s.Trim() != "")
                        Console.Write(s + " ");
                }

                data = str;
                str = GetHttpID.GETSTR(URL, _hl);
                str = str.Replace("\t", " ");
                str = str.Replace("\r\n", " ");
                str = str.Replace("&nbsp", " ");
                str = str.Replace(";", " ");
                //将多个空格变成一个空格
                str = new System.Text.RegularExpressions.Regex("[\\s]+").Replace(str, " ");
                string[] split2 = str.Split(new Char[] { ' ' });
                foreach (string s in split2)
                {

                    if (s.Trim() != "")
                        Console.Write(s + " ");
                }


                if (split.Length == split2.Length && split2.Length == paritiesCount + 2)
                {
                    string riqi = split2[1],
                        MY = split2[2],
                        OY = split2[3],
                        RY = split2[4],
                        GY = split2[5],
                        YB = split2[6],
                        LJT = split2[7],
                        LB = split2[8],
                        NFLT = split2[9],
                        HanYuan = split2[10],
                        AY = split2[13],
                        JY = split2[14],
                        xxly = split2[15],
                        xjpy = split2[16],
                        rsfl = split2[17];

                    riqi = time;
                    //DB.aa(sql.update_sjc("parities", "true"));
                   // DB.aa(sql.delect_hl(riqi));
                    //DB.aa(sql.insertData(riqi, MY, OY, RY, GY, YB, LJT, LB, AY, JY, xxly, xjpy, rsfl, NFLT, HanYuan));

                }

                data = data + "\r\n" + str;
                str = data;

            }
            catch
            {
                 //DB.aa(sql.update_sjc("parities", "false"));
                return null;
            }
            //dt = DB.aa(sql.select_time(time));
            if (dt != null)
            {
                return dt;
            }
            else
            {
                 //DB.aa(sql.update_sjc("parities", "false"));
                return null;
            }
        }

    }
    #endregion



    //2016-05-07作废
    ////银行汇率牌价流程 
    //0.验证数据
    //1.删除原有数据
    //2.更新数据库
    //3.更新时间戳
    //4.发布新数据
    //2016-05-07作废


    ////2016-05-07生效
    //用反射做了一套灰常nb的
    //检测时间
    //超时，重新抓取，删除原有数据，新数据存入数据库，更新时间戳,从数据库提取数据，返回界面
    //未超时，从数据库提取数据，返回界面



    class formate_space
    {

        public static string formate(string str)
        {
            str = str.Replace("\t", " ");
            str = str.Replace("\r\n", " ");
            str = str.Replace("&nbsp", " ");
            str = str.Replace(";", " ");
            //将多个空格变成一个空格
            str = new System.Text.RegularExpressions.Regex("[\\s]+").Replace(str, " ");
            return str;
        }


    }
    public class GetHttpID
    {
        public static HttpResult GETResult(string URL)
        {
            HttpItem item = new HttpItem();
            HttpHelper helper = new HttpHelper();
            item.URL = URL;
            HttpResult result = helper.GetHtml(item);
            return result;
        }

        public static string GETSTR(HttpResult result, string message)
        {
            string str = null;
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(result.Html);
            HtmlNode rootpath = doc.DocumentNode;
            HtmlNodeCollection list = rootpath.SelectNodes(message);
            try
            {
                foreach (HtmlNode day in list)
                {
                    string aa = day.InnerText;
                    if (aa == "") { aa = "null"; }
                    str += aa + "\r\n";
                }
                str += "\r\n";
            }
            catch {; }
            return str;
        }

        public static int GETINT(HttpResult result, string message)
        {
            int num = 0;
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(result.Html);
            HtmlNode rootpath = doc.DocumentNode;
            HtmlNodeCollection list = rootpath.SelectNodes(message);
            num = list.Count;
            return num;
        }


        public static string GETSTR(string URL, string message)
        {
            string str = null;
            HttpItem item = new HttpItem();
            HttpHelper helper = new HttpHelper();
            item.URL = URL;
            HttpResult result = helper.GetHtml(item);
            HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(result.Html);
            HtmlNode rootpath = doc.DocumentNode;
            HtmlNodeCollection list = rootpath.SelectNodes(message);
            try
            {
                foreach (HtmlNode day in list)
                {
                    string aa = day.InnerText;
                    if (aa == "") { aa = "null"; }
                    str += aa + "\r\n";
                }
                str += "\r\n";
            }
            catch {; }
            return str;
        }
    }
}
