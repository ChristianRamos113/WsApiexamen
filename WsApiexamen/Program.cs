using AccesoDatos;
using BaseDatos;
using Microsoft.EntityFrameworkCore;
using Negocio;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BDDirectaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionSQL")));
// Add services to the container.
builder.Services.AddScoped<BDDirecta>();
builder.Services.AddControllers();

builder.Services.AddScoped<INegocioApi, NegocioApi>();
builder.Services.AddScoped<IAccesoDatosApi, AccesoDatosApi>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
