using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ScorerApp.BLL.AutoMapper;
using ScorerApp.BLL.Services;
using ScorerApp.BLL.Services.Interfaces;
using ScorerApp.DAL.Context;
using ScorerApp.FootballDataProvider;
using ScorerApp.FootballDataProvider.Interfaces;

namespace ScorerApp.API
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
            services.AddTransient<DbContext, ScorerAppDbContext>();
            services.AddTransient<IMatchService, MatchService>();
            services.AddTransient<ITeamService, TeamService>();
            services.AddTransient<ILeagueService, LeagueService>();
            services.AddTransient<IFootballDataProvider, FanatikDataProvider>();

            //Sql Sunucusu Kullanal�caksa appsettings.json dosyas�nda d�zenleme yap�lmas� ve Update-Database metodu �al��t�r�lmas� yeterli olacakt�r.
            //services.AddDbContext<ScorerAppDbContext>(db => db.UseSqlServer(Configuration.GetConnectionString("DatabaseConnection")));

            //In Memory Database Kullan�lacaksa A�a��daki Kodun A��lmas� Yeterli.
            services.AddDbContext<ScorerAppDbContext>(db => db.UseInMemoryDatabase("ScorerApp"));



            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Scorer API", Version = "v1" });
            });



            MapperConfiguration config = new MapperConfiguration(
                cfg => cfg.AddProfile<AutoMapperProfile>()
            );

            services.AddSingleton(config.CreateMapper());

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
