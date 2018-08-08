using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LCHBLDotNetCore.Models.BankModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LCHBLDotNetCore.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class HuiLvController : ControllerBase
    {
        [Route("api/ABC/GetAllProducts")]
        public IEnumerable<ABC> GetAllProducts()
        {
            getABC gABC = new getABC();

            DataTable dt = gABC.getExchangeRate();
            ABC[] abcs = new ABC[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                try
                {
                    abcs[i] = new ABC();
                    abcs[i].hbmc = dt.Rows[i][0].ToString();
                    abcs[i].hbsx = CurrencyAcronyms.getAcronyms(abcs[i].hbmc.Substring(0, 2));
                    abcs[i].mrhl = dt.Rows[i][1].ToString();
                    abcs[i].mchl = dt.Rows[i][2].ToString();
                    abcs[i].xcmrhl = dt.Rows[i][3].ToString();
                    //货币图片更新与2016.05.04
                    abcs[i].picUrl2x = flagPicture.getCountryFlag2X(abcs[i].hbmc);
                    abcs[i].picUrl3x = flagPicture.getCountryFlag3X(abcs[i].hbmc);
                }
                catch { DB.aa(sql.delect_abc()); string er = "BocController 第二个for循环"; return null; }
            }
            return abcs;

        }
    }
}