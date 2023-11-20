using Microsoft.IdentityModel.Tokens;
using MyGlobalProject.Infrastructure.Token;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TokenGenerateAPI.Model;

namespace TokenGenerateAPI.Service
{
    public class TokenService : ITokenService
    {
        private DateTime _accessTokenExpiration;
        public AccessToken CreateAccessToken(TokenOptions tokenOptions, UserTokenDTO user, RoleTokenDTO role)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(tokenOptions.AccessTokenExpiration);
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email,user.EMail),
                new Claim(ClaimTypes.Role,role.Name),
                new Claim(ClaimTypes.Name,user.FirstName),
                new Claim(ClaimTypes.MobilePhone,user.PhoneNumber)
            };

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey));

            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var jwt = CreateJwtToken(tokenOptions, signingCredentials, claims);

            JwtSecurityTokenHandler securityTokenHandler = new JwtSecurityTokenHandler();
            var token = securityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };
        }

        private JwtSecurityToken CreateJwtToken(TokenOptions tokenOptions, SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwt = new JwtSecurityToken(
                audience: tokenOptions.Audience,
                issuer: tokenOptions.Issuer,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                signingCredentials: signingCredentials,
                claims: claims);

            return jwt;
        }
    }
}
