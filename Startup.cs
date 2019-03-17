using BethanysPieShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;

namespace BethanysPieShop
{
    public class Startup
    {
        //here I need to pass in the read-out configuration information to Startup class through the dependency injection
        public IConfiguration Configuration{ get; set; }

        //IConfiguration instance contains all the info that was already read out by the program class
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //we need a connection string to connect with the actual database;
            // I can use the configuration instance to ask for a conncetion string
            services.AddDbContext<AppDbContext>(
                optionsAction: options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")),
                contextLifetime: ServiceLifetime.Transient,
                optionsLifetime: ServiceLifetime.Transient
            );
            //Add the default identity ssytem configuration
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>(); //this service should use my AppDbContext to store the info

            //services.AddTransientWithResolver<IPieRepository, MockPieRepository>();//if someone is asking for an IPieRepository, a new MockPieRepository will be returned
            services.AddTransientWithResolver<IPieRepository, PieRepository>();
            //services.AddSingleton<>(); only one single instance is going to be created of the specified type, and only the same instance is going to be returned
            //services.AddScoped<>(); //per request it will always return the sae instance, but as soon as the request goes out of scope, the instance is removed
            services.AddTransient<IFeedbackRepository, FeedbackRepository>();
            services.AddMvc(); //in this way we enable MVC for this application
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(Microsoft.AspNetCore.Builder.IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            //app.UseMvcWithDefaultRoute(); I am going to replace this with app.UseMvc() and passing to this one my route ;
            app.UseMvc(routes =>
            {
                routes.MapRoute(

                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"//this template is going to be use to match incoming request with this pattern
                    );
            }
            );
            // In complex application we can use several routes by calling MapRoute several times with different routes;
            
        }
    }
}
