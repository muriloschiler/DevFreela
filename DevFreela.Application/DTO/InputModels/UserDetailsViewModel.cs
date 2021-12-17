using System;
using System.Collections.Generic;
using DevFreela.Core.Entities;
using DevFreela.Core.Enums;

namespace DevFreela.Application.DTO.InputModels
{
    public class UserDetailsViewModel
    {
        public string Name { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Email { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public List<UserSkill> Skills {get;private set;}
        public List<Project> OwnedProjects {get;private set;} 
        public List<Project> FreelancerProjects {get; private set;}
        public List<ProjectComment> Comments {get; private set;} 
        public UserStatus UserStatus { get; private set; }
    }
}