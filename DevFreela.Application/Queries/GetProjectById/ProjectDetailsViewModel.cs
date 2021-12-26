using System;
using System.Collections.Generic;
using DevFreela.Core.Entities;
using DevFreela.Core.Enums;

namespace DevFreela.Application.Queries.GetProjectById
{
    public class ProjectDetailsViewModel
    {

        public ProjectDetailsViewModel( int id,string title, string description, 
                                        int idClient,User client,
                                        int? idFreelancer,User freelancer,
                                        decimal totalCost, DateTime createdAt,DateTime? finishedAt,
                                        DateTime? startedAt,ProjectStatus projectStatus,
                                        List<ProjectComment> comments)
        {
            this.Id = id;
            this.Title = title;
            this.Description = description;
            this.IdClient = idClient;
            this.Client = client;
            this.IdFreelancer = idFreelancer;
            this.Freelancer = freelancer;
            this.TotalCost = totalCost;
            this.CreatedAt = createdAt;
            this.FinishedAt = finishedAt;
            this.StartedAt = startedAt;
            this.ProjectStatus = projectStatus;
            this.Comments = comments;
        }
        public int Id { get; set; }
        
        
        public string Title { get; private set; }
        public string Description { get; private set; }
        public int IdClient { get; private set; }
        public User Client { get; set; }
        public int? IdFreelancer { get; private set; }
        public User Freelancer { get; private set; }
        public decimal TotalCost { get; private set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? FinishedAt { get; set; }
        public DateTime? StartedAt { get; set; }
        public ProjectStatus ProjectStatus { get; private set; }
        public List<ProjectComment> Comments { get; set; }
    }
}