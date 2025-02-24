using ExercicePizza.Helpers;

var builder = WebApplication.CreateBuilder(args);

builder.InjectDepencies();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(options =>
{
    options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
});

app.UseAuthentication(); 

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
