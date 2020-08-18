using System.Collections;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NUnit.Framework;
using TMoviesDex2.Controllers;
using TMoviesDex2.Models;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using FluentAssertions;
using System.Collections.Generic;
using System;

namespace NUnitTesting
{
    public class ServiceTestClass
    {
        public Actor newActor;

        public Movie newMovie;

        [SetUp]
        public void Setup()
        {
            newActor = new Actor
            {
                Name = "AntonioBanderas",
                Birthdate = "1/1/68",
                Age = 52
            };

            newMovie = new Movie
            {
                Title = "Desperado",
                Release = "1/1/98",
                Budget = 144319
            };
        }

        //Arrange
        public TMoviesContext getInMemoryContext()
        {
            //var options = new DbContextOptionsBuilder<TMoviesContext>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var options = new DbContextOptionsBuilder<TMoviesContext>().UseInMemoryDatabase(databaseName: "For Test").Options;
            var inMemoryContext = new TMoviesContext(options);
            return inMemoryContext;
        }

        //Unit Testing for Actor Service
        [Test]
        public void TestActor_AllPathsReturnsValidValues()
        {
            Assert.That(newActor.Name, Is.EqualTo("AntonioBanderas"));
            Assert.That(newActor.Age, Is.Not.EqualTo(50));
        }

        

        [Test]
        public void TestActorInsertion_ShouldBeEqualTo()
        {
            //arange
            var inMemDbContext = getInMemoryContext();
            var actorContext = new SqlActor(inMemDbContext);

            //act
            Actor returnedActor = actorContext.Add(newActor);

            //assert
            Assert.That(returnedActor, Is.Not.Null);
            Assert.That(returnedActor.Name, Is.EqualTo("AntonioBanderas"));
            Assert.That(returnedActor.Birthdate, Is.EqualTo("1/1/68"));
        }

        [Test]
        public void TestActorUpdate_ShouldBeEqualWithNewValues()
        {
            //arrange

            var inMemDbContext = getInMemoryContext();
            var actorContext = new SqlActor(inMemDbContext);

            //act
            var actorModel = actorContext.Add(newActor);
            var values = JsonConvert.DeserializeObject<IDictionary>("{\"Name\":\"LeonardoDiCaprio\", \"Age\":40}");
            actorContext.Update(actorModel.Id, values);
            var model = actorContext.GetById(actorModel.Id);

            //assert -> 3rd step
            Assert.That(model.Name, Is.EqualTo("LeonardoDiCaprio"));
            Assert.That(model.Age, Is.EqualTo(40));

        }

        [Test]
        public void TestActorDeletion_AtTheEndListShouldBeEmpty()
        {
            //arrange
            var inMemDbContext = getInMemoryContext();
            SqlActor actorContext = new SqlActor(inMemDbContext);
            //act
            actorContext.Add(newActor);
            int listLengthBeforeDeletion = actorContext.GetAll().ToList().Count;
            actorContext.DeleteAt(newActor.Id);
            int listLengthAfterDeletion = actorContext.GetAll().ToList().Count;

            //assert
            Assert.That(listLengthBeforeDeletion, Is.GreaterThan(0));
            Assert.That(listLengthAfterDeletion, Is.EqualTo(0));
        }

        //Unit Testing for Movie Services

        [Test]
        public void TestMovieInsertion_ShouldNotReturnNull()
        {
            //arange
            var inMemDbContext = getInMemoryContext();
            SqlMovie movieContext = new SqlMovie(inMemDbContext);
            //act
            var model = movieContext.addMovie(newMovie);
            //assert
            Assert.That(model, Is.Not.EqualTo(null));
            Assert.That(model.Title, Is.EqualTo("Desperado"));
            Assert.That(model.Release, Is.EqualTo("1/1/98"));
            Assert.That(model.Budget, Is.EqualTo(144319));
        }

        [Test]
        public void TestMovieUpdate_ShouldBeEqualWithNewValues()
        {
            //arange
            var inMemDbContext = getInMemoryContext();
            var movieContext = new SqlMovie(inMemDbContext);
            //act
            var model = movieContext.addMovie(newMovie);
            var toModify = JsonConvert.DeserializeObject<IDictionary>("{\"Title\":\"Desperado 2\"}");
            var modelAfterUpdate = movieContext.Update(model.Id, toModify);
            //assert
            //modelAfterUpdate.Title.Should().NotBe(model.Title);
            modelAfterUpdate.Title.Should().Be("Desperado 2");
            modelAfterUpdate.Release.Should().Be(model.Release);
            modelAfterUpdate.Budget.Should().Be(model.Budget).And.BeGreaterThan(1000);
            
        }

        [Test]
        public void TestMovieDeletion_ShouldBeEmptyAtFinal()
        {
            //arange
            var inMemDbContext = getInMemoryContext();
            var movieContext = new SqlMovie(inMemDbContext);
            //act
            var modelMovie = movieContext.addMovie(newMovie);
            int movieId = modelMovie.Id;
            modelMovie = movieContext.GetById(movieId);
            movieContext.Delete(movieId);
            var modelMovieAfterDeletion = movieContext.GetById(movieId);
            //assert
            modelMovie.Should().NotBeNull();
            modelMovieAfterDeletion.Should().BeNull();
        }

        [Test]
        public void TestMovieActor_ManyToManyRelantion_ActorMoviesListShouldNotBeEmpty()
        {
            //arange
            var inMemDbContext = getInMemoryContext();
            var movieContext = new SqlMovie(inMemDbContext);
            var actorContext = new SqlActor(inMemDbContext);
            //act
            var movieModel = movieContext.addMovie(newMovie);
            var actorModel = actorContext.Add(newActor);
            actorContext.AddBinding(movieModel.Id, actorModel.Id);
            var movieWithActors = movieContext.getMovieWithActorsById(1);
            List<ActorMovie> actorMovies = movieWithActors.ActorMovies.ToList();
            Actor selectedActor = actorContext.GetById(actorMovies[0].ActorId);
            //assert
            actorMovies.Should().HaveCount(1);
            selectedActor.Name.Should().Be(newActor.Name);
        }

        //Integration Testing - Route Testing
        [Test]
        public void TestPostForActorController_ShouldReturnOk()
        {
            //arrange
            var inMemDbContext = getInMemoryContext();
            SqlActor actorContext = new SqlActor(inMemDbContext);
            ActorController actorController = new ActorController(actorContext);
            string actorData = "{" +
                "" + "\"Name\":\"JamieFoxx\"," +
                "" + "\"Birthdate\":\"1/1/70\"," +
                "" + "\"Age\":40" + "}";

            //act
            var response = actorController.Post(actorData);

            //assert
            Assert.That(response, Is.Not.EqualTo(null));
        }

    }
}