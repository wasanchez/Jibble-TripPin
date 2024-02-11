// See https://aka.ms/new-console-template for more information

using Jibble.TripPin.Application;
using Jibble.TripPin.Console;
using Jibble.TripPin.Console.Extensions;
using Jibble.TripPin.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

HostApplicationBuilder  builder = Host.CreateApplicationBuilder(args);
builder.Configuration.Sources.Clear();

IHostEnvironment environment = builder.Environment;

builder.Configuration
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", true, true);

builder.Services
    .AddLogging()
    .AddApplicationLayer() 
    .AddInfrastructureLayer(builder.Configuration)
    .AddControllers();

using IHost host = builder.Build();

Console.WriteLine("Welcome to TripPin...");


var app = new App(builder.Services.BuildServiceProvider());
await app.Start();

await host.RunAsync();