using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    class QuickSort
    {
        static int partitionMid(int[] arr, int low,
                                  int high)
        {
            int pivot = arr[(low + high) / 2];

            var midIndex = (low + high) / 2;
            // index of highest element 
            int index = high + 1;

            int i = 0;
            int j = high;
            while (i < j)
            {
                for (i = low; i < midIndex; i++)
                {
                    if (arr[i] < pivot)
                    {
                        break;
                    }
                }

                for (j = high; j > midIndex; j--)
                {
                    if (arr[j] > pivot)
                    {
                        break;
                    }
                }
                // swap arr[i] and arr[j]
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }

            int temp1 = arr[midIndex];
            arr[midIndex] = arr[j];
            arr[j] = temp1;


            return j;
        }

        static int partitionLow(int[] arr, int low,
                                  int high)
        {
            int pivot = arr[low];
            // index of smaller element 
            int index = high + 1;

            for (int i = high; i > low; i--)
            {
                // If current element is smaller  
                // than the pivot 
                if (arr[i] > pivot)
                {
                    index--;
                    // swap arr[i] and arr[j] 
                    int temp = arr[index];
                    arr[index] = arr[i];
                    arr[i] = temp;
                }

            }

            // swap arr[i+1] and arr[high] (or pivot) 
            int temp1 = arr[index - 1];
            arr[index - 1] = arr[low];
            arr[low] = temp1;
            return index - 1;
        }

        static int partitionHigh(int[] arr, int low,
                                   int high)
        {
            int pivot = arr[high];

            // index of smaller element 
            int i = (low - 1);
            for (int j = low; j < high; j++)
            {
                // If current element is smaller  
                // than the pivot 
                if (arr[j] < pivot)
                {
                    i++;

                    // swap arr[i] and arr[j] 
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            // swap arr[i+1] and arr[high] (or pivot) 
            int temp1 = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = temp1;

            return i + 1;
        }

        /* The main function that implements QuickSort() 
        arr[] --> Array to be sorted, 
        low --> Starting index, 
        high --> Ending index */
        public static void quickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {

                /* pi is partitioning index, arr[pi] is  
                now at right place */
                int pi = partitionMid(arr, low, high);

                // Recursively sort elements before
                // partition and after partition 
                quickSort(arr, low, pi - 1);
                quickSort(arr, pi + 1, high);
            }
        }

        // A utility function to print array of size n 
        static void printArray(int[] arr, int n)
        {
            for (int i = 0; i < n; ++i)
                Console.Write(arr[i] + " ");

            Console.WriteLine();
        }
    }
}
