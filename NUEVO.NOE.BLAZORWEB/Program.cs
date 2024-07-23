using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using NUEVO.NOE.BLAZORWEB;
using NUEVO.NOE.BLAZORWEB.ClientServices.Contrato;
using NUEVO.NOE.BLAZORWEB.ClientServices.Implementacion;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7198/") });

builder.Services.AddScoped<IUsuarioClientService, UsuarioClientService>();

builder.Services.AddMudServices();

await builder.Build().RunAsync();
