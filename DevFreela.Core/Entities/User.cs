using System;
using System.Collections.Generic;
using DevFreela.Core.Enums;

namespace DevFreela.Core.Entities
{
    public class User : BaseEntity
    {

        public  User(string name,string password , UserRole role , DateTime BirthDate ,string email)
        {
            this.Name = name;
            this.Password=password;
            this.Role=role;
            this.BirthDate = BirthDate;
            this.Email = email;
            
            this.CreatedAt = DateTime.Now;
            this.UserStatus = UserStatus.Active;
            this.Comments = new List<ProjectComment>();
            
            if(role == UserRole.client)
                this.OwnedProjects = new List<Project>();
            else
            {
                this.FreelancerProjects = new List<Project>();
                this.Skills = new List<UserSkill>();
            }
        }
        public string Name { get; private set; }
        public string Password { get; private set; }
        public UserRole Role { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Email { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public List<ProjectComment> Comments {get; private set;} 
        public UserStatus UserStatus { get; private set; }
        public List<Project> OwnedProjects {get;private set;} 
        public List<Project> FreelancerProjects {get; private set;}
        public List<UserSkill> Skills {get;private set;}
        public void SetSkills(int idSkill){    
            this.Skills.Add(new UserSkill(this.Id,idSkill));
        }
    
    } 
}