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

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

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
                if (adressBuffer != null)
                {
                    db.UpdateAddress(adressBuffer);
                    Controller.SuccesDialog("Uspesně aktualizována data adresy");
                    RefreshAdresses();
                }
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow clickedRow = dataGridView1.Rows[e.RowIndex];

                GarageForm garageForm = new GarageForm(db.SelectAddress(), db.SelectGarage(Int32.Parse(clickedRow.Cells["Id"].Value.ToString())));
                garageForm.ShowDialog(this);
                garageBuffer = garageForm.Garage;
                if (garageBuffer != null)
                {
                    db.UpdateGarage(garageBuffer);
                    Controller.SuccesDialog("Uspesně aktualizována data garaze");
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

        private void windowToolStripMenuItem_Click(object sender, EventArgs e)
        {

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
    }
}
