using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TMovies.Data
{
    public class Actor
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Birthdate { get; set; }

        [Required]
        public int Age { get; set; }

        public Movies Movies { get; set; }
        public int MoviesId { get; set; }
    }
}
