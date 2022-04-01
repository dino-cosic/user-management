﻿using AutoMapper;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Core.Exceptions;
using UserManagement.Core.Interfaces;
using UserManagement.Core.Validators;
using UserManagement.DAL.Interfaces;
using UserManagement.Models;
using UserManagement.Models.Requests;
using UserManagement.Models.Responses;

namespace UserManagement.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;

        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<User> CreateAsync(User user)
        {
            UserDataValidator.ValidateUserData(user);

            var userEntity = _mapper.Map<EF.Entities.User>(user);

            var newUser = await _userRepository.AddAsync(userEntity);

            return _mapper.Map<User>(newUser);
        }

        public async Task<PagedListResponse<User>> GetAllAsync(UserPagingParameters userPagingParameters)
        {
            var dbUsers = await _userRepository.GetAllAsync();

            if (dbUsers == null || !dbUsers.Any())
            {
                throw new DataNotFoundException();
            }

            return PagedListResponse<User>.ToPagedListResponse(
                dbUsers.Select(u => _mapper.Map<User>(u)).ToList(),
                userPagingParameters.PageNumber,
                userPagingParameters.PageSize);
        }

        public async Task<User> GetAsync(int id)
        {
            // validate business rules

            var userEntity = await _userRepository.GetByIdAsync(id);

            if (userEntity == null)
            {
                throw new DataNotFoundException("Users", nameof(id), id);
            }

            return _mapper.Map<User>(userEntity);
        }

        public async Task<User> UpdateAsync(User user)
        {
            UserDataValidator.ValidateUserData(user);

            var userEntity = await _userRepository.GetByIdAsync(user.Id);

            userEntity.FirstName = user.FirstName;
            userEntity.LastName = user.LastName;
            userEntity.Email = user.Email;
            userEntity.Username = user.Username;
            userEntity.Password = user.Password;
            userEntity.Status = (EF.Entities.Status)(int)user.Status;

            var updatedUserEntity = await _userRepository.UpdateAsync(userEntity);

            return _mapper.Map<User>(updatedUserEntity);
        }

        public async Task DeleteAsync(int id)
        {
            var userEntity = await _userRepository.GetByIdAsync(id);

            if (userEntity == null)
            {
                throw new DataNotFoundException("Users", nameof(id), id);
            }

            await _userRepository.DeleteAsync(userEntity);
        }
    }
}