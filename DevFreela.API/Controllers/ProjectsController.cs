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
    public ActionResult<ProjectViewModel> GetById(int id){        
        return Ok("projeto de {id} retornado");
    }
    [HttpPost]
    public IActionResult Post([FromBody] CreateProjectInputModel projectInputModel){
        return CreatedAtAction(nameof(GetById),new{id = 1},projectInputModel);
    }
    [HttpPut("{id}")]
    public IActionResult Put([FromBody] PutProjectInputModel putProjectInputModel,int id){
        return NoContent();
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id){
        //Aqui so se mudaria o status do projeto
        return Delete(id);
    }

    [Route("{id}/comments")]
    [HttpGet]
    public ActionResult<List<ProjectCommentViewModel>> GetComments(int id){
        return Ok($"Lista de comentarios do projeto {id} retornados");
    }

    [Route("{projectId}/comments/{commentId}")]
    [HttpGet]
    public ActionResult<ProjectCommentViewModel> GetCommentById(int projectId,int commentId){
        return Ok($"Comentario {commentId} do projeto {projectId} retornados");
    }

    [Route("{id}/comments")]
    [HttpPost]
    public IActionResult PostComment([FromBody] CreateProjectCommentInputModel projectComment,int id){
        return CreatedAtAction(nameof(GetCommentById),new{id = 1},projectComment);
    }
}