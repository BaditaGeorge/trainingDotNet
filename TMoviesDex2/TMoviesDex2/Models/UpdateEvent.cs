using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace TMoviesDex2.Models
{
    public class ActorQuery : IRequest<Actor>
    {
        public Actor Artist { get; set; }
    }
    public class UpdateEvent : IRequestHandler<ActorQuery, Actor>
    {
        public TMoviesContext db;

        public UpdateEvent(TMoviesContext db)
        {
            this.db = db;
        }

        public async Task<Actor> Handle(ActorQuery updatedModel,CancellationToken cancellation)
        {
            Actor updated = updatedModel.Artist;
            Actor model = db.Actors.Find(updated.Id);
            model.Name = updated.Name;
            model.Birthdate = updated.Birthdate;
            model.Age = updated.Age;
            db.SaveChanges();
            return model;
        }
    }
}
