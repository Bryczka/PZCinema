﻿using System.Security.Cryptography;
using System.Text;

namespace ClientCinemaApp
{
    public class Crypto
    {
        public static byte[] Hash(string passwordToHash)
        {
            using (var alg = SHA256.Create())
            {
                alg.ComputeHash(Encoding.UTF8.GetBytes(passwordToHash));
                return alg.Hash;
            }
        }
    }
}
