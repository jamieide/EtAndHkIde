using EtAndHkIde.Web;
using EtAndHkIde.Web.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var builder = WebApplication.CreateBuilder(args);

var razorPages = builder.Services.AddRazorPages();

#if DEBUG
// todo
#endif

builder.Services.AddAntiforgery();
builder.Services.Configure<RouteOptions>(o => o.LowercaseUrls = true);
// todo refactor
builder.Services.AddSingleton<ISiteRepository, SiteRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseStatusCodePages();
}
else
{
    app.UseExceptionHandler("/Error");
}

var pages = SiteIndex.Pages;

app.UseStatusCodePagesWithReExecute("/Status{0}");
app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();
app.Run();