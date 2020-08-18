using System;
using System.Collections.Generic;
using System.Text;
using TMovies.Data;

namespace TMovie.Data
{
    public class ActorMovies
    {
        public int Id { get; set; }
        public int ActorId { get; set; }
        public Actor Actor { get; set; }

        public int MoviesId { get; set; }
        public Movies Movies { get; set; }
    }
}
