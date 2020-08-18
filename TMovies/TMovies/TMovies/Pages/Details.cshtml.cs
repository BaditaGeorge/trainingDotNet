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
        public readonly SqlActor actorData;
        public List<Actor> actors;

        public DetailsModel(SqlMovie movieData, SqlActor actorData)
        {
            this.movieData = movieData;
            this.actorData = actorData;
            actors = new List<Actor>();
        }

        public IActionResult OnGet(int movieId)
        {
            movie = movieData.GetById(movieId);
            foreach(var i in movie.ActorMovies)
            {
                actors.Add(actorData.GetById(i.ActorId));
            }
            return Page();
        }
    }
}