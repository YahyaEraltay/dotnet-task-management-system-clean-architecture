using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Infrastructure.DTOs.UserDTOs;
using TaskManagementSystem.Infrastructure.DTOs.UserDTOs.UserRequestModel;

namespace TaskManagementSystem.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(int id);
        Task<List<User>> GetAllUsersAsync();
        Task<User> AddUserAsync(User user);
        Task<User> UpdateUserAsync(UpdateUserRequestDTO request);
        Task DeleteUserAsync(int id);
        Task<User> GetUserByNameAsync(string mail);
    }
}
