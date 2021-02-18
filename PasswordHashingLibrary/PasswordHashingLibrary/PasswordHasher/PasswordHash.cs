using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordHashingLibrary.Helper.PasswordHasher
{
    public class PasswordHash
    {
        /// <summary>
        /// Helper method for hashing password and creating a password salt
        /// </summary>
        /// <param name="password">password to be hashed</param>
        /// <param name="passwordHash">the password hash</param>
        /// <param name="passwordSalt">the password salt</param>
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.",
                 "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        /// <summary>
        /// verifieds if the password has been successfully hashed
        /// </summary>
        /// <param name="password">password string to be hashed</param>
        /// <param name="storedHash">hash of the password string</param>
        /// <param name="storedSalt">salt of the password string</param>
        /// <returns></returns>
        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.",
                 "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password (64 bytes expected).",
                 "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid lenght of password salt (128 bytes expected).",
                 "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;

        }
    }
}
