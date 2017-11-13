using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.IO;
using YEON.VDSC.CORE.Dao;

namespace YEON.VDSC.WEB.Controllers
{
    [Produces("application/json")]
    [Route("api/search")]
    public class SearchController : Controller
    {
        IElandmallDao ElandmallDao;
        IGmarketDao GmarketDao;
        ITMonDao TMonDao;
        IWemakepriceDao WemakepriceDao;

        public SearchController(IElandmallDao elandmallDao, IGmarketDao gmarketDao, ITMonDao tmonDao, IWemakepriceDao wemakepriceDao)
        {
            ElandmallDao = elandmallDao;
            GmarketDao = gmarketDao;
            TMonDao = tmonDao;
            WemakepriceDao = wemakepriceDao;
        }

        [HttpGet("elandmall")]
        public IActionResult GetElandmall(int discount = 50)
        {
            var results = ElandmallDao.SelectOverProducts(discount);
            return Ok(results);
        }

        [HttpGet("gmarket")]
        public IActionResult GetGmarket(int discount = 50)
        {
            var results = GmarketDao.SelectOverProducts(discount);
            return Ok(results);
        }

        [HttpGet("tmon")]
        public IActionResult GetTMon(int discount = 50)
        {
            var results = TMonDao.SelectOverProducts(discount);
            return Ok(results);
        }

        [HttpGet("wemakeprice")]
        public IActionResult GetWemakeprice(int discount = 50)
        {
            var results = WemakepriceDao.SelectOverProducts(discount);
            return Ok(results);
        }
        
    }
}
    

