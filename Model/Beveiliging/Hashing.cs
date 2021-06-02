using System;
using System.Security.Cryptography;
using System.Text;

namespace Model.Beveiliging
{
    public static class Hashing
    {
        public static string Secure_Text(string tekst)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                //From String to byte array
                byte[] sourceBytes = Encoding.UTF8.GetBytes(tekst);
                byte[] hashBytes = sha256Hash.ComputeHash(sourceBytes);
                string hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);

                Console.WriteLine("The SHA256 hash of " + tekst + " is: " + hash);
                return hash;
            }

        }

    }
}