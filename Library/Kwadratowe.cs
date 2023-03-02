using System.Transactions;

namespace Library
{
    public class Kwadratowe
    {
        public Kwadratowe(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        public double a { get; private set; }
        public double b { get; private set; }
        public double c { get; private set; }
        private double Delta()
        {
            return Math.Pow(this.b, 2) - (4*this.a*this.c);
        }
        public double[]? Rozwiazania()
        {
            double delta = this.Delta();
            if(delta>0)
            {
                return new double[] { ((-this.b + Math.Sqrt(delta)) / (2 * this.a)), ((-this.b - Math.Sqrt(delta)) / (2 * this.a)) };
            }else if(delta==0)
            {
                return new double[] { (-this.b) / (2 * this.a) };
            }
            return null;
        }
        public string Pisz()
        {
            string r = "";
            if (a != 0) r += a.ToString() + "*x^(2)";
            if (b > 0) r += " + " + b.ToString() + "*x";
            else if (b < 0) r += " - " + (-1*b).ToString() + "*x";
            if (c > 0) r += " + " + c.ToString();
            else if (c < 0) r += " - " + (-1 * c).ToString();
            r += " = 0";
            return r;
        }
    }
}