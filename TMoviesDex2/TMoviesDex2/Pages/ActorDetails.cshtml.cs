using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TMoviesDex2.Models;

namespace TMoviesDex2.Pages
{
    [AllowAnonymous]
    public class ActorDetailsModel : PageModel
    {
        [BindProperty]
        public Actor ActualActor { get; set; } = new Actor();

        private int actorId;

        public SqlActor sqla;
        private readonly IMediator mediator;
        //tot ce vine prin constructor trebuie teoretic dus in variabile private readonly
        public ActorDetailsModel(SqlActor sqla,IMediator mediator)
        {
            this.sqla = sqla;
            this.mediator = mediator;
        }

        public async Task<IActionResult> OnGet(int actorId)
        {
            //this.actorId = actorId;
            //ActualActor = sqla.GetById(actorId);
            ActualActor = await mediator.Send(new Query { Id = actorId });
            //return ActualActor;
            return Page();
            //return await mediator.Send(new Query { Id = actorId });
        }

        [ValidateAntiForgeryToken]
        public IActionResult OnPost()
        {
            sqla.Update(ActualActor.Id, ActualActor);
            return Page();
        }
    }
}