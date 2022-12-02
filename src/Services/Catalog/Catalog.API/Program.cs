using Hermes.Catalog.API.Constants;
using Microsoft.OpenApi.Models;
using Hermes.Catalog.API.Extensions;
using Hermes.Catalog.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddJsonFile("appsettings.User.json", optional: true, reloadOnChange: true);
}

builder.Host.UseNServiceBus();

builder.Services
    .AddDbContext(builder.Environment)
    .AddCustomOptions()
    .AddDependencies();

builder.Services
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

    options.SwaggerDoc(
        ApiSettings.ApiVersion2,
        new OpenApiInfo
        {
            Title = ApiSettings.ApiTitle,
            Version = ApiSettings.ApiVersion2
        });
});

var app = builder.Build();

await app.EnsureInitializedDatabaseAsync();

app.UseMiddleware<MessageSessionMiddleware>();
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

app.MapControllers();
app.MapSwagger();

app.Run();
