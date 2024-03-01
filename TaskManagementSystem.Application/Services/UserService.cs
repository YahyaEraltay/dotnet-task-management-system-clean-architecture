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

        public async Task<UserDTO> AddUserAsync(UserDTO userDto)
        {
            await _userRepository.AddUserAsync(userDto);
            return userDto;
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteUserAsync(id);
        }
        public async Task<List<UserDTO>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();
            var response = new List<UserDTO>() { };
            foreach (var user in users)
            {
                response.Add(new UserDTO()
                {
                    UserName = user.UserName,
                    DepartmentId = user.DepartmentId,
                });
            }
            return response;
        }
        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            var userDTO = new UserDTO
            {
                UserName = user.UserName,
                DepartmentId = user.DepartmentId,
            };
            return userDTO;
        }
        public async Task<User> LoginUserAsync(string userName)
        {
            return await _userRepository.GetUserByNameAsync(userName);
        }
        public async Task<UserDTO> UpdateUserAsync(UserDTO userDto, int id)
        {
            await _userRepository.UpdateUserAsync(userDto, id);
            return new UserDTO
            {
                UserName = userDto.UserName,
                DepartmentId = userDto.DepartmentId,
            };
        }
    }
}
