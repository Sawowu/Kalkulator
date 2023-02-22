
using Library;
using System.Globalization;

char[] symbols = { '(', ')', '^', '*', '/', '+', '-' };
NumberFormatInfo provider = new NumberFormatInfo();
provider.NumberDecimalSeparator = ".";

double solve(string eq)
{
    int startIndex = 0;
    int endIndex = 0;
    string num1 = "";
    string num2 = "";
    double n1, n2;

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
                num1 = Convert.ToString(eq[j - 1]);
                startIndex = j - 1;
                for (int k = j - 2; k >= 0; k--)
                {
                    if (Char.IsNumber(eq, k) || eq[k] == '.' || (eq[k]=='-' && (k==0 || !Char.IsNumber(eq, k-1))))
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
                n1 = Convert.ToDouble(num1, provider);
                n2 = Convert.ToDouble(num2, provider);
                double result = Math.Pow(n1, n2);
                eq = eq.Replace(eq.Substring(startIndex, endIndex - startIndex + 1), Convert.ToString(result, provider));
            }
            else if (i==3 || i==4)
            {
                if (eq[j] == symbols[3] || eq[j] == symbols[4]) {
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
                    n1 = Convert.ToDouble(num1, provider);
                    n2 = Convert.ToDouble(num2, provider);
                    //Mnożenie
                    if (eq[j] == symbols[3])
                    {
                        double result = n1 * n2;
                        eq = eq.Replace(eq.Substring(startIndex, endIndex - startIndex+1), Convert.ToString(result, provider));
                    }
                    //Dzielenie
                    else
                    {
                        double result = n1 / n2;
                        eq = eq.Replace(eq.Substring(startIndex, endIndex - startIndex + 1), Convert.ToString(result, provider));
                    }
                }
            }
            if(i == 5 || i == 6){
                if ((eq[j] == symbols[5] || eq[j] == symbols[6]) && j!=0)
                {
                    num1 = Convert.ToString(eq[j - 1]);
                    startIndex = j - 1;
                    for (int k = j - 2; k >= 0; k--)
                    {
                        if (Char.IsNumber(eq, k) || eq[k] == '.' || (eq[k] == '-' && (k == 0 || !Char.IsNumber(eq, k - 1))))
                        {
                            num1 = Convert.ToString(eq[k]) + num1;
                            startIndex --;
                        }
                        else break;
                    }
                    Console.WriteLine("num1 = " + num1);
                    num2 = Convert.ToString(eq[j + 1]);
                    endIndex = j+1;
                    for (int k = j + 2; k < eq.Length; k++)
                    {
                        if (Char.IsNumber(eq, k) || eq[k] == '.' || (eq[k] == '-' && (k == 0 || !Char.IsNumber(eq, k - 1))))
                        {
                            num2 += Convert.ToString(eq[k]);
                            endIndex ++;
                        }
                        else break;
                    }
                    Console.WriteLine("num2 = " + num2);
                    n1 = Convert.ToDouble(num1, provider);
                    n2 = Convert.ToDouble(num2, provider);
                    //Dodawanie
                    if (eq[j] == symbols[5])
                    {
                        double result = n1 + n2;
                        eq = eq.Replace(eq.Substring(startIndex, endIndex - startIndex + 1), Convert.ToString(result, provider));
                    }
                    //Odejmowanie
                    else if(num1.Length>=1)
                    {
                        double result = n1 - n2;
                        eq = eq.Replace(eq.Substring(startIndex, endIndex - startIndex + 1), Convert.ToString(result, provider));
                    }
                }
            }
        }
    }
    double sol = Convert.ToDouble(eq, provider);
    return sol;
}

for(; ; )
{
    Console.WriteLine("KALKULATOR\n");
    Console.WriteLine("A - Podaj własne równanie");
    Console.WriteLine("B - Gotowe wzory i problemy");
    char choice = char.ToUpper(Convert.ToChar(Console.ReadLine()));
    Console.Clear();
    switch (choice)
    {
        case 'A':
            
            for(; ; )
            {
                Console.WriteLine("Podaj działania:");
                string eq = Console.ReadLine();
                Console.Clear();
                double sol = solve(eq);
                Console.Write(eq);
                Console.WriteLine(" = " + sol.ToString(provider));
            }
            break;
        case 'B':
            break;
    }
}
