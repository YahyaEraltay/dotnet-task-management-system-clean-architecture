using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Infrastructure.DTOs;

namespace TaskManagementSystem.Application.Services
{
    public interface IUserService
    {
        Task<UserDTO> GetUserByIdAsync(int id);
        Task<List<UserDTO>> GetAllUsersAsync();
        Task<UserDTO> AddUserAsync(UserDTO userDto);
        Task<UserDTO> UpdateUserAsync(UserDTO userDto, int id);
        Task DeleteUserAsync(int id);
        Task<User> LoginUserAsync(string userName);
    }
}
