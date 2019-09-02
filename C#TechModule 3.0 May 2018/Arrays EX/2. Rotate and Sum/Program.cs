using System;

namespace _2._Rotate_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int k = int.Parse(Console.ReadLine());

            int[] numbersArr = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                numbersArr[i] = int.Parse(input[i]);
            }
            int[] sumArr = new int[numbersArr.Length];
            for (int i = 0; i < k; i++)
            {
                int[] rotArr = RotateArray(numbersArr);
                //RotateArray(numbersArr);

                for (int j = 0; j < sumArr.Length; j++)
                {
                    sumArr[j] += rotArr[j];
                }
                numbersArr = rotArr;
            }
            Console.WriteLine(string.Join(" ", sumArr));
        }
        static int[] RotateArray(int[] numbersArr)
        {
            int lastElement = numbersArr[numbersArr.Length - 1];
            int[] rotateElements = new int[numbersArr.Length];
            rotateElements[0] = lastElement;

            for (int i = 1; i < numbersArr.Length; i++)
            {
                rotateElements[i] = numbersArr[i - 1];
            } 
            return rotateElements;
        }
    }
}
