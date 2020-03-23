using CefSharp;
using CefSharp.OffScreen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebBrowser
{
    class Program
    {
        static int tick =0;
        static string html = "";
        static void Main(string[] args)
        {

            var result = GetHtml();
            ;
        }
        public static string GetHtml()
        {
            tick = 0;
            html = "";
            ChromiumWebBrowser browser = new ChromiumWebBrowser("https://per.spdb.com.cn/was5/web/search?channelid=256931");
            browser.FrameLoadEnd += Browser_FrameLoadEnd;
            while (tick < 2)
            {
                Thread.Sleep(1);
            }
            return html;
        }

        private static async void Browser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            
            var browser = sender as ChromiumWebBrowser;
            var str = await browser.GetSourceAsync();
            if (tick == 1)
                html = str;
            tick++;
        }
    }
}
