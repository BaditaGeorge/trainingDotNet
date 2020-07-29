using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
namespace TMovies.Data
{
    public class TMoviesDbContext:DbContext
    {
        public TMoviesDbContext(DbContextOptions<TMoviesDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>()
                .HasOne(a => a.Movies).WithMany(m => m.Actors).HasForeignKey(a => a.MoviesId);
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TMovies;Integrated Security=True;");
        //}
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movies> Movies { get; set; }
    }
}
