using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace LCHBLDotNetCore.Other
{
    abstract public class getER
    {
        protected DataTable getExchangeRate(string URL, string rule, int rateCount)
        {
            DataTable dt = new DataTable();
            HttpResult result;
            result = GetHttpID.GETResult(URL);
            string[] tmpArray = rule.Split('#');
            int startPoint = int.Parse(tmpArray[1].Substring(0, 1));
            string startRule = tmpArray[0];
            string endRule = tmpArray[1].Substring(1, tmpArray[1].Length - 1);
            string tmpStr = "";
            int tmpInt = rateCount + startPoint;
            for (int i = startPoint; i < tmpInt; i++)
            {
                tmpStr = GetHttpID.GETSTR(result, startRule + i + endRule);
                tmpStr = formate_space.formate(tmpStr);
                string[] spliteX = tmpStr.Split(new Char[] { ' ' });
                DataRow dr = dt.NewRow();
                for (int j = 0; j < spliteX.Length; j++)
                {
                    if (i == startPoint) { dt.Columns.Add("" + j, typeof(string)); }
                    dr["" + j] = spliteX[j];
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
        abstract protected bool crawExchangeRate();
        protected DataTable publicSaveData(string url, string rule, int crawCount, int length)
        {
            try
            {
                DataTable dt = getExchangeRate(url, rule, crawCount);
                if ((dt.Rows.Count == crawCount) && (dt.Rows[0].ItemArray.Length == length))
                {
                    return dt;
                }
            }
            catch { return null; }
            return null;
        }
        protected bool saveDataToDB(DataTable dt, int crawCount, int arrStart, int arrEnd)
        {
            string className = this.ToString().Replace("LCHBL.Other.get", "");
            Func<char, char> toggle = c => char.IsUpper(c) ? char.ToLower(c) : char.ToUpper(c);
            className = new string(className.Select(toggle).ToArray());
            string tmpSql = "";
            Type t = typeof(sql);
            MethodInfo mi;
            object obj = Activator.CreateInstance(t);

            mi = t.GetMethod("delect_" + className);
            tmpSql = (string)mi.Invoke(obj, null);
            int tmpInt = (arrEnd - arrStart + 1);
            DB.aa(tmpSql);
            for (int i = 0; i < crawCount; i++)
            {
                object[] canshu = new object[tmpInt];
                for (int j = arrStart; j <= tmpInt; j++)
                {
                    try
                    {
                        canshu[j - arrStart] = dt.Rows[i][j].ToString();
                    }
                    catch {; }

                }
                mi = t.GetMethod("insertData_" + className);
                tmpSql = (string)mi.Invoke(obj, canshu);
                DB.aa(tmpSql);
            }
            DB.aa(sql.update_sjc(className, "true"));
            return true;
        }

        public DataTable getExchangeRate()
        {
            string className = this.ToString().Replace("LCHBL.Other.get", "");
            Func<char, char> toggle = c => char.IsUpper(c) ? char.ToLower(c) : char.ToUpper(c);
            className = new string(className.Select(toggle).ToArray());

            DataTable dt = new DataTable();
            bool updStatus = time_formate.select_time(className);

            Type t = typeof(sql);
            MethodInfo mi = t.GetMethod("select_" + className);
            object obj = Activator.CreateInstance(t);

            string sqlStr = (string)mi.Invoke(obj, null);

            if (updStatus)
            {
                if (crawExchangeRate())
                {
                    dt = DB.aa(sqlStr);
                    return dt;
                }
                return null;
            }
            dt = DB.aa(sqlStr);
            return dt;
        }
    }
    public class getABC : getER
    {
        private static string url = "http://app.abchina.com/rateinfo/ratesearch.aspx?id=1";
        private const string rule = "//table[1]/div[1]/table[1]/tr[#2]/td";
        override protected bool crawExchangeRate()
        {
            int crawCount = 16;
            int length = 5;
            DataTable dt = publicSaveData(url, rule, crawCount, length);

            if (dt != null)
            { return saveDataToDB(dt, crawCount, 0, 4); }
            DB.aa(sql.update_sjc("abc", "false"));
            return false;
        }
    }
    public class getPSBC : getER
    {
        private const string rule = "//table/tbody/tr[#1]/th";
        private static string url = "http://www.psbc.com/portal/main?transName=queryExchange";
        override protected bool crawExchangeRate()
        {
            int crawCount = 5;//抓取的外汇种类数目
            int length = 9;
            DataTable dt = publicSaveData(url, rule, crawCount, length);
            if (dt != null)
            { return saveDataToDB(dt, crawCount, 1, 5); }
            DB.aa(sql.update_sjc("psbc", "false"));
            return false;
        }

    }
    public class getICBC : getER
    {
        private static string url = "http://www.icbc.com.cn/ICBCDynamicSite/Optimize/Quotation/QuotationListIframe.aspx";
        private const string rule = "//table[1]/tr[1]/td[1]/table[1]/tr[2]/td[1]/table/tr[#2]/td";
        override protected bool crawExchangeRate()
        {
            int crawCount = 20;//抓取的外汇种类数目
            int length = 7;//抓取到的数据的宽度if(split2.Length==7)
            DataTable dt = publicSaveData(url, rule, crawCount, length);
            if (dt != null)
            { return saveDataToDB(dt, crawCount, 0, 3); }//datarow要存入数据库的区域(DB.aa(sql.insertData_icbc(split2[0], split2[1], split2[2], split2[3]));)
            DB.aa(sql.update_sjc("icbc", "false"));
            return false;
        }
    }
    public class getBOC : getER
    {
        private static string url = "http://www.boc.cn/sourcedb/whpj/index.html";
        private const string rule = "//table/tr[#2]/td";
        override protected bool crawExchangeRate()
        {
            int crawCount = 24;//抓取的外汇种类数目
            int length = 9;//抓取到的数据的宽度if (split2.Length == 9)
            DataTable dt = publicSaveData(url, rule, crawCount, length);
            if (dt != null)
            { return saveDataToDB(dt, crawCount, 0, 5); }//datarow要存入数据库的区域DB.aa(sql.insertData_boc(split2[0], split2[1], split2[2], split2[3], split2[4], split2[5]));
            DB.aa(sql.update_sjc("boc", "false"));
            return false;
        }
    }
    public class getCCB
    {
        public DataTable getExchangeRate()
        {
            return null;
        }
    }
}
