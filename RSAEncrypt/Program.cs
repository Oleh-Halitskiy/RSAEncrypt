using System.Net.Http.Headers;
using System.Numerics;

namespace RSAEncrypt;
class Program
{
    static void Main(string[] args)
    {
        //DEMO DEMO DEMO
        string input = "0";
        string path = "D:\\MyFolder\\RSA\\";
        EncryptorRSA encryptorRSA = new EncryptorRSA();
        while (input != "q")
        {
            Console.WriteLine("1. Encrypt\n2. Decrypt\n3. q for exit");
            input = Console.ReadLine();
            if (input == "1")
            {
                Console.Write("Enter first prime number: ");
                int q = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter second prime number: ");
                int p = Convert.ToInt32(Console.ReadLine());

                if(!Utils.IsPrime(q) || !Utils.IsPrime(p))
                {
                    Console.WriteLine("One of the numbers is not prime, aborting");
                    return;
                }
                int modulus = RSAUtils.CalculateModulus(q, p);
                int totient = RSAUtils.CalculateTotient(q, p);
                Console.WriteLine("Modulus - " + modulus);
                Console.WriteLine("Totient - " + totient);

                int[] publicKey = RSAUtils.CalculatePublicKey(totient, modulus);
                int[] privateKey = RSAUtils.CalculatePrivateKey(totient, publicKey);

                Console.WriteLine($"Public key: {publicKey[0]}, {publicKey[1]}");
                Console.WriteLine($"Private key: {privateKey[0]}, {privateKey[1]}");

                Console.Write("Enter text to encrypt: ");
                string plaintext = Console.ReadLine();
                string ciphertext = encryptorRSA.Encrypt(plaintext, publicKey);
                Console.WriteLine(ciphertext);
                Console.WriteLine("Saving to the cipher.txt in D:\\MyFolder\\RSA");
                FileManager.SaveFile(ciphertext, path + "cipher.txt");
                Console.WriteLine("Saving public key to the pkey.txt in D:\\MyFolder\\RSA");
                FileManager.SaveFile($"Public key: {publicKey[0]}, {publicKey[1]}", path + "pkey.txt");
            }
            else if (input == "2")
            {
                int[] privateKey = new int[2];
                Console.Write("Enter file name containing cipher text in RSA folder: ");
                string filename = Console.ReadLine();
                string ciphertext = FileManager.ReadFile(path + filename);
                Console.Write("Enter the private key: ");
                privateKey[0] = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter the modulus of private key: ");
                privateKey[1] = Convert.ToInt32(Console.ReadLine());
                string plaintext = encryptorRSA.Decrypt(ciphertext, privateKey);
                Console.WriteLine($"Plaintext: {plaintext}");
            }
            else if (input == "q")
            {
                return;
            }
            else
            {
                Console.WriteLine("Wrong input");
            }
        }
    }
}

