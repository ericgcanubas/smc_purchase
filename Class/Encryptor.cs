using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PurchasePrinting.Class
{
    class Encryptor
    {
        public static string Encrypt(string input)
        {
            StringBuilder encrypted = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                int asciiValue = (int)input[i];
                int modifier = (i % 2 == 0) ? -1 : 1;
                asciiValue += modifier * ((i + 1) % 8);
                encrypted.Append((char)asciiValue);
            }

            return encrypted.ToString();
        }

        public static string Decrypt(string input)
        {
            StringBuilder decrypted = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                int asciiValue = (int)input[i];
                int modifier = (i % 2 == 0) ? -1 : 1;
                asciiValue -= modifier * ((i + 1) % 8);
                decrypted.Append((char)asciiValue);
            }

            return decrypted.ToString();
        }

    }
}
