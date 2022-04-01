using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Permission>> GetPermissionsAsync()
        {
            var dbPermissions = await _permissionRepository.GetAll().ToListAsync();

            return dbPermissions.Select(p => _mapper.Map<Permission>(p)).ToList();
        }

        public async Task<IEnumerable<Permission>> GetUserPermissions(int userId)
        {
            var userPermissions = await _userPermissionRepository.GetUserPermissionsAsync(userId);

            return userPermissions.Select(up => _mapper.Map<Permission>(up)).ToList();
        }

        public async Task AssignNewPermissionAsync(UpdatePermissionRequest updatePermissionRequest)
        {
            var userPermissions = await _userPermissionRepository.GetUserPermissionsAsync(updatePermissionRequest.UserId);

            // confirm that provided permission is not already assigned to the user
            if (userPermissions.Any(up => up.Id == updatePermissionRequest.PermissionId && up.Code == updatePermissionRequest.PermissionCode))
            {
                throw new PermissionAlreadyAssignedException(updatePermissionRequest.PermissionCode);
            }

            var providedPermission = await _permissionRepository.GetByIdAsync(updatePermissionRequest.PermissionId);

            if (providedPermission == null)
            {
                throw new DataNotFoundException("Permission", nameof(updatePermissionRequest.PermissionId), updatePermissionRequest.PermissionId);
            }

            var userPermissionEntity = new EF.Entities.UserPermission
            {
                UserId = updatePermissionRequest.UserId,
                PermissionId = updatePermissionRequest.PermissionId,
            };

            await _userPermissionRepository.AddAsync(userPermissionEntity);
        }

        public async Task RemovePermissionFromUserAsync(UpdatePermissionRequest updatePermissionRequest)
        {
            var userPermissions = await _userPermissionRepository.GetUserPermissionsAsync(updatePermissionRequest.UserId);

            var permissionToRemove = userPermissions.FirstOrDefault(up => up.Id == updatePermissionRequest.PermissionId && up.Code == updatePermissionRequest.PermissionCode);

            // if permission is not assigned to the user return not found/bad request
            if (permissionToRemove == null)
            {
                throw new DataNotFoundException("UserPermission", nameof(updatePermissionRequest.PermissionId), updatePermissionRequest.PermissionId);
            }

            await _userPermissionRepository.DeleteByPermissionIdAsync(permissionToRemove.Id);
        }
    }
}