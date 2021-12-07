using System;
using System.Collections.Generic;
using DevFreela.Core.Entities;
using DevFreela.Core.Enums;

namespace DevFreela.Application.DTO.ViewModels
{
    public class ProjectViewModel
    {

        public ProjectViewModel(int id, string title, string description, int idClient, int? freelancer, decimal totalCost, ProjectStatus projectStatus)
        {
            this.Id = id;
            this.Title = title;
            this.Description = description;
            this.IdClient = idClient;
            this.IdFreelancer = freelancer;
            this.TotalCost = totalCost;
            this.ProjectStatus = projectStatus;

        }
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public int IdClient { get; private set; }
        public int? IdFreelancer { get; private set; }
        public decimal TotalCost { get; private set; }
        public ProjectStatus ProjectStatus { get; private set; }
    }
}