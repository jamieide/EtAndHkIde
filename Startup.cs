using EtAndHkIde.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EtAndHkIde
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages().AddNewtonsoftJson();
            services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
            services.AddAntiforgery();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<ISiteIndexFactory, JsonSiteIndexFactory>();
            services.AddSingleton<ISiteRepository, JsonSiteRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ISiteIndexFactory siteIndexFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseStatusCodePages();
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }

            app.UseStatusCodePagesWithReExecute("/Status{0}");

            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints => endpoints.MapRazorPages());

            siteIndexFactory.BuildIndex();
        }
    }
}
