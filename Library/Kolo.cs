using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Kolo
    {
        public Kolo(double r)
        {
            this.r = r;
        }
        public double r { get; private set; }
        public double Obwod()
        {
            return Math.Round(this.r*2*Math.PI, 6);
        }
        public double Pole()
        {
            return Math.Round(Math.Pow(this.r, 2) * Math.PI, 6);
        }
    }
}
