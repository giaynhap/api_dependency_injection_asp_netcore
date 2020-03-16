using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using apicore.Helpers;

namespace apicore.Helpers
{
    public class JwtHelper
    {
       public static String generateToken(Dictionary<String,String> dicClaim,String secret, DateTime? Expires = null ){
             var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            int claimIndex = 0;
            var claims = new Claim[dicClaim.Count];

            foreach (var claim in dicClaim){
                     claims[claimIndex++] = new Claim(claim.Key, claim.Value);
            }
            //default expires
            if (Expires == null){
                    Expires =  DateTime.UtcNow.AddDays(7);
            }
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity( claims ),
                Expires = Expires,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}