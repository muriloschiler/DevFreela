using System.Collections.Generic;
using DevFreela.Application.DTO.ViewModels;
using DevFreela.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/skills")]
    public class SkillsController: ControllerBase
    {
        private readonly ISkillService _skillService;

        public SkillsController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        [HttpGet]
        public ActionResult<List<SkillViewModel>> Get(){
            var listSkils = _skillService.GetAll();
            return Ok(listSkils);
        }
        [HttpGet("{id}")]
        public ActionResult<SkillDetailsViewModel> GetById(int id){
            var skill = _skillService.GetById(id);
            return Ok(skill);
        }
    }
}