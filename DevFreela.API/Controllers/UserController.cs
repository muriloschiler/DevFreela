
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
        public ActionResult<LoginViewModel> Login([FromBody] LoginInputModel loginModel){
            var login = _UserService.Login(loginModel);
            if(login != null)
                return Ok(login);
            return NotFound();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Register([FromBody] CreateUserInputModel createUserInputModel){

            //Chama a service para adcionar o user no banco
            int id = _UserService.AddUser(createUserInputModel);
            return CreatedAtAction(nameof(GetById),new{Id = id},createUserInputModel);

        }
        [Route("{id}")]
        [HttpGet]
        public ActionResult<UserDetailsViewModel> GetById([FromRoute]int id){
            UserDetailsViewModel user =  _UserService.GetUser(id);
            if(user != null){
                return Ok(user);
            }
            return BadRequest();
        }
        

    }

}