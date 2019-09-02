using System;

class PriceChangeAlert
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        double threshold = double.Parse(Console.ReadLine()) * 100;
        double firstPrice = double.Parse(Console.ReadLine());

        for (int i = 0; i < n - 1; i++)
        {
            double newPrice = double.Parse(Console.ReadLine());
            double diviation = Proc(firstPrice, newPrice);
            bool isSignificantDifference = imaliDif(diviation, threshold);
            
            string message = Get(newPrice, firstPrice, diviation, isSignificantDifference);
            Console.WriteLine(message);

            firstPrice = newPrice;
        }
    }

    private static string Get(double newPrice, double firstPrice, double diviation, bool isSignificantDifference)
    {
        string to = "";
        if (diviation == 0)
        {
            to = string.Format("NO CHANGE: {0}", newPrice);
        }
        else if (!isSignificantDifference)
        {
            to = string.Format("MINOR CHANGE: {0} to {1} ({2:F2}%)", firstPrice, newPrice, diviation);
        }
        else if (isSignificantDifference && (diviation > 0))
        {
            to = string.Format("PRICE UP: {0} to {1} ({2:F2}%)", firstPrice, newPrice, diviation);
        }
        else if (isSignificantDifference && (diviation < 0))
            to = string.Format("PRICE DOWN: {0} to {1} ({2:F2}%)", firstPrice, newPrice, diviation);
        return to;
    }
    private static bool imaliDif(double diviation, double threshhold)
    {
        if (Math.Abs(diviation) >= threshhold)
        {
            return true;
        }
        return false;
    }

    private static double Proc(double firstPrice, double newPrice)
    {
        double diviation = (newPrice - firstPrice) / firstPrice ;
        return diviation * 100;
    }
}
