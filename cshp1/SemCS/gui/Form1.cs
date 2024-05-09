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
            db.LoadVehicles(dataSet);
            dataGridView3.DataSource = dataSet.Tables[2];
            dataGridView3.Columns[0].Visible = false;
            db.LoadDrivers(dataSet);
            dataGridView4.DataSource = dataSet.Tables[3];
            dataGridView4.Columns[0].Visible = false;
            adressBuffer = null;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

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
                    dataSet.Tables[0].Rows.Clear();
                    db.LoadAdresses(dataSet);
                    dataGridView1.Refresh();
                }
            }
        }



        private void addAdressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdressForm af = new AdressForm(null);
            af.ShowDialog(this);
            adressBuffer = af.Address;
            if (adressBuffer != null)
            {
                db.AddAddress(adressBuffer);
                MessageBox.Show("Pridano uspesne");
            }
        }
    }
}
