using System;

namespace DevFreela.Application.DTO.ViewModels
{
    public class SkillDetailsViewModel
    {

        public SkillDetailsViewModel(int id,string description, DateTime createdAt)
        {
            this.Id = id;
            this.Description = description;
            this.CreatedAt = createdAt;
        }
        public int Id { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}