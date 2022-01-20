using System;
using DevFreela.Core.Enums;

namespace DevFreela.Application.DTO.InputModels
{
    public class CreateUserInputModel
    {

        public CreateUserInputModel(string name,string password, UserRole role,DateTime birthday,string email)
        {
            this.Name=name;
            this.Password = password;
            this.Role = role;
            this.BirthDate=birthday;
            this.Email=email;
        }
        public string Name { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
    }
}