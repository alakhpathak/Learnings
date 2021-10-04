using System;
using System.Collections.Generic;
using System.Text;

namespace Recursion
{
    public class ArrayDemo
    {
        public void SortArray(int[] arr, int n)
        {
            if (n == 1)
            {
                return;
            }
            else
            {
                SortArray(arr, n - 1);
                InsertAtIncreasingSorted(arr, n - 1, arr[n - 1]); ;
            }
        }

        private void InsertAtIncreasingSorted(int[] arr, int n, int temp)
        {
            if (n == 0 || arr[n - 1] <= temp)
            {
                arr[n] = temp;
                return;
            }
            int val = arr[n - 1];
            InsertAtIncreasingSorted(arr, n - 1, temp);
            arr[n] = val;
        }

        private void InsertAtDecreasingSorted(int[] arr, int n, int temp)
        {
            if (n == 0 || arr[n - 1] <= temp)
            {
                arr[n] = temp;
                return;
            }
            int val = arr[n - 1];
            InsertAtDecreasingSorted(arr, n - 1, temp);
            arr[n] = val;
        }
    }
}
