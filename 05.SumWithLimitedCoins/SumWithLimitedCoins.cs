namespace _05.SumWithLimitedCoins
{
    using System;
    using System.Linq;

    public static class SumWithLimitedCoins
    {
        private static int totalCount;
        private static bool[] coinsUsed;

        static void Main()
        {
            var targetSum = 6;
            var coins = new [] { 1, 2, 2, 3, 3, 4, 6 }.OrderBy(c => c).ToArray();
            GeneratiCombinationsDynamic(coins, targetSum);
            Console.WriteLine(totalCount);
        }

        private static void GeneratiCombinationsDynamic(int[] coins, int targetSum)
        {
            var storage = new bool[coins.Length + 1, targetSum + 1];

            for (var row = 1; row < storage.GetLength(0); row++)
            {
                for (var col = 1; col < storage.GetLength(1); col++)
                {
                    if (col - coins[row - 1] == 0)
                    {
                        storage[row, col] = true;
                    }
                    else if (col - coins[row - 1] > 0)
                    {
                        var remainder = col - coins[row - 1];
                        if (storage[row - 1, remainder])
                        {
                            storage[row, col] = true;
                        }
                    }
                    else
                    {
                        storage[row, col] = storage[row - 1, col];
                    }
                }
            }

            for (var row = storage.GetLength(0) - 1; row >= 0; row--)
            {
                if (storage[row, targetSum])
                {
                    totalCount++;
                }
            }
        }
    }
}
