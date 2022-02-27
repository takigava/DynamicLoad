using DynamicLoad.Contracts;
using DynamicLoad.Contracts.Services;
using DynamicLoad.Server.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.FileProviders;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

PhysicalFileProvider fileProvider = new PhysicalFileProvider(Directory.GetCurrentDirectory());
IDirectoryContents directoryContents = fileProvider.GetDirectoryContents("Lib");

foreach (IFileInfo file in directoryContents)
{
    Assembly assembly = Assembly.LoadFrom(file.PhysicalPath);
    foreach (Type mytype in assembly.GetTypes()
     .Where(mytype => mytype.GetInterfaces().Contains(typeof(ICommonModuleService))))
    {
        builder.Services.AddTransient(typeof(ICommonModuleService), (provider) =>
        {
            return mytype.GetConstructors()[0].Invoke(new object[] { builder.Services });
        });
    }
}

builder.Services.AddSingleton<IModuleService>(new ModuleService(builder.Services));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
