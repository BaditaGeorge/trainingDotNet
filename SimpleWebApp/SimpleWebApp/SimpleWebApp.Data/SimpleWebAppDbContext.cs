using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SimpleWebApp.Core;

namespace SimpleWebApp.Data
{
    public class SimpleWebAppDbContext:DbContext
    {
        public SimpleWebAppDbContext(DbContextOptions<SimpleWebAppDbContext> options) : base(options)
        {

        }
        public DbSet<Restaurant> Restaurants { get; set; }

    }
}
