
using DevFreela.Application.DTO.InputModels;
using DevFreela.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers{

    [Route("api/v1/users")]
    public class UsersController :ControllerBase{
        
        public readonly IUserService _UserService;
        public UsersController(IUserService userService)
        {
            _UserService=userService;
        }
        [Route("login")]
        [HttpPost]
        public IActionResult Login([FromBody] LoginModel loginModel){

            //Todo:Modulo de autenticacao
            return NoContent();
        }

        [HttpPost]
        public IActionResult Register([FromBody] CreateUserInputModel createUserInputModel){

            //Chama a service para adcionar o user no banco
            _UserService.AddUser(createUserInputModel);
            return NoContent();
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