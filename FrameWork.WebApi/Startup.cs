﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrameWork.WebApi.Container;
using FrameWork.WebApi.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;

namespace FrameWork.WebApi
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

            JwtConfigure.Configure(services);

            services.AddEntityFrameworkNpgsql()
                    .AddDbContext<FrameWork.Repository.FrameWorkContext>(
                        options => options.UseNpgsql(
                        Configuration.GetConnectionString("framework")));

                    
            services.AddMvc();

            ContainerBuilder.ConfigureContainer(services);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

             app.UseAuthentication();

            app.UseMvc();
        }
    }
}
