using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Kwadrat
    {
        public double a { get; private set; }
        public Kwadrat(double a)
        {
            this.a = a;
        }
        public double Przekatna()
        {
            return Math.Round(a * Math.Sqrt(2), 6);
        }
        public double Obwod()
        {
            return 4 * a;
        }
        public double Pole()
        {
            return a * a;
        }
    }
}
