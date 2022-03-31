using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Core.Guards;
using UserManagement.Core.Interfaces;
using UserManagement.Models;
using UserManagement.Models.CustomResponses;

namespace UserManagement.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class PermissionController : ControllerBase
    {
        private readonly IUserPermissionService _userPermissionService;

        public PermissionController(IUserPermissionService userPermissionService)
        {
            _userPermissionService = userPermissionService;
        }

        [HttpGet("User/{userId}")]
        public async Task<ActionResult<IEnumerable<Permission>>> GetUserPermissions(int userId)
        {
            UserGuard.IdParameterValid(userId, nameof(userId));

            var userPermissions = await _userPermissionService.GetUserPermissions(userId);

            return new OkObjectResult(new UserManagementResponse<IEnumerable<Permission>>
            {
                Success = true,
                Data = userPermissions
            });
        }
    }
}