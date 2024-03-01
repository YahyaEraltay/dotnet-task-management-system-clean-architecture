using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Infrastructure.DTOs;
using TaskManagementSystem.Infrastructure.Repositories;

namespace TaskManagementSystem.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> AddUserAsync(UserDTO userDto)
        {
            return await _userRepository.AddUserAsync(userDto);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteUserAsync(id);
        }
        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }
        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }
        public async Task<User> LoginUserAsync(string userName)
        {
            return await _userRepository.GetUserByNameAsync(userName);
        }
        public async Task<User> UpdateUserAsync(UserDTO userDto, int id)
        {
            return await _userRepository.UpdateUserAsync(userDto, id);
        }
    }
}
