using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Practice1.Models;

public partial class DataContext : DbContext
{
    public DataContext()
    {
       
    }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
       Database.EnsureCreated();
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Fond> Fonds { get; set; }

    public virtual DbSet<Guest> Guests { get; set; }

    public virtual DbSet<PricesAndAccommodationsEmployee> PricesAndAccommodationsEmployees { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Gostinica;Integrated Security=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.IdEmpleyee).HasName("PK__employee__A53589592F1466B7");

            entity.ToTable("employees");

            entity.Property(e => e.IdEmpleyee)
          
                .HasColumnName("id_empleyee");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Fond>(entity =>
        {
            entity.HasKey(e => e.TableId).HasName("PK__fond__B21E8F244CF80DE7");

            entity.ToTable("fond");

            entity.Property(e => e.TableId)
               
                .HasColumnName("table_id");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TotalNumberOfGuestRooms).HasColumnName("total_number_of_guest_rooms");
        });

        modelBuilder.Entity<Guest>(entity =>
        {
            entity.HasKey(e => e.IdGuest).HasName("PK__guests__4EAB86C10DD0F023");

            entity.ToTable("guests");

            entity.Property(e => e.IdGuest)
        
                .HasColumnName("id_guest");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .HasColumnName("username");
        });

        modelBuilder.Entity<PricesAndAccommodationsEmployee>(entity =>
        {
            entity.HasKey(e => e.IdPriceAccomodations).HasName("PK__prices_a__116B3119B1759B3A");

            entity.ToTable("prices_and_accommodationsEmployees");

            entity.Property(e => e.IdPriceAccomodations)
               
                .HasColumnName("id_price_accomodations");
            entity.Property(e => e.Finish).HasColumnName("finish");
            entity.Property(e => e.IdEmpleyee).HasColumnName("id_empleyee");
            entity.Property(e => e.IdFond).HasColumnName("id_fond");
            entity.Property(e => e.Start).HasColumnName("start");
            entity.Property(e => e.StatusAccommodation).HasColumnName("status_accommodation");
            entity.Property(e => e.Stoimos)
                .HasColumnType("money")
                .HasColumnName("stoimos");

            entity.HasOne(d => d.IdEmpleyeeNavigation).WithMany(p => p.PricesAndAccommodationsEmployees)
                .HasForeignKey(d => d.IdEmpleyee)
                .HasConstraintName("FK_prices_and_accommodationsEmployees_employees");

            entity.HasOne(d => d.IdFondNavigation).WithMany(p => p.PricesAndAccommodationsEmployees)
                .HasForeignKey(d => d.IdFond)
                .HasConstraintName("FK_prices_and_accommodationsEmployees_fond");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.IdService).HasName("PK__services__D06FB5A8F7DF3A04");

            entity.ToTable("services");

            entity.Property(e => e.IdService)
               
                .HasColumnName("id_service");
            entity.Property(e => e.Accommodation)
                .HasColumnType("money")
                .HasColumnName("accommodation");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
