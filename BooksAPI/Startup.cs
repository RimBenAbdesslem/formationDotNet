using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksAPI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BooksAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        //nsajlou feha les dependicy : IOC Container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //houni sagelne db ili 5as bina
            services.AddDbContext<BooksDBContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("BooksDB"));
            });
            services.AddCors(options => options.AddPolicy("CorsPolicy", Builder =>
            {
                Builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            }));

        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //tsajel les maidllair cad tsajel ili jey men hhttp request
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors("CorsPolicy");
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
