using System;
namespace RSAEncrypt
{
	public class Utils
	{
        public bool IsPrime()
        {
            return true;
        }
        public static int GreatestCommonDivisor(int a, int b)
        {
            if (b == 0)
                return a;
            else
                return GreatestCommonDivisor(b, a % b);
        }
    }
}

