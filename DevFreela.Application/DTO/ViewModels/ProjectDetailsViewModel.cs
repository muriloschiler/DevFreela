using System;
using System.Collections.Generic;
using DevFreela.Core.Entities;
using DevFreela.Core.Enums;

namespace DevFreela.Application.DTO.ViewModels
{
    public class ProjectDetailsViewModel
    {

        public ProjectDetailsViewModel( string title, string description, int idClient,int? idFreelancer, 
                                        decimal totalCost, DateTime createdAt,DateTime? finishedAt, 
                                        DateTime? startedAt ,ProjectStatus projectStatus,
                                        List<ProjectComment> comments)
        {
            this.Title = title;
            this.Description = description;
            this.IdClient = idClient;
            this.IdFreelancer = idFreelancer;
            this.TotalCost = totalCost;
            this.CreatedAt = createdAt;
            this.FinishedAt = finishedAt;
            this.StartedAt = startedAt;
            this.ProjectStatus = projectStatus;
            this.Comments = comments;
        }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public int IdClient { get; private set; }
        public int? IdFreelancer { get; private set; }
        public decimal TotalCost { get; private set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? FinishedAt { get; set; }
        public DateTime? StartedAt { get; set; }
        public ProjectStatus ProjectStatus { get; private set; }
        public List<ProjectComment> Comments { get; set; }
    }
}