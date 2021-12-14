using System.Collections.Generic;
using DevFreela.Application.DTO.ViewModels;
using DevFreela.Application.DTO.InputModels;
using Microsoft.AspNetCore.Mvc;
using DevFreela.Application.Services.Interfaces;

[Route("api/v1/projects")]
public class ProjectsController : ControllerBase
{
    private readonly IProjectService _projectService ;
    
    
    public ProjectsController(IProjectService projectService)
    {
        _projectService = projectService;
    }
    [HttpGet]
    public ActionResult<List<ProjectViewModel>> Get([FromQuery] string query){        
        var listProjects = _projectService.GetAllProjects(query);
        return Ok(listProjects);
    }

    [HttpGet("{id}")]
    public ActionResult<ProjectDetailsViewModel> GetById(int id){        
        var project = _projectService.GetProjectById(id);
        return Ok(project);
    }
    [HttpPost]
    public IActionResult Post([FromBody] NewProjectInputModel createProjectInputModel){
        var id = _projectService.CreateProject(createProjectInputModel);
        return CreatedAtAction(nameof(GetById),new{Id = id},createProjectInputModel);
    }
    [HttpPut("{id}")]
    public IActionResult Put(int id , [FromBody] UpdateProjectInputModel putProjectInputModel){
        _projectService.UpdateProject(putProjectInputModel);
        return NoContent();
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id){
        //Aqui so se mudaria o status do projeto
        _projectService.DeleteProject(id);
        return Delete(id);
    }


    [Route("{id}/start")]
    [HttpPut]
    public IActionResult Start(int id){
        _projectService.StartProject(id);
        return NoContent();
    }

    [Route("{id}/finish")]
    [HttpPut]
    public IActionResult Finish(int id){
        _projectService.FinishProject(id);
        return NoContent();
    }

    [Route("{projectId}/comments")]
    [HttpGet]
    public ActionResult<List<ProjectCommentViewModel>> GetAllComments(int projectId){
        var listComments = _projectService.GetAllComments(projectId);
        return Ok(listComments);
    }

    [Route("{projectId}/comments/{commentId}")]
    [HttpGet]
    public ActionResult<ProjectCommentDetailsViewModel> GetCommentById(int projectId,int commentId){
        var comment = _projectService.GetCommentById(projectId,commentId);
        return Ok(comment);
    }

    [Route("{projectId}/comments")]
    [HttpPost]
    public IActionResult PostComment([FromBody] CreateProjectCommentInputModel projectComment,int projectId){
        var id = _projectService.CreateComment(projectComment,projectId);

        return CreatedAtAction(nameof(GetCommentById),new{Id = id},projectComment);
    }


}