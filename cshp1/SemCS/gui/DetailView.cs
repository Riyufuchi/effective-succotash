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
    public partial class DetailView : Form
    {
        private DataSet dataSet;

        public DetailView(DataSet dataSet)
        {
            InitializeComponent();
            this.dataSet = dataSet;
            dataGridView1.DataSource = dataSet.Tables[0];
            dataGridView1.Columns[0].Visible = false;
            if (dataSet.Tables[0].Rows.Count == 0)
            {
                Controller.WarningDialog("Nebyla nalezana žádná data podle zadaných kritérií.");
            }
        }
    }
}
