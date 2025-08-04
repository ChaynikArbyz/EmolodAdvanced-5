using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TextEncryptor
{
    internal static class VijenerEncryptor
    {
        public static string Encrypt(string text, string key, string alphabet)
        {
            text = text.ToLower();
            key = key.ToLower();
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("Текст та ключ не можуть бути пустими");
            }
            foreach (char c in text)
            {
                if (!alphabet.Contains(c))
                {
                    throw new ArgumentException($"Символ '{c}' не входить до вашого алфавіту");
                }
            }
            foreach (char c in key)
            {
                if (!alphabet.Contains(c))
                {
                    throw new ArgumentException($"Символ ключа '{c}' не входить до вашого алфавіту");
                }
            }
            string result = "";
            for (int i = 0, j = 0; i < text.Length; i++)
            {
                if (alphabet.Contains(text[i]))
                {
                    int index = alphabet.IndexOf(text[i]);
                    int keyIndex = alphabet.IndexOf(key[j % key.Length]);
                    int newindex = (index + keyIndex) % alphabet.Length;
                    result += alphabet[newindex];
                    j++;
                }
                else
                {
                    result += text[i];
                }
            }
            return result;
        }
        public static string Decrypt(string text, string key, string alphabet)
        {
            text = text.ToLower();
            key = key.ToLower();
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("Текст та ключ не можуть бути пустими");
            }
            foreach (char c in text)
            {
                if (!alphabet.Contains(c))
                {
                    throw new ArgumentException($"Символ '{c}' не входить до вашого алфавіту");
                }
            }
            foreach (char c in key)
            {
                if (!alphabet.Contains(c))
                {
                    throw new ArgumentException($"Символ ключа '{c}' не входить до вашого алфавіту");
                }
            }
            string result = "";
            for (int i = 0, j = 0; i < text.Length; i++)
            {
                if (alphabet.Contains(text[i]))
                {
                    int index = alphabet.IndexOf(text[i]);
                    int keyIndex = alphabet.IndexOf(key[j % key.Length]);
                    int newindex = (index - keyIndex + alphabet.Length) % alphabet.Length;
                    result += alphabet[newindex];
                    j++;
                }
                else
                {
                    result += text[i];
                }
            }
            return result;
        }
    }
}
        