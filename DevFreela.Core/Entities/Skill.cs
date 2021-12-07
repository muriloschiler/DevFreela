using System;

namespace DevFreela.Core.Entities
{
    public class Skill:BaseEntity
    {

        public Skill(string description)
        {
            this.Description = description;
            this.CreatedAt = DateTime.Now;

        }
        public string Description { get; private set; }

        public DateTime CreatedAt { get; private set; }
    
    
    }
}