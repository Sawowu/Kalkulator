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
        private double delta()
        {
            return Math.Pow(this.a, 2) - (4*b*c);
        }
        public double[] rozwiazania()
        {
            double delta = this.delta();
            if(delta>0)
            {
                return new double[] { (-this.b + delta) / (2 * a), (-this.b - delta) / (2 * a) };
            }else if(delta==0)
            {
                return new double[] { (-this.b) / (2 * this.a) };
            }
            return null;
        }
        public void pisz()
        {
            if (a != 0) Console.Write(a + "*x^(2) ");
            if (b > 0) Console.Write(" + " + b + "*x");
            else if (b < 0) Console.Write(" - " + (-1*b) + "");
            if (c > 0) Console.Write(" + " + c);
            else if (c < 0) Console.Write(" - " + (-1*c));
            Console.WriteLine(" = 0");
        }
    }
}