using SemCS.gui;
using System;
using System.Data;
using System.Security.Cryptography;

namespace SemCS
{
    public partial class Form1 : Form
    {
        private DataSet dataSet;
        private Database db;
        private Address? adressBuffer;
        private Garage? garageBuffer;
        private Vehicle? vehicleBuffer;
        private Driver? driverBuffer;

        public Form1()
        {
            InitializeComponent();

            this.db = new Database();
            dataSet = new DataSet();
            // Adresy
            db.LoadAdresses(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // Garaze
            db.LoadGaranges(dataSet);
            dataGridView2.DataSource = dataSet.Tables[1];
            dataGridView2.Columns[0].Visible = false;
            dataGridView2.CellClick += dataGridView2_CellClick;
            // Vozidla
            db.LoadVehicles(dataSet);
            dataGridView3.DataSource = dataSet.Tables[2];
            dataGridView3.Columns[0].Visible = false;
            dataGridView3.CellClick += dataGridView3_CellClick;
            // Ridici
            db.LoadDrivers(dataSet);
            dataGridView4.DataSource = dataSet.Tables[3];
            dataGridView4.Columns[0].Visible = false;
            dataGridView4.CellClick += dataGridView4_CellClick;
            //
            adressBuffer = null;
        }

        private void RefreshVehicles()
        {
            dataSet.Tables[2].Rows.Clear();
            db.LoadVehicles(dataSet);
            dataGridView3.Refresh();
        }

        private void RefreshGarages()
        {
            dataSet.Tables[1].Rows.Clear();
            db.LoadGaranges(dataSet);
            dataGridView2.Refresh();
        }

        private void RefreshAdresses()
        {
            dataSet.Tables[0].Rows.Clear();
            db.LoadAdresses(dataSet);
            dataGridView1.Refresh();
        }

        private void RefreshDrivers()
        {
            dataSet.Tables[3].Rows.Clear();
            db.LoadDrivers(dataSet);
            dataGridView4.Refresh();
        }

        #region Edits

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow clickedRow = dataGridView1.Rows[e.RowIndex];

                AdressForm af = new AdressForm(db.SelectAddress(Int32.Parse(clickedRow.Cells["Id"].Value.ToString())));
                af.ShowDialog(this);
                adressBuffer = af.Address;
                if (af.Remove)
                {
                    db.RemoveAdress(af.Address);
                    RefreshAdresses();
                    RefreshDrivers();
                    RefreshGarages();
                    RefreshVehicles();
                }
                if (adressBuffer != null)
                {
                    db.UpdateAddress(adressBuffer);
                    RefreshAdresses();
                }
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow clickedRow = dataGridView2.Rows[e.RowIndex];

                GarageForm garageForm = new GarageForm(db.SelectAddress(), db.SelectGarage(Int32.Parse(clickedRow.Cells["Id"].Value.ToString())));
                garageForm.ShowDialog(this);
                if (garageForm.Delete)
                {
                    db.RemoveGarage(garageForm.Garage);
                    RefreshGarages();
                    RefreshVehicles();
                    return;

                }
                garageBuffer = garageForm.Garage;
                if (garageBuffer != null)
                {
                    db.UpdateGarage(garageBuffer);
                    RefreshGarages();
                }
            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow clickedRow = dataGridView3.Rows[e.RowIndex];

                List<Garage> garages = db.SelectFreeGarages();
                VehicleForm vf = new VehicleForm(garages, db.SelectVehicle(Int32.Parse(clickedRow.Cells["Id"].Value.ToString())));
                vf.ShowDialog(this);
                if (vf.Delete)
                {
                    db.RemoveVehicle(vf.Vehicle);
                    RefreshVehicles();
                    RefreshGarages();
                    return;
                }
                garageBuffer = vf.Garage;
                vehicleBuffer = vf.Vehicle;
                if (vehicleBuffer != null)
                {
                    db.UpdateVehicle(vehicleBuffer);
                    if (garageBuffer.Id != vehicleBuffer.GarageId)
                    {
                        db.UpdateGarage(garageBuffer.Id, 1);
                        db.UpdateGarage(vehicleBuffer.GarageId, -1);
                    }

                    RefreshVehicles();
                    RefreshGarages();
                }
            }
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow clickedRow = dataGridView4.Rows[e.RowIndex];

                DriverForm? df = CreateDriverForm(db.SelectDriver(Int32.Parse(clickedRow.Cells["Id"].Value.ToString())));
                if (df == null)
                    return;
                df.ShowDialog(this);
                driverBuffer = df.Driver;
                if (df.Remove)
                {
                    db.RemoveDriver(driverBuffer);
                    RefreshDrivers();
                    return;
                }
                driverBuffer = df.Driver;
                if (driverBuffer != null)
                {
                    db.UpdateDriver(driverBuffer);
                    RefreshDrivers();
                }
            }
        }

        #endregion

        private void addAdressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdressForm af = new AdressForm(null);
            af.ShowDialog(this);
            adressBuffer = af.Address;
            if (adressBuffer != null)
            {
                db.AddAddress(adressBuffer);
                MessageBox.Show("Pridano uspesne");
                RefreshAdresses();
            }
        }

        private void addGarangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataSet.Tables[0].Rows.Count == 0)
            {
                Controller.ErrorDialog("V dabatazi nejsou žádné adresy!\nPřidejte nejříve alespoň jednu adresu.");
                return;
            }
            GarageForm garageForm = new GarageForm(db.SelectAddress(), null);
            garageForm.ShowDialog(this);
            garageBuffer = garageForm.Garage;
            if (garageBuffer != null)
            {
                db.AddGarage(garageBuffer);
                MessageBox.Show("Pridano uspesne");
                RefreshGarages();
            }
        }

        private void addVehicleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Garage> garages = db.SelectFreeGarages();
            if (garages.Count == 0)
            {
                Controller.ErrorDialog("V databazi nejsou žádné volné garáže!");
                return;
            }
            VehicleForm vf = new VehicleForm(garages, null);
            vf.ShowDialog(this);
            vehicleBuffer = vf.Vehicle;
            if (vehicleBuffer != null)
            {
                db.AddVehicle(vehicleBuffer);
                RefreshVehicles();
                RefreshGarages();

            }
        }

        private DriverForm? CreateDriverForm(Driver? driver)
        {
            List<Garage> garages = db.SelectGarages();
            if (garages.Count == 0)
            {
                Controller.ErrorDialog("V databazi nejsou garaze");
                return null;
            }
            List<List<Vehicle>> vehicles = new List<List<Vehicle>>();
            foreach (Garage garage in garages)
                vehicles.Add(db.SelectVehicle(garage));
            List<Garage> garages1 = new List<Garage>();
            List<List<Vehicle>> vehicles1 = new List<List<Vehicle>>();
            for (int i = 0; i < garages.Count; i++)
            {
                if (vehicles[i].Count != 0)
                {
                    garages1.Add(garages[i]);
                    vehicles1.Add(vehicles[i]);
                }
            }
            if (garages1.Count == 0)
            {
                Controller.ErrorDialog("V databazi nejsou vozidla");
                return null;
            }

            return new DriverForm(driver, db, garages1, vehicles1);
        }

        private void addDriverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DriverForm? df = CreateDriverForm(null);
            if (df == null)
                return;
            df.ShowDialog(this);
            driverBuffer = df.Driver;
            if (driverBuffer != null)
            {
                db.AddDriver(driverBuffer);
                RefreshDrivers();
            }
        }

        private void DetailView(string tableName, DataGridView dgv)
        {
            if (dataSet.Tables[0].Rows.Count == 0)
            {
                Controller.ErrorDialog("V dabatazi nejsou žádné adresy!\nPřidejte nejříve alespoň jednu adresu.");
                return;
            }
            List<string> list = new List<string>();
            for (int i = 1; i < dgv.Columns.Count; i++)
            {
                list.Add(dgv.Columns[i].HeaderText);
            }
            SearchForm sf = new SearchForm(tableName, list);
            sf.ShowDialog(this);
            DataSet ds = new DataSet();
            if (sf.Filter == null || sf.Value == null)
                return;
            db.Load(ds, sf.TableName, sf.Filter, sf.Value);
            DetailView dv = new DetailView(ds);
            dv.ShowDialog(this);
        }

        private void ridicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DetailView("Ridic", dataGridView4);
        }

        private void adresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DetailView("Adresa", dataGridView1);
        }

        private void garazToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DetailView("Garaz", dataGridView2);
        }

        private void vozidloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DetailView("Vozidlo", dataGridView3);
        }
    }
}
