using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TMovies.Data;

namespace TMovies.Pages
{
    public class ActorsModel : PageModel
    {
        public IEnumerable<Actor> ActorsData { get; set; }
        //public readonly InMemoryActor actorData;
        public readonly SqlActor actorData;

        public ActorsModel(SqlActor actorData)
        {
            this.actorData = actorData;
        }

        public IActionResult OnGet()
        {
            ActorsData = actorData.GetActorByName("");
            return Page();
        }
    }
}