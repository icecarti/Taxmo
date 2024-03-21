#pragma warning disable CA1506

using Itmo.Dev.Platform.Common.Extensions;
using Itmo.Dev.Platform.Logging.Extensions;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Data.Entity;
using Taxmo.Application.Extensions;
using Taxmo.Infrastructure.Persistence.Context;
using Taxmo.Infrastructure.Persistence.Extensions;
using Taxmo.Presentation.Http.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddUserSecrets<Program>();

builder.Services.AddOptions<JsonSerializerSettings>();
builder.Services.AddSingleton(sp => sp.GetRequiredService<IOptions<JsonSerializerSettings>>().Value);

builder.Services.AddApplication();
builder.Services.AddInfrastructurePersistence(builder.Configuration);
builder.Services
    .AddControllers()
    .AddNewtonsoftJson()
    .AddPresentationHttp();

builder.Services.AddSwaggerGen().AddEndpointsApiExplorer();

builder.Host.AddPlatformSerilog(builder.Configuration);
builder.Services.AddUtcDateTimeProvider();

WebApplication app = builder.Build();

app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.MapGet("/api/passengers", async (TaxiDbContext db) => await db.Passengers.ToListAsync());

using (var db = new TaxiDbContext())
{
    // получаем объекты из бд и выводим на консоль
    var users = db.Passengers!.ToList();
    Console.WriteLine("Passengers List:");
    foreach (var u in users)
    {
        Console.WriteLine($"- {u.Name} - {u.Email} - {u.Phone} ");
    }
}

Console.ReadKey();

await app.RunAsync();