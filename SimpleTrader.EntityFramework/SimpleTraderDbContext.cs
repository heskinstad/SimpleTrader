using Microsoft.EntityFrameworkCore;
using SimpleTrader.Domain.Models;

namespace SimpleTrader.EntityFramework {
    public class SimpleTraderDbContext : DbContext {
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AssetTransaction> AssetTransactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            //Tell it that we want the Stock object from AssetTransaction to be embedded in the AssetTransaction table
            //In other words, the Stock element in AssetTransaction will be replaced by the elements in the Stock class
            //Think of the Stock in AssetTransaction as a foreign key to the Stock class
            modelBuilder.Entity<AssetTransaction>().OwnsOne(a => a.Stock);

            base.OnModelCreating(modelBuilder);
        }

        //In order to generate the database, migrations must be used.
        //And for this a connection string must be provided.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SimpleTraderDB;Trusted_Connection=True");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
