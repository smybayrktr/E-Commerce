using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
        //Token Optionsu settingsi okuycaz yani
        public IConfiguration Configuration { get; } //appsettings i okumayı sağlar.
        private TokenOptions _tokenOptions; //appsettingste okuduğun değerleri bu sınıfa atayacağız.
        private DateTime _accessTokenExpiration; //Tokenin geçerlilik süresi.
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
            //appsettingsteki TokenOptions bölümünü alıp TokenOptionstaki değerlerle ilişkilendirir.

        }
        //Kullanıcı için token oluşturur.
        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            //Şu andan itibaren tokenOptionsta yazdığımız tokenExpirationdaki süreyi ekleyerek geçerlilik süresini bulur.
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            //TokenOptionstaki SecurityKeyi kullanarak SecurityKeyi oluştur dedik.
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            //Hangi algoritma ve anahtarı kullanacağını söyledik.
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            //JWT üretmek için gerekli bilgileri verdik.
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };

        }
        //JWT bilgileri vererek JWT üret dedik
        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user,
            SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user, operationClaims),
                signingCredentials: signingCredentials
            );
            return jwt;
        }
        //Kullanıcı bilgileri ve claimlerini parametre alarak claim listesi oluşturur.
        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());

            return claims;
        }
    }
}
