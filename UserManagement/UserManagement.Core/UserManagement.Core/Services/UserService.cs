using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Core.Interfaces;
using UserManagement.DAL.Interfaces;
using UserManagement.Models;
using UserManagement.Models.Enums;

namespace UserManagement.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task CreateAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var dbUsers = await _userRepository.Get();

            if (dbUsers == null || !dbUsers.Any())
            {
                throw new Exception("No users found.");
            }

            return dbUsers.Select(x => new User
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                Username = x.Username,
                Password = x.Password,
                Status = (Status)(int)x.Status
            }).ToList();
        }

        public async Task<User> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}