using System;

namespace DevFreela.Application.DTO.InputModels
{
    public class CreateUserInputModel
    {



        public CreateUserInputModel(string name, DateTime birthDate, string email)
        {
            this.Name = name;
            this.BirthDate = birthDate;
            this.Email = email;

        }
        public string Name { get;   set; }
        public DateTime BirthDate { get;   set; }
        public string Email { get;   set; }
    }
}