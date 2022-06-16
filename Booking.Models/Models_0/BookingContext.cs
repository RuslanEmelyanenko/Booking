using Microsoft.EntityFrameworkCore;

namespace Booking.Models.Models_0
{
    public class BookingContext : DbContext
    {
        public DbSet<UserInfo> UsersInfo { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Appartment> Appartments { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<BookingConfirmation> BookingConfirmations { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Region>()
        //        .HasOne<Country>(d => d.Country)
        //        .WithMany(d => d.Regions)
        //        .HasForeignKey(d => d.CountryId);

        //    modelBuilder.Entity<District>()
        //       .HasOne<Region>(d => d.Region)
        //       .WithMany(s => s.Districts)
        //       .HasForeignKey(d => d.RegionId);

        //    modelBuilder.Entity<Location>()
        //      .HasOne<District>(d => d.District)
        //      .WithMany(s => s.Locations)
        //      .HasForeignKey(d => d.DistrictId);

        //    modelBuilder.Entity<Location>()
        //     .HasOne<District>(d => d.District)
        //     .WithMany(s => s.Locations)
        //     .HasForeignKey(d => d.DistrictId);

        //    modelBuilder.Entity<Appartment>()
        //     .HasOne<Location>(d => d.Location)
        //     .WithMany(s => s.Appartments)
        //     .HasForeignKey(d => d.LocationId);

        //    modelBuilder.Entity<BookingConfirmation>()
        //     .HasOne<Customer>(d => d.Customer)
        //     .WithMany(s => s.BookingConfirmations)
        //     .HasForeignKey(d => d.CustomerId);

        //    modelBuilder.Entity<BookingConfirmation>()
        //    .HasOne<Appartment>(d => d.Appartment)
        //    .WithOne(s => s.BookingConfirmations)
        //    //.HasForeignKey(d => d.);
        //}

        public BookingContext(DbContextOptions<BookingContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}