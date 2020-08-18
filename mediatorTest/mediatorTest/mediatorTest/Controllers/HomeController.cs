using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using mediatorTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace mediatorTest.Controllers
{
    [Route("api/TestController")]
    public class HomeController:Controller
    {
        public NotifierMediatorService mediator;
        public HomeController(NotifierMediatorService mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public string Get(int? id)
        {
            return mediator.Notify("some message " + id.ToString());
        }

        [HttpPost]
        public string Post([FromBody] IDictionary dict)
        {
            return Convert.ToString(dict["Age"]);
        }
    }
}
