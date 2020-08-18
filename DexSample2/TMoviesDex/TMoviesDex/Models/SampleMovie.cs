using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TMoviesDex.Models
{
    public class SampleMovie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string ReleaseData { get; set; }
        public float Budget { get; set; }
        public List<string> Actors { get; set; }
    }
}
