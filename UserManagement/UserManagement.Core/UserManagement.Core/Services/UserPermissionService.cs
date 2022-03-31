using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Core.Exceptions;
using UserManagement.Core.Interfaces;
using UserManagement.DAL.Interfaces;
using UserManagement.Models;
using UserManagement.Models.Requests;

namespace UserManagement.Core.Services
{
    public class UserPermissionService : IUserPermissionService
    {
        private readonly IUserPermissionRepository _userPermissionRepository;
        private readonly IPermissionRepository _permissionRepository;
        private readonly IMapper _mapper;

        public UserPermissionService(IPermissionRepository permissionRepository, IUserPermissionRepository userPermissionRepository, IMapper mapper)
        {
            _permissionRepository = permissionRepository;
            _userPermissionRepository = userPermissionRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Permission>> GetUserPermissions(int userId)
        {
            var userPermissions = await _userPermissionRepository.GetUserPermissionsAsync(userId);

            if (userPermissions == null || !userPermissions.Any())
            {
                throw new DataNotFoundException("User Permission", nameof(userId), userId);
            }

            return userPermissions.Select(up => _mapper.Map<Permission>(up)).ToList();
        }

        public async Task AssignNewPermissionAsync(AssignPermissionRequest assignPermissionRequest)
        {
            // confirm that provided permission is not already assigned to the user

            var userPermissions = await _userPermissionRepository.GetUserPermissionsAsync(assignPermissionRequest.UserId);

            if (userPermissions.Any(up => up.Id == assignPermissionRequest.PermissionId && up.Code == assignPermissionRequest.PermissionCode))
            {
                throw new PermissionAlreadyAssignedException(assignPermissionRequest.PermissionCode);
            }

            var providedPermission = await _permissionRepository.GetByIdAsync(assignPermissionRequest.PermissionId);

            if (providedPermission == null)
            {
                throw new DataNotFoundException("Permission", nameof(assignPermissionRequest.PermissionId), assignPermissionRequest.PermissionId);
            }

            var userPermissionEntity = new EF.Entities.UserPermission
            {
                UserId = assignPermissionRequest.UserId,
                PermissionId = assignPermissionRequest.PermissionId,
            };

            await _userPermissionRepository.AddAsync(userPermissionEntity);
        }
    }
}