// builder => sert à construire et configurer l'application

using Demo01.Data;
using Exercice06.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(); 

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("default")));


builder.Services.AddScoped<IRepository<Movie>, MovieRepository>();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

}
app.UseStaticFiles(); 

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",

    pattern: "{controller=Movie}/{action=Index}/{id?}");

app.Run();
