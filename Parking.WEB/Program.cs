using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Parking.WEB;
using Parking.WEB.Repositories;

//inyeccion de dependencias

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//Aquí ponemos la url del localhost en el cuál sale nuestra API
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7119/")});

builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddSweetAlert2();

await builder.Build().RunAsync();
