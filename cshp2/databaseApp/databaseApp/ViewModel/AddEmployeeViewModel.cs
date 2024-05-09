using DatabaseApp.Database;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace DatabaseApp.ViewModel
{
    public class AddEmployeeViewModel
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public List<Address> Addresses { get; set; } = new List<Address>();
        public EmployeeType[] EmployeeType { get; set; } = (EmployeeType[])Enum.GetValues(typeof(EmployeeType));

        public Address? electedAddress { get; set; }
        public EmployeeType SelectedJob { get; set; }

        public void SaveEmployee()
        {
            // Implement logic to save the employee with selected address and job
            // You can access FirstName, LastName, SelectedAddress, and SelectedJob here
        }
    }

}
