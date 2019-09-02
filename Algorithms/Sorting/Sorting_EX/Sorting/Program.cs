using System;
using System.Linq;

namespace Sorting
{
    class Program
    {
        static int[] arr;

        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            arr = new int[numbers.Length];
            //SelectionSort();
            //InsertionSort();
            MergeSort(numbers,0, arr.Length - 1);
            //arr = new int[numbers.Length];

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void MergeSort(int[] numbers,int startIndex, int endIndex)
        {
            if (startIndex >= endIndex)
            {
                return;
            }

            int middleIndex = (startIndex + endIndex) / 2;

            MergeSort(numbers,startIndex, middleIndex);
            MergeSort(numbers,middleIndex + 1, endIndex);

            Merge(numbers,startIndex, middleIndex, endIndex);
        }

        private static void Merge(int[] numbers,int startIndex, int middleIndex, int endIndex)
        {
            if (middleIndex < 0 ||
                middleIndex + 1 >= numbers.Length ||
                numbers[middleIndex] <= numbers[middleIndex + 1])
            {
                return;
            }

            for (int i = startIndex; i < endIndex + 1; i++)
            {
                arr[i] = numbers[i];
            }
            int leftIndex = startIndex;
            int rightIndex = middleIndex + 1;
            
            for (int i = startIndex; i <= endIndex; i++)
            {
                if (leftIndex > middleIndex)
                {
                    numbers[i] = arr[rightIndex++];
                }
                else if (rightIndex > endIndex)
                {
                    numbers[i] = arr[leftIndex++];
                }
                else if (arr[leftIndex] <= arr[rightIndex])
                {
                    numbers[i] = arr[leftIndex++];
                }
                else
                {
                    numbers[i] = arr[rightIndex++];
                }
            }
        }

        //private static void InsertionSort()
        //{
        //    for (int i = 1; i < arr.Length; i++)
        //    {
        //        int elemnt = arr[i];

        //        for (int y = i; y >= 0; y--)
        //        {
        //            if (elemnt < arr[y])
        //            {
        //                Swap(y, y + 1);
        //            }
        //        }
        //    }
        //}

        //private static void SelectionSort()
        //{
        //    for (int i = 0; i < arr.Length - 1; i++)
        //    {
        //        int element = arr[i];
        //        int indexToSwap = -1;

        //        for (int y = i + 1; y < arr.Length; y++)
        //        {
        //            if (element > arr[y])
        //            {
        //                element = arr[y];
        //                indexToSwap = y;
        //            }
        //        }

        //        if (indexToSwap > -1)
        //        {
        //            Swap(i, indexToSwap);
        //        }
        //    }
        //}

        //private static void Swap(int index, int indexToSwap)
        //{
        //    int element = arr[indexToSwap];
        //    arr[indexToSwap] = arr[index];
        //    arr[index] = element;
        //}
    }
}