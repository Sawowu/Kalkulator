using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    internal class Kolo
    {
        public Kolo(double r)
        {
            this.r = r;
        }
        public double r { get; private set; }
        public double obwod()
        {
            return this.r*2*Math.PI;
        }
        public double pole()
        {
            return Math.Pow(this.r, 2) * Math.PI;
        }
    }
}
