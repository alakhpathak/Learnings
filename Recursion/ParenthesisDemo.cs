using System;
using System.Collections.Generic;
using System.Text;

namespace Recursion
{
    class ParenthesisDemo
    {
        public void GenerateValid()
        {
            int open = 3;
            int close = 3;
            SolveGenerate(open, close, string.Empty);
        }
        private void SolveGenerate(int open, int close, string op)
        {
            if (open == 0 && close == 0)
            {
                Console.WriteLine(op);
                return;
            }
            if (open > 0)
            {
                string op1 = op;
                op1 += "(";
                SolveGenerate(open - 1, close, op1);
            }
            if (close > open)
            {
                string op2 = op;
                op2 += ")";
                SolveGenerate(open, close - 1, op2);
            }
        }
        public void AllValidParenthesis(int n, int lcount, int rcount, int count, HashSet<string> result, char[] temp)
        {
            if (lcount < 0 || rcount < lcount)
            {
                return;
            }
            if (lcount == 0 && rcount == 0)
            {
                result.Add(new string(temp));
            }
            else
            {
                if (lcount > 0)
                {
                    temp[count] = '(';
                    AllValidParenthesis(n, lcount - 1, rcount, count + 1, result, temp);
                }
                if (rcount > lcount)
                {
                    temp[count] = ')';
                    AllValidParenthesis(n, lcount, rcount - 1, count + 1, result, temp);
                }
            }
        }

        public int CountAllValidParenthesis(int n, int lcount, int rcount, HashSet<string> result, string temp)
        {
            if (lcount < 0 || rcount < lcount)
            {
                return 0;
            }
            if (lcount == 0 && rcount == 0)
            {
                result.Add(temp);
                return 1;
                ///result.Add(temp);
            }
            else
            {
                int lsum = 0;
                int rsum = 0;
                if (lcount > 0)
                {
                    temp += '(';
                    lsum = CountAllValidParenthesis(n, lcount - 1, rcount, result, temp);
                    temp = temp.Remove(temp.Length - 1);
                }
                if (rcount > lcount)
                {
                    temp += ')';
                    rsum = CountAllValidParenthesis(n, lcount, rcount - 1, result, temp);
                    temp = temp.Remove(temp.Length - 1);
                }
                return lsum + rsum;
            }
        }

    }
}
