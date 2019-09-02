using System;

class PriceChangeAlert
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        double threshold = double.Parse(Console.ReadLine());
        double firstPrice = double.Parse(Console.ReadLine());

        for (int i = 0; i < n - 1; i++)
        {
            double price = double.Parse(Console.ReadLine());
            double diff = Proc(firstPrice, price);
            bool isSignificantDifference = imaliDif(diff, threshold);
            string message = Get(price, firstPrice, diff, isSignificantDifference);

            Console.WriteLine(message);

            firstPrice = price;
        }
    }

    private static string Get(double threshhold, double firstPrice, double razlika, bool etherTrueOrFalse)
    {
        string result = "";
        if (razlika == 0)
        {
            result = string.Format("NO CHANGE: {0}", threshhold);
        }
        else if (!etherTrueOrFalse)
        {
            result = string.Format("MINOR CHANGE: {0} to {1} ({2:F2}%)", firstPrice, threshhold, razlika);
        }
        else if (etherTrueOrFalse && (razlika > 0))
        {
            result = string.Format("PRICE UP: {0} to {1} ({2:F2}%)", firstPrice, threshhold, razlika);
        }
        else if (etherTrueOrFalse && (razlika < 0))
            result = string.Format("PRICE DOWN: {0} to {1} ({2:F2}%)", firstPrice, threshhold, razlika);
        return result;
    }

    private static bool imaliDif(double threshold, double isDiff)
    {
        if (Math.Abs(threshold) >= isDiff)
        {
            return true;
        }
        return false;
    }

    private static double Proc(double firstPrice, double price)
    {
        double r = (price - firstPrice) / firstPrice * 100;
        return r;
    }
}
