using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{
    public static class StackFundamentals
    {
        public static void SolveNSR()
        {
            int[] arr = new int[] { 7, 1, 5, 3, 6, 4 };
            Console.WriteLine(string.Join(',', NSR(arr)));
        }
        private static int[] NSR(int[] arr)
        {
            int[] result = new int[arr.Length];
            Stack<int> stack = new Stack<int>();
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                if (stack.Count == 0)
                {
                    stack.Push(arr[i]);
                    result[i] = -1;
                }
                else if (stack.Peek() < arr[i])
                {
                    result[i] = stack.Peek();
                    stack.Push(arr[i]);
                }
                else
                {
                    while (stack.Count != 0 && stack.Peek() > arr[i])
                    {
                        stack.Pop();
                    }
                    if (stack.Count != 0)
                    {
                        result[i] = stack.Peek();
                        stack.Push(arr[i]);
                    }
                    else
                    {
                        stack.Push(arr[i]);
                        result[i] = -1;
                    }
                }
            }
            return result;
        }
        public static void SolveNGR()
        {
            int[] arr = new int[] { 7, 1, 5, 3, 6, 4 };
            Console.WriteLine(string.Join(',', NGR(arr)));
        }
        private static int[] NGR(int[] arr)
        {
            int[] result = new int[arr.Length]; 
            Stack<int> stack = new Stack<int>();
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                if(stack.Count==0)
                {
                    stack.Push(arr[i]);
                    result[i] = -1;
                }
                else if(stack.Peek()>arr[i])
                {
                    result[i] = stack.Peek();
                    stack.Push(arr[i]);
                }
                else
                {
                    while(stack.Count!=0 && stack.Peek() < arr[i])
                    {
                        stack.Pop();
                    }
                    if(stack.Count!=0)
                    {
                        result[i] = stack.Peek();
                        stack.Push(arr[i]);
                    }
                    else
                    {
                        stack.Push(arr[i]);
                        result[i] = -1;
                    }
                }
            }
            return result;
        }
    }
}
