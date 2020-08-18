using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;
using System.Text;
using TMovie.Data;

namespace TMovies.Data
{
    public class Movies
    {
        public Movies()
        {
            this.ActorMovies = new HashSet<ActorMovies>();
        }

        [Required]
        public int Id { get; set; }

        [Required]
        public String Title { get; set; }
        [Required]
        public String Description { get; set; }
        [Required]
        public String Release { get; set; }

        public virtual ICollection<ActorMovies> ActorMovies { get; set; }

    }
}
