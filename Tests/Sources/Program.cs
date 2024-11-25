using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NotionAPI;
using NotionAPI.Tests;

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddNotionAPI("NotionAPI")
    .AddTransient<Test>();

var host = builder.Build();

await host.Services.GetRequiredService<Test>().AllTestsAsync();
