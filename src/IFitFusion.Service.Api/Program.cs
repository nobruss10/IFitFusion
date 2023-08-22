using IFitFusion.Infrastructure.CrossCutting.IoC;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using WebApplication1.Config;
using WebApplication3.Config;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.WebApiConfig();
builder.Services.AddSwaggerConfig();
builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
builder.Services.AddDependenciesExtensions(builder.Configuration);

//var port = Environment.GetEnvironmentVariable("PORT") ?? "7012";
//builder.WebHost.UseUrls($"http://*:{port}");

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseMvcConfiguration();
app.UseSwaggerConfig(builder.Services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>());

app.Run();
