using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using TMoviesDex2.Models;

namespace TMoviesDex2.Controllers
{
    public class MovieDetails:Controller
    {
        SqlMovie movieContext;

        public MovieDetails(SqlMovie movieContext)
        {
            this.movieContext = movieContext;
        }

        //public ActionResult Overview()
        //{
        //    return View(this.movieContext.GetAll().ToList()[0]);
        //}

        [HttpGet]
        public object GetMovieDetails(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(this.movieContext.GetAll().ToList(), loadOptions);
            //return View("Data");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Validation(Movie model)
        {
            //var model = JsonConvert.DeserializeObject<Movie>(values);
            this.movieContext.UpdateOnModel(model);
            return View("../SuccesPage");
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return null;
        }

        [HttpPut]
        public IActionResult Put()
        {
            return null;
        }
    }
}
