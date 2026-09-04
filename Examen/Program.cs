using AccesoDatos;
using BaseDatos;
using Configuracion;
using Microsoft.EntityFrameworkCore;

// Add services to the container.

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var connectionString = builder.Configuration["ConnectionSQL"];

builder.Services.AddDbContext<BDDirectaContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<ServicesConfiguracion>();
builder.Services.AddScoped<IAccesoDatosApi, AccesoDatosApi>();
builder.Services.AddScoped<ClsExamen>();
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
    pattern: "{controller=Examen}/{action=Index}/{id?}");

app.Run();
