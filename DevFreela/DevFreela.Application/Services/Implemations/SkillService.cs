using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.Application.DTO.ViewModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Application.Services.Implemations
{
    public class SkillService : ISkillService
    {
        public readonly ISkillRepository _skillRepository;
        public SkillService(ISkillRepository skillRepository)
        {
            _skillRepository=skillRepository;
        }
        public async Task<List<SkillViewModel>> GetAllAsync()
        {
            var skills = await _skillRepository.GetAllAsync();
            return skills.Select(s=> new SkillViewModel(s.Id,s.Description)).ToList();
        
        }

        public async Task<SkillDetailsViewModel> GetByIdAsync(int idSkill)
        {
            var skill = await _skillRepository.GetByIdAsync(idSkill);
            return new SkillDetailsViewModel(skill.Id,skill.Description,skill.CreatedAt);
        }
    }
}