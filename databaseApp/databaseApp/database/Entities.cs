﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseApp.Database
{
    public enum EmployeeType
    {
        Cheff,
        Waiter,
        Cleaner
    }

    internal class Entities
    {
    }

    public class Employee
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required EmployeeType Type { get; set; }

        // Navigation property for the address
        public int AddressId { get; set; }
        public required Address Address { get; set; }

        // Navigation property for the shifts
        public ICollection<Shift> Shifts { get; set; } = new List<Shift>();
    }

    public class Address
    {
        public int Id { get; set; }
        public required string Street { get; set; }
        public required string City { get; set; }
        public required string State { get; set; }
        public required string ZipCode { get; set; }

        // Navigation property for employees
        public ICollection<Employee>? Employees { get; set; }

        public override string ToString()
        {
            return $"{Street} {City} {State} {ZipCode}";
        }
    }

    public class Shift
    {
        public int Id { get; set; }
        public required string ShiftName { get; set; }

        // Navigation property for employees
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
