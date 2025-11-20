using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Npgsql.EntityFrameworkCore;
using proyecto_caldas.Data;
using proyecto_caldas.Data.Services;
using proyecto_caldas.Implementation;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration
.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<DBContext>(options => options.UseNpgsql(connectionString));

// Add services to the container.
builder.Services.AddControllersWithViews();



builder.Services.AddScoped<IUsuarioservice, UsuarioService>();

builder.Services.AddScoped<IPaswordServicio, PaswordServicio>();
builder.Services.AddScoped<LoginServicio, LoginServicio>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
