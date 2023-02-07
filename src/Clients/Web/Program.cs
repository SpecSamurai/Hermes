using Hermes.Client.Web.Constants;
using Hermes.Client.Web.Options;
using Hermes.Client.Web.Services;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddJsonFile("appsettings.User.json", optional: true, reloadOnChange: true);
}

builder.Services
    .AddOptions<CatalogApiOptions>()
    .Configure<IConfiguration>((settings, configuration) =>
        configuration
            .GetSection(nameof(CatalogApiOptions))
            .Bind(settings))
    .ValidateDataAnnotations()
    .ValidateOnStart();

builder.Services
    .AddOptions<PaginationOptions>()
    .Configure<IConfiguration>((settings, configuration) =>
        configuration
            .GetSection(nameof(PaginationOptions))
            .Bind(settings))
    .ValidateDataAnnotations()
    .ValidateOnStart();

builder.Services
    .AddControllersWithViews()
    .AddViewLocalization();

builder.Services
    .AddHttpClient(Settings.CatalogApiClientName, (serviceProvider, client) =>
    {
        var options = serviceProvider.GetRequiredService<IOptions<CatalogApiOptions>>().Value;
        client.BaseAddress = new Uri(options.BaseAddress);
    });

builder.Services
    .AddScoped<ICatalogService, CatalogService>()
    .AddScoped<IOrdersService, OrdersService>()
    .AddScoped<IPaymentsService, PaymentsService>()
    .AddScoped<IBasketService, BasketService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Catalog}/{action=Index}/{id?}");

app.Run();
