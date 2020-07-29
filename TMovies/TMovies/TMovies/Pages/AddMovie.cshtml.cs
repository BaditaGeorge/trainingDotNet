using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TMovies.Data;

namespace TMovies.Pages
{
    public class AddMovieModel : PageModel
    {
        private readonly SqlMovie movieData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Movies Movie { get; set; }
        public AddMovieModel(SqlMovie movieData,IHtmlHelper htmlHelper)
        {
            this.movieData = movieData;
            this.htmlHelper = htmlHelper;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                movieData.Add(Movie);
            }
            return RedirectToPage("./Movies");
        }
    }
}