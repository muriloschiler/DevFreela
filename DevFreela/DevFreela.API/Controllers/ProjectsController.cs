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
using Microsoft.AspNetCore.Authorization;
using DevFreela.Application.Commands.ApplyProject;
using DevFreela.Application.Commands.HireProject;
using DevFreela.Application.Commands.UncontractProject;

[Route("api/v1/projects")]
public class ProjectsController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public ProjectsController(IMediator mediator)
    {
        _mediator=mediator;

    }
    
    [HttpGet]
    [Authorize(Roles = "client, freelancer")]
    public async Task<ActionResult<List<ProjectViewModel>>> Get([FromQuery] string query){        
        var projectQuery = new GetAllProjectQuery(query);
        var listProjects = await _mediator.Send(projectQuery);
        return Ok(listProjects);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "client, freelancer")]
    public async Task<ActionResult<ProjectDetailsViewModel>> GetById(int id){
        GetProjectByIdQuery projectQuery = new GetProjectByIdQuery(id);
        var project = await _mediator.Send(projectQuery);        
        return Ok(project);
    }

    
    [HttpPost]
    [Authorize(Roles = "client")]
    public async Task<IActionResult> Post([FromBody] CreateProjectCommand createProjectCommand){
        int id = await _mediator.Send(createProjectCommand);    
        return CreatedAtAction(nameof(GetById),new{Id = id},createProjectCommand);
    }
    
    [HttpPut("{id}")]
    [Authorize(Roles = "client")]
    public async Task<IActionResult> Put([FromBody] UpdateProjectCommand updateProjectCommand){
        await _mediator.Send(updateProjectCommand);
        return NoContent();
    }

    
    [HttpDelete("{id}")]
    [Authorize(Roles = "client")]
    public async Task<IActionResult> Delete(int id){
        var request = new DeleteProjectCommand(id);
        await _mediator.Send(request);
        return NoContent();
    }

    
    [Route("{id}/start")]
    [HttpPut]
    [Authorize(Roles = "client")]
    public async Task<IActionResult> Start(int id){
        var request = new StartProjectCommand(id);
        await _mediator.Send(request);
        return NoContent();
    }

    
    [Route("{id}/finish")]
    [HttpPut]
    [Authorize(Roles = "client")]
    public async Task<IActionResult> Finish(FinishProjectCommand finishProjectCommand, int id){
        finishProjectCommand.IdProject = id;
        await _mediator.Send(finishProjectCommand);
        return NoContent();
    }

    [Route("{id}/comments")]
    [HttpGet]
    [Authorize(Roles = "client, freelancer")]
    public async Task<ActionResult<List<ProjectCommentViewModel>>> GetAllComments(int id){
        var commentsQuery = new GetAllCommentsQuery(id);
        var listComments = await _mediator.Send(commentsQuery);
        return Ok(listComments);
    }

    [Route("{id}/comments/{commentId}")]
    [HttpGet]
    [Authorize(Roles = "client, freelancer")]
    public async Task<ActionResult<ProjectCommentDetailsViewModel>> GetCommentById(int id,int commentId){
        var commentQuery = new GetCommentByIdQuery(id,commentId);
        
        var comment = await _mediator.Send(commentQuery);
        return Ok(comment);
    }

    [Route("{id}/comments")]
    [HttpPost]
    [Authorize(Roles = "client, freelancer")]
    public async Task<IActionResult> PostComment([FromBody] CreateCommentCommand createCommentCommand,
                                                [FromRoute]int id){

        createCommentCommand.SetIdProject(id);  
        var idComment = await _mediator.Send(createCommentCommand);
        return CreatedAtAction(nameof(GetCommentById),new{Id = idComment},createCommentCommand);
    }

    [Route("{id}/apply")]
    [HttpPut]
    [Authorize(Roles = "freelancer")]
    public async Task<IActionResult> Apply([FromBody] ApllyInputCommand apllyInputCommand,int id)
    {
        apllyInputCommand.SetIdProject(id);
        if(await _mediator.Send(apllyInputCommand))
            return BadRequest("Seu perfil já está cadastrado");
        return NoContent();
    }

    [Route("{id}/hire")]
    [HttpPut]
    [Authorize(Roles = "client")]
    public async Task<IActionResult> Hire(HireProjectCommand hireProjectCommand,int id)
    {
        //Buscar o id, ou o email, do client , pelo identity, para verificar se o projeto o pertence 
        hireProjectCommand.SetIdProject(id);    
        await _mediator.Send(hireProjectCommand);
        return NoContent();
    }

    [Route("{id}/Uncontract")]
    [HttpPut]
    [Authorize(Roles = "client")]
    public async Task<IActionResult> Uncontract(UncontractProjectCommand uncontractProjectCommand,int id){
        uncontractProjectCommand.SetIdProject(id);
        await _mediator.Send(uncontractProjectCommand);
        return NoContent();
    }
}