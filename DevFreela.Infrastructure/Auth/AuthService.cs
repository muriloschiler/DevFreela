using DevFreela.Core.IAuth;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace DevFreela.Infrastructure.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        public AuthService(IConfiguration configuration)
        {
            _configuration=configuration;
        }
        public string GenerateJWTToken(string email,string role)
        {
            var key = _configuration["JWT:Key"];
            var issuer = _configuration["JWT:Issuer"];
            var audience = _configuration["JWT:Audience"];
            var credentials = new SigningCredentials
            (
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                SecurityAlgorithms.HmacSha256
            );
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,email),
                new Claim(ClaimTypes.Role,role)                
            };
            
            var token = new JwtSecurityToken
            (   issuer:issuer,audience:audience,claims:claims,
                expires:DateTime.Now.AddHours(8),
                signingCredentials:credentials
            );                                
            var tokenHandler= new JwtSecurityTokenHandler();
            var stringToken = tokenHandler.WriteToken(token);       

            return stringToken;
        }
    }
}