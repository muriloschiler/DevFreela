using System.Collections.Generic;
using DevFreela.Application.DTO.InputModels;
using DevFreela.Application.DTO.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/skills")]
    public class SkillsController: ControllerBase
    {
        [HttpGet]
        public ActionResult<List<SkillViewModel>> Get(){
            return Ok("Lista de skills");
        }
        [HttpGet("{id}")]
        public ActionResult<SkillDetailsViewModel> GetById(int id){
            return Ok($"Skill{id}");
        }
    }
}