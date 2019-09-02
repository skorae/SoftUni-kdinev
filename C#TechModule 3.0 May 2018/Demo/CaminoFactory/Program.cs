using System;
using System.Collections.Generic;
using System.Linq;

class KaminoFactory
{
    static void Main(string[] args)
    {
        int sequenceLength = int.Parse(Console.ReadLine());
        string sequence = Console.ReadLine();

        List<int[]> samples = new List<int[]>();

        while (sequence != "Clone them!")
        {
            int[] dna = sequence
                .Split("!".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            if (dna.Length == sequenceLength)
            {
                samples.Add(dna);
            }

            sequence = Console.ReadLine();
        }

        int index = 1;
        int bestStartIndex = sequenceLength;
        int bestLength = 0;
        int bestSum = 0;
        string bestSample = string.Join(" ", samples[0]);

        for (int sequenceIndex = 0; sequenceIndex < samples.Count; sequenceIndex++)
        {
            int sum = samples[sequenceIndex].Sum();
            int startIndex = sequenceLength;
            int bestLen = 0;
            int len = 0;

            for (int i = 0; i < samples[sequenceIndex].Length; i++)
            {
                if (samples[sequenceIndex][i] == 1)
                {
                    len++;
                }
                else
                {
                    if (len > bestLen)
                    {
                        bestLen = len;
                        startIndex = i - len;
                    }

                    len = 0;
                }
            }

            if (bestLen > bestLength)
            {
                bestLength = bestLen;
                index = sequenceIndex + 1;
                bestSum = sum;
                bestStartIndex = startIndex;
                bestSample = string.Join(" ", samples[sequenceIndex]);
            }
            else if (bestLen == bestLength)
            {
                if (bestStartIndex > startIndex)
                {
                    index = sequenceIndex + 1;
                    bestSum = sum;
                    bestStartIndex = startIndex;
                    bestSample = string.Join(" ", samples[sequenceIndex]);
                }
                else if (bestStartIndex == startIndex)
                {
                    if (bestSum < sum)
                    {
                        index = sequenceIndex + 1;
                        bestSum = sum;
                        bestSample = string.Join(" ", samples[sequenceIndex]);
                    }
                }
            }
        }

        Console.WriteLine($"Best DNA sample {index} with sum: {bestSum}.");
        Console.WriteLine($"{bestSample}");
    }
}