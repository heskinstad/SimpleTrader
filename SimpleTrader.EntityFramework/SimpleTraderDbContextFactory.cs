using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.EntityFramework {
    public class SimpleTraderDbContextFactory : IDesignTimeDbContextFactory<SimpleTraderDbContext> {
        public SimpleTraderDbContext CreateDbContext(string[] args = null) {
            //The = null sends null as the parameter if no parameter is given

            var options = new DbContextOptionsBuilder<SimpleTraderDbContext>();

            //In order to generate the database, migrations must be used.
            //And for this a connection string must be provided.
            options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SimpleTraderDB;Trusted_Connection=True");

            return new SimpleTraderDbContext(options.Options);
        }
    }
}
