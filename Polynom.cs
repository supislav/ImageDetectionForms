using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drum
{
    internal class Polynom
    {
        private double a;
        private double b;
        private double c;

        public Polynom(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public double A
        {
            get { return a; }
            set { a = value; }
        }

        public double B
        {
            get { return b; }
            set { b = value; }
        }

        public double C
        {
            get { return c; }
            set { c = value; }
        }

        public override string ToString()
        {
            return $"{a}x^2 + {b}x + {c}";
        }

        // Show a message box with polinom function
        public void Show()
        {
            MessageBox.Show($"Polynom: y = {a:F4}x^2 + {b:F4}x + {c:F4}"); // :F4 - 4 decimal places
        }

    }
}
