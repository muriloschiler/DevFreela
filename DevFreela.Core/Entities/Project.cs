using System;
using System.Collections.Generic;
using System.Linq;
using DevFreela.Core.Enums;

namespace DevFreela.Core.Entities
{
    public class Project : BaseEntity
    {


        public Project(string title, string description, int idClient, decimal totalCost)
        {

            this.Title = title;
            this.Description = description;
            this.IdClient = idClient;
            this.TotalCost = totalCost;

            CreatedAt = DateTime.Now;
            this.ProjectStatus = ProjectStatus.Created;
            Comments = new List<ProjectComment>();
            this.ListCandidates= new List<int>();
        }    
        public string Title { get; private set; }
        public string Description { get; private set; }
        public int IdClient { get; private set; }
        public User Client { get; set; }
        public int? IdFreelancer { get; private set; }
        public User Freelancer { get; set; }
        public List<int> ListCandidates{get ; private set;}
        public decimal TotalCost { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? FinishedAt { get; private set; }
        public DateTime? StartedAt { get; private set; }
        public ProjectStatus ProjectStatus { get; private set; }
        public List<ProjectComment> Comments { get; private set; }
    
        public void Cancel()
        {
            if(this.ProjectStatus == ProjectStatus.InProgress)
                this.ProjectStatus = ProjectStatus.Cancelled;
        }
        public void Start()
        {
            if(this.ProjectStatus == ProjectStatus.Created){
                this.ProjectStatus = ProjectStatus.InProgress;
                this.StartedAt = DateTime.Now;
            }
        }
        public void Finish()
        {
            if(this.ProjectStatus == ProjectStatus.InProgress)
            {
                this.ProjectStatus = ProjectStatus.Finished;
                this.FinishedAt = DateTime.Now;
            }
        }
        public void Update(string title,string description,decimal totalCost)
        {
            this.Title = title;
            this.Description = description;
            this.TotalCost=totalCost;
        }
    
        public bool Aplly(int idFreelancer)
        { 
            if(ListCandidates.SingleOrDefault(id => id==idFreelancer) == 0)
            {
                this.ListCandidates.Add(idFreelancer);
                return true;
            }
            return false;
        }
    }
}