using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TMovies.Data;

namespace TMovies.Pages
{
    public class MoviesModel : PageModel
    {

        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }
        public IEnumerable<Movies> MoviesData { get; set; }
        //public InMemoryData movieData;
        public SqlMovie movieData;

        public MoviesModel(SqlMovie movieData)
        {
            this.movieData = movieData;
        }
        public void OnGet()
        {
            MoviesData = movieData.GetMovieByTitle(SearchTerm);
        }
    }
}