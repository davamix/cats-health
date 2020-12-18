using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatsHealth.API.Data.Database;
using CatsHealth.API.Data.Entities;
using CatsHealth.API.Data.Repositories;
using CatsHealth.API.Data.StorageProviders;
using CatsHealth.API.Data.StorageProviders.MongoProvider;
using CatsHealth.API.Services.ProfileService;
using CatsHealth.API.Services.WeightService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace CatsHealth.API
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

            // services.AddSingleton<IStorageProvider<Profile>, ProfileStorage>();
            services.AddSingleton<IDatabaseConfiguration, DatabaseConfiguration>();
            services.AddScoped<IDatabaseBootstrap, DatabaseBootstrap>();
            services.AddScoped<IStorageProvider<Profile>, ProfileStorageProvider>();
            services.AddScoped<IStorageProvider<Weight>, WeightStorageProvider>();
            services.AddScoped<IRepository<Profile>, ProfileRepository>();
            services.AddScoped<IRepository<Weight>, WeightRepository>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<IWeightService, WeightService>();

            services.AddCors(o => o.AddPolicy("AllowCors", builder =>
                        {
                            builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                        }));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CatsHealth.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CatsHealth.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("AllowCors");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            serviceProvider.GetService<IDatabaseBootstrap>().Setup();
            
        }
    }
}
