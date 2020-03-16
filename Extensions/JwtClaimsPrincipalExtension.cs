
using System.ComponentModel;
using System.Reflection;
using System.Security.Claims;
using System.Linq;
using System;
namespace apicore.Extensions{
    public static class JwtClaimsPrincipal
    {
        public static string getClaimValue(this ClaimsPrincipal value,string key)
        { 
            if (value.HasClaim(c => c.Type == key))  
            {  
                return value.Claims.FirstOrDefault(c => c.Type == key).Value;
            }  
            return null;
        }
        public static int? claimToInt(this ClaimsPrincipal value,string key)
        {
            if (value.HasClaim(c => c.Type == key))  
            {  
                return  Convert.ToInt32(value.Claims.FirstOrDefault(c => c.Type == key).Value);
            }  
            return null;
        }
         public static long? claimToLong(this ClaimsPrincipal value,string key)
        {
            if (value.HasClaim(c => c.Type == key))  
            {  
                return  Convert.ToInt64(value.Claims.FirstOrDefault(c => c.Type == key).Value);
            }  
            return null;
        }

        public static string statusCodeMessage(this int status){
            switch(status){
                case 404:
                    return "Not found";
                case 401:
                    return "Unauthorized";
                case 501:
                    return "Internal Server Error";
                case 403:
                    return "Bad request";
            }
            return null;
        }
        


    }

}