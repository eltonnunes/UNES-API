using System;

namespace ApiUnes.Models.Object.Bibliotecas
{
    public class Token
    {
        public static string GetUniqueKey(string login)
        {
            DateTime agora = DateTime.Now;
            string hash = agora.Ticks.ToString() + agora.Year.ToString() + agora.Month.ToString() + agora.Day.ToString() + login;
            hash += hash.GetHashCode();
            byte[] tokenData = GetBytes(hash);
            string token = Convert.ToBase64String(tokenData);
            token = token.Replace("+", "X").Replace("/", "Y").Replace("&", "Z").Replace("=", "A");
            return token.PadLeft(10);
        }

        private static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        private static string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }
    }
}