
using Library;

char[] symbols = { '(', ')', '^', '*', '/', '+', '-' };

double solve(string eq)
{
    int startIndex = 0;
    int endIndex = 0;
    string num1 = "";
    string num2 = "";

    for(int i = 0; i<symbols.Length; i++)
    {
        for(int j = 0; j<eq.Length; j++ )
        {
            //Obliczanie wyrażenia w nawiasie
            if (i == 0)
            {
                if (eq[j] == symbols[i])
                {
                    startIndex = j;
                }
                if (j == eq.Length - 1 && eq[j] != symbols[i] && startIndex < 0) { i++; break; }
                else if (j == eq.Length - 1) i++;
            }
            else if(i==1) {
                if (j < startIndex) j=startIndex;
                if (eq[j] == symbols[i]) {
                    eq = eq.Replace(eq.Substring(startIndex, endIndex + 1), Convert.ToString(solve(eq.Substring(startIndex+1, endIndex))));
                    i = 0; break;
                }
            }
            //Operacja potęgowania
            else if(i==2 && eq[j] == symbols[2])
            {
                num1 = Convert.ToString(eq[j - 1]);
                for (int k = j - 2; k >= 0; k--)
                {
                    try
                    {
                        Convert.ToDouble(eq[k]);
                        num1.Insert(0, Convert.ToString(eq[k]));
                        startIndex = k;
                    }
                    catch (Exception e)
                    {
                        if (eq[k] == '.')
                        {
                            num1.Insert(0, Convert.ToString(eq[k]));
                            startIndex = k;
                        }
                        else break;
                    }
                }
                num2 = Convert.ToString(eq[j + 1]);
                for (int k = j + 2; k < eq.Length; k++)
                {
                    try
                    {
                        Convert.ToDouble(eq[k]);
                        num2 += Convert.ToString(eq[k]);
                        endIndex = k;
                    }
                    catch (Exception e)
                    {
                        if (eq[k] == '.')
                        {
                            endIndex = k;
                            num2 += Convert.ToString(eq[k]);
                        }
                        else break;
                    }
                }
                double result = Math.Pow(Convert.ToDouble(num1), Convert.ToDouble(num2));
                eq = eq.Replace(eq.Substring(startIndex, endIndex + 1), Convert.ToString(result));
            }
            else if (i==3 || i==4)
            {
                if (eq[j] == symbols[3] || eq[j] == symbols[4]) {
                    num1 = Convert.ToString(eq[j - 1]);
                    for (int k = j - 2; k >= 0; k--)
                    {
                        try
                        {
                            Convert.ToDouble(eq[k]);
                            num1.Insert(0, Convert.ToString(eq[k]));
                            startIndex = k;
                        }
                        catch (Exception e)
                        {
                            if (eq[k] == '.')
                            {
                                num1.Insert(0, Convert.ToString(eq[k]));
                                startIndex = k;
                            }
                            else break;
                        }
                    }
                    num2 = Convert.ToString(eq[j + 1]);
                    for (int k = j + 2; k < eq.Length; k++)
                    {
                        try
                        {
                            Convert.ToDouble(eq[k]);
                            num2 += Convert.ToString(eq[k]);
                            endIndex = k;
                        }
                        catch (Exception e)
                        {
                            if (eq[k] == '.')
                            {
                                endIndex = k;
                                num2 += Convert.ToString(eq[k]);
                            }
                            else break;
                        }
                    }
                    if (eq[j] == eq[3])
                    {
                        double result = Convert.ToDouble(num1) * Convert.ToDouble(num2);
                        eq = eq.Replace(eq.Substring(startIndex, endIndex + 1), Convert.ToString(result));
                    }
                    else
                    {
                        double result = Convert.ToDouble(num1) / Convert.ToDouble(num2);
                        eq = eq.Replace(eq.Substring(startIndex, endIndex + 1), Convert.ToString(result));
                    }
                }
            }
            if(i == 5 || i == 6){
                if (eq[j] == symbols[5] || eq[j] == symbols[6])
                {
                    num1 = Convert.ToString(eq[j - 1]);
                    startIndex = j - 1;
                    for (int k = j - 2; k >= 0; k--)
                    {
                        if (Char.IsNumber(eq, k) || eq[k] == '.')
                        {
                            num1.Insert(0, Convert.ToString(eq[k]));
                            startIndex = k;
                        }
                        else break;
                    }
                    num2 = Convert.ToString(eq[j + 1]);
                    endIndex = j+1;
                    for (int k = j + 2; k < eq.Length; k++)
                    {
                        if (Char.IsNumber(eq, k) || eq[k] == '.')
                        {
                            num2 += Convert.ToString(eq[k]);
                            endIndex = k;
                        }
                        else break;
                    }
                    if (eq[j] == symbols[5])
                    {
                        double result = Convert.ToDouble(num1) + Convert.ToDouble(num2);
                        eq = eq.Replace(eq.Substring(startIndex, endIndex+1), Convert.ToString(result));
                    }
                    else
                    {
                        double result = Convert.ToDouble(num1) - Convert.ToDouble(num2);
                        eq = eq.Replace(eq.Substring(startIndex, endIndex + 1), Convert.ToString(result));
                    }
                }
            }
        }
    }
    return Convert.ToDouble(eq);
}

Console.WriteLine("KALKULATOR\n");
Console.WriteLine("A - Podaj własne równanie");
Console.WriteLine("B - Gotowe wzory i problemy");
char choice = char.ToUpper(Convert.ToChar(Console.ReadLine()));
Console.Clear();
switch (choice)
{
    case 'A':
        Console.WriteLine("Podaj działania:");
        string eq = Console.ReadLine();
        double sol = solve(eq);
        Console.WriteLine("= "+sol);
        break;
    case 'B':
        break;
}
