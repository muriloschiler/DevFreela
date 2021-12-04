using System.Collections.Generic;
using DevFreela.Application.DTO.ViewModels;
using DevFreela.Application.DTO.InputModels;
using Microsoft.AspNetCore.Mvc;

[Route("api/v1/projects")]
public class ProjectsController : ControllerBase
{
    [HttpGet]
    public ActionResult<List<ProjectViewModel>> Get([FromQuery] string query){        
        return Ok("Lista de projetos retornados");
    }

    [HttpGet("{id}")]
    public ActionResult<ProjectDetailsViewModel> GetById(int id){        
        return Ok("projeto de {id} retornado");
    }
    [HttpPost]
    public IActionResult Post([FromBody] NewProjectInputModel createProjectInputModel){
        return CreatedAtAction(nameof(GetById),new{id = 1},createProjectInputModel);
    }
    [HttpPut("{id}")]
    public IActionResult Put([FromBody] UpdateProjectInputModel putProjectInputModel){
        return NoContent();
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id){
        //Aqui so se mudaria o status do projeto
        return Delete(id);
    }


    [Route("{id}/start")]
    [HttpPut]
    public IActionResult Start(int id){
        return NoContent();
    }

    [Route("{id}/finish")]
    [HttpPut]
    public IActionResult Finish(int id){
        return NoContent();
    }

    [Route("{id}/comments")]
    public ActionResult<List<ProjectCommentViewModel>> GetAllComments(int id){
        return Ok($"Lista de comentarios do Projeto{id}");
    }

    [Route("{projectId}/comments/{commentId}")]
    [HttpGet]
    public ActionResult<ProjectCommentDetailsViewModel> GetCommentById(int projectId,int commentId){
        return Ok($"Comentario {commentId} do projeto {projectId} retornados");
    }

    [Route("{id}/comments")]
    [HttpPost]
    public IActionResult PostComment([FromBody] CreateProjectCommentInputModel projectComment,int id){
        return CreatedAtAction(nameof(GetCommentById),new{id = 1},projectComment);
    }


}