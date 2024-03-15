using Microsoft.EntityFrameworkCore;
using Taxmo.Infrastructure.Persistence.Context;

namespace Taxmo.Infrastructure.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext() { }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(@"Host=ep-jolly-sun-a2wj47cv-pooler.eu-central-1.aws.neon.tech;Port=5432;Database=TaxiDB;Username=TaxiDB_owner;Password=vw4TIdSLze0R;SSL Mode=Require;");
    }

    public DbSet<Passenger> Passengers { get; set; }

    /*public DbSet<Car> Cars { get; set; }

    public DbSet<Driver> Drivers { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<CarPark> Parks { get; set; }

    public DbSet<CarRent> Rents { get; set; }

    public DbSet<TaxiCompany> Companies { get; set; }

    public DbSet<TimeWorksheet> WorkSheets { get; set; }*/

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        // Сюда добавлять различные конфигурации ваших файлов
        base.OnModelCreating(modelBuilder);
    }
}