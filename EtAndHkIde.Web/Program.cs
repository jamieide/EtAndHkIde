using EtAndHkIde.Archive;
using EtAndHkIde.Web;
using EtAndHkIde.Web.Data;
using EtAndHkIde.Web.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var builder = WebApplication.CreateBuilder(args);

var razorPages = builder.Services.AddRazorPages();

#if DEBUG
// todo
#endif

builder.Services.AddAntiforgery();
builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
    options.LowercaseQueryStrings = true;
});

// todo refactor
builder.Services.AddSingleton<ISiteRepository, SiteRepository>();

builder.Services.AddDbContext<ArchiveDbContext>(options =>
{
    options.UseSqlite("Data source=C:\\Users\\jamie\\source\\EtAndHkIdeDb\\EtAndHkIde.sqlite");
});
builder.Services.AddScoped<ArchiveService>();

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