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
using Microsoft.EntityFrameworkCore;
using UserLogInService.UserinfoDbContext;
using UserLogInService.Model;
using UserLogInService.Services;
using AutoMapper;

namespace UserLogInService
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
            services.AddControllers();
            services.AddScoped< IUserService, UserService>();
            services.AddDbContext<LoginDbContext>(opt => opt.UseInMemoryDatabase("UserInfo"));
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddRouting(options => options.LowercaseUrls = true);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //var context = app.ApplicationServices.GetService<LoginDbContext>();
            var scope = app.ApplicationServices.CreateScope();
            var service = scope.ServiceProvider.GetService<LoginDbContext>();
            AddTestData(service);

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void AddTestData(LoginDbContext context)
        {
            var testUser1 = new Entities.User
            {
                Id = 100,
                FirstName = "Luke",
                LastName = "Skywalker",
                Username = "LKarthick",
                Password = "testing"
                
            };

            context.UserInfo.Add(testUser1);
            var testUser2 = new Entities.User
            {
                Id = 101,
                FirstName = "tw",
                LastName = "sfs",
                Username = "LKarthsfsick",
                Password = "testissng"

            };
            context.UserInfo.Add(testUser2);
            context.SaveChanges();
        }
    }
}
