using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Core.Interfaces;
using UserManagement.Models;

namespace UserManagement.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<User>> Create([FromBody] User user)
        {
            // Guard against invalid user object

            var newUser = await _userService.CreateAsync(user);

            return new OkObjectResult(newUser);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            var users = await _userService.GetAllAsync();

            return new OkObjectResult(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            // Guard against invalid user id

            return await _userService.GetAsync(id);
        }

        [HttpPut]
        public async Task<ActionResult<User>> Update([FromBody] User user)
        {
            // Guard against invalid user object

            var updatedUser = await _userService.UpdateAsync(user);

            return new OkObjectResult(updatedUser);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // Guard against invalid user id

            await _userService.DeleteAsync(id);

            return new OkResult();
        }
    }
}