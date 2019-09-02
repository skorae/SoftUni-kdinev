using System;
using System.Diagnostics;
using System.Numerics;

class Program
{
    const int TestIterations = 5000000;

    static void Main(string[] args)
    {
        RunTest("Byte Loop", TestByteLoop, TestIterations);
        RunTest("Short Loop", TestShortLoop, TestIterations);
        RunTest("Int Loop", TestIntLoop, TestIterations);
        RunTest("Long Loop", TestLongLoop, TestIterations);
        RunTest("ULong Loop", TestULongLoop, TestIterations);
        RunTest("BigInteger Loop", TestBigIntegerLoop, TestIterations);
        Console.ReadLine();
    }

    private static void TestULongLoop()
    {
        ulong x = 0;
        for (ulong b = 0; b < 255; b++)
            ++x;
    }

    private static void TestBigIntegerLoop()
    {
        BigInteger x = 0;
        for (BigInteger b = 0; b < 255; b++)
            ++x;
    }

    static void TestLongLoop()
    {
        long x = 0;
        for (long b = 0; b < 255; b++)
            ++x;
    }

    static void RunTest(string testName, Action action, int iterations)
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        for (int i = 0; i < iterations; i++)
        {
            action();
        }
        sw.Stop();
        Console.WriteLine("{0}: Elapsed Time = {1}", testName, sw.Elapsed);
    }

    static void TestByteLoop()
    {
        byte x = 0;
        for (byte b = 0; b < 255; b++)
            ++x;
    }

    static void TestShortLoop()
    {
        short x = 0;
        for (short s = 0; s < 255; s++)
            ++x;
    }

    static void TestIntLoop()
    {
        int x = 0;
        for (int i = 0; i < 255; i++)
            ++x;
    }
}