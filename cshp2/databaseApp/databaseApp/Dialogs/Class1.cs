using DatabaseApp.Database;
using DatabaseApp.ViewModel;

public class AddEmployeeForm : Form
{
    private readonly AddEmployeeViewModel _viewModel;

    public AddEmployeeForm()
    {
        InitializeComponent();

        _viewModel = new AddEmployeeViewModel();

        // Populate Addresses and Jobs (replace these with your data)
        _viewModel.Addresses = GetAddresses();

        // Bind data to ComboBoxes
        addressComboBox.DataSource = _viewModel.Addresses;
        addressComboBox.DisplayMember = "AddressName";

        jobComboBox.DataSource = _viewModel.EmployeeType;
        jobComboBox.DisplayMember = "JobName";
    }

    private List<Address> GetAddresses()
    {
        // Implement logic to get addresses from your data source
        return new List<Address> { /* Populate with addresses */ };
    }

    // Handle Save button click event
    private void saveButton_Click(object sender, EventArgs e)
    {
        _viewModel.FirstName = firstNameTextBox.Text;
        _viewModel.LastName = lastNameTextBox.Text;

        _viewModel.SaveEmployee();

        // Close the form or perform other actions as needed
        Close();
    }
}
