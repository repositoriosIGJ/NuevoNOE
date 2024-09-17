using Blazored.SessionStorage;
using CurrieTechnologies.Razor.SweetAlert2;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using NUEVO.NOE.BLAZORWEB;
using NUEVO.NOE.BLAZORWEB.ClientServices.Contrato;
using NUEVO.NOE.BLAZORWEB.ClientServices.Implementacion;
using NUEVO.NOE.Service;
using Radzen;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7198/") });


//INYECCION DE DEPENCIAS CLIENT SERVICE
builder.Services.AddScoped<IUsuarioClientService, UsuarioClientService>();
builder.Services.AddScoped<IDepartamentoClientService, DepartamentoClientService>();
builder.Services.AddScoped<IRolesClientService, RolesClientService>();
builder.Services.AddScoped<IRolesUsuariosclientService, RolesUsuariosClientService>();
builder.Services.AddScoped<IDepartamentoClientService, DepartamentoClientService>();
builder.Services.AddScoped<IFuncionesClientService, FuncionClientService>();
builder.Services.AddScoped<IFuncionesRolClientService, FuncionesRolClientServices>();
builder.Services.AddScoped<IUtilidadesDBOracle, UtilidadesDBOracle>();
builder.Services.AddTransient<IGenerarPDFClientService, GenerarPDFClientService>();
builder.Services.AddScoped<IGenerarExcelClientService, GenerarExcelClientService>();
builder.Services.AddScoped<IExpedienteClientService, ExpedienteClientService>();
builder.Services.AddScoped<ITramitesClientService, TramitesClientService>();


builder.Services.AddBlazoredSessionStorage();
builder.Services.AddMudServices();
builder.Services.AddSweetAlert2();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddRadzenComponents();
builder.Services.AddSingleton<UsuarioNotificationService>();
builder.Services.AddSingleton<RolNotificationService>();
builder.Services.AddSingleton<FuncionNotificationService>();
builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
builder.Services.AddTransient<GenerarPDFService>();
await builder.Build().RunAsync();
