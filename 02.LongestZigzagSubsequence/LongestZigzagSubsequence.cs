namespace _02.LongestZigzagSubsequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class LongestZigzagSubsequence
    {
        private static int[] len;
        private static int[] prev;

        public static void Main()
        {
//            var sequence = new[] { 8, 3, 5, 7, 0, 8, 9, 10, 20, 20, 20, 12, 19, 11 };
//
//            var longestSeq = FindZigZag(sequence);
//
//            Console.WriteLine("Longest ZigZag subsequence (LZZS)");
//            Console.WriteLine("  Length: {0}", longestSeq.Length);
//            Console.WriteLine("  Sequence: [{0}]", string.Join(", ", longestSeq));

            var notes = new
            {
                Value = new
                {
                    Opponents = new List<string>() {}
                }
            };

//            if (notes.Value.Opponents.Count != 0)
//            {
//                Console.WriteLine();
//            }
//            else
//            {
//                Console.WriteLine("-opponents: (empty)");
//            }

            Console.WriteLine(notes.Value.Opponents.Count != 0
                ? $"-opponents: {string.Join(", ", notes.Value.Opponents)}"
                : "-opponents: (empty)");
        }

        public static int[] FindZigZag(int[] sequence)
        {
            len = new int[sequence.Length];
            prev = new int[sequence.Length];

            var maxLen = 0;
            var lastIndex = -1;

            for (int x = 0; x < sequence.Length; x++)
            {
                len[x] = 1;
                prev[x] = -1;

                for (int i = 0; i < x; i++)
                {
                    if (sequence[i] < sequence[x] &&
                        len[i] + 1 > len[x])
                    {
                        len[x] = len[i] + 1;
                        prev[x] = i;
                    }
                }

                if (len[x] > maxLen)
                {
                    maxLen = len[x];
                    lastIndex = x;
                }
            }

            var longestZigZagSeq = new List<int>();
            while (lastIndex != -1)
            {
                longestZigZagSeq.Add(sequence[lastIndex]);
                lastIndex = prev[lastIndex];
            }

            longestZigZagSeq.Reverse();

            return longestZigZagSeq.ToArray();
        }
    }
}
