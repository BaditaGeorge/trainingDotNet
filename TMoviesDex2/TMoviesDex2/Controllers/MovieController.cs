using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TMoviesDex2.Models;

namespace TMoviesDex2.Controllers
{
    [Route("api/[controller]")]
    public class MovieController:Controller
    {
        SqlMovie sqlmv;
        List<Movie> movies;
        public MovieController(SqlMovie sqlmv)
        {
            this.sqlmv = sqlmv;
        }
        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            movies = this.sqlmv.GetAll().ToList();
            return DataSourceLoader.Load(movies, loadOptions);
        }

        [HttpPost]
        public IActionResult Post(string values)
        {
            var newMovie = new Movie();
            var _values = JsonConvert.DeserializeObject<Movie>(values);
            movies = this.sqlmv.GetAll().ToList();
            movies.Add(this.sqlmv.addMovie(_values));
            return Ok(movies);
        }

        [HttpDelete]
        public IActionResult Delete(int key)
        {
            sqlmv.Delete(key);
            return Ok();
        }


        [HttpPut]
        public IActionResult Put(int key,string values)
        {
            //var _values = jsonconvert.deserializeobject<actor>(values);
            //var _values = JsonConvert.DeserializeObject<Movie>
            var _updatedProps = JsonConvert.DeserializeObject<IDictionary>(values);
            sqlmv.Update(key, _updatedProps);
            return Ok();
        }
    }
}
