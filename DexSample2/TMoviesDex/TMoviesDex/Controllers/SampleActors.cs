using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using TMoviesDex.Models;

namespace TMoviesDex.Controllers
{
    [Route("api/[controller]")]
    public class SampleActors:Controller
    {
        ActorService acServ;
        public SampleActors(ActorService acServ)
        {
            this.acServ = acServ;
        }
        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            var actors = this.acServ.GetAll();
            return DataSourceLoader.Load(actors, loadOptions);
        }

        [HttpPost]
        public IActionResult Post(string values)
        {
            var newActor = new Actor();
            var _values = JsonConvert.DeserializeObject<Actor>(values);
            var actors = this.acServ.AddActor(_values);
            return Ok(actors);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var actors = this.acServ.DeleteAt(id);
            return Ok(actors);
        }


        [HttpPut]
        public IActionResult Put(string values)
        {
            //var _values = jsonconvert.deserializeobject<actor>(values);
            var actors = this.acServ.Replace(values);
            return Ok(actors);
        }
    }
}
