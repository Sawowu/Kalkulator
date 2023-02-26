using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Rownoleglobok
    {
        public double a { get; private set; }
        public double b { get; private set; }
        public double h { get; private set; }

        public Rownoleglobok(double a, double b, double h)
        {
            this.a = a;
            this.b = b;
            this.h = h;
        }

        public double Obwod()
        {
            return (2 * a) + (2 * b);
        }
        public double Pole()
        {
            return a * h;
        }
    }
}
