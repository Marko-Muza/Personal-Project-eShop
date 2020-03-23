using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Mapper;
using AutoMapper;
using DataAccessLayer.Classes;
using DataAccessLayer;
using BussinesLogicLayer;
using BussinesLogicLayer;
using DataAccessLayer.Interfaces;

namespace ProjekatAPI
{
    public class Startup
    {
        public readonly string MyAllowSpecificOrigins = "myPolicy";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperFunctionality));

            services.AddCors(options => options.AddPolicy(
                    MyAllowSpecificOrigins, builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    }
                )
            );
            services.AddScoped<IProductManager, ProductManager>();
            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<IUser, User>();
            services.AddScoped<IValidation, Validation>();
            services.AddScoped<ICurrentDate, CurrentDate>();
            services.AddScoped<IGuidGenerator, GuidGenerator>();
            services.AddScoped<IGuidForAddProducts, GuidForAddProducts>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(MyAllowSpecificOrigins); // This MUST BE ABOVE app.UseEndpoints()

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
