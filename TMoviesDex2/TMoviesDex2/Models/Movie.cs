using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace TMoviesDex2.Models
{
    public class Movie
    {
        public Movie()
        {
            this.ActorMovies = new HashSet<ActorMovie>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Release { get; set; }
        public int Budget { get; set; }

        public ICollection<ActorMovie> ActorMovies { get; set; }
    }
}
