using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LCHBLDotNetCore.Other
{
    public class CurrencyAcronyms
    {
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
