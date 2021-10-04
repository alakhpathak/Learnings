using System;
using System.Collections.Generic;
using System.Text;

namespace Recursion
{
    public class StringDemo
    {
        public int AllKLength(string st, string st2, int k, int[] count)
        {
            if (st2.Length == k)
            {
                Console.WriteLine(st2);
                return 1;
            }
            else
            {
                int sum = 0;
                for (int i = 0; i < st.Length; i++)
                {
                    if (count[i] > 0)
                    {
                        st2 += st[i];
                        count[i] = count[i] - 1;
                        sum += AllKLength(st, st2, k, count);
                        st2 = st2.Remove(st2.Length - 1, 1);
                        count[i] = count[i] + 1;
                    }
                }
                return sum;
            }
        }

        public void PrintSubSet()
        {
            string str = "aab";
            SolvePrintSubSetSolve(str, string.Empty);
        }
        private void SolvePrintSubSetSolve(string ip, string op)
        {
            if (ip.Length == 0)
            {
                Console.WriteLine(op);
                return;
            }

            string op1 = op;
            string op2 = op;

            op2 = op2 + ip[0];
            ip = ip.Remove(0, 1);

            SolvePrintSubSetSolve(ip, op1);
            SolvePrintSubSetSolve(ip, op2);
        }

        public void PrintUniqueSubSet()
        {
            string str = "aab";
            var result = new HashSet<string>();
            SolvePrintSubSetUnique(str, string.Empty, result);
            Console.WriteLine(string.Join(',', result));
        }

        private void SolvePrintSubSetUnique(string ip, string op, HashSet<string> result)
        {
            if (ip.Length == 0)
            {
                result.Add(op);
                return;
            }

            string op1 = op;
            string op2 = op;

            op2 = op2 + ip[0];
            ip = ip.Remove(0, 1);

            SolvePrintSubSetUnique(ip, op1, result);
            SolvePrintSubSetUnique(ip, op2, result);
        }

        public void PermutationWithSpaces()
        {
            string str = "ABC";
            SolvePermutationWithSpaces(str.Remove(0, 1), str[0].ToString());
        }

        private void SolvePermutationWithSpaces(string ip, string op)
        {
            if (ip.Length == 0)
            {
                Console.WriteLine(op);
                return;
            }

            string op1 = op;
            string op2 = op;

            op1 = op1 + ip[0];
            op2 = op2 + " " + ip[0];
            ip = ip.Remove(0, 1);

            SolvePermutationWithSpaces(ip, op1);
            SolvePermutationWithSpaces(ip, op2);
        }

        public void PermutationWithCaseChange()
        {
            string str = "ab";
            SolvePermutationWithCaseChange(str, string.Empty);
        }

        private void SolvePermutationWithCaseChange(string ip, string op)
        {
            if (ip.Length == 0)
            {
                Console.WriteLine(op);
                return;
            }

            string op1 = op;
            string op2 = op;

            op1 = op1 + ip[0].ToString();
            op2 = op2 + ip[0].ToString().ToUpper();
            ip = ip.Remove(0, 1);

            SolvePermutationWithCaseChange(ip, op1);
            SolvePermutationWithCaseChange(ip, op2);
        }

        public void LetterAndDigitCaseChange()
        {
            string str = "a1B2";
            SolveLetterAndDigitCaseChange(str, string.Empty);
        }

        private void SolveLetterAndDigitCaseChange(string ip, string op)
        {
            if (ip.Length == 0)
            {
                Console.WriteLine(op);
                return;
            }

            if (ip[0] >= 48 && ip[0] <= 57)
            {
                SolveLetterAndDigitCaseChange(ip.Remove(0, 1), op + ip[0]);
            }
            else
            {
                string op1 = op;
                string op2 = op;
                op1 = op1 + ip[0].ToString().ToLower();
                op2 = op2 + ip[0].ToString().ToUpper();
                ip = ip.Remove(0, 1);
                SolveLetterAndDigitCaseChange(ip, op1);
                SolveLetterAndDigitCaseChange(ip, op2);
            }
        }
    }
}
