using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemCS
{
    public class Controller
    {
        public static void SuccesDialog(string message)
        {
           MessageBox.Show(message, "Uspesna operace", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
