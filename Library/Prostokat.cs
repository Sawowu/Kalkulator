using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Prostokat
    {
        public double a { get; private set; }
        public double b { get; private set; }
        public Prostokat(double a, double b)
        {
            this.a = a;
            this.b = b;
        }
        public double Przekatna()
        {
            return Math.Round(Math.Sqrt(a * a + b * b), 6);
        }
        public double Obwod()
        {
            return (2 * a) + (2 * b);
        }
        public double Pole()
        {
            return a * b;
        }
    }
}
