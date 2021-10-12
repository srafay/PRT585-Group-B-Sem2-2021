//using LOGIC.Services.Implementation;
using Exceptionless;
using Exceptionless.Logging;
using LOGIC.Services.Implementation;
using LOGIC.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIApp
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPIApp", Version = "v1" });
            });

            services.AddExceptionless("kUrnuPOBwKE3Ek8hshHxvR6My9eCJcurb1cxu8vm");

            #region CUSTOM SERVICES [D-I]

            services.AddScoped<IStudent_Service, Student_Service>();
            services.AddScoped<IProduct_Service, Product_Service>();
            services.AddScoped<IBrand_Service, Brand_Service>();
            services.AddScoped<IType_Service, Type_Service>();
            //services.AddScoped<IApplicant_Service, Applicant_Service>();
            //services.AddScoped<IGrade_Service, Grade_Service>();
            //services.AddScoped<IApplication_Service, Application_Service>();
            //services.AddScoped<IApplicationStatus_Service, ApplicationStatus_Service>();
            #endregion

            #region CORS
            services.AddCors();

            string corsUrl = Configuration["CORS:site"];
            string[] corsUrls;
            if (corsUrl.Contains(","))
            {
                corsUrls = corsUrl.Split(',').ToArray();
            }
            else
            {
                corsUrls = new string[1];
                corsUrls[0] = corsUrl;
            }
            services.AddCors(options =>
            {
                options.AddPolicy("angular",
                    builder =>
                    {
                        builder.WithOrigins(corsUrls)
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                    });
            });
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPIApp v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors();
            app.UseAuthorization();
            /* Import Exceptionless */
            app.UseExceptionless();
            ExceptionlessClient.Default.Configuration.UseFileLogger("D:\\Projects\\PRT585-Group-B-Sem2-2021\\Syed (S330705)\\Week 08\\LibraryAppCoreAppAngularNTierApp\\WebAPIApp\\exceptionless.log",
                                                                    Exceptionless.Logging.LogLevel.Trace);
            /*ExceptionlessClient.Default.Configuration.UseFolderStorage("D:\\Projects\\PRT585-Group-B-Sem2-2021\\Syed (S330705)\\Week 08\\LibraryAppCoreAppAngularNTierApp\\WebAPIApp\\");*/

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
