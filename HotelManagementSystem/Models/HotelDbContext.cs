using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Usuario\\HotelWPF.mdf;Integrated Security=True;Connect Timeout=30");

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
