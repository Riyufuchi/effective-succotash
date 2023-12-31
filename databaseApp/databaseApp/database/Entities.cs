using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseApp.Database
{
    internal class Entities
    {
    }

    // Employee.cs
    public class Employee
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }

        // Navigation property for the address
        public int AddressId { get; set; }
        public required Address Address { get; set; }

        // Navigation property for the shift
        public int ShiftId { get; set; }
        public required Shift Shift { get; set; }
    }

    // Address.cs
    public class Address
    {
        public int Id { get; set; }
        public required string Street { get; set; }
        public required string City { get; set; }
        public required string State { get; set; }
        public required string ZipCode { get; set; }

        // Navigation property for employees
        public ICollection<Employee>? Employees { get; set; }
    }

    // Example: Shift.cs
    public class Shift
    {
        public int Id { get; set; }
        public required string ShiftName { get; set; }

        // Navigation property for employees
        public ICollection<Employee>? Employees { get; set; }
    }
}
