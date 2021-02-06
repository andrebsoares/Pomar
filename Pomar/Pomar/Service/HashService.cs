using System;
using System.Security.Cryptography;
using System.Text;

namespace Pomar.Service
{
    public class HashService
    {
        private HashAlgorithm _algorithm;
        public HashService(HashAlgorithm algoritmo)
        {
            _algorithm = algoritmo;
        }

        public string EncryptPassword(string password)
        {
            var encodeValue = Encoding.UTF8.GetBytes(password);
            var encryptedPassword = _algorithm.ComputeHash(encodeValue);

            var passwordHash = new StringBuilder();
            foreach (var character in encryptedPassword)
                passwordHash.Append(character.ToString("X2"));

            return passwordHash.ToString();
        }

        public bool CheckPassword(string typedPassword, string registeredPassword)
        {
            if (string.IsNullOrEmpty(typedPassword))
                throw new NullReferenceException("Cadastre uma senha");

            var encryptedPassword = EncryptPassword(typedPassword);

            return encryptedPassword == registeredPassword;
        }
    }
}