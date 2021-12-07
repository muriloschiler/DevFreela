using System.Collections.Generic;
using System.Linq;
using DevFreela.Application.DTO.InputModels;
using DevFreela.Application.DTO.ViewModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Application.Services.Implemations
{
    public class SkillService : ISkillService
    {
        public readonly DevFreelaDbContext _devFreelaDbContext;
        public SkillService(DevFreelaDbContext devFreelaDbContext)
        {
            _devFreelaDbContext=devFreelaDbContext;
        }
        public List<SkillViewModel> GetAll()
        {
            return _devFreelaDbContext.Skills.Select(s=> new SkillViewModel(s.Id,s.Description)).ToList();
        }

        public SkillDetailsViewModel GetById(int id)
        {
            var skill = _devFreelaDbContext.Skills.SingleOrDefault(s => s.Id==id );
            return new SkillDetailsViewModel(skill.Id,skill.Description,skill.CreatedAt);
        }
    }
}