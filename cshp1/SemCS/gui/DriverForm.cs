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
    public partial class DriverForm : Form
    {
        public Driver? Driver { get; private set; }
        public bool Remove { get; private set; }
        private Database db;
        private List<Garage> garages;
        private List<List<Vehicle>> vehicles;

        public DriverForm(Driver? driver, Database db, List<Garage> garages, List<List<Vehicle>> vehicles)
        {
            InitializeComponent();
            Driver = driver;
            Remove = false;
            this.garages = garages;
            this.vehicles = vehicles;
            this.db = db;
            if (driver != null)
            {
                button1.Text = "Edit";
                numericUpDown1.Value = Driver.Salary;
                comboBox1.SelectedItem = Driver.Vehicle;
                textBox1.Text = Driver.FirstName;
                textBox2.Text = Driver.LastName;
                comboBox2.SelectedItem = Driver.HomeBaseGarage;
            }
            else
            {
                button1.Text = "Add";
            }
            
            comboBox1.DataSource = garages;
            comboBox1.SelectedIndex = 0;
            comboBox2.DataSource = vehicles[0];
            comboBox2.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Remove = true;
            Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1.Text) || string.IsNullOrEmpty(comboBox2.Text))
            {
                Controller.ErrorDialog("Neplatný vstup!");
                return;
            }
            Garage garage = comboBox1.SelectedItem as Garage;
            Vehicle vehicle = comboBox2.SelectedItem as Vehicle;
            if (Driver != null)
            {
                Driver.Salary = (int)numericUpDown1.Value;
                Driver.VehicleId = vehicle.Id;
                Driver.Vehicle = vehicle;
                Driver.FirstName = textBox1.Text;
                Driver.LastName = textBox2.Text;
                Driver.HomeBase = garage.Id;
                Driver.HomeBaseGarage = garage;
            }
            else
            {
                Driver = new Driver(textBox1.Text, textBox2.Text, (int)numericUpDown1.Value, garage.Id, vehicle.Id, garage, vehicle);
            }
            Dispose();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.DataSource = vehicles[comboBox1.SelectedIndex];
        }
    }
}
