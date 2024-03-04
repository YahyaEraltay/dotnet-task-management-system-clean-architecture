using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Infrastructure.DTOs;
using TaskManagementSystem.Infrastructure.RelationalDb;

namespace TaskManagementSystem.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository()
        {
        }

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<User> AddUserAsync(UserDTO userDto)
        {
            var user = new User
            {
                UserName = userDto.UserName,
                Mail = userDto.Mail,
                DepartmentId = userDto.DepartmentId,
            };
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task DeleteUserAsync(int id)
        {
            var x = await _context.Users.FindAsync(id);
            if (x != null)
            {
                _context.Users.Remove(x);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Task with the specified ID could not be found.");
            }
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                throw new Exception("User Not Found");
            }
            return user;
        }

        public async Task<User> GetUserByNameAsync(string userName)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.UserName == userName);
        }

        public async Task<User> UpdateUserAsync(UserDTO userDto, int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                throw new Exception("Id not found");
            }
            user.UserName = userDto.UserName;
            user.Mail = userDto.Mail;
            user.DepartmentId = userDto.DepartmentId;
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
