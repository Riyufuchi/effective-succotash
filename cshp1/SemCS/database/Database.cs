using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data;
using System.Security.Cryptography;
using System.Drawing;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SemCS
{
    public class Database
    {
        private string connectionString;
        private string dbPath = "data.sqlite";
        public SQLiteConnection Connection { get; }
        private SQLiteDataAdapter adapter;

        public Database()
        {
            connectionString = $"Data Source={dbPath};Version=3;";
            InitializeDatabase();
            Connection = new SQLiteConnection(connectionString);
        }

        #region Load

        public void Load(DataSet dataSet, string tableName, string filter, string value)
        {
            Connection.Open();
            adapter = new SQLiteDataAdapter(Connection.CreateCommand());
            // Use parameterized query to prevent SQL injection
            adapter.SelectCommand.CommandText = $"SELECT * FROM {tableName} WHERE {filter} = @Value";
            // Add parameter for the filter value
            adapter.SelectCommand.Parameters.AddWithValue("@Value", value);
            adapter.Fill(dataSet, tableName);
            Connection.Close();
        }


        public void LoadAdresses(DataSet dataSet)
        {
            Connection.Open();
            adapter = new SQLiteDataAdapter(Connection.CreateCommand());
            adapter.SelectCommand.CommandText = @"SELECT * from Adresa";
            adapter.Fill(dataSet, "Adresa");
            Connection.Close();
        }

        public void LoadGaranges(DataSet dataSet)
        {
            Connection.Open();
            adapter = new SQLiteDataAdapter(Connection.CreateCommand());
            adapter.SelectCommand.CommandText = @"SELECT * from Garaz";
            adapter.Fill(dataSet, "Garaz");
            Connection.Close();
        }

        public void LoadVehicles(DataSet dataSet)
        {
            Connection.Open();
            adapter = new SQLiteDataAdapter(Connection.CreateCommand());
            adapter.SelectCommand.CommandText = @"SELECT * from Vozidlo";
            adapter.Fill(dataSet, "Vozidlo");
            Connection.Close();
        }

        public void LoadDrivers(DataSet dataSet)
        {
            Connection.Open();
            adapter = new SQLiteDataAdapter(Connection.CreateCommand());
            adapter.SelectCommand.CommandText = @"SELECT * from Ridic";
            adapter.Fill(dataSet, "Ridic");
            Connection.Close();
        }
        #endregion

        #region Remove

        public void RemoveVehicle(Vehicle vehicle)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand("DELETE FROM Vozidlo WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", vehicle.Id);
                    if (command.ExecuteNonQuery() > 0)
                    {
                        UpdateGarage(vehicle.GarageId, 1);
                        RemoveDriver(vehicle);
                    }
                }
                connection.Close();
            }
        }

        public bool RemoveDriver(Driver driver)
        {
            bool result = false;
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand("DELETE FROM Ridic WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", driver.Id);
                    result = command.ExecuteNonQuery() > 0;
                }
                connection.Close();
            }
            return result;
        }

        public bool RemoveDriver(Vehicle vehicle)
        {
            bool result = false;
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand("DELETE FROM Ridic WHERE VozidloId = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", vehicle.Id);
                    result = command.ExecuteNonQuery() > 0;
                }
                connection.Close();
            }
            return result;
        }

        public void RemoveGarage(Garage garage)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand("DELETE FROM Garaz WHERE Id = @Id", connection))
                {
                    List<Vehicle> v = SelectVehicle();
                    foreach (Vehicle vehicle in v)
                    {
                        if (vehicle.GarageId == garage.Id)
                            RemoveVehicle(vehicle);
                    }
                    command.Parameters.AddWithValue("@Id", garage.Id);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void RemoveAdress(Address address)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand("DELETE FROM Adresa WHERE Id = @Id", connection))
                {
                    List<Garage> v = SelectGarages();
                    foreach (Garage g in v)
                    {
                        if (g.Address.Id == address.Id)
                            RemoveGarage(g);
                    }
                    command.Parameters.AddWithValue("@Id", address.Id);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        #endregion


        #region Add

        public void AddAddress(Address address)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var cmd = new SQLiteCommand("INSERT INTO Adresa (Mesto, Ulice, CP) VALUES (@Mesto, @Ulice, @CP)", connection);
                cmd.Parameters.AddWithValue("@Mesto", address.City);
                cmd.Parameters.AddWithValue("@Ulice", address.Street);
                cmd.Parameters.AddWithValue("@CP", address.HouseNumber);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void AddGarage(Garage garage)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var cmd = new SQLiteCommand("INSERT INTO Garaz (Kapacita, VolnaMista, AdresaId) VALUES (@Kapacita, @VolnaMista, @AdresaId)", connection);
                cmd.Parameters.AddWithValue("@Kapacita", garage.Capacity);
                cmd.Parameters.AddWithValue("@VolnaMista", garage.FreeSpots);
                cmd.Parameters.AddWithValue("@AdresaId", garage.Address.Id);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void AddVehicle(Vehicle vehicle)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var cmd = new SQLiteCommand("INSERT INTO Vozidlo (SPZ, Znacka, PocetMist, GarazId) VALUES (@SPZ, @Znacka, @PocetMist, @GarazId)", connection);
                cmd.Parameters.AddWithValue("@SPZ", vehicle.LicensePlate);
                cmd.Parameters.AddWithValue("@Znacka", vehicle.Brand);
                cmd.Parameters.AddWithValue("@PocetMist",vehicle.SeatCount);
                cmd.Parameters.AddWithValue("@GarazId", vehicle.Garage.Id);
                cmd.ExecuteNonQuery();
                UpdateGarage(vehicle.GarageId, -1);
                connection.Close();
            }
        }

        public void AddDriver(Driver driver)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var cmd = new SQLiteCommand("INSERT INTO Ridic (Jmeno, Prijmeni, Plat, HomeBase, VozidloId) VALUES (@Jmeno, @Prijmeni, @Plat, @HomeBase, @VozidloId)", connection);
                cmd.Parameters.AddWithValue("@Jmeno", driver.FirstName);
                cmd.Parameters.AddWithValue("@Prijmeni", driver.LastName);
                cmd.Parameters.AddWithValue("@Plat", driver.Salary);
                cmd.Parameters.AddWithValue("@HomeBase", driver.HomeBase);
                cmd.Parameters.AddWithValue("@VozidloId", driver.VehicleId);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        #endregion

        #region Update

        public void UpdateAddress(Address address)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string sql = "UPDATE Adresa SET Mesto = @City, Ulice = @Street, CP = @Number WHERE Id = @Id";

                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@City", address.City);
                    command.Parameters.AddWithValue("@Street", address.Street);
                    command.Parameters.AddWithValue("@Number", address.HouseNumber);
                    command.Parameters.AddWithValue("@Id", address.Id);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateGarage(int id, int value)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string sql = "UPDATE Garaz SET VolnaMista = VolnaMista + @value WHERE Id = @Id";

                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@value", value);
                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateDriver(Driver driver)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var cmd = new SQLiteCommand("UPDATE Ridic SET Jmeno = @Jmeno, Prijmeni = @Prijmeni, Plat = @Plat, HomeBase = @HomeBase, VozidloId = @VozidloId WHERE Id = @Id", connection);
                cmd.Parameters.AddWithValue("@Jmeno", driver.FirstName);
                cmd.Parameters.AddWithValue("@Prijmeni", driver.LastName);
                cmd.Parameters.AddWithValue("@Plat", driver.Salary);
                cmd.Parameters.AddWithValue("@HomeBase", driver.HomeBase);
                cmd.Parameters.AddWithValue("@VozidloId", driver.VehicleId);
                cmd.Parameters.AddWithValue("@Id", driver.Id);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }


        public void UpdateGarage(Garage garage)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string sql = "UPDATE Garaz SET Kapacita = @Kapacita, VolnaMista = @VolnaMista, AdresaId = @AdresaId WHERE Id = @Id";

                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Kapacita", garage.Capacity);
                    command.Parameters.AddWithValue("@VolnaMista", garage.FreeSpots);
                    command.Parameters.AddWithValue("@AdresaId", garage.AddressId);
                    command.Parameters.AddWithValue("@Id", garage.Id);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateVehicle(Vehicle vehicle)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string sql = "UPDATE Vozidlo SET SPZ = @SPZ, Znacka = @Znacka, PocetMist = @PocetMist, GarazId = @GarazId WHERE Id = @Id";

                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@SPZ", vehicle.LicensePlate);
                    command.Parameters.AddWithValue("@Znacka", vehicle.Brand);
                    command.Parameters.AddWithValue("@PocetMist", vehicle.SeatCount);
                    command.Parameters.AddWithValue("@GarazId", vehicle.GarageId);
                    command.Parameters.AddWithValue("@Id", vehicle.Id);
                    command.ExecuteNonQuery();
                }
            }
        }


        #endregion

        #region Select

        public Address? SelectAddress(int id)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM Adresa WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Address(Convert.ToInt32(reader["Id"]), reader["Mesto"].ToString(),
                                reader["Ulice"].ToString(), reader["CP"].ToString());
                        }
                    }
                }
            }

            return null; // Address with the specified ID not found
        }

        public Vehicle? SelectVehicle(int id)
        {
            Garage? garage = null;
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM Vozidlo WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            garage = SelectGarage(Convert.ToInt32(reader["GarazId"]));
                            return new Vehicle(Convert.ToInt32(reader["Id"]), reader["SPZ"].ToString(),
                                 reader["Znacka"].ToString(), Convert.ToInt32(reader["PocetMist"]), garage.Id, garage);                        }
                    }
                }
            }
            return null;
        }

        public List<Vehicle> SelectVehicle()
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            Garage? garage = null;
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM Vozidlo", connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            garage = SelectGarage(Convert.ToInt32(reader["GarazId"]));
                            vehicles.Add(new Vehicle(Convert.ToInt32(reader["Id"]), reader["SPZ"].ToString(),
                                 reader["Znacka"].ToString(), Convert.ToInt32(reader["PocetMist"]), garage.Id, garage));
                        }
                    }
                }
            }
            return vehicles;
        }

        public Driver? SelectDriver(int id)
        {
            Driver? driver = null;
            Vehicle? vehicle = null;
            Garage? garage = null;

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                var cmd = new SQLiteCommand("SELECT * FROM Ridic WHERE Id = @Id", connection);
                cmd.Parameters.AddWithValue("@Id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        garage = SelectGarage(Convert.ToInt32(reader["HomeBase"]));
                        vehicle = SelectVehicle(Convert.ToInt32(reader["VozidloId"]));
                        driver = new Driver(Convert.ToInt32(reader["Id"]), reader["Jmeno"].ToString(), reader["Prijmeni"].ToString(),
                            Convert.ToInt32(reader["Plat"]), garage.Id, vehicle.Id, garage, vehicle);
                    }
                }
                connection.Close();
            }
            return driver;
        }


        public List<Vehicle> SelectVehicle(Garage garazId)
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            Garage? garage = garazId;
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM Vozidlo WHERE GarazId = @GarazId", connection))
                {
                    command.Parameters.AddWithValue("@GarazId", garazId.Id);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            vehicles.Add(new Vehicle(Convert.ToInt32(reader["Id"]), reader["SPZ"].ToString(),
                                 reader["Znacka"].ToString(), Convert.ToInt32(reader["PocetMist"]), garage.Id, garage));
                        }
                    }
                }
            }
            return vehicles;
        }

        public List<Address> SelectAddress()
        {
            List<Address> addresses = new List<Address>();
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM Adresa", connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            addresses.Add(new Address(Convert.ToInt32(reader["Id"]), reader["Mesto"].ToString(),
                                reader["Ulice"].ToString(), reader["CP"].ToString()));
                        }
                    }
                }
            }

            return addresses;
        }

        public Garage? SelectGarage(int id)
        {
            Address? address = null;
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM Garaz WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            address = SelectAddress(Convert.ToInt32(reader["AdresaId"]));
                            return new Garage(Convert.ToInt32(reader["Id"]), Convert.ToInt32(reader["Kapacita"]),
                                Convert.ToInt32(reader["VolnaMista"]), address.Id, address);
                        }
                    }
                }
            }
            return null;
        }

        public List<Garage> SelectGarages()
        {
            List<Garage> garages = new List<Garage>();
            Address? address = null;
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM Garaz", connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            address = SelectAddress(Convert.ToInt32(reader["AdresaId"]));
                            garages.Add(new Garage(Convert.ToInt32(reader["Id"]), Convert.ToInt32(reader["Kapacita"]),
                               Convert.ToInt32(reader["VolnaMista"]), address.Id, address));
                        }
                    }
                }
                connection.Close();
            }
            return garages;
        }

        public List<Garage> SelectFreeGarages()
        {
            List<Garage> garages = new List<Garage>();
            Address? address = null;
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM Garaz WHERE VolnaMista > 0", connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            address = SelectAddress(Convert.ToInt32(reader["AdresaId"]));
                            garages.Add(new Garage(Convert.ToInt32(reader["Id"]), Convert.ToInt32(reader["Kapacita"]),
                               Convert.ToInt32(reader["VolnaMista"]), address.Id, address));
                        }
                    }
                }
                connection.Close();
            }
            return garages;
        }

        #endregion

        private void InitializeDatabase()
        {
            if (!File.Exists(dbPath))
            {
                SQLiteConnection.CreateFile(dbPath);
            }

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                var commands = new[]
                {
                @"
                CREATE TABLE IF NOT EXISTS Garaz (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Kapacita INTEGER NOT NULL,
                VolnaMista INTEGER NOT NULL,
                AdresaId INTEGER NOT NULL,
                FOREIGN KEY (AdresaId) REFERENCES Adresa(Id)
                );",
                @"
                CREATE TABLE IF NOT EXISTS Vozidlo (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                SPZ TEXT NOT NULL,
                Znacka TEXT NOT NULL,
                PocetMist INTEGER NOT NULL,
                GarazId INTEGER NOT NULL,
                FOREIGN KEY (GarazId) REFERENCES Garaz(Id)
                );",
                @"
                CREATE TABLE IF NOT EXISTS Ridic (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Jmeno TEXT NOT NULL,
                Prijmeni TEXT NOT NULL,
                Plat INTEGER NOT NULL,
                HomeBase INTEGER NOT NULL,
                VozidloId INTEGER NOT NULL,
                FOREIGN KEY (HomeBase) REFERENCES Garaz(Id),
                FOREIGN KEY (VozidloId) REFERENCES Vozidlo(Id)
                );",
                @"
                CREATE TABLE IF NOT EXISTS Adresa (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Mesto TEXT NOT NULL,
                Ulice TEXT NOT NULL,
                CP TEXT NOT NULL
                );"
               };

                foreach (var cmd in commands)
                {
                    using (var command = new SQLiteCommand(cmd, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                connection.Close();
            }
        }
    }
}
