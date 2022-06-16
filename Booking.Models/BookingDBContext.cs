using Microsoft.EntityFrameworkCore;

namespace Booking.Models
{
    public partial class BookingDBContext : DbContext
    {
        public BookingDBContext()
        {
        }

        public BookingDBContext(DbContextOptions<BookingDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appartment> Appartments { get; set; } = null!;
        public virtual DbSet<BookingConfirmation> BookingConfirmations { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<District> Districts { get; set; } = null!;
        public virtual DbSet<Location> Locations { get; set; } = null!;
        public virtual DbSet<Region> Regions { get; set; } = null!;
        public virtual DbSet<UserInfo> UserInfos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=EMELYANENKO;Database=BookingDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appartment>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Gpa).HasColumnName("GPA");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Appartments)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Appartments_Locations");
            });

            modelBuilder.Entity<BookingConfirmation>(entity =>
            {
                entity.ToTable("BookingConfirmation");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AppartmentId).HasColumnName("AppartmentID");

                entity.Property(e => e.BookingDate).HasColumnType("date");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.IsApproved)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("isApproved")
                    .IsFixedLength();

                entity.HasOne(d => d.Appartment)
                    .WithMany(p => p.BookingConfirmations)
                    .HasForeignKey(d => d.AppartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BookingConfirmation_Appartments");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.BookingConfirmations)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BookingConfirmation_Customers");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CountryName).HasMaxLength(50);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .HasMaxLength(15)
                    .IsFixedLength();

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(15)
                    .IsFixedLength();

                entity.Property(e => e.Surname)
                    .HasMaxLength(15)
                    .IsFixedLength();
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DistrictName).HasMaxLength(50);

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Districts)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Districts_Regions");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.HasOne(d => d.District)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.DistrictId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Locations_Districts");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.RegionName).HasMaxLength(50);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Regions)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Regions_Country");
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_Registrations");

                entity.ToTable("UserInfo");

                entity.Property(e => e.Id).HasColumnName("RegistrationID");

                entity.Property(e => e.Login).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(30);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}