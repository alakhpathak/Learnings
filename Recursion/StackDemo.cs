using System;
using System.Collections.Generic;
using System.Text;

namespace Recursion
{
    public class StackDemo
    {
        public void Sort(Stack<int> stack)
        {
            if (stack.Count == 1)
                return;
            int temp = stack.Pop();
            Sort(stack);
            InsertSorted(stack, temp);
        }
        private void InsertSorted(Stack<int> stack, int temp)
        {
            if (stack.Count == 0 || stack.Peek() <= temp)
            {
                stack.Push(temp);
                return;
            }

            int val = stack.Pop();
            InsertSorted(stack, temp);
            stack.Push(val);
        }

        public void DeleteMiddle(Stack<int> stack)
        {
            if (stack.Count == 0)
            {
                return;
            }
            else
            {
                DeleteAtK(stack, (stack.Count / 2) + 1);
            }
        }

        private void DeleteAtK(Stack<int> stack, int k)
        {
            if (k == 1)
            {
                stack.Pop();
                return;
            }

            int temp = stack.Pop();
            DeleteAtK(stack, k - 1);
            stack.Push(temp);
        }

        public void Reverse(Stack<int> stack)
        {
            if (stack.Count == 1)
            {
                return;
            }
            int temp = stack.Pop();
            Reverse(stack);
            InsertReversed(stack, temp);
        }
        private void InsertReversed(Stack<int> stack, int temp)
        {
            if (stack.Count == 0)
            {
                stack.Push(temp);
                return;
            }

            int val = stack.Pop();
            InsertReversed(stack, temp);
            stack.Push(val);
        }
    }
}
