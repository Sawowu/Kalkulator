
using Library;

char[] symbols = { '(', ')', '^', '*', '/', '+', '-' };

double solve(string eq)
{
    bool found = false;
    int startIndex = 0;
    int endIndex = 0;
    string num1 = String.Empty;
    string num2 = String.Empty;

    for(int i = 0; i<symbols.Length; )
    {
        for(int j = 0; j<eq.Length; j++ )
        {
            //Obliczanie wyrażenia w nawiasie
            if (i == 0)
            {
                if (eq[j] == eq[i])
                {
                    found = true;
                    startIndex = j;
                }
                if (j == eq.Length-1 && eq[j] != symbols[j] && !found) i=2;
            }
            else if(i==1) {
                if (j < startIndex) j=startIndex;
                if (eq[j] ==')') {
                    eq.Replace(eq.Remove(j+1).Remove(0, startIndex), Convert.ToString(solve(eq.Remove(j).Remove(0, startIndex+1 ))));
                    i = 0; break;
                }
            }
            //Operacja potęgowania
            else if(1==2 && eq[j] == symbols[2])
            {
                for(int k=j-1; k>=0; k--)
                {
                    try
                    {
                        Convert.ToDouble(eq[k]);
                        num1.Insert(0, Convert.ToString(eq[k]));
                        startIndex = k;
                    }
                    catch(Exception e) {
                        if (eq[k] == '.')
                        {
                            num1.Insert(0, Convert.ToString(eq[k]));
                            startIndex = k;
                        }
                        else break; 
                    }
                }
                for (int k = j + 1; k < eq.Length; k++)
                {
                    try
                    {
                        Convert.ToDouble(eq[k]);
                        num2 += Convert.ToString(eq[k]);
                        endIndex = k;
                    }
                    catch (Exception e) {
                        if (eq[k] == '.')
                        {
                            endIndex = k;
                            num2 += Convert.ToString(eq[k]);
                        }
                        else break;
                    }
                }
                double result = Math.Pow(Convert.ToDouble(num1), Convert.ToDouble(num2));
                eq.Replace(eq.Remove(endIndex+1).Remove(0, startIndex), Convert.ToString(result));
            }else if (i==3 || i==4)
            {
                
                if (eq[j] == eq[3] || eq[j] == eq[4]) {
                    for (int k = j - 1; k >= 0; k--)
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
                    for (int k = j + 1; k < eq.Length; k++)
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
                    if(eq[j] == eq[3])
                    {
                    double result = Convert.ToDouble(num1) * Convert.ToDouble(num2);
                    eq.Replace(eq.Remove(endIndex+1).Remove(0, startIndex), Convert.ToString(result));
                    }
                    else
                    {
                        double result = Convert.ToDouble(num1) / Convert.ToDouble(num2);
                        eq.Replace(eq.Remove(endIndex + 1).Remove(0, startIndex), Convert.ToString(result));
                    }
                }
            }
            if(i == 5 || i == 6){
                if (eq[j] == eq[5] || eq[j] == eq[6])
                {
                    for (int k = j - 1; k >= 0; k--)
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
                    for (int k = j + 1; k < eq.Length; k++)
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
                    if (eq[j] == eq[5])
                    {
                        double result = Convert.ToDouble(num1) * Convert.ToDouble(num2);
                        eq.Replace(eq.Remove(endIndex + 1).Remove(0, startIndex), Convert.ToString(result));
                    }
                    else
                    {
                        double result = Convert.ToDouble(num1) / Convert.ToDouble(num2);
                        eq.Replace(eq.Remove(endIndex + 1).Remove(0, startIndex), Convert.ToString(result));
                    }
                }
            }
        }
        startIndex = 0;
        endIndex = 0;
        if (found)
        {
            found = false;
            i++;
        }
    }
    return 0;
}

Console.WriteLine("KALKULATOR\n");
Console.WriteLine("A - Podaj własne równanie");
Console.WriteLine("B - Gotowe wzory i problemy");
char choice = char.ToUpper(Convert.ToChar(Console.ReadLine()));
Console.Clear();
switch (choice)
{
    case 'A':
        break;
    case 'B':
        break;
}
