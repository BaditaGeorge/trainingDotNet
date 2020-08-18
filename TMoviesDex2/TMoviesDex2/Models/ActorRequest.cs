using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace TMoviesDex2.Models
{
    public class Query : IRequest<Actor>
    {
        public int Id { get; set; }
    }

    public class ActorHandler : IRequestHandler<Query, Actor>
    {
        private TMoviesContext db;

        public ActorHandler(TMoviesContext db)
        {
            this.db = db;
        }

        public Task<Actor> Handle(Query request,CancellationToken cancellation)
        {
            return this.db.Actors.Where(c => c.Id == request.Id).SingleOrDefaultAsync();
        }
    }
}
