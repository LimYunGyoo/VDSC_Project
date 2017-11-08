using HtmlAgilityPack;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using YEON.VDSC.BOT.Service;
using YEON.VDSC.CORE.Dao;
using YEON.VDSC.CORE.Domain;

namespace YEON.VDSC.BOT
{
    class Program
    {

        static void Main(string[] args)
        {
            // www.elandmall.com
            //ElandmallService elandmallService = new ElandmallService();
            //elandmallService.getDiscountProducts();

            // www.gmarket.co.kr
            GmarketService gmarketService = new GmarketService();
            gmarketService.getDiscountProducts();

        }
    }
}