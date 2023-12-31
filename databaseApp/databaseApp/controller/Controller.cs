﻿using DatabaseApp.Database;
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
        //private readonly DatabaseLoader databaseLoader;
        public ObservableCollection<Employee> Employees { get; set; }
        public ObservableCollection<Shift> Shifts { get; set; }
        public ObservableCollection<Address> Addresses { get; set; }

        public ControllerDB()
        {
            //databaseLoader = new DatabaseLoader();
            Employees = DatabaseLoader.LoadData();
            Shifts = DatabaseLoader.LoadShifts();
            Addresses = DatabaseLoader.LoadAddresses();
        }

        // Tahle to prozatim staci
        public void RefreshDataGrid()
        {
            Employees.Clear();
            Shifts.Clear();
            Addresses.Clear();
            using (var dbContext = new AppDbContext())
            {
                var employees = dbContext.Employees.ToList();
                var shifts = dbContext.Shifts.ToList();
                var addresses = dbContext.Addresses.ToList();

                foreach (var employee in employees)
                {
                    Employees.Add(employee);
                }
                foreach (var data in shifts)
                {
                    Shifts.Add(data);
                }
                foreach (var data in addresses)
                {
                    Addresses.Add(data);
                }
            }
        }

        public void DeleteEmployees()
        {
            using (var dbContext = new AppDbContext())
            {
                var allEmployees = dbContext.Employees.Include(e => e.Shifts).ToList();
                foreach (var employee in allEmployees)
                {
                    dbContext.Shifts.RemoveRange(employee.Shifts);
                }
                dbContext.Employees.RemoveRange(allEmployees);
                dbContext.SaveChanges();
            }
            RefreshDataGrid();
        }

        public void AddDummyEmployee()
        {
            using (var context = new AppDbContext())
            {
                var shift = new Shift()
                {
                    ShiftName = "Obědová"
                };
                var address = new Address
                {
                    Street = "123 Main St",
                    City = "Anytown",
                    State = "CA",
                    ZipCode = "12345"
                };
                var testEmployee = new Employee
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Type = EmployeeType.Waiter,
                    Address = address,
                    Shifts = new Collection<Shift>
                    {
                        shift
                    }
                };
                shift.Employees.Add(testEmployee);

                context.Employees.Add(testEmployee);
                context.Shifts.Add(shift);
                context.Addresses.Add(address);
                context.SaveChanges();
            }
            RefreshDataGrid();
        }
    }
}
