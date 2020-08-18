using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TMoviesDex2.Models
{
    public class Actor
    {
        public Actor()
        {
            this.ActorsMovies = new HashSet<ActorMovie>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Birthdate { get; set; }
        public int Age { get; set; }

        public virtual ICollection<ActorMovie> ActorsMovies { get; set; }
    }
}
