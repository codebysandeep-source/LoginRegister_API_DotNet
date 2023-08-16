using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace BAL.Configuration
{
    public class PasswordManager
    {

        public string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                var hashedPassword = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                return hashedPassword;
            }
        }


        public bool VerifyPassword(string enteredPassword, string storedHashedPassword)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(enteredPassword));
                var enteredHashedPassword = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();

                return (enteredHashedPassword == storedHashedPassword);
            }
        }


    }
}
