var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddJsonFile("appsettings.User.json", optional: true, reloadOnChange: true);
}

builder.Services.RegisterOptions();
builder.Services.RegisterHttpClients();
builder.Services.RegisterServices();

builder.Services
    .AddControllersWithViews()
    .AddViewLocalization();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Catalog}/{action=Index}/{id?}");

app.Run();