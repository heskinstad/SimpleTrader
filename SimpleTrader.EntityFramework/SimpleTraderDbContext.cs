using Microsoft.EntityFrameworkCore;
using SimpleTrader.Domain.Models;

namespace SimpleTrader.EntityFramework {
    public class SimpleTraderDbContext : DbContext {
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AssetTransaction> AssetTransactions { get; set; }

        public SimpleTraderDbContext(DbContextOptions options) : base(options) {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            //Tell it that we want the Stock object from AssetTransaction to be embedded in the AssetTransaction table
            //In other words, the Stock element in AssetTransaction will be replaced by the elements in the Stock class
            //Think of the Stock in AssetTransaction as a foreign key to the Stock class
            modelBuilder.Entity<AssetTransaction>().OwnsOne(a => a.Asset);

            base.OnModelCreating(modelBuilder);
        }
    }
}
