using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using DevFreela.Application.Commands.CreateProject;
using System.Threading.Tasks;
using DevFreela.Application.Commands.UpdateProject;
using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Application.Commands.StartProject;
using DevFreela.Application.Commands.FinishProject;
using DevFreela.Application.Commands.CreateComment;
using DevFreela.Application.Queries.GetProjectById;
using DevFreela.Application.Queries.GetProject;
using DevFreela.Application.Queries.GetAllComments;
using DevFreela.Application.Queries.GetCommentById;
using DevFreela.Application.Queries.GetAllProject;
using System.Linq;

[Route("api/v1/projects")]
public class ProjectsController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public ProjectsController(IMediator mediator)
    {
        _mediator=mediator;

    }
    
    [HttpGet]
    public async Task<ActionResult<List<ProjectViewModel>>> Get([FromQuery] string query){        
        var projectQuery = new GetAllProjectQuery(query);
        var listProjects = await _mediator.Send(projectQuery);
        return Ok(listProjects);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProjectDetailsViewModel>> GetById(int id){
        GetProjectByIdQuery projectQuery = new GetProjectByIdQuery(id);
        var project = await _mediator.Send(projectQuery);        
        return Ok(project);
    }

    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateProjectCommand createProjectCommand){
        int id = await _mediator.Send(createProjectCommand);    
        return CreatedAtAction(nameof(GetById),new{Id = id},createProjectCommand);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Put([FromBody] UpdateProjectCommand updateProjectCommand){
        await _mediator.Send(updateProjectCommand);
        return NoContent();
    }

    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id){
        var request = new DeleteProjectCommand(id);
        await _mediator.Send(request);
        return NoContent();
    }

    
    [Route("{id}/start")]
    [HttpPut]
    public async Task<IActionResult> Start(int id){
        var request = new StartProjectCommand(id);
        await _mediator.Send(request);
        return NoContent();
    }

    
    [Route("{id}/finish")]
    [HttpPut]
    public async Task<IActionResult> Finish(int id){
        var request = new FinishProjectCommand(id);
        await _mediator.Send(request);
        return NoContent();
    }

    [Route("{projectId}/comments")]
    [HttpGet]
    public async Task<ActionResult<List<ProjectCommentViewModel>>> GetAllComments(int projectId){
        var commentsQuery = new GetAllCommentsQuery(projectId);
        var listComments = await _mediator.Send(commentsQuery);
        return Ok(listComments);
    }

    [Route("{projectId}/comments/{commentId}")]
    [HttpGet]
    public async Task<ActionResult<ProjectCommentDetailsViewModel>> GetCommentById(int projectId,int commentId){
        var commentQuery = new GetCommentByIdQuery(projectId,commentId);
        
        var comment = await _mediator.Send(commentQuery);
        return Ok(comment);
    }

    [Route("{projectId}/comments")]
    [HttpPost]
    public async Task<IActionResult> PostComment([FromBody] CreateCommentCommand createCommentCommand,
                                                 [FromRoute]int idProject){

        createCommentCommand.SetIdProject(idProject);  
        var id = await _mediator.Send(createCommentCommand);
        return CreatedAtAction(nameof(GetCommentById),new{Id = id},createCommentCommand);
    }

}