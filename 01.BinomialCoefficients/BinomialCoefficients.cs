namespace _01.BinomialCoefficients
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    public static class BinomialCoefficients
    {
        public static void Main()
        {
            Console.Write("n = ");
            var n = int.Parse(Console.ReadLine());
            Console.Write("k = ");
            var k = int.Parse(Console.ReadLine());

            var binomialCoeficent = CalculateBinom(n, k, new Dictionary<Tuple<int, int>, BigInteger>());
            Console.WriteLine(binomialCoeficent);
        }

        private static BigInteger CalculateBinom(int n, int k, Dictionary<Tuple<int, int>, BigInteger> memo)
        {
            if (k == 1)
            {
                return n;
            }

            if (n == 1)
            {
                return 0;
            }

            if (!memo.ContainsKey(new Tuple<int, int>(n, k)))
            {
                memo.Add(
                    new Tuple<int, int>(n, k), 
                    CalculateBinom(n - 1, k - 1, memo) + CalculateBinom(n - 1, k, memo));;
            }

            return memo[new Tuple<int, int>(n, k)];
        }
    }
}