using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelenSposa.Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        /// <summary>
        /// db kayit oncesinde kullanici sifresi icin salt ve hash degerleri olusturur
        /// </summary>
        /// <param name="password">kullanicidan alinan sifre</param>
        /// <param name="passwordHash">db de saklanacak olan encrypte edilmis parola</param>
        /// <param name="passwordSalt">hash degerini olusturuken kullanilan kullaniciya ozel deger</param>
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            //encrypte isleminde kullanacagimiz .net in bize saladigi nesneyi oluturuyoruz
            using (var hmac=new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i]!=passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}
