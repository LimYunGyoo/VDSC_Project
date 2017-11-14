using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YEON.VDSC.WEB.Services;
using YEON.VDSC.CORE.Dao;

namespace YEON.VDSC.WEB.Controllers
{
    [Produces("application/json")]
    [Route("api/batch")]
    public class BatchController : Controller
    {
        IElandmallService elandmallService;
        IGmarketService gmarketService;
        ITMonService tmonService;
        IWemakepriceService wemakepriceService;

        public BatchController(IElandmallService ElandmallService, IGmarketService GmarketService, ITMonService TMonService, IWemakepriceService WemakepriceService)
        {
            elandmallService = ElandmallService;
            gmarketService = GmarketService;
            tmonService = TMonService;
            wemakepriceService = WemakepriceService;
        }

        [HttpGet("renewal")]
        public IActionResult RenewalDiscountProduct()
        {
            int success = 0;
            int error = 0;

            // www.elandmall.com
            try
            {
                elandmallService.getDiscountProducts();
                success++;
            }
            catch (Exception e)
            {
                error++;
            }

            // www.gmarket.co.kr
            try
            {
                gmarketService.getDiscountProducts();
                success++;
            } catch(Exception e)
            {
                error++;
            }


            // www.ticketmonster.co.kr
            try
            {
                tmonService.getDiscountProducts();
                success++;
            }
            catch (Exception e)
            {
                error++;
            }


            //www.wemakeprice.com
            try
            {
                wemakepriceService.getDiscountProducts();
                success++;
            }
            catch (Exception e)
            {
                error++;
            }


            return Ok("Success : " + success + ", Error : " + error);
        }
    }
}