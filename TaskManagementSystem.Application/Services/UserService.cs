using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Infrastructure.DTOs.UserDTOs;
using TaskManagementSystem.Infrastructure.Repositories;

namespace TaskManagementSystem.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public UserService(IUserRepository userRepository, IDepartmentRepository departmentRepository)
        {
            _userRepository = userRepository;
            _departmentRepository = departmentRepository;
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
        public async Task<List<GetUserDTO>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();
            var response = new List<GetUserDTO>();
            foreach (var user in users)
            {
                var department = await _departmentRepository.GetDepartmentByIdAsync(user.DepartmentId);
                    response.Add(new GetUserDTO()
                    {
                        UserName = user.UserName,
                        Mail = user.Mail,
                        DepartmentName = department.DepartmentName,
                    });
            }
            return response;
        }
        public async Task<GetUserDTO> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            var department = await _departmentRepository.GetDepartmentByIdAsync(user.DepartmentId);
            var userDTO = new GetUserDTO
            {
                UserName = user.UserName,
                Mail = user.Mail,
                DepartmentName = department.DepartmentName,
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
                Mail = userDto.Mail,
                DepartmentId = userDto.DepartmentId,
            };
        }
    }
}
