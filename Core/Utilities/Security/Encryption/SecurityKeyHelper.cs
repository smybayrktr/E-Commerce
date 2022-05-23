using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    //Stringle key oluşturamıyoruz. Byte array olmalı.
    public class SecurityKeyHelper
    {
        //appsettings de securitykey vermiştik onu byte array haline getircez.
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
