using System;
using System.Collections.Generic;
using System.Text;

namespace SlidingWindow
{
    public static class VariableWindow
    {
        public static int LongestSubstringWithKUnqiueCharacterSolve()
        {
            // op cbebebe i.e. 7
            return LongestSubstringWithKUnqiueCharacter("aabacbebebe", 3);
        }
        private static int LongestSubstringWithKUnqiueCharacter(string str, int k)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            int i = 0, j = 0;
            int n = str.Length;
            int maxLength = 0;
            int subStringLength = 0;
            while (j < n)
            {
                int count;
                if (dict.TryGetValue(str[j], out count))
                {
                    count++;
                    dict[str[j]] = count;
                }
                else
                {
                    dict[str[j]] = 1;
                }
                subStringLength++;

                if (dict.Count < k)
                {
                    j++;
                }
                else if (dict.Count == k)
                {
                    maxLength = Math.Max(maxLength, subStringLength);
                    j++;
                }
                else if (dict.Count > k)
                {
                    while (dict.Count > k)
                    {
                        dict[str[i]] = dict[str[i]] - 1;
                        if (dict[str[i]] == 0)
                        {
                            dict.Remove(str[i]);
                        }
                        subStringLength--;
                        i++;
                    }
                    j++;
                }
            }
            return maxLength;
        }

        public static int LongestSubstringAllUnqiueCharacterSolve()
        {
            // op wke or kew i.e 3
            return LongestSubstringAllUnqiueCharacter("pwwkew");
        }
        private static int LongestSubstringAllUnqiueCharacter(string str)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            int i = 0, j = 0;
            int n = str.Length;
            int maxLength = 0;
            int subStringLength = 0;
            while (j < n)
            {
                int count;
                if (dict.TryGetValue(str[j], out count))
                {
                    count++;
                    dict[str[j]] = count;
                }
                else
                {
                    dict[str[j]] = 1;
                }
                subStringLength++;

                if (dict.Count == subStringLength)
                {
                    maxLength = Math.Max(maxLength, subStringLength);
                    j++;
                }
                else if (dict.Count < subStringLength)
                {
                    while (dict.Count < subStringLength)
                    {
                        dict[str[i]] = dict[str[i]] - 1;
                        if (dict[str[i]] == 0)
                        {
                            dict.Remove(str[i]);
                        }
                        subStringLength--;
                        i++;
                    }
                    j++;
                }
            }
            return maxLength;
        }

        public static int PickToysSolve()
        {
            // op acca i.e 4
            return PickToys("abaccab", 2);
        }
        private static int PickToys(string str, int uniqueToys)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            int i = 0, j = 0;
            int n = str.Length;
            int maxLength = 0;
            int subStringLength = 0;
            while (j < n)
            {
                int count;
                if (dict.TryGetValue(str[j], out count))
                {
                    count++;
                    dict[str[j]] = count;
                }
                else
                {
                    dict[str[j]] = 1;
                }
                subStringLength++;

                if (dict.Count < uniqueToys)
                {
                    j++;
                }
                else if (dict.Count == uniqueToys)
                {
                    maxLength = Math.Max(maxLength, subStringLength);
                    j++;
                }
                else if (dict.Count > uniqueToys)
                {
                    while (dict.Count > uniqueToys)
                    {
                        dict[str[i]] = dict[str[i]] - 1;
                        if (dict[str[i]] == 0)
                        {
                            dict.Remove(str[i]);
                        }
                        subStringLength--;
                        i++;
                    }
                    j++;
                }
            }
            return maxLength;
        }

        public static int MinimumWindowSubstringSolve()
        {
            // op toprac i.e 6
            return MinimumWindowSubstring("timetopractice", "toc");
        }
        private static int MinimumWindowSubstring(string s, string t)
        {
            Dictionary<char, int> tDict = new Dictionary<char, int>();
            int count;
            foreach (var item in t)
            {
                if (tDict.TryGetValue(item, out count))
                {
                    count++;
                    tDict[item] = count;
                }
                else
                {
                    tDict[item] = 1;
                }
            }

            int i = 0, j = 0;
            int n = s.Length;
            int charCount = tDict.Count;
            int substringLength = Int32.MaxValue;
            
            while (j < n)
            {
                if (tDict.TryGetValue(s[j], out count))
                {
                    tDict[s[j]] = tDict[s[j]] - 1;
                    if (tDict[s[i]] == 0)
                    {
                        charCount--;
                    }
                    j++;
                }
                else if (charCount == 0)
                {
                    substringLength = Math.Min(substringLength, j - i + 1);
                    j++;
                }
                else if (tDict.TryGetValue(s[i], out count))
                {
                    tDict[s[i]] = tDict[s[i]] + 1;
                    if (tDict[s[i]] == 1)
                    {
                        charCount++;
                    }
                    i++;
                }
                else
                {
                    i++;
                }


            }
            return substringLength;
        }
    }
}
