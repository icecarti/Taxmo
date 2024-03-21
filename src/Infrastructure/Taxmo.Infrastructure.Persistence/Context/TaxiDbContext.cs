using Microsoft.EntityFrameworkCore;

namespace Taxmo.Infrastructure.Persistence.Context;

public partial class TaxiDbContext : DbContext
{
    public TaxiDbContext()
    {
    }

    public TaxiDbContext(DbContextOptions<TaxiDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<Carpark> Carparks { get; set; }

    public virtual DbSet<Carrent> Carrents { get; set; }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<Passenger> Passengers { get; set; }

    public virtual DbSet<Taxiorder> Taxiorders { get; set; }

    public virtual DbSet<Taxi> Taxies { get; set; }

    public virtual DbSet<Timeworksheet> Timeworksheets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=ep-jolly-sun-a2wj47cv-pooler.eu-central-1.aws.neon.tech;Port=5432;Database=TaxiDB;Username=TaxiDB_owner;Password=vw4TIdSLze0R;SSL Mode=Require;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.CarId).HasName("car_pkey");

            entity.ToTable("cars");

            entity.Property(e => e.CarId)
                .HasDefaultValueSql("nextval('car_car_id_seq'::regclass)")
                .HasColumnName("car_id");
            entity.Property(e => e.Brand)
                .HasMaxLength(50)
                .HasColumnName("brand");
            entity.Property(e => e.CarNumber)
                .HasMaxLength(15)
                .HasColumnName("car_number");
            entity.Property(e => e.CarparkId).HasColumnName("carpark_id");
            entity.Property(e => e.Color)
                .HasMaxLength(18)
                .HasColumnName("color");
            entity.Property(e => e.Model)
                .HasMaxLength(50)
                .HasColumnName("model");
            entity.Property(e => e.Year).HasColumnName("year");

            entity.HasOne(d => d.Carpark).WithMany(p => p.Cars)
                .HasForeignKey(d => d.CarparkId)
                .HasConstraintName("car_carpark_id_fkey");
        });

        modelBuilder.Entity<Carpark>(entity =>
        {
            entity.HasKey(e => e.CarparkId).HasName("carpark_pkey");

            entity.ToTable("carparks");

            entity.Property(e => e.CarparkId)
                .HasDefaultValueSql("nextval('carpark_carpark_id_seq'::regclass)")
                .HasColumnName("carpark_id");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .HasColumnName("address");
            entity.Property(e => e.CarCount)
                .HasMaxLength(18)
                .HasColumnName("car_count");
            entity.Property(e => e.Ie)
                .HasMaxLength(15)
                .HasColumnName("ie");
            entity.Property(e => e.Postcode)
                .HasMaxLength(50)
                .HasColumnName("postcode");

            entity.HasOne(d => d.Taxi).WithMany(p => p.Carparks)
                .HasForeignKey(d => d.Ie)
                .HasConstraintName("carpark_ie_fkey");
        });

        modelBuilder.Entity<Carrent>(entity =>
        {
            entity.HasKey(e => e.RentId).HasName("carrent_pkey");

            entity.ToTable("carrents");

            entity.Property(e => e.RentId)
                .HasDefaultValueSql("nextval('carrent_rent_id_seq'::regclass)")
                .HasColumnName("rent_id");
            entity.Property(e => e.CarId).HasColumnName("car_id");
            entity.Property(e => e.DailyPrice)
                .HasDefaultValue(0)
                .HasColumnName("daily_price");
            entity.Property(e => e.DriverId).HasColumnName("driver_id");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.StartDate).HasColumnName("start_date");

            entity.HasOne(d => d.Car).WithMany(p => p.Carrents)
                .HasForeignKey(d => d.CarId)
                .HasConstraintName("carrent_car_id_fkey");

            entity.HasOne(d => d.Driver).WithMany(p => p.Carrents)
                .HasForeignKey(d => d.DriverId)
                .HasConstraintName("carrent_driver_id_fkey");
        });

        modelBuilder.Entity<Driver>(entity =>
        {
            entity.HasKey(e => e.DriverId).HasName("driver_pkey");

            entity.ToTable("drivers");

            entity.HasIndex(e => e.DriverLicense, "driver_driver_license_key").IsUnique();

            entity.HasIndex(e => e.Email, "driver_email_key").IsUnique();

            entity.HasIndex(e => e.Passport, "driver_passport_key").IsUnique();

            entity.HasIndex(e => e.Phone, "driver_phone_key").IsUnique();

            entity.Property(e => e.DriverId)
                .HasDefaultValueSql("nextval('driver_driver_id_seq'::regclass)")
                .HasColumnName("driver_id");
            entity.Property(e => e.DriverLicense)
                .HasMaxLength(50)
                .HasColumnName("driver_license");
            entity.Property(e => e.Email)
                .HasMaxLength(18)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Passport)
                .HasMaxLength(18)
                .HasColumnName("passport");
            entity.Property(e => e.Phone)
                .HasMaxLength(18)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Passenger>(entity =>
        {
            entity.HasKey(e => e.PassengerId).HasName("passenger_pkey");

            entity.ToTable("passengers");

            entity.HasIndex(e => e.Email, "passenger_email_key").IsUnique();

            entity.HasIndex(e => e.Phone, "passenger_phone_key").IsUnique();

            entity.Property(e => e.PassengerId).HasDefaultValueSql("nextval('passenger_passenger_id_seq'::regclass)");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(18);
        });

        modelBuilder.Entity<Taxiorder>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("orders_pkey");

            entity.ToTable("taxiorders");

            entity.Property(e => e.OrderId)
                .HasDefaultValueSql("nextval('orders_order_id_seq'::regclass)")
                .HasColumnName("order_id");
            entity.Property(e => e.DriverId).HasColumnName("driver_id");
            entity.Property(e => e.DriverRate).HasColumnName("driver_rate");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.OrderType)
                .HasMaxLength(25)
                .HasColumnName("order_type");
            entity.Property(e => e.PassengerId).HasColumnName("passenger_id");
            entity.Property(e => e.PassengerRate).HasColumnName("passenger_rate");
            entity.Property(e => e.Price)
                .HasDefaultValue(0)
                .HasColumnName("price");
            entity.Property(e => e.StartDate).HasColumnName("start_date");

            entity.HasOne(d => d.Driver).WithMany(p => p.Taxiorders)
                .HasForeignKey(d => d.DriverId)
                .HasConstraintName("orders_driver_id_fkey");

            entity.HasOne(d => d.Passenger).WithMany(p => p.Taxiorders)
                .HasForeignKey(d => d.PassengerId)
                .HasConstraintName("orders_passenger_id_fkey");
        });

        modelBuilder.Entity<Taxi>(entity =>
        {
            entity.HasKey(e => e.Ie).HasName("taxi_pkey");

            entity.ToTable("taxies");

            entity.HasIndex(e => e.Phone, "taxi_phone_key").IsUnique();

            entity.Property(e => e.Ie)
                .HasMaxLength(15)
                .HasColumnName("ie");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(18)
                .HasColumnName("phone");
            entity.Property(e => e.RegistrationDate).HasColumnName("registration_date");
        });

        modelBuilder.Entity<Timeworksheet>(entity =>
        {
            entity.HasKey(e => e.WorksheetId).HasName("timeworksheet_pkey");

            entity.ToTable("timeworksheets");

            entity.Property(e => e.WorksheetId)
                .HasDefaultValueSql("nextval('timeworksheet_worksheet_id_seq'::regclass)")
                .HasColumnName("worksheet_id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.DriverId).HasColumnName("driver_id");
            entity.Property(e => e.HourCount)
                .HasDefaultValue(0)
                .HasColumnName("hour_count");
            entity.Property(e => e.HourlySalary)
                .HasDefaultValue(0)
                .HasColumnName("hourly_salary");
            entity.Property(e => e.TaxiIe)
                .HasMaxLength(15)
                .HasColumnName("taxi_ie");

            entity.HasOne(d => d.Driver).WithMany(p => p.Timeworksheets)
                .HasForeignKey(d => d.DriverId)
                .HasConstraintName("timeworksheet_driver_id_fkey");

            entity.HasOne(d => d.TaxiIeNavigation).WithMany(p => p.Timeworksheets)
                .HasForeignKey(d => d.TaxiIe)
                .HasConstraintName("timeworksheet_taxi_ie_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
