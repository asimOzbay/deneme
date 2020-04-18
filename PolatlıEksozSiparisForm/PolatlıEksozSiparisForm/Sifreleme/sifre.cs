using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace PolatlıEksozSiparisForm.Sifreleme
{
    public class sifre
    {
        public string GetHash(string input)
        {
            SHA256 sifreAlgoritmasi = SHA256.Create();
            byte[] data = sifreAlgoritmasi.ComputeHash(Encoding.UTF8.GetBytes(input));

            var sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        public bool VerifyHash(string input, string hash)
        {
            SHA256 sifreAlgoritmasi = SHA256.Create();

            var hashOfInput = GetHash(input);

            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            return comparer.Compare(hashOfInput, hash) == 0;
        }
    }
}