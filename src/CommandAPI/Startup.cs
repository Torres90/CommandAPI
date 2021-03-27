using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommandAPI.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

namespace CommandAPI
{
    public class Startup
    {
        //added by me
        //This is Configuration Code. We'll use to supply the connection strign in 'appsettings.json' to
        //our DbContext class.
        public IConfiguration Configuration {get;}
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Added by me
            services.AddDbContext<CommandContext>(opt => opt.UseNpgsql
                (Configuration.GetConnectionString("PostgreSqlConnection")));

            //Added by me
            services.AddControllers();

            //Added by me
            //services.AddScoped<ICommandAPIRepo, MockCommandAPIRepo>(); //Old use of the Mock Repository Implementation
            services.AddScoped<ICommandAPIRepo, SqlCommandAPIRepo>(); //New Repository Implementation
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                // endpoints.MapGet("/", async context =>
                // {
                //     await context.Response.WriteAsync("Hello World!");
                // });

                //added by me
                endpoints.MapControllers();

            });
        }
    }
}
