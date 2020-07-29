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
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Actor Actor { get; set; }
        public AddActorModel(SqlActor actorData, IHtmlHelper htmlHelper)
        {
            this.actorData = actorData;
            this.htmlHelper = htmlHelper;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                actorData.Add(Actor);
            }
            return RedirectToPage("./Movies");
        }
        public void OnGet()
        {

        }
    }
}