using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    class ArrayDuplicate
    {
        static void FindDuplicate(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[Math.Abs(array[i])] >= 0)
                {
                    array[Math.Abs(array[i])] = -array[Math.Abs(array[i])];
                }
                else
                {
                    Console.WriteLine("Duplicate at " + i + " " + Math.Abs(array[i]) + " ");
                }
                PrintArray(array);
            }
            Console.ReadLine();
        }

        static void PrintArray(int[] a)
        {
            Console.WriteLine("********");
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i] + ",");
            }
            Console.WriteLine("********");
        }

        // Driver program  
        public static void FindDuplicateSolve()
        {
            int[] array = { 3, 2, 1, 6, 4, 3, 4 };
            FindDuplicate(array);
        }
    }
}
