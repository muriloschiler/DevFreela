using System.Collections.Generic;
using System.Threading.Tasks;
using DevFreela.Application.DTO.ViewModels;

namespace DevFreela.Application.Services.Interfaces
{
    public interface ISkillService
    {
        Task<List<SkillViewModel>> GetAllAsync();
        Task<SkillDetailsViewModel> GetByIdAsync(int id);
        
    }
}