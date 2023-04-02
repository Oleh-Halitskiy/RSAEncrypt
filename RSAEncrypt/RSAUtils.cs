using System;
namespace RSAEncrypt
{
	public class RSAUtils
	{
        public static int CalculateModulus(int p, int q) => p * q;

        public static int CalculateTotient(int p, int q) => (q - 1) * (p - 1);

        public static int[] CalculatePublicKey(int totient, int modulus)
        {
            int[] key = new int[2]; 
            int publicKey = 0;
            for (int i = 2; i < totient; i++)
            {
                if (Utils.GreatestCommonDivisor(i, totient) == 1)
                {
                    publicKey = i;
                    break;
                }
            }
            key[0] = publicKey;
            key[1] = modulus;
            return key;
        }
        public static int[] CalculatePrivateKey(int totient, int[] publicKey)
        {
            int m = totient, n = publicKey[0], t;
            int q, r, u = 0, v = 1;

            // Calculate the modular inverse of n modulo m using the extended Euclidean algorithm
            while (n > 0)
            {
                q = m / n;
                r = m % n;

                t = u - q * v;
                u = v;
                v = t;

                m = n;
                n = r;
            }

            // Make sure the private key is positive and not equal to the public key
            if (u < 0)
            {
                u += totient;
            }

            if (u == publicKey[0] || u == 1)
            {
                u += totient;
            }
            // Create an array to hold the private key components and return it
            int[] privateKeyArr = new int[2];
            privateKeyArr[0] = u;
            privateKeyArr[1] = publicKey[1];
            return privateKeyArr;
        }
        public static void OutputPossibleCombinations(ulong modulus)
        {
            ulong[][] combinations = Combinations(PrimeFactorization(modulus));

            foreach (ulong[] combination in combinations)
            {
                Console.WriteLine(string.Join(" * ", combination));
            }
        }
        private static ulong[] PrimeFactorization(ulong n)
        {
            // Compute the prime factorization of n using trial division
            ulong[] factors = new ulong[0];
            for (ulong i = 2; i <= n; i++)
            {
                while (n % i == 0)
                {
                    Array.Resize(ref factors, factors.Length + 1);
                    factors[factors.Length - 1] = i;
                    n /= i;
                }
            }
            return factors;
        }
        private static ulong[][] Combinations(ulong[] factors)
        {
            // Compute all possible combinations of factors
            int numCombinations = (int)Math.Pow(2, factors.Length) - 1;
            ulong[][] combinations = new ulong[numCombinations][];
            for (int i = 0; i < numCombinations; i++)
            {
                int mask = i + 1;
                int numFactors = 0;
                for (int j = 0; j < factors.Length; j++)
                {
                    if ((mask & (1 << j)) != 0)
                        numFactors++;
                }
                combinations[i] = new ulong[numFactors];
                int index = 0;
                for (int j = 0; j < factors.Length; j++)
                {
                    if ((mask & (1 << j)) != 0)
                    {
                        combinations[i][index] = factors[j];
                        index++;
                    }
                }
            }
            return combinations;
        }
    }
}

