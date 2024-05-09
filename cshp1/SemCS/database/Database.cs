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
    internal class Database
    {
        private string connectionString;
        private string dbPath = "data.sqlite";
        public SQLiteConnection Connection { get; }
        private SQLiteCommand sql_cmd;
        private SQLiteDataAdapter adapter;

        public Database()
        {
            connectionString = $"Data Source={dbPath};Version=3;";
            InitializeDatabase();
            Connection = new SQLiteConnection(connectionString);
            //Adapter = new SQLiteDataAdapter(Connection.CreateCommand());
        }

        public void LoadAdresses(DataSet dataSet)
        {
            Connection.Open();
            adapter = new SQLiteDataAdapter(Connection.CreateCommand());
            adapter.SelectCommand.CommandText = @"SELECT * from Adresa";
            adapter.Fill(dataSet, "Adresa");
            Connection.Close();
        }
        
        #region Load

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
                                reader["Ulice"].ToString(), Convert.ToInt32(reader["CP"]));
                        }
                    }
                }
            }

            return null; // Address with the specified ID not found
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
                                reader["Ulice"].ToString(), Convert.ToInt32(reader["CP"])));
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
                                Convert.ToInt32(reader["VolnaMista"]), address.Id, address);;
                        }
                    }
                }
            }

            return null;
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
                FOREIGN KEY (HomeBase) REFERENCES Garaz(Id)
                );",
                @"
                CREATE TABLE IF NOT EXISTS SpojovaTabulka (
                RidicId INTEGER NOT NULL,
                VozidloId INTEGER NOT NULL,
                FOREIGN KEY (RidicId) REFERENCES Ridic(Id),
                FOREIGN KEY (VozidloId) REFERENCES Vozidlo(Id),
                PRIMARY KEY (RidicId, VozidloId)
                );",
                @"
                CREATE TABLE IF NOT EXISTS Adresa (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Mesto TEXT NOT NULL,
                Ulice TEXT NOT NULL,
                CP INTEGER NOT NULL
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
