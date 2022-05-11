using Cinema_Server.Models;
using Cinema_Server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cinema_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UsersService usersService;

        public UsersController(UsersService usersService)
        {
            this.usersService = usersService;
        }

        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            return this.Ok(this.usersService.GetUserById(Id));
        }

        [HttpGet]
        public IActionResult Get()
        {
            return this.Ok(this.usersService.GetAllUsers());
        }

        [HttpPost]
        public IActionResult Post(User user)
        {
            return this.Ok(this.usersService.CreateUser(user));
        }
    }
}
