using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SemCS.gui
{
    public partial class VehicleForm : Form
    {
        public Vehicle? Vehicle { get; private set; }
        public Garage? Garage { get; private set; }

        public VehicleForm(List<Garage> garages, Vehicle? vehicle)
        {
            InitializeComponent();
            Vehicle = vehicle;
            this.comboBox1.DataSource = garages;
            if (vehicle != null)
            {
                textBox1.Text = Vehicle.LicensePlate;
                textBox2.Text = Vehicle.Brand;
                numericUpDown1.Value = Vehicle.SeatCount;
                comboBox1.SelectedItem = Vehicle.Garage;
                Garage = Vehicle.Garage;
                button1.Text = "Edit";
            }
            else
            {
                button1.Text = "Add";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                Controller.ErrorDialog("Neplatná data!");
                return;
            }

            if (Vehicle != null)
            {
                Vehicle.LicensePlate = textBox1.Text;
                Vehicle.SeatCount = (int)numericUpDown1.Value;
                Vehicle.Brand = textBox2.Text;
                Vehicle.Garage = comboBox1.SelectedItem as Garage;
                Vehicle.GarageId = Vehicle.Garage.Id;
            }
            else
            {
                Vehicle = new Vehicle(textBox1.Text, textBox2.Text, (int)numericUpDown1.Value,
                    (comboBox1.SelectedItem as Garage).Id, comboBox1.SelectedItem as Garage);
            }
            Dispose();
        }
    }
}
