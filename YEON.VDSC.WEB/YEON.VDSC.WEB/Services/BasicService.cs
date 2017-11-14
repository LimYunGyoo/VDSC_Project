using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using YEON.VDSC.CORE.Domain;

namespace YEON.VDSC.WEB.Services
{
    public class BasicService
    {
        protected const int discountMinimum = 50;

        protected static HtmlNodeCollection ParseHTML(string strUri, string nodeDiv)
        {
            HttpClient http = new HttpClient();
            Encoding utf = Encoding.GetEncoding("utf-8");
            HtmlDocument document = new HtmlDocument();

            Stream stream_source = http.GetStreamAsync(strUri).Result;
            StreamReader reader = new StreamReader(stream_source, utf);
            string html = reader.ReadToEnd();
            document.LoadHtml(html);
            HtmlNodeCollection results = document.DocumentNode.SelectNodes(nodeDiv);

            return results;

        }
    }
}
