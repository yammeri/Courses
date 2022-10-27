using Serilog;

namespace Courses.WebAPI.AppConfiguration.ApplicationExtensions
{
    /// <summary>
    /// Application builder extensions
    /// </summary>
    public static partial class AppExtensions
    {
        /// <summary>
        /// Use serilog configuration
        /// </summary>
        /// <param name="app"></param>
        public static void UseSerilogConfiguration(this IApplicationBuilder app)
        {
            app.UseSerilogRequestLogging();
        }
    }
}