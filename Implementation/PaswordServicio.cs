using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;
using proyecto_caldas.Data.Services;

namespace proyecto_caldas.Implementation
{
    public class PaswordServicio : IPaswordServicio
    {
        public bool CompararContrasenas(string Contrasena, string ContrasenaBD, string salt)
        {
            byte[] SaltBytes = Convert.FromBase64String(salt);
            string hashedPasswordToCheck = EncryptPassword(Contrasena, SaltBytes);
            return hashedPasswordToCheck == ContrasenaBD;
        }

        
        public string HashPassword(string password, out string Salt)
        {
            string hashedPassword;

            byte[] saltBytes = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }
            Salt = Convert. ToBase64String(saltBytes);
            hashedPassword = EncryptPassword(password, saltBytes);
            return hashedPassword;

        }
        private string EncryptPassword(string contrasena, Byte[] saltBytes)
        {
            String hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: contrasena,
                salt: saltBytes,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 1000000,
                numBytesRequested: 256 / 8));
            return hashedPassword;
        }
    }
}