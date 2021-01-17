using EtAndHkIde.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net;

namespace EtAndHkIde
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // https://stackoverflow.com/a/58657997/12752
            services.AddRazorPages().AddRazorRuntimeCompilation().AddNewtonsoftJson();
            services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
            services.AddAntiforgery();

            //services.AddTransient<ISiteIndexFactory, JsonSiteIndexFactory>();
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

            // site re-org 12/5/20, everything is just a page now
            // TODO change to permanent when working
            var redirectStatusCode = (int)HttpStatusCode.Redirect;
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
