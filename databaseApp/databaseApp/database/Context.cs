using DatabaseApp.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DatabaseApp.Database
{
    internal class Context
    {
    }
    // Example: AppDbContext.cs

    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Shift> Shifts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // SQLite connection string, assuming a local file named "database.db"
            optionsBuilder.UseSqlite("Data Source=database.db");
        }
    }

}
