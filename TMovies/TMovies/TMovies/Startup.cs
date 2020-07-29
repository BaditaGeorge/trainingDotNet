using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TMovies.Data;

namespace TMovies
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddSingleton<IMovieData, InMemoryData>();
            services.AddDbContextPool<TMoviesDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("TMoviesDb"));
            });

            services.AddSingleton<InMemoryData>();
            services.AddSingleton<IMovieData>(x => x.GetRequiredService<InMemoryData>());
            services.AddSingleton<IData<Movies>>(x => x.GetRequiredService<InMemoryData>());

            services.AddSingleton<InMemoryActor>();
            services.AddSingleton<IActorData>(x => x.GetRequiredService<InMemoryActor>());
            services.AddSingleton<IData<Actor>>(x => x.GetRequiredService<InMemoryActor>());

            services.AddScoped<SqlMovie>();
            //services.AddScoped<IMovieData>(x => x.GetRequiredService<SqlMovie>());
            //services.AddScoped<IData<Movies>>(x => x.GetRequiredService<SqlMovie>());

            services.AddScoped<SqlActor>();
            //services.AddScoped<IActorData>(x => x.GetRequiredService<SqlActor>());
            //services.AddScoped<IData<Actor>>(x => x.GetRequiredService<SqlActor>());

            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
