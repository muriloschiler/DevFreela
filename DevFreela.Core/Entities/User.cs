using System;
using System.Collections.Generic;
using DevFreela.Core.Enums;

namespace DevFreela.Core.Entities
{
    public class User : BaseEntity
    {

        public User(string name,string email,DateTime BirthDate)
        {
            this.Name = name;
            this.BirthDate = BirthDate;
            this.Email = email;
            
            this.CreatedAt = DateTime.Now;
            this.Skills = new List<UserSkill>();
            this.OwnedProjects = new List<Project>();
            this.FreelancerProjects = new List<Project>();
            this.UserStatus = UserStatus.Active;
            this.Comments = new List<ProjectComment>();
        }
        public string Name { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; private set; }
        public List<UserSkill> Skills {get;private set;}
        public List<Project> OwnedProjects {get;private set;} 
        public List<Project> FreelancerProjects {get; set;}
        public List<ProjectComment> Comments {get; set;} 
        public UserStatus UserStatus { get; private set; }
    }
}