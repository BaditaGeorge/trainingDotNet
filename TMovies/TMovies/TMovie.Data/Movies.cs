using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TMovies.Data
{
    public class Movies
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public String Title { get; set; }
        [Required]
        public String Description { get; set; }
        [Required]
        public String Release { get; set; }

        public virtual ICollection<Actor> Actors { get; set; }

    }
}
