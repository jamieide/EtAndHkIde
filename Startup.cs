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

            services.AddTransient<ISiteIndexFactory, JsonSiteIndexFactory>();
            services.AddSingleton<ISiteRepository, JsonSiteRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ISiteIndexFactory siteIndexFactory)
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
            app.UseStatusCodePagesWithReExecute("/Status{0}");

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseMvc();

            siteIndexFactory.BuildIndex();
        }
    }
}
