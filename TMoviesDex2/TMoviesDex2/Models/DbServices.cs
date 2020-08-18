using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Mvc;

namespace TMoviesDex2.Models
{
    public class SqlActor
    {
        public List<Actor> actors;
        private readonly TMoviesContext db;

        public SqlActor(TMoviesContext db)
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

        public IEnumerable<Actor> GetAll()
        {
            return from a in db.Actors select a;
        }

        public Actor Add(Actor newActor)
        {
            db.Add(newActor);
            db.SaveChanges();
            return newActor;
        }

        public void AddBinding(int movieId, int actorId)
        {
            ActorMovie am = new ActorMovie();
            am.MovieId = movieId;
            am.ActorId = actorId;
            db.Add(am);
            db.SaveChanges();
        }

        public Actor DeleteAt(int actorId)
        {
            var model = db.Actors.Find(actorId);
            db.Actors.Remove(model);
            db.SaveChanges();
            return model;
        }

        public Actor Update(int key,IDictionary values)
        {
            Actor model = db.Actors.Find(key);
            this.PopulateModel(model,values);
            db.SaveChanges();
            return model;
        }

        public Actor Update(int key,Actor values)
        {
            Actor model = db.Actors.Find(key);
            model.Name = values.Name;
            model.Birthdate = values.Birthdate;
            model.Age = values.Age;
            db.SaveChanges();
            return model;
        }

        public void PopulateModel(Actor model,IDictionary values)
        {
            if(values.Contains("Name"))
            {
                model.Name = Convert.ToString(values["Name"]);
            }

            if(values.Contains("Age"))
            {
                model.Age = Convert.ToInt32(values["Age"]);
            }

            if(values.Contains("Birthdate"))
            {
                model.Birthdate = Convert.ToString(values["Birthdate"]);
            }
        }
    }

    public class SqlMovie
    {
        public List<Movie> movies;
        public readonly TMoviesContext db;

        public SqlMovie(TMoviesContext db)
        {
            this.db = db;
        }

        public IEnumerable<Movie> GetAll()
        {
            return from m in db.Movies select m;
        }

        public void Delete(int key)
        {
            var model = db.Movies.Find(key);
            db.Movies.Remove(model);
            db.SaveChanges();
        }

        public Movie addMovie(Movie newMovie)
        {
            db.Add(newMovie);
            db.SaveChanges();
            return newMovie;
        }

        public Movie GetById(int key)
        {
            var movie = db.Movies.Find(key);
            return movie;
        }

        public void Commit()
        {
            db.SaveChanges();
        }

        public Movie Update(int key, IDictionary updatedProps)
        {
            var model = db.Movies.Find(key);
            this.PopulateMode(model, updatedProps);
            db.SaveChanges();
            return model;
        }

        public Movie UpdateOnModel(Movie model)
        {
            var actualModel = db.Movies.Find(model.Id);
            actualModel.Title = model.Title;
            actualModel.Release = model.Release;
            actualModel.Budget = model.Budget;
            //var aModel = new Movie { Title="Kill Bill Vol.2 ",Release="1/1/2005",Budget=313334};
            //db.Add(aModel);
            db.SaveChanges();
            return actualModel;
        }

        public Movie getMovieWithActorsById(int id)
        {
            var model = db.Movies.Find(id);
            db.Entry(model).Collection(m => m.ActorMovies).Load();
            return model;
        }

        public void PopulateMode(Movie model,IDictionary properties)
        {
            if (properties.Contains("Title"))
            {
                model.Title = Convert.ToString(properties["Title"]);
            }

            if (properties.Contains("Release"))
            {
                model.Release = Convert.ToString(properties["Release"]);
            }

            if (properties.Contains("Budget"))
            {
                model.Budget = Convert.ToInt32(properties["Budget"]);
            }
        }
    }
}
