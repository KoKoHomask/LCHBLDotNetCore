using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LCHBLDotNetCore.Other
{
    public class CurrencyAcronyms
    {
        public static string 缩写转货币名(string sx)
        {
            switch (sx)
            {
                case "CNY": return "人民币";
                case "RMB":
                    return "人民币";
                case "USD":
                    return "美元 ";
                case "ATS":
                    return "奥地利先令 ";
                case "AUD":
                    return "澳元 ";
                case "BEF":
                    return "比利时法郎 ";
                case "BRL":
                    return "巴西雷亚尔 ";
                case "CAD":
                    return "加元 ";
                case "CHF":
                    return "瑞郎 ";
                case "CLP":
                    return "智利比索 ";
                case "CZK":
                    return "捷克克朗 ";
                case "DEM":
                    return "德国马克 ";
                case "DKK":
                    return "丹麦克朗 ";
                case "ESP":
                    return "西班牙比塞塔 ";
                case "EUR":
                    return "欧元 ";
                case "FIM":
                    return "芬兰马克 ";
                case "FRF":
                    return "法国法郎 ";
                case "GBP":
                    return "英镑 ";
                case "HKD":
                    return "港币 ";
                case "HUF":
                    return "匈牙利福林 ";
                case "IDR":
                    return "印度尼西亚盾 ";
                case "INR":
                    return "印度卢比 ";
                case "ITL":
                    return "意大利里拉 ";
                case "JPY":
                    return "日元 ";
                case "KER":
                    return "韩元 ";
                case "MXN":
                    return "墨西哥比索 ";
                case "MYR":
                    return "马来西亚元 ";
                case "NLG":
                    return "荷兰盾 ";
                case "NOK":
                    return "挪威克朗 ";
                case "NZD":
                    return "新西兰元 ";
                case "PHP":
                    return "菲律宾比索 ";
                case "PLN":
                    return "波兰兹罗提 ";
                case "PTE":
                    return "葡萄牙埃斯库多 ";
                case "RUB":
                    return "俄罗斯卢布 ";
                case "SAR":
                    return "沙特里亚尔 ";
                case "SEK":
                    return "瑞典克朗 ";
                case "SGD":
                    return "新加坡元 ";
                case "THB":
                    return "泰铢 ";
                case "TWD":
                    return "台币 ";
                case "VEF":
                    return "强势玻利瓦尔 ";
                case "VND":
                    return "越南盾 ";
                case "ZAR":
                    return "南非兰特 ";
            }
            return "";
        }
        public static string getCCBHBMC(string ccbCode)
        {
            switch (ccbCode)
            {
                case "840": return "美元";
                case "978": return "欧元";
                case "826": return "英镑";
                case "392": return "日元";
                case "344": return "港币";
                case "036": return "澳大利亚元";
                case "124": return "加拿大元";
                case "756": return "瑞士法郎";
                case "702": return "新加坡元";
                case "208": return "丹麦克朗";
                case "578": return "挪威克朗";
                case "752": return "瑞典克朗";
                case "410": return "韩元";
                case "554": return "新西兰元";
                case "446": return "澳门元";
                case "710": return "南非兰特";
                case "764": return "泰铢";
                case "458": return "马来西亚林吉特";
                case "643": return "俄罗斯卢布";
                case "398": return "哈萨克斯坦坚戈";
            }
            return "未知";
        }
        public static string getKHAcronyms(string currencyName)
        {
            return "(" + getAcronyms(currencyName) + ")";
        }
        public static string getAcronyms(string currencyName)
        {
            switch (currencyName)
            {
                case "阿联":
                    {
                        return "AED";
                    }
                case "巴西":
                    {
                        return "BRL";
                    }
                case "印尼":
                    {
                        return "IDR";
                    }
                case "印度":
                    {
                        return "INR";
                    }
                case "美元":
                    {
                        return "USD";
                    }
                case "丹麦":
                    {
                        return "DKK";
                    }
                case "挪威":
                    {
                        return "NOK";
                    }
                case "瑞典":
                    {
                        return "SEK";
                    }
                case "瑞士":
                    {
                        return "CHF";
                    }
                case "澳门":
                    {
                        return "MOP";
                    }
                case "泰铢":
                    {
                        return "THB";
                    }
                case "泰国":
                    {
                        return "THB";
                    }
                case "索莫":
                    {
                        return "TJS";
                    }
                case "日元":
                    {
                        return "JPY";
                    }
                case "港元":
                    {
                        return "HKD";
                    }
                case "港币":
                    {
                        return "HKD";
                    }
                case "韩国":
                    {
                        return "KRW";
                    }
                case "韩元":
                    {
                        return "KRW";
                    }
                case "欧元":
                    {
                        return "EUR";
                    }
                case "英磅":
                    {
                        return "GBP";
                    }
                case "英镑":
                    {
                        return "GBP";
                    }
                case "加拿":
                    {
                        return "CAD";
                    }
                case "加元":
                    {
                        return "CAD";
                    }
                case "澳大":
                    {
                        return "AUD";
                    }
                case "澳元":
                    {
                        return "AUD";
                    }
                case "新加":
                    {
                        return "SGD";
                    }
                case "新西":
                    {
                        return "NZD";
                    }
                case "卢布":
                    {
                        return "RUB";
                    }
                case "菲律":
                    {
                        return "PHP";
                    }

                case "南非":
                    {
                        return "ZAR";
                    }
                case "林吉":
                    {
                        return "MYR";
                    }
                case "新台":
                    {
                        return "TWD";
                    }

            }
            return "";
        }
    }
}
