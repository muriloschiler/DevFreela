using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        public readonly DevFreelaDbContext _devFreelaDbContext;

        public SkillRepository(DevFreelaDbContext devFreelaDbContext)
        {
            _devFreelaDbContext = devFreelaDbContext;
        }

        public async Task<List<Skill>> GetAllAsync()
        {
            return await _devFreelaDbContext.Skills.ToListAsync();
        }

        public async Task<Skill> GetByIdAsync(int idSkill)
        {
            return await _devFreelaDbContext.Skills.SingleOrDefaultAsync(skill => skill.Id == idSkill );
        }
    }
}