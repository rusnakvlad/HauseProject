using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnesLogicLayer.JWTs
{
    public class JwtOptions
    {
        public const string ISSUER = "https://localhost:44365"; 
        public const string AUDIENCE = "https://localhost:44328"; 
        public const string KEY = "ThEHouseSeCRetKeyOfJwTtoUseItONReQuEStwiTHaUtHoriZE";   
        public const int LIFETIME = 15;

        public static bool ValidateLifeTime( DateTime? notBefore, DateTime? expires, SecurityToken tokenToValidate, TokenValidationParameters @param )
        {
            return (expires != null && expires > DateTime.UtcNow);
        }
    }
}
