using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{
    public class Heap
    {
        private int[] heap;

        public int HeapSize { get; set; }

        public Heap(int[] arr)
        {
            heap = arr;
            HeapSize = arr.Length;
        }

        public void BuildMaxHeap()
        {
            for (int i = 1; i < HeapSize; i++)
            {
                MaxHeapifyUp(i);
            }
        }

        public void BuildMinHeap()
        {
            for (int i = 1; i < HeapSize; i++)
            {
                MinHeapifyUp(i);
            }
        }

        private void MaxHeapifyUp(int pos)
        {
            if (pos > 0)
            {
                int parent = (pos - 1) / 2;
                if (heap[pos] > heap[parent])
                {
                    int temp = heap[pos];
                    heap[pos] = heap[parent];
                    heap[parent] = temp;

                    MaxHeapifyUp(parent);
                }
            }
        }

        private void MinHeapifyUp(int pos)
        {
            if (pos > 0)
            {
                int parent = (pos - 1) / 2;
                if (heap[pos] < heap[parent])
                {
                    int temp = heap[pos];
                    heap[pos] = heap[parent];
                    heap[parent] = temp;

                    MinHeapifyUp(parent);
                }
            }
        }

        public int DeleteAtIndexFromMaxHeap(int index)
        {
            int temp = heap[index];
            heap[index] = heap[HeapSize - 1];
            heap[HeapSize - 1] = temp;
            HeapSize = HeapSize - 1;

            MaxHeapifyDown(index);

            return temp;
        }

        public int DeleteAtIndexFromMinHeap(int index)
        {
            int temp = heap[index];
            heap[index] = heap[HeapSize - 1];
            heap[HeapSize - 1] = temp;
            HeapSize = HeapSize - 1;

            MinHeapifyDown(index);

            return temp;
        }
        public int ExtractMax()
        {
            int temp = heap[0];
            heap[0] = heap[HeapSize - 1];
            heap[HeapSize - 1] = temp;
            HeapSize = HeapSize - 1;

            MaxHeapifyDown(0);

            return temp;
        }

        public int GetMax()
        {
            return heap[0];
        }

        public int ExtractMin()
        {
            int temp = heap[0];
            heap[0] = heap[HeapSize - 1];
            heap[HeapSize - 1] = temp;
            HeapSize = HeapSize - 1;
            MinHeapifyDown(0);
            return temp;
        }

        public int GetMin()
        {
            return heap[0];
        }

        private void MaxHeapifyDown(int pos)
        {
            int largest = pos;
            int left = 2 * pos + 1;
            int right = 2 * pos + 2;

            if (left < HeapSize && heap[largest] < heap[left])
            {
                largest = left;
            }
            if (right < HeapSize && heap[largest] < heap[right])
            {
                largest = right;
            }

            if (largest != pos)
            {
                int temp = heap[largest];
                heap[largest] = heap[pos];
                heap[pos] = temp;
                MaxHeapifyDown(largest);
            }
        }

        private void MinHeapifyDown(int pos)
        {
            int smallest = pos;
            int left = 2 * pos + 1;
            int right = 2 * pos + 2;

            if (left < HeapSize && heap[smallest] > heap[left])
            {
                smallest = left;
            }
            if (right < HeapSize && heap[smallest] > heap[right])
            {
                smallest = right;
            }

            if (smallest != pos)
            {
                int temp = heap[smallest];
                heap[smallest] = heap[pos];
                heap[pos] = temp;
                MinHeapifyDown(smallest);
            }
        }
    }
}
