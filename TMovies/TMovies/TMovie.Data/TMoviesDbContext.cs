using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TMovie.Data;

namespace TMovies.Data
{
    public class TMoviesDbContext:DbContext
    {
        public TMoviesDbContext(DbContextOptions<TMoviesDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<ActorMovies>().HasKey(am => new { am.ActorId, am.MoviesId });
            //modelBuilder.Entity<Actor>().HasMany(a => a.ActorMovies).WithOne().HasForeignKey(am => am.ActorId);
            //modelBuilder.Entity<Movies>().HasMany(m => m.ActorMovies).WithOne().HasForeignKey(am => am.MoviesId);
            //modelBuilder.Entity<Movies>().HasMany(m => m.Actors).WithOne(a => a.Movies).HasForeignKey(a => a.MoviesId);
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TMovies;Integrated Security=True;");
        //}
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<ActorMovies> ActorMovies { get; set; }
    }
}
