var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(); // Obligatoire en MVC

// M�thode qui passe d'une application en construction a une application "pr�te" � �tre lanc�e.
var app = builder.Build();

// Configure the HTTP request pipeline.
// Configuration des middlewares
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    
    //app.UseHsts(); // utilis� pour le https:// 
    
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // wwwroot (css,js, images, favicon...)

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); // Change l'ordre de la route
 //pattern : "{action=index}/{controller=Home}"

// Lancement de l'application une fois configur�e
app.Run();
