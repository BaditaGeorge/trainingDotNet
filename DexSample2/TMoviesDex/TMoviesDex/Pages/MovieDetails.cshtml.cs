using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TMoviesDex.Models;

namespace TMoviesDex.Pages
{
    public class MovieDetailsModel : PageModel
    {
        public List<SampleMovie> lst;

        public MovieDetailsModel()
        {
            lst = new List<SampleMovie>()
            {
                new SampleMovie{
                    MovieId = 1,
                    Title = "Django Unchained",
                    ReleaseData = "1/11/2",
                    Budget = 2333,
                    Actors = new List<string>()
                    {
                        "Leonardo DiCaprio","Jamie Foxx"
                    }
                }
            };
        }
        public void OnGet()
        {

        }
    }
}