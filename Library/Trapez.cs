using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Trapez
    {
        public double a { get; private set; }
        public double b { get; private set; }
        public double c { get; private set; }
        public double h { get; private set; }

        public Trapez(double a, double b, double c, double h)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.h = h;
        }

        public double Obwod()
        {
            return a + c + (2 * b);
        }
        public double Pole()
        {
            return (a + b) * h / 2;
        }
    }
}
