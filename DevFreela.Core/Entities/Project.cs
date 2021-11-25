using System;
using System.Collections.Generic;
using DevFreela.Core.Enums;

namespace DevFreela.Core.Entities
{
    public class Project : BaseEntity
    {


        public Project(string title, string description, int idClient, int idFreelancer, decimal totalCost, DateTime createdAt, ProjectStatus projectStatus)
        {
            this.Title = title;
            this.Description = description;
            this.IdClient = idClient;
            this.IdFreelancer = idFreelancer;
            this.TotalCost = totalCost;

            CreatedAt = DateTime.Now;
            Comments = new List<ProjectComment>();
            this.ProjectStatus = ProjectStatus.Created;
        }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public int IdClient { get; private set; }
        public int IdFreelancer { get; private set; }
        public decimal TotalCost { get; private set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? FinishedAt { get; set; }
        public DateTime? StartedAt { get; set; }
        public ProjectStatus ProjectStatus { get; private set; }
        public List<ProjectComment> Comments { get; set; }





    }
}