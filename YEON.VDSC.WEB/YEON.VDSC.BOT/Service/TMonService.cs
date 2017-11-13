using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;
using YEON.VDSC.CORE.Dao;
using YEON.VDSC.CORE.Domain;

namespace YEON.VDSC.BOT.Service
{
    public class TMonService : BasicService
    {
        ITMonDao tmonDao = new TMonDao();

        private const string basicUrl = "http://www.ticketmonster.co.kr";

        public override void getDiscountProducts()
        {
            try
            {
                IList<Product> products = new List<Product>();

                HtmlNodeCollection mainViewResults = ParseHTML(basicUrl + "/home"
                                      , "//p[contains(@class,'percent')]");

                if (mainViewResults != null)
                {
                    for (int j = 0; j < mainViewResults.Count; j++)
                    {
                        int discount = Int32.Parse(mainViewResults[j].InnerText.Split('%')[0].Trim());
                        if (discount >= discountMinimum)
                        {
                            Product product = new Product { Id = Guid.NewGuid(), Discount = discount, Detail = mainViewResults[j].ParentNode.ParentNode.InnerText };
                            products.Add(product);
                        }
                    }
                }

                tmonDao.InsertProducts(products);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
