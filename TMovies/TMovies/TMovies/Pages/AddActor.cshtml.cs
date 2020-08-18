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
    public class AddActorModel : PageModel
    {
        private readonly SqlActor actorData;
        private readonly SqlMovie movieData;
        private readonly IHtmlHelper htmlHelper;
        public IEnumerable<Movies> movies;

        [BindProperty]
        public Actor Actor { get; set; }

        [BindProperty]
        public string Title { get; set; }
        public AddActorModel(SqlActor actorData, SqlMovie movieData, IHtmlHelper htmlHelper)
        {
            this.actorData = actorData;
            this.movieData = movieData;
            movies = this.movieData.GetMovieByTitle("");
            this.htmlHelper = htmlHelper;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                int movieId = -1;
                foreach (var i in movies)
                {
                    if (i.Title.StartsWith(Title)){
                        movieId = i.Id;
                    }
                }
                actorData.Add(Actor);
                actorData.AddBinding(movieId, Actor.Id);
            }
            return RedirectToPage("./Movies");
        }
        public void OnGet()
        {

        }
    }
}