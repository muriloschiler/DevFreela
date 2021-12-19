using System.Collections.Generic;
using DevFreela.Application.DTO.ViewModels;
using DevFreela.Application.DTO.InputModels;
using Microsoft.AspNetCore.Mvc;
using DevFreela.Application.Services.Interfaces;
using MediatR;
using DevFreela.Application.Commands.CreateProject;
using System.Threading.Tasks;
using DevFreela.Application.Commands.UpdateProject;
using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Application.Commands.StartProject;
using DevFreela.Application.Commands.FinishProject;
using DevFreela.Application.Commands.CreateComment;

[Route("api/v1/projects")]
public class ProjectsController : ControllerBase
{
    private readonly IProjectService _projectService ;
    private readonly IMediator _mediator;
    
    public ProjectsController(IProjectService projectService,IMediator mediator)
    {
        _projectService = projectService;
        _mediator=mediator;

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

    //Refatorado
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateProjectCommand createProjectCommand){
        int id = await _mediator.Send(createProjectCommand);    
        return CreatedAtAction(nameof(GetById),new{Id = id},createProjectCommand);
    }
    //Refatorado
    [HttpPut("{id}")]
    public async Task<IActionResult> Put([FromBody] UpdateProjectCommand updateProjectCommand){
        await _mediator.Send(updateProjectCommand);
        return NoContent();
    }

    //Refatorado
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id){
        var request = new DeleteProjectCommand(id);
        await _mediator.Send(request);
        return NoContent();
    }

    //Refatorado
    [Route("{id}/start")]
    [HttpPut]
    public async Task<IActionResult> Start(int id){
        var request = new StartProjectCommand(id);
        await _mediator.Send(request);
        return NoContent();
    }

    //Refatorado
    [Route("{id}/finish")]
    [HttpPut]
    public async Task<IActionResult> Finish(int id){
        var request = new FinishProjectCommand(id);
        await _mediator.Send(request);
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
    //Refatorado
    public async Task<IActionResult> PostComment([FromBody] CreateCommentCommand createCommentCommand,
                                                 [FromRoute]int idProject){

        createCommentCommand.SetIdProject(idProject);  
        var id = await _mediator.Send(createCommentCommand);
        return CreatedAtAction(nameof(GetCommentById),new{Id = id},createCommentCommand);
    }

}