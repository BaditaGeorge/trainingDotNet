using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TMovies.Data;

namespace TMovies.Pages
{
    public class DetailsModel : PageModel
    {
        public readonly SqlMovie movieData;
        public Movies movie;

        public DetailsModel(SqlMovie movieData)
        {
            this.movieData = movieData;
        }

        public IActionResult OnGet(int movieId)
        {
            movie = movieData.GetById(movieId);
            return Page();
        }
    }
}