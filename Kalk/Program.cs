
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
            else if(1==2)
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
