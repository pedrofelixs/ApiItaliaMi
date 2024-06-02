using ApiItaliaMi.Models;
using ApiItaliaMi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace ApiItaliaMi.Controllers

{

    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly TokenService _tokenService;
        public AccountController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("v1/login")]
        public IActionResult Login([FromServices] TokenService tokenService)
        {
            
            var token = tokenService.GenerateToken(null);


            return Ok(token);

        }
        [Authorize(Roles = "user")]
        [HttpGet("v1/userAuthorized")]
        public IActionResult GetUser() => Ok(User.Identity.Name);


    }
}
