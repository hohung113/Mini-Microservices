using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserAPI.Models;
using UserAPI.Services;

namespace UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService _userService)
        {
            userService = _userService;
        }
        [HttpGet]
        public async Task<IActionResult> UserList()
        {
            if (!Request.Headers.TryGetValue("X-Gateway-Auth", out var headerValue) || headerValue != "true")
            {
                return Unauthorized("Missing or invalid gateway authentication header.");
            }
            var userList = await userService.GetUserList();
            return Ok(userList);
        }
        [HttpGet("{id}")]
        public User GetUserById(int Id)
        {
            return userService.GetUserById(Id);
        }
        [HttpPost]
        public User AddUser(User user)
        {
            return userService.AddUser(user);
        }
        [HttpPut]
        public User UpdateUser(User user)
        {
            return userService.UpdateUser(user);
        }
        [HttpDelete("{id}")]
        public bool DeleteUser(int id)
        {
            return userService.DeleteUser(id);
        }
    }
}