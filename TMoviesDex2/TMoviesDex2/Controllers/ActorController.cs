using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using TMoviesDex2.Models;

namespace TMoviesDex2.Controllers
{
    [Route("api/[controller]")]
    public class ActorController:Controller
    {
        SqlActor sqlact;
        public List<Actor> actors;

        public ActorController(SqlActor sqlact)
        {
            this.sqlact = sqlact;
        }

        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            actors = this.sqlact.GetAll().ToList();
            return DataSourceLoader.Load(actors, loadOptions);
        }

        [HttpPost]
        public IActionResult Post(string values)
        {
            var newActor = new Actor();
            var _values = JsonConvert.DeserializeObject<Actor>(values);
            actors = this.sqlact.GetAll().ToList();
            actors.Add(this.sqlact.Add(_values));
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int key)
        {
            sqlact.DeleteAt(key);
            return Ok();
        }


        [HttpPut]
        public IActionResult Put(int key,string values)
        {
            var _values = JsonConvert.DeserializeObject<IDictionary>(values);
            sqlact.Update(key,_values);
            return Ok();
        }
    }
}
