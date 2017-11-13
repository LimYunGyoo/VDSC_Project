using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;
using YEON.VDSC.CORE.Dao;
using YEON.VDSC.CORE.Domain;

namespace YEON.VDSC.BOT.Service
{
    public class GmarketService : BasicService
    {
        IGmarketDao gmarketDao = new GmarketDao();

        private const string basicUrl = "http://corners.gmarket.co.kr";

        public override void getDiscountProducts()
        {
            try
            {
                IList<Product> products = new List<Product>();

                HtmlNodeCollection superDealResults = ParseHTML(basicUrl + "/SuperDeals"
                                      , "//em[contains(@class,'sale')]");

                if (superDealResults != null)
                {
                    for (int j = 0; j < superDealResults.Count; j++)
                    {
                        int discount = Int32.Parse(superDealResults[j].InnerText.Split('%')[0].Trim());
                        if (discount >= discountMinimum)
                        {
                            Product product = new Product { Id = Guid.NewGuid(), Discount = discount, Detail = superDealResults[j].ParentNode.ParentNode.ParentNode.InnerText };
                            products.Add(product);
                        }
                    }
                }

                gmarketDao.InsertProducts(products);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
