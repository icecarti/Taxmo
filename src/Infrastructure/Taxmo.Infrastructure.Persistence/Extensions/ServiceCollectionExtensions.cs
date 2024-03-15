using Itmo.Dev.Platform.Postgres.Extensions;
using Itmo.Dev.Platform.Postgres.Plugins;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Taxmo.Application.Abstractions.Persistence;
using Taxmo.Infrastructure.Persistence.Contexts;
using Taxmo.Infrastructure.Persistence.Migrations;
using Taxmo.Infrastructure.Persistence.Plugins;

// using Taxmo.Infrastructure.Persistence.Context;
namespace Taxmo.Infrastructure.Persistence.Extensions;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructurePersistence(this IServiceCollection collection, IConfiguration configuration)
    {
        collection.AddPlatformPostgres(builder => builder.BindConfiguration("Infrastructure:Persistence:Postgres"));
        collection.AddSingleton<IDataSourcePlugin, MappingPlugin>();

        collection.AddPlatformMigrations(typeof(IAssemblyMarker).Assembly);
        collection.AddHostedService<MigrationRunnerService>();

        // TODO: add repositories
        collection.AddScoped<IPersistenceContext, PersistenceContext>();

        collection.AddDbContext<AppDbContext>(options => options.UseNpgsql(configuration["Infrastructure:Persistence:Postgres:ConnectionString"]));

        return collection;
    }
}