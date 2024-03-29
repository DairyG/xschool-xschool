﻿using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using XShop.GCenter.Repositories.Extensions;
using XShop.GCenter.Businesses.Extensions;
using XShop.GCenter.DoMain.Extensions;

namespace xschool
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
            var connectonString = this.Configuration.GetConnectionString("Default");
            if (string.IsNullOrWhiteSpace(connectonString))
            {
                throw new Exception("找不到ConnectionStrings:Default节点,未能正确配置数据库连接字符串");
            }

            services.AddCors();

            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ApiVersionReader = ApiVersionReader.Combine(new QueryStringApiVersionReader("version"), new HeaderApiVersionReader("api-version", "version"));
            });

            services.AddBusinesses();
            services.AddDoMain();
            services.AddScoped<xschool.Controllers.CompanyTestDo>();

            services.AddDbContextPool<GCenterDbContext>(options => options.UseSqlServer(connectonString), poolSize: 64);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
        }
    }
}
