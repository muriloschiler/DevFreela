using System.Collections.Generic;
using DevFreela.Application.DTO.InputModels;
using DevFreela.Application.DTO.ViewModels;

namespace DevFreela.Application.Services.Interfaces
{
    public interface ISkillService
    {
        List<SkillViewModel> GetAll();
        SkillDetailsViewModel GetById(int id);
        
    }
}