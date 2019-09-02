namespace SumOfCoins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SumOfCoins
    {
        public static void Main(string[] args)
        {
            var availableCoins = new[] { 1, 2, 3,4 };
            var targetSum = 1234;

            var selectedCoins = ChooseCoins(availableCoins, targetSum);

            Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
            foreach (var selectedCoin in selectedCoins)
            {
                Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
            }
        }

        public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
        {
            var chosenCoins = new Dictionary<int, int>();
            var currentSum = 0;
            var coinIndex = 0;

            var sorteCoins = coins.OrderByDescending(x => x).ToList();

            while (currentSum != targetSum && coinIndex < sorteCoins.Count)
            {
                var currentCoinValue = sorteCoins[coinIndex];
                var remainingSum = targetSum - currentSum;
                var numberOfCoinsToTake = remainingSum / currentCoinValue;

                if (numberOfCoinsToTake > 0)
                {
                    if (!chosenCoins.ContainsKey(currentCoinValue))
                    {
                        chosenCoins.Add(currentCoinValue, numberOfCoinsToTake);
                    }
                    currentSum += numberOfCoinsToTake * currentCoinValue;
                }

                coinIndex++;
            }

            if (currentSum != targetSum)
            {
                throw new InvalidOperationException("Greedy algorithm cannot produce desired sum with specified coins.");
            }

            return chosenCoins;
        }
    }
}