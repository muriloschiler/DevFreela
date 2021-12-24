using System;
using System.Collections.Generic;
using DevFreela.Core.Entities;
using DevFreela.Core.Enums;

namespace DevFreela.Application.Queries.GetProjectById
{
    public class ProjectDetailsViewModel
    {

        public ProjectDetailsViewModel( int id,string title, string description, int idClient,
                                        string clientName,string clientEmail, 
                                        int? idFreelancer,string freelancerName,string freelancerEmail,
                                        decimal totalCost, DateTime createdAt,DateTime? finishedAt,
                                        DateTime? startedAt,ProjectStatus projectStatus,
                                        List<ProjectComment> comments)
        {
            this.Id = id;
            this.Title = title;
            this.Description = description;
            this.IdClient = idClient;
            this.ClientName=clientName;
            this.ClientEmail=clientEmail;
            this.IdFreelancer = idFreelancer;
            this.FreelancerName=freelancerName;
            this.FreelancerEmail=FreelancerEmail;
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
        public string ClientName { get; private set; }
        public string ClientEmail { get; private set; }
        public int? IdFreelancer { get; private set; }
        public string FreelancerName { get; private set; }
        public string FreelancerEmail { get; private set; }
        public decimal TotalCost { get; private set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? FinishedAt { get; set; }
        public DateTime? StartedAt { get; set; }
        public ProjectStatus ProjectStatus { get; private set; }
        public List<ProjectComment> Comments { get; set; }
    }
}