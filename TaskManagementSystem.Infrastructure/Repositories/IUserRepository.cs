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
        Task<User> Detail(int id);
        Task<List<User>> All();
        Task<User> Create(User user);
        Task<User> Update(UpdateUserRequestDTO request);
        Task Delete(int id);
        Task<User> Login(string mail);
    }
}
