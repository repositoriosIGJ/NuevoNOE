using Microsoft.EntityFrameworkCore;
using NUEVO.NOE.API.Models;
using NUEVO.NOE.Business.Contrato;
using NUEVO.NOE.Business.Implementacion;
using NUEVO.NOE.Repository.Seguridad.Contrato;
using NUEVO.NOE.Repository.Seguridad.Implementacion;
using NUEVO.NOE.Service.Contrato;
using NUEVO.NOE.Service.Implementacion;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SeguridadDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerSeguridad"));
});

builder.Services.AddScoped<ISeguridadBusiness, SeguridadBusiness>();

builder.Services.AddScoped<IActiveDirectoryService, ActiveDirectoryService>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

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
