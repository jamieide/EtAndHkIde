using EtAndHkIde.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Net;

namespace EtAndHkIde
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // TODO response caching
            // https://stackoverflow.com/a/58657997/12752
            services.AddRazorPages()
                .AddRazorRuntimeCompilation()
                //.AddMvcOptions(options =>
                //{
                //    var defaultCacheAttribute = new ResponseCacheAttribute
                //    {
                //        Duration = 86400, // 1 day
                //        Location = ResponseCacheLocation.Any
                //    };
                //    options.Filters.Add(defaultCacheAttribute);
                //})
                .AddNewtonsoftJson();
            //services.AddResponseCaching();
            services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
            services.AddAntiforgery();
            services.AddSingleton<ISiteRepository, SiteRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseStatusCodePages();
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }

            app.UseStatusCodePagesWithReExecute("/Status{0}");
            app.UseStaticFiles();
            //app.UseResponseCaching();
            //app.Use(async (context, next) =>
            //{
            //    context.Response.GetTypedHeaders().CacheControl =
            //    new Microsoft.Net.Http.Headers.CacheControlHeaderValue
            //    {
            //        Public = true,
            //        MaxAge = TimeSpan.FromDays(1),
            //    };
            //    await next();
            //});

            // site re-org 12/5/20, everything is just a page now
            // TODO change to permanent when working
            var redirectStatusCode = (int)HttpStatusCode.PermanentRedirect;
            app.UseRewriter(new RewriteOptions()
                .AddRedirect("articles/(.*)", "$1", redirectStatusCode)
                .AddRedirect("blog/(.*)", "$1", redirectStatusCode)
                .AddRedirect("images/(.*)", "$1", redirectStatusCode)
            );
            app.UseRouting();
            app.UseEndpoints(endpoints => endpoints.MapRazorPages());
        }
    }
}
