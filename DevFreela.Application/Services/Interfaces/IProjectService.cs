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
        void UpdateProject(int id,UpdateProjectInputModel putProjectInputModel);
        void DeleteProject(int id);
        void StartProject(int id);
        void FinishProject(int id);
        List<ProjectCommentViewModel> GetAllComments(int id);
        ProjectCommentDetailsViewModel GetCommentById(int projectId,int commentId);
        int CreateComment(CreateProjectCommentInputModel projectComment,int id);

    }
}