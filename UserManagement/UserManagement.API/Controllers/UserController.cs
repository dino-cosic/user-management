using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Core.Guards;
using UserManagement.Core.Interfaces;
using UserManagement.Models;
using UserManagement.Models.Responses;

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
            UserGuard.ParameterNotNull(user, nameof(user));

            var newUser = await _userService.CreateAsync(user);

            return new OkObjectResult(new UserManagementResponse<User>
            {
                Success = true,
                Data = newUser
            });
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            var users = await _userService.GetAllAsync();

            return new OkObjectResult(new UserManagementResponse<IEnumerable<User>>
            {
                Success = true,
                Data = users
            });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            UserGuard.IdParameterValid(id, nameof(id));

            var user = await _userService.GetAsync(id);

            return new OkObjectResult(new UserManagementResponse<User>
            {
                Success = true,
                Data = user
            });
        }

        [HttpPut]
        public async Task<ActionResult<User>> Update([FromBody] User user)
        {
            UserGuard.ParameterNotNull(user, nameof(user));

            var updatedUser = await _userService.UpdateAsync(user);

            return new OkObjectResult(new UserManagementResponse<User>
            {
                Success = true,
                Data = updatedUser
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            UserGuard.IdParameterValid(id, nameof(id));

            await _userService.DeleteAsync(id);

            return new OkObjectResult(new UserManagementResponse<User>
            {
                Success = true
            });
        }
    }
}