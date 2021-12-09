using System;
using System.Collections.Generic;
using DevFreela.Core.Enums;

namespace DevFreela.Core.Entities
{
    public class Project : BaseEntity
    {


        public Project(string title, string description, int idClient, int idFreelancer, decimal totalCost)
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
        public User Client { get; set; }
        public int? IdFreelancer { get; private set; }
        public User Freelancer { get; set; }
        public decimal TotalCost { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? FinishedAt { get; private set; }
        public DateTime? StartedAt { get; private set; }
        public ProjectStatus ProjectStatus { get; private set; }
        public List<ProjectComment> Comments { get; private set; }
    
        public void Cancel(){
            if(this.ProjectStatus == ProjectStatus.InProgress)
                this.ProjectStatus = ProjectStatus.Cancelled;
        }
        public void Start(){
            if(this.ProjectStatus == ProjectStatus.Created){
                this.ProjectStatus = ProjectStatus.InProgress;
                this.StartedAt = DateTime.Now;
            }
        }
        public void Finish(){
            if(this.ProjectStatus == ProjectStatus.InProgress){
                this.ProjectStatus = ProjectStatus.Finished;
                this.FinishedAt = DateTime.Now;
            }
        }
    }
}