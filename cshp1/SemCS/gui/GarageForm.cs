﻿using SemCS.database;
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
    public partial class GarageForm : Form
    {
        public Garage? Garage { get; private set; }
        public bool Delete { get; private set; }

        public GarageForm(List<Address> addresses, Garage? garage)
        {
            InitializeComponent();
            comboBoxAdresa.DataSource = addresses;
            comboBoxAdresa.SelectedIndex = 0;
            Garage = garage;
            Delete = false;
            numericUpDownVolnaMista.Enabled = false;
            if (garage != null)
            {
                button1.Text = "Edit";
                numericUpDownKapacita.Value = garage.Capacity;
                numericUpDownVolnaMista.Value = garage.FreeSpots;
                comboBoxAdresa.SelectedItem = garage.Address;
            }
            else
            {
                button1.Text = "Add";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Garage != null)
            {
                if (numericUpDownKapacita.Value - numericUpDownVolnaMista.Value < numericUpDownVolnaMista.Value)
                    Controller.ErrorDialog("Nelze mít počet míst menší než je počet vozidel v garáži!");
                Garage.Capacity = (int)numericUpDownKapacita.Value;
                Garage.FreeSpots = (int)numericUpDownVolnaMista.Value;
                Garage.Address = comboBoxAdresa.SelectedItem as Address;
                Garage.AddressId = Garage.Address.Id;
            }
            else
            {
                Garage = new Garage((int)numericUpDownKapacita.Value, (int)numericUpDownKapacita.Value, (comboBoxAdresa.SelectedItem as Address).Id, comboBoxAdresa.SelectedItem as Address);
            }
            Dispose();
        }

        private void numericUpDownKapacita_ValueChanged(object sender, EventArgs e)
        {
            if (Garage == null)
                numericUpDownVolnaMista.Value = numericUpDownKapacita.Value;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Delete = true;
            Dispose();
        }
    }
}
