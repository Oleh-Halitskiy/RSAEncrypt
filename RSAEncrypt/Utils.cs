using System;
namespace RSAEncrypt
{
	public class Utils
	{
        public static bool IsPrime(int number)
        {
            // Check if the number is less than 2, in which case it's not prime
            if (number < 2)
            {
                return false;
            }

            // Check if the number is 2 or 3, in which case it's prime
            if (number == 2 || number == 3)
            {
                return true;
            }

            // Check if the number is even, in which case it's not prime
            if (number % 2 == 0)
            {
                return false;
            }

            // Check if the number is divisible by any odd integer up to the square root of the number
            int maxDivisor = (int)Math.Sqrt(number);
            for (int i = 3; i <= maxDivisor; i += 2)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            // If none of the above conditions apply, the number is prime
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

