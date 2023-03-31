namespace RSAEncrypt;
class Program
{
    static void Main(string[] args)
    {
        int[] test = RSAUtils.CalculatePublicKey(6, 14);
        int[] test1 = RSAUtils.CalculatePrivateKey(6, test);
        int[] test2 = new int[2];
        test2[0] = 11;
        test2[1] = 14;
        foreach(int i in test)
        {
            Console.WriteLine(i);
        }
        EncryptorRSA encryptorRSA = new EncryptorRSA();
        var s = encryptorRSA.Encrypt("d", test);
        Console.WriteLine(s);
        var b = encryptorRSA.Decrypt(s, test2);
        Console.WriteLine(b);
        Console.ReadKey();

    }
}

