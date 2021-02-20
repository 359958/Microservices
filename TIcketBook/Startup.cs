using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using TIcketBook.DataTier.Models;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TIcketBook.Service;
using TIcketBook.DataTier.Repositories;

namespace TIcketBook
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
            
            SetupJWTServices(services);
            services.AddControllers();
            services.AddScoped<IMovie, Movie>();
            services.AddScoped<IMovieShow, MovieshowRepository>();
            services.AddTransient<IMovieService, MovieService>();
            services.AddSwaggerGen();
            services.AddDbContext<Movie_TicketContext>(constr => constr.UseSqlServer(Configuration["ConnectionStrings:MbkDbConstr"]));
            services.AddAutoMapper(typeof(Startup));
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddRouting(options => options.LowercaseUrls = true);

        }
        private void SetupJWTServices(IServiceCollection services)
        {
            string key = "Hiuserusetikeytoencrype"; //this should be same which is used while creating token      
             //this should be same which is used while creating token  

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
          .AddJwtBearer(options =>
          {
              options.TokenValidationParameters = new TokenValidationParameters
              {
                  ValidateIssuer = true,
                  ValidateAudience = true,
                  ValidIssuer = "https://api.mydomain.com/",
                  ValidAudience = "https://api.mydomain.com/",
                  ValidateIssuerSigningKey = true,
                  IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(key))
                  
              };

              options.Events = new JwtBearerEvents
              {
                  OnAuthenticationFailed = context =>
                  {
                      if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                      {
                          context.Response.Headers.Add("Token-Expired", "true");
                      }
                      return Task.CompletedTask;
                  }
              };
          });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
          

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
