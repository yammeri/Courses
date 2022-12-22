using Courses.Repository;
using Courses.WebAPI.AppConfiguration.ServicesExtensions;
using Courses.WebAPI.AppConfiguration.ApplicationExtensions;
using Courses.Entities;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.AddSerilogConfiguration();
builder.Services.AddDbContextConfiguration(new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false)
    .Build());
builder.Services.AddVersioningConfiguration();
builder.Services.AddControllers();
builder.Services.AddSwaggerConfiguration();

//temporary
builder.Services.AddScoped<DbContext, Context>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

var app = builder.Build();

app.UseSerilogConfiguration();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerConfiguration();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

try
{
    Log.Information("Application starting...");
    app.Run();
}
catch (Exception ex)
{
    Log.Error("Application finished with error {error}", ex);
}
finally
{
    Log.Information("Application stopped");
    Log.CloseAndFlush();
}