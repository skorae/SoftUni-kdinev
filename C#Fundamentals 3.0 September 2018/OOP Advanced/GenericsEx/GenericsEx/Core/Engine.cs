using GenericsEx.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericsEx.Core
{
    public class Engine
    {
        public void Run()
        {
            CustomList<string> customList = new CustomList<string>();
            //int n = int.Parse(Console.ReadLine());
            //Box<double> boxes = new Box<double>();

            //for (int i = 0; i < n; i++)
            //{
            //    double value = double.Parse(Console.ReadLine());
            //    boxes.Text.Add(value);
            //}

            //double compare = double.Parse(Console.ReadLine());
            ////int[] positions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            ////Swap(boxes, positions);

            ////foreach (var b in boxes)
            ////{
            ////    Console.WriteLine(b);
            ////}

            //Console.WriteLine(boxes.Compare(compare));

            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] arr = command.Split();
                string com = arr[0];
                string element;
                int index;

                switch (com)
                {
                    case "Add":
                        element = arr[1];
                        customList.Add(element);
                        break;
                    case "Remove":
                        index = int.Parse(arr[1]);
                        Console.WriteLine(customList.Remove(index));
                        break;
                    case "Contains":
                        element = arr[1];
                        Console.WriteLine(customList.Contains(element));
                        break;
                    case "Swap":
                        index = int.Parse(arr[1]);
                        customList.Swap(index, int.Parse(arr[2]));
                        break;
                    case "Greater":
                        element = arr[1];
                        Console.WriteLine(customList.CountGreaterThan(element));
                        break;
                    case "Max":
                        Console.WriteLine(customList.Max());
                        break;
                    case "Min":
                        Console.WriteLine(customList.Min());
                        break;
                    case "Print":
                        Console.WriteLine(customList);
                        break;
                }
                //bool Contains(T element);
                //void Swap(int index1, int index2);
                //int CountGreaterThan(T element);
                //T Max();
                //T Min();

                command = Console.ReadLine();
            }
        }


        public void Swap<T>(List<T> items, int[] positions)
        {
            int first = positions[0];
            int second = positions[1];

            T temp = items[first];
            items[first] = items[second];
            items[second] = temp;
        }
    }
}
