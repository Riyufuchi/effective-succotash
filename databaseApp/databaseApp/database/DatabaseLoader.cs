// Example: DatabaseLoader.cs
using DatabaseApp.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq;

namespace DatabaseApp.Database
{
    public class DatabaseLoader
    {
        public ObservableCollection<Employee> LoadData()
        {
            using (var dbContext = new AppDbContext())
            {
                dbContext.Database.Migrate(); // Apply any pending migrations

                // Include related entities in the query
                return new ObservableCollection<Employee>(
                    dbContext.Employees
                        .Include(e => e.Address)
                        .Include(e => e.Shifts)
                        .ToList());
            }
        }

        public ObservableCollection<Shift> LoadShifts()
        {
            using (var dbContext = new AppDbContext())
            {
                dbContext.Database.Migrate();
                return new ObservableCollection<Shift>(
                    dbContext.Shifts
                        .Include(e => e.Employees)
                        .ToList());
            }
        }
    }
}

