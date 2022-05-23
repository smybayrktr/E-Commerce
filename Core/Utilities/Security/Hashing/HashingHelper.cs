using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
    //Bu sınıf Hash oluşturup hashi doğrular.
    public class HashingHelper
    {
        //Verilen şifrenin Hash ve Saltını oluşturur.
        public static void CreatePasswordHash
            (string password, out byte[] passwordHash, out byte [] passwordSalt)
            //string şifreyi vericez. passwordHash ve passwordSaltı dışarı vericez.
        {
            using (var hmac= new System.Security.Cryptography.HMACSHA512()) //Sha512 algoritması kullanıcaz.
            {
                passwordSalt = hmac.Key; //Her kullanıcı için farklı key üretir. Onu da veritabanında saklıyoruz.
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                //ComputeHash metotu hashliycek. Ama byte array haline istiyor ondan byte array haline getirdik.
            }
        }
        //PasswordHashini doğrulamak için kullanılır. Şifreyi, hashini ve saltını veriyoruz.
        //Giriş yaparken girilen passwordü aynı algoritmayı kullanarak şifreleyip
        //aynısı olur mu onu kontrol ediyoruz.
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));//Salt kullanılarak Hash hesaplanıyor.
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] !=passwordHash[i])
                    //Veritabanından gelen passwordHash ile hesaplanan Hash karşılaştırılıyor
                    //Kısaca veritabanındaki şifre ile giriş yapılırken girilen şifre aynı mı bakılıyor
                    {
                        return false;
                    }
                }
            }
            return true;
        }

    }
}
