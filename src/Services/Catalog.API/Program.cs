var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddJsonFile("appsettings.User.json", optional: true, reloadOnChange: true);
}

var app = builder.Build();


app.Run();
