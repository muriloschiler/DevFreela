using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        public readonly DevFreelaDbContext _devFreelaDbContext;

        public ProjectRepository(DevFreelaDbContext devFreelaDbContext)
        {
            _devFreelaDbContext = devFreelaDbContext;
        }

        public async Task AddComment(ProjectComment newComment)
        {
            await _devFreelaDbContext.ProjectComments.AddAsync(newComment);
            await _devFreelaDbContext.SaveChangesAsync();
        }

        public async Task AddProject(Project newProject)
        {
            await _devFreelaDbContext.Projects.AddAsync(newProject);
            await _devFreelaDbContext.SaveChangesAsync();
        }

        public async Task DeleteProject(Project project)
        {
            project.Cancel();
            await _devFreelaDbContext.SaveChangesAsync();
        }

        public async Task FinishProject(Project project)
        {
            project.Finish();
            await _devFreelaDbContext.SaveChangesAsync();
        }
        public async Task SetPaymentPending(Project project)
        {
            project.SetPaymentPending();
            await _devFreelaDbContext.SaveChangesAsync();

        }
        public async Task StartProject(Project project)
        {
            project.Start();        
            await _devFreelaDbContext.SaveChangesAsync();
        }
        public async Task UpdateProject(Project project,string title,string description,decimal totalCost)
        {

                project.Update(title,description,totalCost);
                await _devFreelaDbContext.SaveChangesAsync();
        }

        public async Task<List<ProjectComment>> GetAllComments(int projectId)
        {
            return await Task.FromResult(
                                    _devFreelaDbContext.ProjectComments
                                    .Where(p => p.IdProject == projectId).ToList()
                                );
        }

        public async Task<List<Project>> GetAllProjects(string query)
        {
            return await _devFreelaDbContext.Projects.ToListAsync();
                                                
        }

        public async Task<ProjectComment> GetComment(int projectId, int commentId)
        {
            return await _devFreelaDbContext.ProjectComments.SingleOrDefaultAsync(pc=> pc.IdProject ==projectId && pc.Id==commentId);
        }

        public async Task<Project> GetProject(int projectId)
        {
            Project project =await _devFreelaDbContext.Projects.SingleOrDefaultAsync(p=> p.Id == projectId);
            return project;
        }

        public async Task<Project> GetProjectIncluded(int projectId)
        {
            return await _devFreelaDbContext.Projects
                                                .Include(p=>p.Client)
                                                .Include(p=>p.Freelancer)
                                                .SingleOrDefaultAsync(p=> p.Id == projectId);
                                                            
        }
    
        public async Task SaveChangesAsync(){
            await _devFreelaDbContext.SaveChangesAsync();
        }

    }

}