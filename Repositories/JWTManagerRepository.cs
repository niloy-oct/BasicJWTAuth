using BasicJWTAuth.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BasicJWTAuth.Repositories
{
    public class JWTManagerRepository : IJWTManagerRepository
    {
        private IConfiguration configuration;
        // make this static//
        // you use Database context to get data from db
        private Dictionary<string, string> userRecords = new Dictionary<string, string>
        {
            {"Niloy","HPLMIS"},
            {"Admin","HPLMIS123"},
            {"MIS","mis"},
        };


        public JWTManagerRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public Tokens AuthenticateTokes(User user)
        {
            if (!userRecords.Any(x => x.Key == user.UserName && x.Value == user.Password))
            {
                return null;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName)
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new Tokens { Token = tokenHandler.WriteToken(token) };
        }
    }
}
