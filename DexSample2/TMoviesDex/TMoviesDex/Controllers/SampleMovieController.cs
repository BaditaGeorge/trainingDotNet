using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using TMoviesDex.Models;

namespace TMoviesDex.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataMovieController:Controller
    {

        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(SampleDataMovie.Movies, loadOptions);
        }
    }
}
