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

            if (u < 0)
            {
                u += totient;
            }

            if (u == publicKey[0] || u == 1)
            {
                u += totient;
            }
            int[] privateKeyArr = new int[2];
            privateKeyArr[0] = u;
            privateKeyArr[1] = publicKey[1];
            return privateKeyArr;
        }
    }
}

