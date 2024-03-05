using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Infrastructure.DTOs.UserDTOs;

namespace TaskManagementSystem.Application.Services
{
    public interface IUserService
    {
        Task<GetUserDTO> GetUserByIdAsync(int id);
        Task<List<GetUserDTO>> GetAllUsersAsync();
        Task<UserDTO> AddUserAsync(UserDTO userDto);
        Task<UserDTO> UpdateUserAsync(UserDTO userDto, int id);
        Task DeleteUserAsync(int id);
        Task<User> LoginUserAsync(string userName);
    }
}
