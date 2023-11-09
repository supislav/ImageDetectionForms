using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drum
{
    internal class LinearFunction
    {
        public double K { get; set; }
        public double N { get; set; }

        public LinearFunction(double k, double n)
        {
            K = k;
            N = n;
        }

        // Show a message box with linear function, because othervise it would throw an error (who knows why :))
        public void Show()
        {
            MessageBox.Show($"Linear Function: y = {K:F4}x + {N:F4}"); // :F4 - 4 decimal places
        }
    }

}
