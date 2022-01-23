
using System.Threading.Tasks;
using DevFreela.Application.DTO.InputModels;
using DevFreela.Application.DTO.ViewModels;
using DevFreela.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers{

    [Route("api/v1/users")]
    [Authorize]
    public class UsersController :ControllerBase{
        
        public readonly IUserService _UserService;
        public UsersController(IUserService userService)
        {
            _UserService=userService;
        }

        [Route("login")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<LoginViewModel>> Login([FromBody] LoginInputModel loginModel)
        {
            var login = await _UserService.LoginAsync(loginModel);
            if(login != null)
                return Ok(login);
            return NotFound();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] CreateUserInputModel createUserInputModel)
        {
            int id = await _UserService.AddUserAsync(createUserInputModel);
            return CreatedAtAction(nameof(GetById),new{Id = id},createUserInputModel);
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult<UserDetailsViewModel>> GetById([FromRoute]int id)
        {
            UserDetailsViewModel user =  await _UserService.GetUserAsync(id);
            if(user != null){
                return Ok(user);
            }
            return BadRequest();
        }
        
        [Route("{id}/skill")]
        [HttpPut]
        [Authorize(Roles = "freelancer")]
        public async Task<ActionResult> AddSkill([FromBody] AddSkilInputModel addSkilInputModel,int id)
        {
            addSkilInputModel.idFreelancer=id;
            var result = await _UserService.addSkilAsync(addSkilInputModel);
            if(result == true)
                return Ok();
            return BadRequest();
        }
        
    }
}