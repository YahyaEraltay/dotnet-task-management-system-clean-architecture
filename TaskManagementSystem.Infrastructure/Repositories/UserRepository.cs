using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Infrastructure.DTOs.UserDTOs;
using TaskManagementSystem.Infrastructure.DTOs.UserDTOs.UserRequestModel;
using TaskManagementSystem.Infrastructure.RelationalDb;

namespace TaskManagementSystem.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;


        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<User> Create(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }
        public async Task<User> Delete(User user)
        {
            var deletedUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == user.Id);

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return deletedUser;
        }

        public async Task<List<User>> All()
        {
            return await _context.Users
                                 .Include(x => x.Department)
                                 .ToListAsync();
        }

        public async Task<User> Detail(int id)
        {
            var user = await _context.Users
                                     .Include(x => x.Department)
                                     .FirstOrDefaultAsync(x => x.Id == id);

            return user;
        }

        public async Task<User> Login(string mail)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Mail == mail);
        }

        public async Task<User> Update(UpdateUserRequestDTO request)
        {
            var user = await _context.Users
                                     .Include(x=>x.Department)
                                     .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (user == null)
            {
                throw new Exception("Id not found");
            }

            user.UserName = request.UserName;
            user.Mail = request.Mail;
            user.DepartmentId = request.DepartmentId;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return user;
        }
    }
}
