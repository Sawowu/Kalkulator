
using Library;
using System.Globalization;

char[] symbols = { '(', ')', '^', '*', '/', '+', '-' };
NumberFormatInfo provider = new NumberFormatInfo();
provider.NumberDecimalSeparator = ".";
int startIndex = 0;
int endIndex = 0;
double[] numberFinder(string eq, int j)
{
    string num1 = "";
    string num2 = "";
    num1 = Convert.ToString(eq[j - 1]);
    startIndex = j - 1;
    for (int k = j - 2; k >= 0; k--)
    {
        if (Char.IsNumber(eq, k) || eq[k] == '.' || (eq[k] == '-' && (k == 0 || !Char.IsNumber(eq, k - 1))))
        {
            num1 = Convert.ToString(eq[k]) + num1;
            startIndex--;
        }
        else break;
    }
    num2 = Convert.ToString(eq[j + 1]);
    endIndex = j + 1;
    for (int k = j + 2; k < eq.Length; k++)
    {
        if (Char.IsNumber(eq, k) || eq[k] == '.' || (eq[k] == '-' && (k == 0 || !Char.IsNumber(eq, k - 1))))
        {
            num2 += Convert.ToString(eq[k]);
            endIndex++;
        }
        else break;
    }
    return new double[] {Convert.ToDouble(num1, provider), Convert.ToDouble(num2, provider), num1.Length};
}

double solve(string eq)
{
    startIndex = 0;
    endIndex = 0;

    for(int i = 0; i<symbols.Length; i++)
    {
        for(int j = 0; j<eq.Length; j++ )
        {
            //Obliczanie wyrażenia w nawiasie
            if (i == 0)
            {
                if (eq[j] == symbols[0])
                {
                    startIndex = j;
                }
                if (j == eq.Length - 1 && eq[j] != symbols[i] && startIndex < 0) { i++; break; }
            }
            else if(i==1) {
                if (j < startIndex) j=startIndex;
                if (eq[j] == symbols[1]) {
                    eq = eq.Replace(eq.Substring(startIndex, j - startIndex + 1), Convert.ToString(solve(eq.Substring(startIndex+1, j - startIndex-1)), provider));
                    i = 0; break;
                }
            }
            //Operacja potęgowania
            else if(i==2 && eq[j] == symbols[2])
            {
                double[] numbers = numberFinder(eq, j);
                double result = Math.Pow(numbers[0], numbers[1]);
                eq = eq.Replace(eq.Substring(startIndex, endIndex - startIndex + 1), Convert.ToString(result, provider));
            }
            else if (i==3 || i==4)
            {
                if (eq[j] == symbols[3] || eq[j] == symbols[4]) {
                    double[] numbers = numberFinder(eq, j);
                    //Mnożenie
                    if (eq[j] == symbols[3])
                    {
                        double result = numbers[0] * numbers[1];
                        eq = eq.Replace(eq.Substring(startIndex, endIndex - startIndex+1), Convert.ToString(result, provider));
                    }
                    //Dzielenie
                    else
                    {
                        double result = numbers[0] / numbers[1];
                        eq = eq.Replace(eq.Substring(startIndex, endIndex - startIndex + 1), Convert.ToString(result, provider));
                    }
                }
            }
            if(i == 5 || i == 6){
                if ((eq[j] == symbols[5] || eq[j] == symbols[6]) && j!=0)
                {
                    double[] numbers = numberFinder(eq, j);
                    //Dodawanie
                    if (eq[j] == symbols[5])
                    {
                        double result = numbers[0] + numbers[1];
                        eq = eq.Replace(eq.Substring(startIndex, endIndex - startIndex + 1), Convert.ToString(result, provider));
                    }
                    //Odejmowanie
                    else if (numbers[2] >=1)
                    {
                        double result = numbers[0] - numbers[1];
                        eq = eq.Replace(eq.Substring(startIndex, endIndex - startIndex + 1), Convert.ToString(result, provider));
                    }
                }
            }
        }
    }
    double sol = Convert.ToDouble(eq, provider);
    return sol;
}

//UI
for(; ; )
{
    Console.WriteLine("KALKULATOR\n");
    Console.WriteLine("1 - Podaj własne równanie");
    Console.WriteLine("2 - Gotowe wzory i problemy");
    char choice = char.ToUpper(Convert.ToChar(Console.ReadLine()));
    Console.Clear();
    switch (choice)
    {
        case '1':
            bool guide = true;
            for (; ; )
            {
                if (guide)
                {
                    Console.WriteLine("Dostępne działania\n '+' Dodawanie\n '-'\n '*' Mnożenie\n '/' Dzielenie\n '^' Potęgowanie\n '( )' Nawiasy\n '.' Liczby po przecinku");
                    guide = false;
                }
                else Console.WriteLine("P - Pomoc");
                Console.WriteLine("B - Wyjdź");
                Console.WriteLine("\nDziałanie:");
                string eq = Console.ReadLine();
                Console.Clear();
                if (eq.ToUpper() == "P") { guide = true; continue; }
                if (eq.ToUpper() == "B") break;
                double sol = Math.Round(solve(eq), 6);
                Console.Write(eq);
                Console.WriteLine(" = " + sol.ToString(provider));
            }
            break;
        case '2':
            for(; ; )
            {
                Console.WriteLine("1 - Równanie Kwadratowe");
                Console.WriteLine("2 - Figury Geometryczne");
                Console.WriteLine("B - Wyjdź");
                choice = char.ToUpper(Convert.ToChar(Console.ReadLine()));
                Console.Clear();
                switch (choice)
                {
                    case '1':
                        Console.WriteLine("Podaj współczynnik a:");
                        double a = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Podaj współczynnik b:");
                        double b = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Podaj współczynnik c:");
                        double c = Convert.ToDouble(Console.ReadLine());
                        Console.Clear();
                        Kwadratowe kw = new Kwadratowe(a, b, c);
                        kw.pisz();
                        double[] zerow = kw.rozwiazania();
                        if (zerow!=null && zerow.Length == 1) Console.WriteLine("\nx = "+zerow[0]+"\n");
                        else if (zerow != null && zerow.Length == 2) Console.WriteLine("\nx1 = " + zerow[0]+"\nx2 = "+zerow[1]+"\n");
                        else Console.WriteLine("\nRównanie nie ma rozwiązań\n");
                        break;
                    case '2':
                        for(; ; )
                        {

                        }
                        break;
                }
                if (choice == 'B') break;
            }
            break;
    }
}
