using DynamicLoad.Client;
using DynamicLoad.Client.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.WebAssembly.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

Dictionary<string, object?> viewParams = new Dictionary<string, object?>();
viewParams.Add("Services", builder.Services);

builder.RootComponents.Add(typeof(App), "#app", ParameterView.FromDictionary(viewParams));

builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<LazyAssemblyLoader>();
builder.Services.AddSingleton<DIContainerService>(new DIContainerService(builder.Services));

await builder.Build().RunAsync();
