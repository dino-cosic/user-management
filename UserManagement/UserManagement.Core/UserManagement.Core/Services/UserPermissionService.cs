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

        public async Task AssignNewPermissionsAsync(AssignPermissionsRequest updatePermissionRequest)
        {
            var userPermissions = await _userPermissionRepository.GetUserPermissionsAsync(updatePermissionRequest.UserId);

            var permissionIdsToAdd = updatePermissionRequest.PermissionIds
                .Where(p => userPermissions
                .FirstOrDefault(up => up.Id == p) == null)
                .ToList();

            if (!permissionIdsToAdd.Any())
            {
                throw new PermissionAlreadyAssignedException();
            }

            var systemPermissions = await _permissionRepository.GetAll().ToListAsync();

            var newUserPermissions = new List<EF.Entities.UserPermission>();

            foreach (var permissionId in permissionIdsToAdd)
            {
                if (!systemPermissions.Any(sp => sp.Id == permissionId))
                {
                    throw new DataNotFoundException("Permission", nameof(permissionId), permissionId);
                }

                var userPermissionEntity = new EF.Entities.UserPermission
                {
                    UserId = updatePermissionRequest.UserId,
                    PermissionId = permissionId,
                };

                newUserPermissions.Add(userPermissionEntity);
            }

            await _userPermissionRepository.AddRangeAsync(newUserPermissions);
        }

        public async Task RemovePermissionFromUserAsync(int permissionId, int userId)
        {
            var userPermissions = await _userPermissionRepository.GetUserPermissionsAsync(userId);

            var permissionToRemove = userPermissions.FirstOrDefault(up => up.Id == permissionId);

            // if permission is not assigned to the user return not found/bad request
            if (permissionToRemove == null)
            {
                throw new DataNotFoundException("UserPermission", nameof(permissionId), permissionId);
            }

            await _userPermissionRepository.DeleteByPermissionIdAsync(permissionToRemove.Id);
        }
    }
}