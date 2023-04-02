using System.Net.Http.Headers;
using System.Numerics;

namespace RSAEncrypt;
class Program
{
    static void Main(string[] args)
    {
     //   Console.WriteLine("Modulus " + RSAUtils.CalculateModulus(509, 587));
     //   Console.WriteLine("Totient " + RSAUtils.CalculateTotient(509, 587));
        int[] test = RSAUtils.CalculatePublicKey(297688, 298783);
        int[] test1 = RSAUtils.CalculatePrivateKey(297688, test);

       // Console.WriteLine(BigInteger.ModPow(97, 3, 298783));

        EncryptorRSA encryptorRSA = new EncryptorRSA();
        var s = encryptorRSA.Encrypt("Oleh is super happy pls, recomend this to your friends, I probably made a mistake!", test);
        Console.WriteLine(s);
        var b = encryptorRSA.Decrypt(s, test1);
        Console.WriteLine(b);
    //    Console.WriteLine(BigInteger.ModPow(100, 3, 298783));
    //    Console.WriteLine(BigInteger.ModPow(103651, 198459, 298783));
        Console.ReadKey();
    }
}

