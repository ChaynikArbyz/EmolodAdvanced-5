using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEncryptor
{
    internal static class CezarEncryptor
    {

        public static string Encrypt(string text, int numb, string alphabet)
        {
            text = text.ToLower();
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentException("Текст не може бути пустим");
            }
            if (numb < -alphabet.Length || numb > alphabet.Length)
            {
                throw new ArgumentException("Зсув не може бути Більшим за алфавіт");
            }
            foreach (char c in text)
            {
                if (!alphabet.Contains(c))
                {
                    throw new ArgumentException($"Символ '{c}' не входить до вашого алфавіту");
                }
            }

            char[] encrypted = new char[text.Length];
            for (int i = 0; i < text.Length; i++)
            {
                int index = alphabet.IndexOf(text[i]);
                int newindex = (index + numb) % alphabet.Length;
                if (newindex < 0)
                    newindex += alphabet.Length;
                encrypted[i] = alphabet[newindex];
            }
            return new string(encrypted);
        }
        public static string Decrypt(string text, int shift, string alphabet)
        {
            return Encrypt(text, -shift, alphabet);
        }
    }
}
