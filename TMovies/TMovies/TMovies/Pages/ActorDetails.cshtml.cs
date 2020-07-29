using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TMovies.Data;

namespace TMovies.Pages
{
    public class ActorDetailsModel : PageModel
    {
        public readonly SqlActor actorData;
        public Actor ActorInfo { get; set; }

        public ActorDetailsModel(SqlActor actorData)
        {
            this.actorData = actorData;
        }

        public IActionResult OnGet(int actorId)
        {
            ActorInfo = actorData.GetById(actorId);
            return Page();
        }
    }
}