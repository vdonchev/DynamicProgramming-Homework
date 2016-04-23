namespace _03.DividingPresents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class DividingPresents
    {
        public static void Main()
        {
            var presents = new[] { 3, 2, 3, 2, 2, 77, 89, 23, 90, 11 };

            var allpresentsSum = presents.Sum();
            var halfPresentsSum = allpresentsSum / 2;

            var alanPresents = SplitPresents(presents, halfPresentsSum);

            var alanPresentsSum = alanPresents.Sum();
            var bobPresentsSum = allpresentsSum - alanPresentsSum;
            var presentDifference = Math.Abs(alanPresentsSum - bobPresentsSum);

            Console.WriteLine($"Difference: {presentDifference}");
            Console.WriteLine($"Alan: {alanPresentsSum} Bob: {bobPresentsSum}");
            Console.WriteLine($"Alan takes: {string.Join(", ", alanPresents)}");
            Console.WriteLine("Bob takes the rest.");
        }

        private static int[] SplitPresents(int[] presents, int target)
        {
            var rows = presents.Length;
            var cols = target + 1;

            var isPresentTaken = new bool[rows, cols];
            var presentsSum = new int[rows, cols];

            for (int col = 0; col < cols; col++)
            {
                if (presents[0] <= col)
                {
                    presentsSum[0, col] = presents[0];
                    isPresentTaken[0, col] = true;
                }
            }

            for (int row = 1; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    presentsSum[row, col] = presentsSum[row - 1, col];
                    var remainingPresents = col - presents[row];
                    if (remainingPresents >= 0)
                    {
                        var possibleMaxPresents = presentsSum[row - 1, remainingPresents] + presents[row];
                        if (possibleMaxPresents > presentsSum[row, col])
                        {
                            presentsSum[row, col] = possibleMaxPresents;
                            isPresentTaken[row, col] = true;
                        }
                    }
                }
            }

            var presentsTaken = new List<int>();
            int itemIndex = presents.Length - 1;
            while (itemIndex >= 0)
            {
                if (isPresentTaken[itemIndex, target])
                {
                    target -= presents[itemIndex];
                    presentsTaken.Insert(0, presents[itemIndex]);
                }

                itemIndex--;
            }

            return presentsTaken.ToArray();
        }
    }
}
