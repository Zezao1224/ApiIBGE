using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace ApiIBGE.util
{
    public class ClsUtil
    {
        internal static Token GerarTokenJWT(string key)
        {
            var expiry = DateTime.Now.AddMinutes(120);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(expires: DateTime.Now.AddMinutes(120), signingCredentials: credentials);
            var tokenHandler = new JwtSecurityTokenHandler();
            var stringToken = tokenHandler.WriteToken(token);
            Token _token = new Token(stringToken.ToString());
            return _token;
        }
        public class Token
        {
            public string Bearer { get; set; }

            public Token(string bearer)
            {
                Bearer = bearer;
            }
        }
    }
}
