using System.Collections.Generic;
using DevFreela.Application.DTO.InputModels;
using DevFreela.Application.DTO.ViewModels;

namespace DevFreela.Application.Services.Interfaces
{
    public interface IProjectService
    {
        List<ProjectViewModel> GetAllProjects(string query);
        ProjectDetailsViewModel GetProjectById(int id);
        int CreateProject(NewProjectInputModel projectInputModel);
        void UpdateProject(UpdateProjectInputModel putProjectInputModel,int id);
        void DeleteProject(int id);
        void StartProject(int id);
        void FinishProject(int id);
        List<ProjectCommentViewModel> GetAllComments(int id);
        ProjectCommentDetailsViewModel GetCommentById(int projectId,int commentId);
        void CreateComment(CreateProjectCommentInputModel projectComment,int id);

    }
}