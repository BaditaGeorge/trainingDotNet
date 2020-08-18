using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TMoviesDex2.Controllers
{
    [Route("api/TestController")]
    public class TestController : Controller
    {
        [HttpGet]
        public string Get()
        {
            return "testGetter";
        }
    }
}
