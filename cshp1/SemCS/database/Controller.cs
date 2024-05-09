using SemCS.gui;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemCS
{
    public class Controller
    {
        private Garage? garageBuffer;

        public Controller()
        {
            this.garageBuffer = null;
        }

        public static void SuccesDialog(string message)
        {
           MessageBox.Show(message, "Uspesna operace", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ErrorDialog(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /*public Garage GarageDialog(DataTable dataTable, Garage garage)
        {
            GarageForm gd = new GarageForm(dataTable, garage);
            gd.ShowDialog(); 
        }*/
    }
}
