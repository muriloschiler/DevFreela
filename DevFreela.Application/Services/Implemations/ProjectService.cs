using System;
using System.Collections.Generic;
using System.Linq;
using DevFreela.Application.DTO.InputModels;
using DevFreela.Application.DTO.ViewModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Core.Entities;
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
                                        .Select(p=> new ProjectViewModel(p.Id,p.Title,p.Description,p.IdClient,p.Client.Name,
                                                                         p.IdFreelancer,p.TotalCost,p.ProjectStatus))
                                        .ToList();
            return listProjectViewModel;                            
        }

        public ProjectDetailsViewModel GetProjectById(int id)
        {
            Project project = _devFreelaDbContext.Projects.SingleOrDefault(p => p.Id == id);

            ProjectDetailsViewModel projectDetailsViewModel = new ProjectDetailsViewModel
                                                                        (
                                                                            project.Id,
                                                                            project.Title, 
                                                                            project.Description, 
                                                                            project.IdClient,
                                                                            project.Client.Name,
                                                                            project.Client.Email,
                                                                            project.IdFreelancer, 
                                                                            project.Freelancer.Name,
                                                                            project.Freelancer.Email,
                                                                            project.TotalCost, 
                                                                            project.CreatedAt,
                                                                            project.FinishedAt,
                                                                            project.StartedAt, 
                                                                            project.ProjectStatus, 
                                                                            project.Comments);
        
            return projectDetailsViewModel;
        }
        
        //Obsoleto
        public int CreateProject(NewProjectInputModel projectInputModel)
        {
            Project newProject = new Project(   projectInputModel.Title,
                                                projectInputModel.Description,
                                                projectInputModel.IdClient,
                                                projectInputModel.IdFreelancer,
                                                projectInputModel.TotalCost);

            _devFreelaDbContext.Projects.Add(newProject);
            _devFreelaDbContext.SaveChanges();
            return newProject.Id;
        }

        public void DeleteProject(int id)
        {
            Project project = _devFreelaDbContext.Projects.SingleOrDefault(p=> p.Id == id);
            if(project !=null){
                project.Cancel();
                _devFreelaDbContext.SaveChanges();
            }    

        }

        public void FinishProject(int id)
        {
            Project project = _devFreelaDbContext.Projects.SingleOrDefault(p=> p.Id == id);
            if(project !=null){
                project.Finish();
                _devFreelaDbContext.SaveChanges();

            }
        }

        public void StartProject(int id)
        {
            Project project = _devFreelaDbContext.Projects.SingleOrDefault(p=> p.Id == id);
            if(project !=null){
                project.Start();        
                _devFreelaDbContext.SaveChanges();
            }
        }

        public void UpdateProject(UpdateProjectInputModel putProjectInputModel)
        {
            Project project = _devFreelaDbContext.Projects.SingleOrDefault(p => p.Id == putProjectInputModel.Id);
            if(project != null){
                project.Update(putProjectInputModel.Title,putProjectInputModel.Description,putProjectInputModel.TotalCost);
                _devFreelaDbContext.SaveChanges();
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

        public int CreateComment(CreateProjectCommentInputModel projectComment, int id)
        {
            var newComment = new ProjectComment(projectComment.Content,projectComment.IdProject,projectComment.IdUser);
            _devFreelaDbContext.ProjectComments.Add(newComment);
            _devFreelaDbContext.SaveChanges();
            return newComment.Id;
        }
    }
}