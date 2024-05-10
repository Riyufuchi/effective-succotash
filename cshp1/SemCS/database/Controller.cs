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
        public Controller()
        {
           
        }

        public static void WarningDialog(string message)
        {
            MessageBox.Show(message, "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void SuccesDialog(string message)
        {
           MessageBox.Show(message, "Uspesna operace", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ErrorDialog(string message)
        {
            MessageBox.Show(message, "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
