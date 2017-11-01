using HtmlAgilityPack;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using YEON.VDSC.CORE.Dao;
using YEON.VDSC.CORE.Domain;

namespace YEON.VDSC.BOT
{
    class Program
    {       

        static void Main(string[] args)
        {
            IElandmallDao elandmallDao = new ElandmallDao();
            IList<Product> products = new List<Product>();

            for(int i = 1; i < 5; i++)
            {
                HtmlNodeCollection results = ParseHTML(@"http://www.elandmall.com/shop/initShopLuckyDeal.action"
                                      + "?listOnly=Y&conr_set_cmps_no=170800000014077&conr_set_no=170800000001584&rows_per_page=60"
                                      + "&conr_stock_grp_no=1708001584&area_no=D1512000293&undefined=0&&_=1508809137180&page_idx=" + i
                                      , "//span[contains(@class,'p_per')]");

                for (int j = 0; j < results.Count; j++)
                {
                    int discount = Int32.Parse(results[j].InnerText.Replace("%", "").Trim());
                    if (discount >= 50)
                    {
                        Product product = new Product { Discount = discount, Node = results[j].ParentNode.ParentNode.ParentNode.OuterHtml };
                        products.Add(product);
                    }
                }
            }

            elandmallDao.InsertProducts(products);
            
        }


        private static HtmlNodeCollection ParseHTML(string strUri, string nodeDiv)
        {
            HttpClient http = new HttpClient();
            Encoding utf = Encoding.GetEncoding("utf-8");
            HtmlDocument document = new HtmlDocument();

            Stream stream_source = http.GetStreamAsync(strUri).Result;
            StreamReader reader = new StreamReader(stream_source, utf);
            string html = reader.ReadToEnd();
            document.LoadHtml(html);
            HtmlNodeCollection p_per = document.DocumentNode.SelectNodes(nodeDiv);

            return p_per;

        }
    }


}