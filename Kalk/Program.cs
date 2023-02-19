
using Library;

char[] symbols = { '(', ')', '^', '*', '/', '+', '-' };

double solve(string eq)
{
    bool found = false;
    int startIndex = 0;

    for(int i = 0; i<symbols.Length; )
    {
        for(int j = 0; j<eq.Length; j++ )
        {
            if (i == 0)
            {
                if (eq[j] == '(')
                {
                    found = true;
                    startIndex = j; break;
                }
                if (j == eq.Length-1 && eq[j] != symbols[j] && !found) i=2;
            }
            else if(i==1) {
                if (eq[j] ==')') {
                    eq.Replace(eq.Remove(j).Remove(0, startIndex+1), Convert.ToString(solve(eq.Remove(j).Remove(0, startIndex + 1))));
                    i = 0; break;
                }
            }
            else if(1==2 && eq[j] == symbols[2])
            {
                string num = String.Empty;
                for(int k=j-1; k>=0; k--)
                {
                    try
                    {
                        Convert.ToDouble(eq[k]);
                        num += Convert.ToString(eq[k]);
                        startIndex = k;
                    }
                    catch(Exception e) { break; }
                }
                double result = Convert.ToDouble(num);
                result *= result;
                eq.Replace(eq.Remove(j+1).Remove(0, startIndex), Convert.ToString(result));
            }else if (i==3 || i==4) { }
            {

            }
        }
        if (found)
        {
            found = false;
            i++;
        }
    }
    return 0;
}
