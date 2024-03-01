using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorPageMovie.Data;
using RazorPageMovie.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
//Agregado por scaffolding
builder.Services.AddDbContext<RazorPageMovieContextDb>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RazorPageMovieContextDb") ?? throw new InvalidOperationException("Connection string 'RazorPageMovieContextDb' not found.")));

var app = builder.Build();

using (var scope =app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
