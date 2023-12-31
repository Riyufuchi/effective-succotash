using databaseApp.database;
using DatabaseApp.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseApp.Controller
{
    public class ControllerDB
    {
        private readonly DatabaseLoader databaseLoader;
        public ObservableCollection<Employee> People { get; set; }

        public ControllerDB()
        {
            databaseLoader = new DatabaseLoader();
            People = databaseLoader.LoadData();
            AddTestEmployee();
        }

        public ControllerDB(DatabaseLoader databaseLoader, ObservableCollection<Employee> people)
        {
            this.databaseLoader = databaseLoader;
            People = people;
        }

        private void AddTestEmployee()
        {
            // Add a test employee to the database
            using (var context = new AppDbContext())
            {
                var testEmployee = new Employee
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Address = new Address
                    {
                        Street = "123 Main St",
                        City = "Anytown",
                        State = "CA",
                        ZipCode = "12345"
                    },
                    Shift = new Shift
                    {
                        ShiftName = "Day Shift"
                    }
                };

                context.Employees.Add(testEmployee);
                context.SaveChanges();

                // Reload data after adding the test employee
                People = databaseLoader.LoadData();
            }
        }
    }
}
