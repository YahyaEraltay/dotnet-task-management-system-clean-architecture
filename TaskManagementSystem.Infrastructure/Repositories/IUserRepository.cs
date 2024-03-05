using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Infrastructure.DTOs.UserDTOs;

namespace TaskManagementSystem.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(int id);
        Task<List<User>> GetAllUsersAsync();
        Task<User> AddUserAsync(UserDTO userDto);
        Task<User> UpdateUserAsync(UserDTO userDto, int id);
        Task DeleteUserAsync(int id);
        Task<User> GetUserByNameAsync(string userName);
    }
}
