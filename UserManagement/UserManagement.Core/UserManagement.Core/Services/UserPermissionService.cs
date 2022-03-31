using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Core.Exceptions;
using UserManagement.Core.Interfaces;
using UserManagement.DAL.Interfaces;
using UserManagement.Models;

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

        public async Task<Permission> UpdateUserPermissions(Permission permission)
        {
            // validate business rules

            var permissionEntity = _mapper.Map<EF.Entities.Permission>(permission);

            var updatedPermission = await _permissionRepository.UpdateAsync(permissionEntity);

            return _mapper.Map<Permission>(updatedPermission);
        }
    }
}