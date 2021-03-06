﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using YEON.VDSC.CORE.Dao;
using Microsoft.AspNetCore.Cors.Infrastructure;
using YEON.VDSC.WEB.Services;
using YEON.VDSC.CORE.Config;

namespace YEON.VDSC.WEB
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            // Setup cors
            services.AddCors();


            /* Dependency Injection */
            // add service
            services.AddTransient<IElandmallService, ElandmallService>();
            services.AddTransient<IGmarketService, GmarketService>();
            services.AddTransient<ITMonService, TMonService>();
            services.AddTransient<IWemakepriceService, WemakepriceService>();

            // add dao
            services.AddSingleton<IElandmallDao, ElandmallDao>();
            services.AddSingleton<IGmarketDao, GmarketDao>();
            services.AddSingleton<ITMonDao, TMonDao>();
            services.AddSingleton<IWemakepriceDao, WemakepriceDao>();

            /* Configuration */
            // add basic configuration
            services.Configure<Connection>(Configuration.GetSection("Connection"));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseCors(builder =>
                builder.AllowAnyHeader()
                       .AllowAnyMethod()
                       .AllowAnyOrigin()
                       .AllowCredentials()
            );

            app.UseMvc();

        }
    }
}
