using System;
using System.Numerics;
using System.Text;

namespace RSAEncrypt
{
	public class EncryptorRSA
	{
        /// <summary>
        /// Decrypts the text using private key
        /// </summary>
        /// <param name="pt">Plain text</param>
        /// <param name="key">Public key</param>
        /// <returns>Returns string of encrypted text</returns>
        /// <exception cref="NotImplementedException"></exception>
        public byte[] Encrypt(string plaintext, int[] key)
        {
            var bytes = Encoding.UTF8.GetBytes(plaintext);
            var modulus = key[1];
            var encryptedBytes = new byte[bytes.Length];
            var publicKey = new BigInteger(key[0]);
            var n = new BigInteger(modulus);

            for (int i = 0; i < bytes.Length; i++)
            {
                var m = new BigInteger(bytes[i]);
                var c = BigInteger.ModPow(m, publicKey, n);
                encryptedBytes[i] = (byte)c;
            }

            return encryptedBytes;
        }


        /// <summary>
        /// Decrypts the text using private key
        /// </summary>
        /// <param name="et">Encrypted text</param>
        /// <param name="key">Private key</param>
        /// <returns>Returns string of decrypted text</returns>
        /// <exception cref="NotImplementedException"></exception>
        public string Decrypt(byte[] ciphertext, int[] key)
		{
            var encryptedBytes = ciphertext;
            var modulus = key[1];
            var decryptedBytes = new byte[encryptedBytes.Length];
            var privateKey = new BigInteger(key[0]);
            var n = new BigInteger(modulus);
         //   var totient = GetTotient(n);

            for (int i = 0; i < encryptedBytes.Length; i++)
            {
                var c = new BigInteger(encryptedBytes[i]);
                var m = BigInteger.ModPow(c, privateKey, n);
                decryptedBytes[i] = (byte)m;
            }

            var plaintext = Encoding.UTF8.GetString(decryptedBytes);
            return plaintext;
        }
    }
}

