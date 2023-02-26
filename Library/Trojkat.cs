using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Trojkat
    {
        public double a { get; private set; }
        public double b { get; private set; }
        public double c { get; private set; }
        public double h { get; private set; }

        public Trojkat(double a, double b, double c, double h)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.h = h;
        }
        public double Obwod()
        {
            return a + b + c;
        }
        public double Pole()
        {
            if (a == c)
            {
                return Math.Round(b / 2 * h, 6);
            }
            if(a == b)
            {
                return Math.Round(c / 2 * h, 6);
            }
            return Math.Round(a / 2 * h, 6);
        }
    }
}
