using Hermes.Basket.API.Constants;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddJsonFile("appsettings.User.json", optional: true, reloadOnChange: true);
}

builder.Services
    .AddDependencies()
    .AddRedisConnectionProvider()
    .AddControllers()
    .AddNewtonsoftJson();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SupportNonNullableReferenceTypes();

    options.SwaggerDoc(
        ApiSettings.ApiVersion1,
        new OpenApiInfo
        {
            Title = ApiSettings.ApiTitle,
            Version = ApiSettings.ApiVersion1
        });
});

var app = builder.Build();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.RoutePrefix = string.Empty;
    options.SwaggerEndpoint(
        $"/swagger/{ApiSettings.ApiVersion1}/swagger.json",
        $"{ApiSettings.ApiTitle} {ApiSettings.ApiVersion1}");
});

app.MapControllers();
app.MapSwagger();

app.Run();
