using System;
using System.Security.Cryptography;

namespace TaskMaster.Helpers
{
    public static class PasswordHelper
    {
        /// <summary>
        /// Hash le mot de passe en générant un sel aléatoire et en utilisant PBKDF2.
        /// Le résultat combine le sel et le hash, encodé en Base64.
        /// </summary>
        public static string HashPassword(string password)
        {
            // Générer un sel de 16 octets
            byte[] salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            // Utilisation de PBKDF2 (ici 10 000 itérations)
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000))
            {
                byte[] hash = pbkdf2.GetBytes(20);

                // Combiner le sel et le hash dans un tableau de 36 octets
                byte[] hashBytes = new byte[36];
                Array.Copy(salt, 0, hashBytes, 0, 16);
                Array.Copy(hash, 0, hashBytes, 16, 20);

                // Retourner le tout encodé en Base64
                return Convert.ToBase64String(hashBytes);
            }
        }

        /// <summary>
        /// Vérifie qu’un mot de passe correspond bien au hash stocké.
        /// </summary>
        public static bool VerifyPassword(string storedHash, string passwordToCheck)
        {
            // Récupérer les octets du hash stocké
            byte[] hashBytes = Convert.FromBase64String(storedHash);

            // Le sel est stocké dans les 16 premiers octets
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            // Calculer le hash pour le mot de passe fourni avec le sel récupéré
            using (var pbkdf2 = new Rfc2898DeriveBytes(passwordToCheck, salt, 10000))
            {
                byte[] hash = pbkdf2.GetBytes(20);

                // Comparer chaque octet
                for (int i = 0; i < 20; i++)
                {
                    if (hashBytes[i + 16] != hash[i])
                        return false;
                }
            }

            return true;
        }
    }
}
