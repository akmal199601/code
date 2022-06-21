using Contracts;
using Entities;
using LoggerService;
using Microsoft.EntityFrameworkCore;
namespace code.Extensions;
public static class ServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy",
                builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                );
        });
    }
    public static void ConfigureIISIntegration(this IServiceCollection services)
    {
        services.Configure<IISOptions>(options =>
        {

        });
    }
    public static void ConfigureLoggerService(this IServiceCollection services)
    {
        services.AddSingleton<ILoggerManager, LoggerManager>();
    }
    public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration) =>
        services.AddDbContext<RepositoryContext>(optionsAction =>

            optionsAction.UseNpgsql(configuration.GetConnectionString("PostgresCS"),ma=> ma.MigrationsAssembly("code")).LogTo(Console.WriteLine));
}