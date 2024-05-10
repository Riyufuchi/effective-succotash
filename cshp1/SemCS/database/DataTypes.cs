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
        public int Id { get; private set; }
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

        public Vehicle(int id, string licensePlate, string brand, int seatCount, int garageId, Garage garage)
        {
            Id = id;
            LicensePlate = licensePlate;
            Brand = brand;
            SeatCount = seatCount;
            GarageId = garageId;
            this.Garage = garage;
        }

        public override string ToString()
        {
            return LicensePlate + " " + Brand + " " + SeatCount;
        }
    }

    public class Driver
    {
        public int Id { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Salary { get; set; }
        public int HomeBase { get; set; }
        public int VehicleId { get; set; }
        public Garage HomeBaseGarage { get; set; }
        public Vehicle Vehicle { get; set; }

        //public Driver() { }

        public Driver(string firstName, string lastName, int salary, int homeBase, int vehicleId, Garage HomeBaseGarage, Vehicle vehicle)
        {
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
            HomeBase = homeBase;
            VehicleId = vehicleId;
            this.HomeBaseGarage = HomeBaseGarage;
            Vehicle = vehicle;
        }

        public Driver(int id, string firstName, string lastName, int salary, int homeBase, int vehicleId, Garage HomeBaseGarage, Vehicle vehicle)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
            HomeBase = homeBase;
            VehicleId = vehicleId;
            this.HomeBaseGarage = HomeBaseGarage;
            Vehicle = vehicle;
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
        public int Id { get; private set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }

        // public Address() { }

        public Address(string city, string street, string houseNumber)
        {
            City = city;
            Street = street;
            HouseNumber = houseNumber;
        }

        public Address(int id, string city, string street, string houseNumber)
        {
            Id = id;
            City = city;
            Street = street;
            HouseNumber = houseNumber;
        }

        public override string ToString()
        {
            return City + " " + Street + " " + HouseNumber;
        }
    }

    public class Garage
    {
        public int Id { get; private set; }
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

        public Garage(int id, int capacity, int freeSpots, int addressId, Address Address)
        {
            Id = id;
            Capacity = capacity;
            FreeSpots = freeSpots;
            this.Address = Address;
            AddressId = addressId;
        }

        public override string ToString()
        {
            return Capacity + "/" + FreeSpots + " " + Address.ToString();
        }
    }

}
