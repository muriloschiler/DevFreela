using System;
using System.Collections.Generic;

namespace DevFreela.Core.Entities
{
    public class Skill:BaseEntity
    {

        public Skill(string description)
        {
            this.Description = description;
            this.CreatedAt = DateTime.Now;
            this.Users = new List<UserSkill>();
        }
        public string Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public List<UserSkill> Users { get; set; }
        
        

    
    
    }
}