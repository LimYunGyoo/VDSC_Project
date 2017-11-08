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

        public SearchController(IElandmallDao elandmallDao, IGmarketDao gmarketDao)
        {
            ElandmallDao = elandmallDao;
            GmarketDao = gmarketDao;
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
    }
}
    

