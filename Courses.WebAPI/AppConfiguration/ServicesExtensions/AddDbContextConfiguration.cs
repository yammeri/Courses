using Courses.Entities;
using Microsoft.EntityFrameworkCore;

namespace Courses.WebAPI.AppConfiguration.ServicesExtensions;
/// <summary>
/// Services extensions
/// </summary>
public static partial class ServicesExtensions
{
    /// <summary>
    /// Add DbContext configuration
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    public static void AddDbContextConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("Context");
        services.AddDbContext<Context>(options =>
        {
            options
                .UseLazyLoadingProxies()
                .UseSqlServer(connectionString, sqlServerOption => 
                    {
                        sqlServerOption.CommandTimeout(60 * 60);
                    });
        });
    }
}
