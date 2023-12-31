using DatabaseApp.Database;
using Microsoft.EntityFrameworkCore;
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
        public ObservableCollection<Employee> Employees { get; set; }
        public ObservableCollection<Shift> Shifts { get; set; }

        public ControllerDB()
        {
            databaseLoader = new DatabaseLoader();
            Employees = databaseLoader.LoadData();
            Shifts = databaseLoader.LoadShifts();
            //AddTestEmployee();
        }

        public void DeleteEmployees()
        {
            using (var dbContext = new AppDbContext())
            {
                // Retrieve all employees
                var sh = dbContext.Shifts.ToList();

                // Remove all employees from the Employees table
                dbContext.Shifts.RemoveRange(sh);

                // Save changes to the database
                dbContext.SaveChanges();

                // Retrieve all employees with their shifts
                var allEmployees = dbContext.Employees.Include(e => e.Shifts).ToList();

                // Remove all shifts associated with employees
                foreach (var employee in allEmployees)
                {
                    dbContext.Shifts.RemoveRange(employee.Shifts);
                }

                // Remove all employees from the Employees table
                dbContext.Employees.RemoveRange(allEmployees);

                // Save changes to the database
                dbContext.SaveChanges();
            }
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
                    Shifts = new Collection<Shift>
                    {
                        new() { ShiftName = "Morning Shift" },
                        new() { ShiftName = "Evening Shift" }
                    }
                };

                context.Employees.Add(testEmployee);
                context.SaveChanges();

                // Reload data after adding the test employee
                Employees = databaseLoader.LoadData();
            }
        }
    }
}
