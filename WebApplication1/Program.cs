using DinkToPdf;
using DinkToPdf.Contracts;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Microsoft.EntityFrameworkCore;
using NUEVO.NOE.API.Models;
using NUEVO.NOE.Business.Contrato;
using NUEVO.NOE.Business.DatosCiviles.Contrato;
using NUEVO.NOE.Business.DatosCiviles.Implementacion;
using NUEVO.NOE.Business.Implementacion;
using NUEVO.NOE.Repository.DatosCiviles.Contrato;
using NUEVO.NOE.Repository.DatosCiviles.Implementacion;
using NUEVO.NOE.Repository.Seguridad.Contrato;
using NUEVO.NOE.Repository.Seguridad.Implementacion;
using NUEVO.NOE.Service;
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

builder.Services.AddCors(options =>
{
    options.AddPolicy("NuevaPolitica", app =>
    {

        app.WithOrigins("https://localhost:7276") /// Hay que cambiaR
        .AllowAnyHeader()
        .AllowCredentials()
        .SetIsOriginAllowedToAllowWildcardSubdomains()
        .WithMethods("GET", "PUT", "POST", "DELETE", "OPTIONS")
        .SetPreflightMaxAge(TimeSpan.FromSeconds(3600));

    });
});

// * B U S I N E S S * 
builder.Services.AddScoped<IUsuarioBusiness, UsuarioBusiness>();
builder.Services.AddScoped<IRolesBusiness, RolesBusiness>();
builder.Services.AddScoped<IRolesUsuariosBusiness, RolesUsuariosBusiness>();
builder.Services.AddScoped<IFuncionRolBusiness, FuncionRolBusiness>();
builder.Services.AddScoped<IFuncionBusiness, FuncionBusiness>();
builder.Services.AddScoped<IDepartamentoBusiness, DepartamentoBusiness>();
builder.Services.AddScoped<IDatosCivilesBusiness, DatosCivilesBusiness>();
// *  S E R V I C I O S  *
builder.Services.AddScoped<IActiveDirectoryService, ActiveDirectoryService>();
builder.Services.AddScoped<IGenerarExcelService, GenerarExcelService>();
builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
builder.Services.AddScoped<GenerarPDFService>();
//AUTOMAPPER
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

// * R  E  P  O  S  I  T  O  R  I  O  S *
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IRolRepository, RolRepository>();
builder.Services.AddScoped<IFuncionRepository, FuncionRepository>();
builder.Services.AddScoped<IRolUsuarioRepository, RolUsuarioRepository>();
builder.Services.AddScoped<IFuncionRolRepository, FuncionRolRepositoy>();
builder.Services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();
builder.Services.AddScoped<IDatosCivilesRepository, DatosCivilesRepository>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:32674/") });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("NuevaPolitica");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
