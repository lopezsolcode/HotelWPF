using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;

namespace HotelManagementSystem.Models;

public partial class HotelDbContext : DbContext
{
    public HotelDbContext()
    {
    }

    public HotelDbContext(DbContextOptions<HotelDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DboCustomer> DboCustomers { get; set; }

    public virtual DbSet<DboEmployee> DboEmployees { get; set; }

    public virtual DbSet<DboReservation> DboReservations { get; set; }

    public virtual DbSet<DboRoom> DboRooms { get; set; }

    public virtual DbSet<DboUser> DboUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory()) // Usa AppContext.BaseDirectory si estás en producción
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        var connectionString = config.GetConnectionString("HotelConnection");

        optionsBuilder.UseSqlServer(connectionString);
    }                                           
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DboReservation>(entity =>
        {
            entity.Property(e => e.ReservationId).ValueGeneratedNever();
        });

        modelBuilder.Entity<DboRoom>(entity =>
        {
            entity.Property(e => e.Booked).HasDefaultValue("No");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
