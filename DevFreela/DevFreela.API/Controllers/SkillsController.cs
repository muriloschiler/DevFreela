using System.Collections.Generic;
using DevFreela.Application.DTO.ViewModels;
using Microsoft.AspNetCore.Mvc;
using DevFreela.Application.Services.Interfaces;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
{
    [Route("api/v1/skills")]
    public class SkillsController: ControllerBase
    {
        private readonly ISkillService _skillService;

        public SkillsController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SkillViewModel>>> Get(){
            var listSkils = await _skillService.GetAllAsync();
            return Ok(listSkils);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SkillDetailsViewModel>> GetById(int id){
            var skill = await _skillService.GetByIdAsync(id);
            return Ok(skill);
        }
    }
}