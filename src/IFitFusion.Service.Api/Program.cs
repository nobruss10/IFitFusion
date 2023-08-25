using IFitFusion.Service.Api.Config;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.WebApiConfig();
builder.Services.AddSwaggerConfig();
builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

var portVar = Environment.GetEnvironmentVariable("PORT");
if (portVar is { Length: > 0 } && int.TryParse(portVar, out int port))
    builder.WebHost.UseUrls($"http://*:{port}");

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseMvcConfiguration();
app.UseSwaggerConfig(builder.Services?.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>()!);

app.Run();
