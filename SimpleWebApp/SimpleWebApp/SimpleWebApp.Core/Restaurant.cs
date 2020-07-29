using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SimpleWebApp.Core
{
    public enum CuisineType
    {
        None,
        Mexican,
        Italian,
        Indian
    }

    /// <summary>
    /// foreign key-urile ajuta la traducerea modelelor in colectii
    /// class Menu
    /// {
    ///     public int Id {get;set;}
    ///     public int FilmId {get;set;}
    ///     public int ActorId {get;set;}
    /// }
    /// </summary>

    public class Restaurant
    {
        public int Id { get; set; }
        [Required]
        [StringLength(80)]
        public string Name { get; set; }
        [Required]
        [StringLength(255)]
        public string Location { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
