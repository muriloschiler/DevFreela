using DevFreela.Core.IAuth;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
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

        public string ComputeSha256Hash(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - retorna byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Converte byte array para string   
                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2")); // x2 faz com que seja convertido em representação hexadecimal
                }

                return builder.ToString();
            }
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
            (   issuer:issuer,
                audience:audience,
                claims:claims,
                expires:DateTime.Now.AddHours(8),
                signingCredentials:credentials
            );                                
            var tokenHandler= new JwtSecurityTokenHandler();
            var stringToken = tokenHandler.WriteToken(token);       

            return stringToken;
        }
    }
}