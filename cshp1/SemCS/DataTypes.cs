using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SemCS
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string LicensePlate { get; set; }
        public string Brand { get; set; }
        public int SeatCount { get; set; }
        public int GarageId { get; set; }
        public Garage Garage { get; set; }

       // public Vehicle() { }

        public Vehicle(string licensePlate, string brand, int seatCount, int garageId, Garage garage)
        {
            LicensePlate = licensePlate;
            Brand = brand;
            SeatCount = seatCount;
            GarageId = garageId;
            this.Garage = garage;
        }
    }

    public class Driver
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Salary { get; set; }
        public int HomeBase { get; set; }
        public Garage HomeBaseGarage { get; set; }

        //public Driver() { }

        public Driver(string firstName, string lastName, int salary, int homeBase, Garage HomeBaseGarage)
        {
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
            HomeBase = homeBase;
            this.HomeBaseGarage = HomeBaseGarage;
        }
    }

    public class AssociationTable
    {
        public int DriverId { get; set; }
        public int VehicleId { get; set; }

        public AssociationTable() { }

        public AssociationTable(int driverId, int vehicleId)
        {
            DriverId = driverId;
            VehicleId = vehicleId;
        }
    }

    public class Address
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }

        // public Address() { }

        public Address(int id, string city, string street, int houseNumber)
        {
            Id = id;
            City = city;
            Street = street;
            HouseNumber = houseNumber;
        }

        public Address(string city, string street, int houseNumber)
        {
            City = city;
            Street = street;
            HouseNumber = houseNumber;
        }
    }

    public class Garage
    {
        public int Id { get; set; }
        public int Capacity { get; set; }
        public int FreeSpots { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }

       // public Garage() { }

        public Garage(int capacity, int freeSpots, int addressId, Address Address)
        {
            Capacity = capacity;
            FreeSpots = freeSpots;
            this.Address = Address;
            AddressId = addressId;
        }
    }

}
