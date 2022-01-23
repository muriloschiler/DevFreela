using System.Collections.Generic;
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
        Task<ProjectComment> GetComment(int projectId,int commentId);
        Task<List<ProjectComment>> GetAllComments(int projectId);
        Task AddComment(ProjectComment newComment);
        Task SaveChangesAsync() ; 
    }
}