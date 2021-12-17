using System;

namespace DevFreela.Application.DTO.InputModels
{
    public class CreateUserInputModel
    {



        public CreateUserInputModel(string name, DateTime myProperty, string email)
        {
            this.Name = name;
            this.MyProperty = myProperty;
            this.Email = email;

        }
        public string Name { get; private set; }
        public DateTime MyProperty { get; private set; }
        public string Email { get; private set; }
    }
}