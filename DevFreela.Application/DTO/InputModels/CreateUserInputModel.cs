using System;

namespace DevFreela.Application.DTO.InputModels
{
    public class CreateUserInputModel
    {



        public CreateUserInputModel(string name, DateTime BirthDate, string email)
        {
            this.Name = name;
            this.BirthDate = BirthDate;
            this.Email = email;

        }
        public string Name { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Email { get; private set; }
    }
}