using System;
using System.Collections.Generic;
using System.Linq;
using DevFreela.Application.DTO.InputModels;
using DevFreela.Application.DTO.ViewModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Core.Entities;
using DevFreela.Core.Enums;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Application.Services.Implemations
{
    public class ProjectService : IProjectService
    {
        private readonly DevFreelaDbContext _devFreelaDbContext;
        public ProjectService(DevFreelaDbContext devFreelaDbContext){
            _devFreelaDbContext=devFreelaDbContext;
        }
   
        public List<ProjectViewModel> GetAllProjects(string query)
        {
            var projects = _devFreelaDbContext.Projects;
            var listProjectViewModel = projects
                                        .Select(p=> new ProjectViewModel(p.Title,p.Description,p.IdClient,p.IdFreelancer,p.TotalCost,p.ProjectStatus))
                                        .ToList();
            return listProjectViewModel;                            
        }

        public ProjectDetailsViewModel GetProjectById(int id)
        {
            Project project = _devFreelaDbContext.Projects.SingleOrDefault(p => p.Id == id);

            ProjectDetailsViewModel projectDetailsViewModel = new ProjectDetailsViewModel
                                                                        (
                                                                            project.Title, 
                                                                            project.Description, 
                                                                            project.IdClient,
                                                                            project.IdFreelancer, 
                                                                            project.TotalCost, 
                                                                            project.CreatedAt,
                                                                            project.FinishedAt,
                                                                            project.StartedAt, 
                                                                            project.ProjectStatus, 
                                                                            project.Comments);
        
            return projectDetailsViewModel;
        }
        
        public int CreateProject(NewProjectInputModel projectInputModel)
        {
            Project newProject = new Project(   projectInputModel.Title,
                                                projectInputModel.Description,
                                                projectInputModel.IdClient,
                                                projectInputModel.IdFreelancer,
                                                projectInputModel.TotalCost);

            _devFreelaDbContext.Projects.Add(newProject);
            return newProject.Id;
        }

        public void DeleteProjetc(int id)
        {
            Project project = _devFreelaDbContext.Projects.SingleOrDefault(p=> p.Id == id);
            if(project !=null)
                project.Cancel();
        }

        public void FinishProject(int id)
        {
            Project project = _devFreelaDbContext.Projects.SingleOrDefault(p=> p.Id == id);
            if(project !=null)
                project.Finish();
        }

        public void StartProject(int id)
        {
            Project project = _devFreelaDbContext.Projects.SingleOrDefault(p=> p.Id == id);
            if(project !=null)
                project.Start();        
        }

        public void UpdateProject(UpdateProjectInputModel putProjectInputModel, int id)
        {
            if(_devFreelaDbContext.Projects.Any(p => p.Id == id)){
               //EntityFramework ou implementando um metodo Update na Entity 
            }    
        }
        
        public List<ProjectCommentViewModel> GetAllComments(int id)
        {
            var listProjectCommentsViewModel = _devFreelaDbContext.ProjectComments
                                                        .Where(p => p.IdProject == id)
                                                        .Select(p => new ProjectCommentViewModel(p.Content,p.IdUser))
                                                        .ToList();
            return listProjectCommentsViewModel;
        }
        public ProjectCommentDetailsViewModel GetCommentById(int projectId, int commentId)
        {
            var projectComment = _devFreelaDbContext.ProjectComments.SingleOrDefault(p=> p.IdProject ==projectId && p.Id==commentId);
            var projectDetailsViewModel = new ProjectCommentDetailsViewModel(projectComment.Content,projectComment.IdProject,projectComment.IdUser,projectComment.CreatedAt);
        
            return projectDetailsViewModel;
        }

        public void CreateComment(CreateProjectCommentInputModel projectComment, int id)
        {
            var newComment = new ProjectComment(projectComment.Content,projectComment.IdProject,projectComment.IdUser);
            _devFreelaDbContext.ProjectComments.Add(newComment);
        }
    }
}