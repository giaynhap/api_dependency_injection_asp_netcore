using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using apicore.Helpers;

namespace apicore.Domain.Services
{
    public class UserService:IUserService
    {
        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings){
                this._appSettings = appSettings.Value;
        }
        public  bool Authenticate(string username, string password){

            return false;
        }

       
    }
}