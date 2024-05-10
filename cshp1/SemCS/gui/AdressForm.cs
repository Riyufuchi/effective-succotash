using System;
using System.Windows.Forms;

namespace SemCS
{
    public partial class AdressForm : Form
    {
        public Address? Address { get; private set; }

        public AdressForm(Address? address)
        {
            InitializeComponent();
            Address = address;
            if (address != null)
            {
                // If editing an existing address, set button text to "Edit"
                button1.Text = "Edit";
                // Populate text boxes with existing address data
                textBoxCity.Text = address.City;
                textBoxStreet.Text = address.Street;
                textBoxNumber.Text = address.HouseNumber;
            }
            else
            {
                // If adding a new address, set button text to "Add"
                button1.Text = "Add";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Validate input fields
            if (string.IsNullOrWhiteSpace(textBoxCity.Text) || string.IsNullOrWhiteSpace(textBoxStreet.Text)
                || string.IsNullOrWhiteSpace(textBoxNumber.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // If everything is valid, create or update the address object
            if (Address == null)
            {
                // If adding a new address
                Address = new Address(textBoxCity.Text, textBoxStreet.Text, textBoxNumber.Text);
            }
            else
            {
                // If editing an existing address
                Address.City = textBoxCity.Text;
                Address.Street = textBoxStreet.Text;
                Address.HouseNumber = textBoxNumber.Text;
            }

            // Close the form
            this.Close();
        }
    }
}
