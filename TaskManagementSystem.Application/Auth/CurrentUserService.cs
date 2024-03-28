using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks; // Asenkron metot kullanımı için bu using eklenmeli
using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Infrastructure.DTOs.UserDTOs.UserResponseModel;
using TaskManagementSystem.Infrastructure.Repositories;

namespace TaskManagementSystem.Application.Auth
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRepository _userRepository;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor, IUserRepository userRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
        }

        public async Task<UserResponseDTO> GetCurrentUser()
        {
            var claims = _httpContextAccessor.HttpContext.User.Claims;
            var email = claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

            var user = await _userRepository.CurrentUser(email);

            if (user != null)
            {
                return new UserResponseDTO
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Mail = user.Mail,
                    DepartmentName = user.Department.DepartmentName
                };
            }
            else
            {
                throw new Exception("User not found");
            }
        }
    }
}
