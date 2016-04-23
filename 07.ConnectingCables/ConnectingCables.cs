namespace _07.ConnectingCables
{
    using System;
    using System.Collections.Generic;

    public static class ConnectingCables
    {
        public static void Main()
        {
            var sideA = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var sideB = new[] { 2, 5, 3, 8, 7, 4, 6, 9, 1 };

            var connectedCables = FindMaximumConnectedCables(sideA, sideB);
            var connectedCablesCount = connectedCables.Length;

            Console.WriteLine($"Maximum pairs connected: {connectedCablesCount}");
            Console.WriteLine($"Connected pairs: {string.Join(", ", connectedCables)}");
        }

        private static int[] FindMaximumConnectedCables(int[] sideA, int[] sideB)
        {
            var sideALength = sideA.Length + 1;
            var sideBLength = sideB.Length + 1;
            var memoMatrix = new int[sideALength, sideBLength];

            for (int row = 1; row < sideALength; row++)
            {
                for (int col = 1; col < sideBLength; col++)
                {
                    if (sideA[row - 1] == sideB[col - 1])
                    {
                        memoMatrix[row, col] = memoMatrix[row - 1, col - 1] + 1;
                    }
                    else
                    {
                        memoMatrix[row, col] = Math.Max(memoMatrix[row - 1, col], memoMatrix[row, col - 1]);
                    }
                }
            }

            return RetrieveConnections(sideA, sideB, memoMatrix);
        }

        private static int[] RetrieveConnections(int[] sideA, int[] sideB, int[,] memoMatrix)
        {
            var row = sideA.Length;
            var col = sideB.Length;

            var cables = new List<int>();
            while (row > 0 && col > 0)
            {
                if (sideA[row - 1] == sideB[col - 1])
                {
                    cables.Add(sideA[row - 1]);
                    row--;
                    col--;
                }
                else
                {
                    if (memoMatrix[row - 1, col] > memoMatrix[row, col - 1])
                    {
                        row--;
                    }
                    else
                    {
                        col--;
                    }
                }
            }

            cables.Reverse();
            return cables.ToArray();
        }
    }
}
