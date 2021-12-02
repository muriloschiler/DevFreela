using System.Collections.Generic;
using DevFreela.Application.DTO.InputModels;
using DevFreela.Application.DTO.ViewModels;

namespace DevFreela.Application.Services.Interfaces
{
    public interface IProjectService
    {
        List<ProjectViewModel> GetAll(string query);
        ProjectDetailsViewModel GetById(int id);
        void CreateProject(CreateProjectInputModel projectInputModel);
        void UpdateProject(UpdateProjectInputModel putProjectInputModel,int id);
        void DeleteProjetc(int id);
    }
}