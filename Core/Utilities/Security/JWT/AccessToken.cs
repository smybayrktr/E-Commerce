using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    //Tokenın Özellikleri. JWTnin kendisi.
    //Kullanıcı bize kullanıcı adı ve parola verecek bizde ona token ve biriş süresini vericez.
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; } //Tokenin geçerliliğinin bitiş süresi
    }
}
