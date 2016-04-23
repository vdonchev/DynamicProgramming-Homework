namespace _04.SumWithUnlimitedCoins
{
    using System;

    public static class SumWithUnlimitedCoins
    {
        private static int totalCount;

        static void Main()
        {
            var targetSum = 100;
            var coins = new[] { 1, 2, 5, 10, 20, 50, 100 };
            GeneratCombinations(targetSum, coins);

            Console.WriteLine(totalCount);
        }

        private static void GeneratCombinations(int targetSum, int[] coins)
        {
            var rows = coins.Length + 1;
            var cols = targetSum + 1;
            int[,] storage = new int[rows, cols];

            for (int row = 1; row < rows; row++)
            {
                for (int col = 1; col < cols; col++)
                {
                    if (coins[row - 1] == col)
                    {
                        storage[row, col] = storage[row - 1, col] + 1;
                    }
                    else
                    {
                        if (coins[row - 1] < col)
                        {
                            storage[row, col] = storage[row - 1, col] + storage[row, col - coins[row - 1]];
                        }
                        else
                        {
                            storage[row, col] = storage[row - 1, col];
                        }
                    }
                }
            }

            totalCount = storage[coins.Length, targetSum];
        }
    }
}
