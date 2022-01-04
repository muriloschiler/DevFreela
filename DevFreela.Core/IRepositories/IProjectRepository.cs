using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories
{
    public interface IProjectRepository
    {   
        Task<Project> GetProject(int projectId);
        Task<Project> GetProjectIncluded(int projectId);
        Task<List<Project>> GetAllProjects(string query);
        Task AddProject(Project newProject);
        Task DeleteProject(Project project);
        Task FinishProject(Project project);
        Task StartProject(Project project);
        Task UpdateProject(Project project,string title,string description,decimal totalCost);
        Task<ProjectComment> GetComment(int projectId,int commentId);
        Task<List<ProjectComment>> GetAllComments(int projectId);
        Task AddComment(ProjectComment newComment);

        
    }
}