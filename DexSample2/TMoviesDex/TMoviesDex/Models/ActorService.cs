using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TMoviesDex.Models
{
    public class ActorService
    {

        List<Actor> Actors;

        public ActorService()
        {
            Actors = new List<Actor>()
            {
                new Actor
                {
                    ActorId=1,
                    Name="Leonardo DiCaprio",
                    Birthdate="1/1/80"
                },
                new Actor
                {
                    ActorId=2,
                    Name="Jamie Foxx",
                    Birthdate="1/1/76"
                }
            };
        }

        public List<Actor> GetAll()
        {
            return Actors;
        }

        public List<Actor> AddActor(Actor newActor)
        {
            Actors.Add(newActor);
            return Actors;
        }

        public List<Actor> DeleteFromList(Actor actor)
        {
            for(int i = 0; i < Actors.Count; i++)
            {
                if(Actors[i].Name == actor.Name)
                {
                    Actors.RemoveAt(i);
                    return Actors;
                }
            }
            return Actors;
        }

        public List<Actor> DeleteAt(int id)
        {
            Actors.RemoveAt(id);
            return Actors;
        }

        public List<Actor> Replace(string data)
        {
            //int i = Actors.FindIndex(e => e.ActorId == updateActor.ActorId);
            //int index = 0;
            //for(int i = 0; i < Actors.Count; i++)
            //{
            //    if(Actors[i].ActorId == updateActor.ActorId)
            //    {
            //        index = i;
            //        break;
            //    }
            //}
            //Actors[0].ActorId = index;

            Actors[0].Name = data;
            //Actors[0].Name = updateActor.Name;
            return Actors;
        }
    }
}
