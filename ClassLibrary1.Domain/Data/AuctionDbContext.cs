using ClassLibrary1.Core.Enums;
using ClassLibrary1.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary1.Domain.Data
{
    public class AuctionDbContext : DbContext
    {
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<Source> Sources { get; set; }
        public DbSet<Lot> Lots { get; set; }

        public AuctionDbContext(DbContextOptions<AuctionDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Source>().HasData(new Source
            {
                Id = 1,
                Title = "Source1",
                URL = "https://example.com/source1"
            });

            modelBuilder.Entity<Auction>().HasData(
                new Auction { Id = 1, SourceId = 1, Name = "Auction1" },
                new Auction { Id = 2, SourceId = 1, Name = "Auction2" },
                new Auction { Id = 3, SourceId = 1, Name = "Auction3" },
                new Auction { Id = 4, SourceId = 1, Name = "Auction4" },
                new Auction { Id = 5, SourceId = 1, Name = "Auction5" }
                );

            modelBuilder.Entity<Auction>().Property(a => a.Status)
                .HasDefaultValue(Status.Pending);

            modelBuilder.Entity<Lot>().HasData(
                new Lot { Id = 1, AuctionId = 1, SourceId = 1, LotNo = "1", Price = 100, Title = "Lot1", Description = "Description1", URL = "https://example.com/lot1" },
                new Lot { Id = 2, AuctionId = 1, SourceId = 1, LotNo = "2", Price = 200, Title = "Lot2", Description = "Description2", URL = "https://example.com/lot2" },
                new Lot { Id = 3, AuctionId = 1, SourceId = 1, LotNo = "3", Price = 300, Title = "Lot3", Description = "Description3", URL = "https://example.com/lot3" }
            );
        }
    }
}