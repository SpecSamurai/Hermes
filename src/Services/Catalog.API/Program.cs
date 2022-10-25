using Hermes.Catalog.API.Infrastructure;
using Hermes.Catalog.API.Constants;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddJsonFile("appsettings.User.json", optional: true, reloadOnChange: true);
}

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc(
        ApiSettings.ApiVersion1,
        new OpenApiInfo
        {
            Title = ApiSettings.ApiTitle,
            Version = ApiSettings.ApiVersion1
        });

    options.SwaggerDoc(
        ApiSettings.ApiVersion2,
        new OpenApiInfo
        {
            Title = ApiSettings.ApiTitle,
            Version = ApiSettings.ApiVersion2
        });
});

var catalogContextConnectionString = builder.Configuration.GetConnectionString(nameof(CatalogContext));
builder.Services.AddSqlServer<CatalogContext>(
    catalogContextConnectionString,
    sqlServerOptions =>
    {
        sqlServerOptions.MigrationsAssembly(typeof(Program).Assembly.FullName);
        sqlServerOptions.EnableRetryOnFailure();
    },
    options =>
    {
        if (builder.Environment.IsDevelopment())
        {
            options.EnableDetailedErrors();
            options.EnableSensitiveDataLogging();
        }
    }
);

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
    options.SwaggerEndpoint(
        $"/swagger/{ApiSettings.ApiVersion2}/swagger.json",
        $"{ApiSettings.ApiTitle} {ApiSettings.ApiVersion2}");
});

app.UseEndpoints(configure =>
{
    configure.MapControllers();
    configure.MapSwagger();
});

app.Run();
