﻿using System.IO;
using EtAndHkIde.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace EtAndHkIde
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
            services.AddAntiforgery();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSingleton<IContentsRepository, InMemoryContentsRepository>();
            services.AddSingleton<ContentPageCollectionFactory>(x =>
            {
                var hostingEnvironment = x.GetRequiredService<IHostingEnvironment>();
                var contentsPath = Path.Combine(hostingEnvironment.WebRootPath, "content");
                return new ContentPageCollectionFactory(contentsPath);
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseStatusCodePages();
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
