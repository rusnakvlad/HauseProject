using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BuisnesLogicLayer.DTO;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;

namespace BuisnesLogicLayer.JWTs
{
    public static class TokenManager
    {
        public static UserTokenDTO GenerateToken(UserProfileDTO userProfile, string refreshToken)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, userProfile.Id),
                new Claim(ClaimTypes.Name, userProfile.Name),
                new Claim(ClaimTypes.Surname, userProfile.Surname),
                new Claim(ClaimTypes.Email, userProfile.Email),
                new Claim(ClaimTypes.MobilePhone, userProfile.PhoneNumber),
                new Claim("AdsAmount",userProfile.AdsAmount.ToString()),
                new Claim("ComentsAmount", userProfile.ComentsAmount.ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtOptions.KEY));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddMinutes(JwtOptions.LIFETIME);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: JwtOptions.ISSUER,
                audience: JwtOptions.AUDIENCE,
                claims: claims,
                expires: expiration,
                signingCredentials: creds);

            return new UserTokenDTO() { AccessToken = new JwtSecurityTokenHandler().WriteToken(token), RefreshToken = refreshToken };
            
        }

        public static string GenerateRfreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        public static ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false, //you might want to validate the audience and issuer depending on your use case
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtOptions.KEY)),
                ValidateLifetime = false //here we are saying that we don't care about the token's expiration date
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return principal;
        }
    }
}
