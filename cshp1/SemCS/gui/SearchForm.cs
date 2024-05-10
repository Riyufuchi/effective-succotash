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
    public partial class SearchForm : Form
    {
        public string? Filter { get; private set; }
        public string? Value { get; private set; }
        public string TableName { get; private set; }

        public SearchForm(string tableName, List<string> filters)
        {
            InitializeComponent();
            comboBox1.DataSource = filters;
            TableName = tableName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                Controller.ErrorDialog("Invalid input!");
                return;
            }
            Filter = comboBox1.SelectedItem as string;
            Value = textBox1.Text;
            Dispose();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
