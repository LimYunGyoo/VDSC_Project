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

        public SearchController(IElandmallDao elandmallDao)
        {
            ElandmallDao = elandmallDao;
        }

        [HttpGet("elandmall")]
        public IActionResult GetElandmall(int discount = 50)
        {
            var results = ElandmallDao.SelectAllProducts(discount);
            return Ok(results);
        }


    }
}
    

