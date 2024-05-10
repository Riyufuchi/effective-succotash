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

        public VehicleForm(List<Garage> garages, Vehicle? vehicle)
        {
            InitializeComponent();
            Vehicle = vehicle;
            this.comboBox1.DataSource = garages;
            if (vehicle != null)
            {
            }
            else
            {
                button1.Text = "Add";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Vehicle != null)
            {

            }
            else
            {
                
            }
        }
    }
}
