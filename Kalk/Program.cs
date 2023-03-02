
using Library;
using System.Globalization;
using System.IO;

char[] symbols = { '(', ')', '^', '*', '/', '+', '-' };
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
        if (Char.IsNumber(eq, k) || eq[k] == ',' || (eq[k] == '-' && (k == 0 || !Char.IsNumber(eq, k - 1))))
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
        if (Char.IsNumber(eq, k) || eq[k] == ',' || (eq[k] == '-' && (k == 0 || !Char.IsNumber(eq, k - 1))))
        {
            num2 += Convert.ToString(eq[k]);
            endIndex++;
        }
        else break;
    }
    return new double[] {Convert.ToDouble(num1), Convert.ToDouble(num2), num1.Length};
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
                    eq = eq.Replace(eq.Substring(startIndex, j - startIndex + 1), Convert.ToString(solve(eq.Substring(startIndex+1, j - startIndex-1))));
                    i = 0; break;
                }
            }
            //Operacja potęgowania
            else if(i==2 && eq[j] == symbols[2])
            {
                double[] numbers = numberFinder(eq, j);
                double result = Math.Pow(numbers[0], numbers[1]);
                eq = eq.Replace(eq.Substring(startIndex, endIndex - startIndex + 1), Convert.ToString(result));
            }
            else if (i==3 || i==4)
            {
                if (eq[j] == symbols[3] || eq[j] == symbols[4]) {
                    double[] numbers = numberFinder(eq, j);
                    //Mnożenie
                    if (eq[j] == symbols[3])
                    {
                        double result = numbers[0] * numbers[1];
                        eq = eq.Replace(eq.Substring(startIndex, endIndex - startIndex+1), Convert.ToString(result));
                    }
                    //Dzielenie
                    else
                    {
                        double result = numbers[0] / numbers[1];
                        eq = eq.Replace(eq.Substring(startIndex, endIndex - startIndex + 1), Convert.ToString(result));
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
                        eq = eq.Replace(eq.Substring(startIndex, endIndex - startIndex + 1), Convert.ToString(result));
                    }
                    //Odejmowanie
                    else if (numbers[2] >=1)
                    {
                        double result = numbers[0] - numbers[1];
                        eq = eq.Replace(eq.Substring(startIndex, endIndex - startIndex + 1), Convert.ToString(result));
                    }
                }
            }
        }
    }
    double sol = Convert.ToDouble(eq);
    return sol;
}
StreamWriter sw;
//UI
for (; ; )
{
    Console.WriteLine("KALKULATOR\n");
    Console.WriteLine("1 - Podaj własne równanie");
    Console.WriteLine("2 - Gotowe wzory i problemy");
    Console.WriteLine("H - Historia");
    Console.WriteLine("B - Zakończ");
    char choice = char.ToUpper(Convert.ToChar(Console.ReadLine()));
    Console.Clear();
    if(choice == 'H')
    {
        for(; ; )
        {
            FileStream op = new FileStream("C:\\Users\\DELL\\source\\repos\\Sawowu\\Kalkulator\\historia.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(op);
            Console.WriteLine("HISTORIA:");
            while (!sr.EndOfStream)
            {
                Console.WriteLine(sr.ReadLine());
            }
            sr.Close();
            Console.WriteLine("\nD - Usuń\nB - Wyjdź");
            choice = char.ToUpper(Convert.ToChar(Console.ReadLine()));
            op.Close();
            if (choice == 'D') 
            {
                op = new FileStream("C:\\Users\\DELL\\source\\repos\\Sawowu\\Kalkulator\\historia.txt", FileMode.Create, FileAccess.Write);
                op.Close();
            }
            else if (choice == 'B') break;
        }
        choice = 'h';
    }
    if (choice == 'B')
    {
        Console.WriteLine("Do zobaczenia!");
        break;
    }
    FileStream fs = new FileStream("C:\\Users\\DELL\\source\\repos\\Sawowu\\Kalkulator\\historia.txt", FileMode.Append, FileAccess.Write);
    switch (choice)
    {
        case '1':
            bool guide = true;
            for (; ; )
            {
                if (guide)
                {
                    Console.WriteLine("Dostępne działania\n '+' Dodawanie\n '-'\n '*' Mnożenie\n '/' Dzielenie\n '^' Potęgowanie\n '( )' Nawiasy\n ',' Liczby po przecinku");
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
                Console.WriteLine(" = " + sol.ToString());
                sw = new StreamWriter(fs);
                sw.WriteLine("\n"+eq + " = " + sol.ToString());
                sw.Close();
            }
            break;
        case '2':
            double a, b, c, h;
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
                        a = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Podaj współczynnik b:");
                        b = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Podaj współczynnik c:");
                        c = Convert.ToDouble(Console.ReadLine());
                        Console.Clear();
                        sw = new StreamWriter(fs);
                        Kwadratowe kw = new Kwadratowe(a, b, c);
                        Console.WriteLine(kw.Pisz());
                        sw.WriteLine(kw.Pisz());
                        double[] zerow = kw.Rozwiazania();
                        if (zerow != null && zerow.Length == 1)
                        {
                            Console.WriteLine("\nx = " + zerow[0].ToString() + "\n");
                            sw.WriteLine("\nx = " + zerow[0].ToString() + "\n");
                        }
                        else if (zerow != null && zerow.Length == 2)
                        {
                            Console.WriteLine("\nx1 = " + zerow[0].ToString() + "\nx2 = " + zerow[1].ToString());
                            sw.WriteLine("\nx1 = " + zerow[0].ToString() + "\nx2 = " + zerow[1].ToString());
                        }
                        else
                        {
                            Console.WriteLine("\nRównanie nie ma rozwiązań");
                            sw.WriteLine("\nRównanie nie ma rozwiązań");
                        }
                        sw.Close();
                        break;
                    case '2':
                        for(; ; )
                        {
                            Console.Clear();
                            Console.WriteLine("1 - Kwadrat\n2 - Prostokąt\n3 - Trapez\n4 - Równoległobok\n5 - Koło\n6 - Trójkąt\nB - Wyjdź");
                            choice = char.ToUpper(Convert.ToChar(Console.ReadLine()));
                            if (choice == 'B') break;
                            switch (choice)
                            {
                                case '1':
                                    Console.WriteLine("Podaj długość boku:");
                                    a = Convert.ToDouble(Console.ReadLine());
                                    Kwadrat sq = new Kwadrat(a);
                                    Console.Clear();
                                    for(; ; )
                                    {
                                        Console.WriteLine("Bok = "+sq.a);
                                        Console.WriteLine("Obwód = "+sq.Obwod());
                                        Console.WriteLine("Pole = " + sq.Pole());
                                        Console.WriteLine("Przekątna = " + sq.Przekatna());
                                        Console.WriteLine("B - Wyjdź");
                                        choice = char.ToUpper(Convert.ToChar(Console.ReadLine()));
                                        if (choice == 'B') break;
                                    }
                                    sw = new StreamWriter(fs);
                                    sw.WriteLine("\nBok = " + sq.a + "\nObwód = " + sq.Obwod() + "\nPole = " + sq.Pole() + "\nPrzekątna = " + sq.Przekatna());
                                    sw.Close();
                                    break;
                                case '2':
                                    Console.WriteLine("Podaj długość boku a:");
                                    a = Convert.ToDouble(Console.ReadLine());
                                    Console.WriteLine("Podaj długość boku b:");
                                    b = Convert.ToDouble(Console.ReadLine());
                                    Prostokat pr = new Prostokat(a, b);
                                    Console.Clear();
                                    for (; ; )
                                    {
                                        Console.WriteLine("a = " + pr.a.ToString());
                                        Console.WriteLine("b = " + pr.b.ToString());
                                        Console.WriteLine("Obwód = " + pr.Obwod().ToString());
                                        Console.WriteLine("Pole = " + pr.Pole().ToString());
                                        Console.WriteLine("Przekątna = " + pr.Przekatna().ToString());
                                        Console.WriteLine("B - Wyjdź");
                                        choice = char.ToUpper(Convert.ToChar(Console.ReadLine()));
                                        if (choice == 'B') break;
                                    }
                                    break;
                                case '3':
                                    Console.WriteLine("Podaj długość podstawy a:");
                                    a = Convert.ToDouble(Console.ReadLine());
                                    Console.WriteLine("Podaj długość podstawy b:");
                                    b = Convert.ToDouble(Console.ReadLine());
                                    Console.WriteLine("Podaj długość ramienia c:");
                                    c = Convert.ToDouble(Console.ReadLine());
                                    Console.WriteLine("Podaj długość wysokości h:");
                                    h = Convert.ToDouble(Console.ReadLine());
                                    Trapez tr = new Trapez(a, b, c, h);
                                    Console.Clear();
                                    for (; ; )
                                    {
                                        Console.WriteLine("a = " + tr.a.ToString());
                                        Console.WriteLine("b = " + tr.b.ToString());
                                        Console.WriteLine("c = " + tr.c.ToString());
                                        Console.WriteLine("h = " + tr.h.ToString());
                                        Console.WriteLine("Obwód = " + tr.Obwod().ToString());
                                        Console.WriteLine("Pole = " + tr.Pole().ToString());
                                        Console.WriteLine("B - Wyjdź");
                                        choice = char.ToUpper(Convert.ToChar(Console.ReadLine()));
                                        if (choice == 'B') break;
                                    }
                                    break;
                                case '4':
                                    Console.WriteLine("Podaj długość podstawy a:");
                                    a = Convert.ToDouble(Console.ReadLine());
                                    Console.WriteLine("Podaj długość podstawy b:");
                                    b = Convert.ToDouble(Console.ReadLine());
                                    Console.WriteLine("Podaj długość wysokości h:");
                                    h = Convert.ToDouble(Console.ReadLine());
                                    Rownoleglobok ro = new Rownoleglobok(a, b, h);
                                    Console.Clear();
                                    for (; ; )
                                    {
                                        Console.WriteLine("a = " + ro.a.ToString());
                                        Console.WriteLine("b = " + ro.b.ToString());
                                        Console.WriteLine("h = " + ro.h.ToString());
                                        Console.WriteLine("Obwód = " + ro.Obwod().ToString());
                                        Console.WriteLine("Pole = " + ro.Pole().ToString());
                                        Console.WriteLine("B - Wyjdź");
                                        choice = char.ToUpper(Convert.ToChar(Console.ReadLine()));
                                        if (choice == 'B') break;
                                    }
                                    break;
                                case '5':
                                    Console.WriteLine("Podaj długość promienia:");
                                    double r = Convert.ToDouble(Console.ReadLine());
                                    Kolo ko = new Kolo(r);
                                    Console.Clear();
                                    for (; ; )
                                    {
                                        Console.WriteLine("Bok = " + ko.r.ToString());
                                        Console.WriteLine("Obwód = " + ko.Obwod().ToString());
                                        Console.WriteLine("Pole = " + ko.Pole().ToString());
                                        Console.WriteLine("B - Wyjdź");
                                        choice = char.ToUpper(Convert.ToChar(Console.ReadLine()));
                                        if (choice == 'B') break;
                                    }
                                    break;
                                case '6':
                                    Console.WriteLine("Podaj długość boku a:");
                                    a = Convert.ToDouble(Console.ReadLine());
                                    Console.WriteLine("Podaj długość boku b:");
                                    b = Convert.ToDouble(Console.ReadLine());
                                    Console.WriteLine("Podaj długość boku c:");
                                    c = Convert.ToDouble(Console.ReadLine());
                                    if (a == b && b == c) h = Math.Round(Math.Sqrt(a * a - a / 2 * (a / 2)), 6);
                                    else if (b == c) h = Math.Round(Math.Sqrt(b * b - a / 2 * (a / 2)), 6);
                                    else if (a == c) h = Math.Round(Math.Sqrt(a * a - b / 2 * (b / 2)), 6);
                                    else if (a == b) h = Math.Round(Math.Sqrt(a * a - c / 2 * (c / 2)), 6);
                                    else
                                    {
                                        Console.WriteLine("Podaj wysokośc h:");
                                        h = Convert.ToDouble(Console.ReadLine());
                                    }
                                    Trojkat tro = new Trojkat(a, b, c, h);
                                    Console.Clear();
                                    for (; ; )
                                    {
                                        Console.WriteLine("a = " + tro.a.ToString());
                                        Console.WriteLine("b = " + tro.b.ToString());
                                        Console.WriteLine("c = " + tro.c.ToString());
                                        Console.WriteLine("h = " + tro.h.ToString());
                                        Console.WriteLine("Obwód = " + tro.Obwod().ToString());
                                        Console.WriteLine("Pole = " + tro.Pole().ToString());
                                        Console.WriteLine("B - Wyjdź");
                                        choice = char.ToUpper(Convert.ToChar(Console.ReadLine()));
                                        if (choice == 'B') break;
                                    }
                                    break;
                            }
                        }
                        break;
                }
                if (choice == 'B') break;
            }
            break;
    }
    fs.Close();
}
