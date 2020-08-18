using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TMovie.Data;

namespace TMovies.Data
{
    public class Actor
    {
        public Actor()
        {
            this.ActorMovies = new HashSet<ActorMovies>();
        }

        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Birthdate { get; set; }

        [Required]
        public int Age { get; set; }

        public virtual ICollection<ActorMovies> ActorMovies { get; set; }
        //public Movies Movies { get; set; }
        //public int MoviesId { get; set; }
    }
}
