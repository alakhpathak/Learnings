using System;
using System.Collections.Generic;
using System.Net.Security;
using System.Security.Cryptography;
using System.Text;

namespace DynamicProgramming
{
    class StringProblem
    {

        public static string LongestPalindrome(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            string s2 = new string(arr);

            int[,] dp = LCS(s, s2);

            int max = 0;
            int maxI = 0;
            int maxJ = 0;
            for (int k = 1; k < s.Length + 1; k++)
            {
                for (int l = 1; l < s.Length + 1; l++)
                {
                    if (dp[k, l] > max)
                    {
                        max = dp[k, l];
                        maxI = k;
                        maxJ = l;
                    }
                    Console.Write(dp[k, l] + ",");
                }
                Console.WriteLine();
            }
            StringBuilder str = new StringBuilder();
            if (max != 0)
            {

                int i = maxI;
                int j = maxJ;
                while (dp[i, j] != 0)
                {
                    if (s[i - 1] == s2[j - 1])
                    {
                        str.Append(s[i - 1]);
                    }
                    i--;
                    j--;
                }
            }
            return str.ToString();

        }

        private static int[,] LCS(string s1, string s2)
        {
            int[,] dp = new int[s1.Length + 1, s2.Length + 1];

            for (int i = 0; i < s1.Length + 1; i++)
            {
                for (int j = 0; j < s2.Length + 1; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        dp[i, j] = 0;
                    }
                    else if (s1[i - 1] == s2[j - 1])
                    {
                        dp[i, j] = 1 + dp[i - 1, j - 1];
                    }
                    else
                    {
                        dp[i, j] = 0;
                    }
                }
            }
            return dp;

        }

        ////public static string LongestLCSPalindrome(string s)
        ////{
        ////    char[] arr = s.ToCharArray();
        ////    Array.Reverse(arr);
        ////    string s2 = new string(arr);

        ////    int[,] dp = LCSDP(s, s2);

        ////    int i = s.Length;
        ////    int j = i;

        ////    StringBuilder str = new StringBuilder();
        ////    while (i > 0 && j > 0)
        ////    {
        ////        if (s[i - 1] == s2[j - 1])
        ////        {
        ////            i--;
        ////            j--;
        ////            str.Append(s[i - 1]);
        ////        }
        ////        else if (dp[i, j - 1] > dp[i - 1, j])
        ////        {
        ////            j--;
        ////        }
        ////        else if (dp[i, j - 1] < dp[i - 1, j])
        ////        {
        ////            i--;
        ////        }
        ////    }
        ////    return str.ToString();

        ////}

        ////public static string LongestLCS(string s1,string s2)
        ////{
        ////    string s=LongestReverseLCS(s1, s2);
        ////    return StringReverse(s);
        ////}
        ////public static string LongestReverseLCS(string s1, string s2)
        ////{
        ////    int[,] dp = LCSDP(s1, s2);

        ////    int i = s1.Length;
        ////    int j = s2.Length;

        ////    StringBuilder str = new StringBuilder();
        ////    while (i > 0 && j > 0)
        ////    {
        ////        if (s1[i - 1] == s2[j - 1])
        ////        {
        ////            str.Append(s1[i - 1]);
        ////            i--;
        ////            j--;
        ////        }
        ////        else 
        ////        {
        ////            if (dp[i, j - 1] > dp[i - 1, j])
        ////                j--;
        ////            else
        ////                i--;
        ////        }
        ////    }
        ////    return str.ToString();
        ////}

        ////private static string StringReverse(string s)
        ////{
        ////    char[] arr = s.ToCharArray();
        ////    Array.Reverse(arr);
        ////    return new string(arr);
        ////}
        ////public static int LCS(string s1,string s2)
        ////{
        ////    int [,] dp=LCSDP(s1, s2);
        ////    return dp[s1.Length, s2.Length];
        ////}
        ////private static int[,] LCSDP(string s1, string s2)
        ////{
        ////    int[,] dp = new int[s1.Length + 1, s2.Length + 1];

        ////    for (int i = 0; i < s1.Length + 1; i++)
        ////    {
        ////        for (int j = 0; j < s2.Length + 1; j++)
        ////        {
        ////            if (i == 0 || j == 0)
        ////            {
        ////                dp[i, j] = 0;
        ////            }
        ////            else if (s1[i - 1] == s2[j - 1])
        ////            {
        ////                dp[i, j] = 1 + dp[i - 1, j - 1];
        ////            }
        ////            else
        ////            {
        ////                dp[i, j] = Math.Max(dp[i, j - 1], dp[i - 1, j]);
        ////            }
        ////        }
        ////    }
        ////    return dp;
        ////}
    }
}