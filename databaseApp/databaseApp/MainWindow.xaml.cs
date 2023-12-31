using DatabaseApp.Controller;
using DatabaseApp.Database;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DatabaseApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ControllerDB controller;

        public MainWindow()
        {
            InitializeComponent();
            controller = new ControllerDB();
            DataContext = controller;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Delete_Employees(object sender, RoutedEventArgs e)
        {
            controller.DeleteEmployees();
        }

        private void AddEmployee(object sender, RoutedEventArgs e)
        {

        }

        private void EditEmployee(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteEmployee(object sender, RoutedEventArgs e)
        {

        }
    }
}