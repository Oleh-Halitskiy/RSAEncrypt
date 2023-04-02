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
        public string Encrypt(string plaintext, int[] key)
        {
            var bytes = Encoding.UTF8.GetBytes(plaintext);
            var modulus = new BigInteger(key[1]); // get the RSA modulus
            var encryptedBytes = new byte[bytes.Length * sizeof(long)];
            var publicKey = new BigInteger(key[0]);
            for (int i = 0; i < bytes.Length; i++)
            {
                var m = new BigInteger(bytes[i]);
                var c = (long)BigInteger.ModPow(m, publicKey, modulus);
                var blockBytes = BitConverter.GetBytes(c);

                // Copy the bytes of the block into the encrypted bytes array
                for (int j = 0; j < blockBytes.Length; j++)
                {
                    encryptedBytes[i * sizeof(long) + j] = blockBytes[j];
                }
            }
            return Convert.ToBase64String(encryptedBytes);
        }


        /// <summary>
        /// Decrypts the text using private key
        /// </summary>
        /// <param name="et">Encrypted text</param>
        /// <param name="key">Private key</param>
        /// <returns>Returns string of decrypted text</returns>
        public string Decrypt(string ciphertext, int[] key)
		{
            var encryptedBytes = Convert.FromBase64String(ciphertext);
            var modulus = new BigInteger(key[1]); ; // get the RSA modulus
            var decryptedBytes = new byte[encryptedBytes.Length/8];

            List<long> longs = new List<long>();
            for(int q = 0; q < encryptedBytes.Length; q+=8)
            {
                longs.Add(BitConverter.ToInt64(encryptedBytes, q));
            }

            var privateKey = new BigInteger(key[0]);

            for (int i = 0; i < longs.Count; i++)
            {
                var c = new BigInteger(longs[i]);
                var m = BigInteger.ModPow(c, privateKey, modulus);
                var mBytes = m.ToByteArray();
                decryptedBytes[i] = mBytes[mBytes.Length - 1];
            }

            RSAUtils.OutputPossibleCombinations((ulong)modulus);
            return Encoding.UTF8.GetString(decryptedBytes);
        }
    }
}

