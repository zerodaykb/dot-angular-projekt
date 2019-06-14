﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassReconApi.Core.Services;
using MassReconApi.Infrastucture.Context;
using MassReconApi.Infrastucture.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace MassReconApi
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            
            services.AddScoped<IReconNoteRepository, ReconNoteRepository>();
            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<IReportItemRepository, ReportItemRepository>();
            services.AddScoped<IResponseExternalRepository, ResponseExternalRepository>();
            
            services.AddScoped<IReconNoteService, ReconNoteService>();
            services.AddScoped<IReportService, ReportService>();
            services.AddScoped<IResponseService, ResponseService>();
            services.AddScoped<IReportItemService, ReportItemService>();
            
            services.AddDbContext<MassReconContext>(options => 
                options.UseSqlite("DataSource=dbo.MassReconApi.db",
                    builder => builder.MigrationsAssembly("MassReconApi.Infrastructure")    
                ));

            services.AddCors(options =>
            {
                options.AddPolicy("cors", builder => builder.AllowAnyOrigin().AllowAnyHeader());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseCors("cors");
        }
    }
}