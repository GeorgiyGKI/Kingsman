using Serilog;

namespace Kingsman.Server.Extensions;

public static class LoggingExtensions
{
    public static IHostBuilder UseCustomSerilog(this IHostBuilder hostBuilder, IConfiguration configuration)
    {
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Hour)
            .CreateLogger();

        return hostBuilder.UseSerilog();
    }
}

