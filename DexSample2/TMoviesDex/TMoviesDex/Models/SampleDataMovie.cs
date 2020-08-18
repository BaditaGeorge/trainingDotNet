using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TMoviesDex.Models
{
    static class SampleDataMovie
    {
        public static List<SampleMovie> Movies = new List<SampleMovie>()
        {
            new SampleMovie()
            {
                MovieId = 1,
                Title = "Django Unchained",
                ReleaseData = "1/11/2",
                Budget = 2333,
                Actors = new List<string>()
                {
                    "Leonardo DiCaprio","Jamie Foxx"
                }
            },
            new SampleMovie()
            {
                MovieId = 2,
                Title = "Kill Bill Vol.1 & 2",
                ReleaseData = "1/2/1",
                Budget = 1121,
                Actors = new List<string>()
                {
                    "Uma Thurman","Lucy Liu","Mickey Rourke"
                }
            },
            new SampleMovie()
            {
                MovieId = 3,
                Title = "The Hateful Eight",
                ReleaseData = "1/1/3",
                Budget = 2000,
                Actors = new List<string>()
                {
                    "Samuel L.Jackson","Kurt Russel"
                }
            }
        };
    }
}
