using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.ComponentModel;

namespace TMovies.Data
{
    public interface IMovieData
    {
        public IEnumerable<Movies> GetMovieByTitle(string title);
    }

    public interface IActorData
    {
        public IEnumerable<Actor> GetActorByName(string name);
    }

    public interface IData<T>
    {
        public T GetById(int id);
        public T Add(T newEntity);
        public T Update(T updatedEntity);
    }

    public class SqlActor:IActorData,IData<Actor>
    {
        public List<Actor> actors;
        private readonly TMoviesDbContext db;

        public SqlActor(TMoviesDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Actor> GetActorByName(string name)
        {
            return from a in db.Actors where string.IsNullOrEmpty(name) || a.Name.StartsWith(name) orderby a.Name select a;
        }
        public Actor GetById(int id)
        {
            return db.Actors.Find(id);
        }

        public Actor Add(Actor newActor)
        {
            db.Add(newActor);
            db.SaveChanges();
            return newActor;
        }

        public Actor Update(Actor updatedActor)
        {
            return null;
        }
    }

    public class SqlMovie : IMovieData,IData<Movies>
    {
        public List<Movies> movies;
        private readonly TMoviesDbContext db;

        public SqlMovie(TMoviesDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Movies> GetMovieByTitle(string title)
        {
            return from m in db.Movies where string.IsNullOrEmpty(title) || m.Title.StartsWith(title) orderby m.Title select m;
        }

        public Movies GetById(int id)
        {
            return db.Movies.Find(id);
        }

        public Movies Add(Movies newMovie)
        {
            db.Add(newMovie);
            db.SaveChanges();
            return newMovie;
        }

        public Movies Update(Movies updatedMovie)
        {
            return null;
        }

    }

    public class InMemoryActor : IActorData, IData<Actor>
    {
        public List<Actor> actors;

        public InMemoryActor()
        {
            actors = new List<Actor>()
            {
                new Actor{Id=1,Name="Leonardo DiCaprio",Birthdate="1/1/1",Age=40 },
                new Actor{Id=2,Name="Jamie Foxx",Birthdate="1/1/1",Age=43 },
                new Actor{Id=3,Name="Brad Pitt",Birthdate="1/1/1",Age=51 }
            };
        }

        public IEnumerable<Actor> GetActorByName(string name)
        {
            return from a in actors where string.IsNullOrEmpty(name) || a.Name.StartsWith(name) orderby a.Name select a;
        }

        public Actor GetById(int id)
        {
            foreach(var actor in actors)
            {
                if(actor.Id == id)
                {
                    return actor;
                }
            }
            return null;
        }

        public Actor Add(Actor newActor)
        {
            return null;
        }

        public Actor Update(Actor updatedActor)
        {
            return null;
        }
    }

    public class InMemoryData:IMovieData,IData<Movies>
    {
        public List<Movies> movies;

        public InMemoryData()
        {
            movies = new List<Movies>()
            {
                new Movies{Id=1,Title="Reservoir Dogs",Description="good",Release="1/1/1" },
                new Movies{Id=2,Title="Kill Bill Vol.1",Description="good",Release="1/1/1" },
                new Movies{Id=3,Title="Django Unchained",Description="good",Release="1/1/1" }
            };
        }

        public IEnumerable<Movies> GetMovieByTitle(string title)
        {
            return from m in movies where string.IsNullOrEmpty(title) || m.Title.StartsWith(title) orderby m.Title select m;
        }

        public Movies Add(Movies newMovie)
        {
            movies.Add(newMovie);
            newMovie.Id = movies.Max(m => m.Id) + 1;
            return newMovie;
        }

        public Movies Update(Movies updatedMovie)
        {
            foreach(var movie in movies)
            {
                if(movie.Id == updatedMovie.Id)
                {
                    movie.Title = updatedMovie.Title;
                    movie.Description = updatedMovie.Description;
                    movie.Release = updatedMovie.Release;
                }
            }
            return updatedMovie;
        }

        public Movies GetById(int movieId)
        {
            foreach(var i in movies)
            {
                if(i.Id == movieId)
                {
                    return i;
                }
            }
            return null;
        }
    }
}
