using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Infrastructure.DTOs.UserDTOs.UserRequestModel;
using TaskManagementSystem.Infrastructure.DTOs.UserDTOs.UserResponseModel;

namespace TaskManagementSystem.Application.Services
{
    public interface IUserService
    {
        Task<GetUserByIdResponseDTO> GetUserByIdAsync(GetUserByIdRequestDTO request);
        Task<List<GetUserResponseDTO>> GetAllUsersAsync();
        Task<UserResponseDTO> AddUserAsync(UserRequestDTO request);
        Task<UpdateUserResponseDTO> UpdateUserAsync(UpdateUserRequestDTO request);
        Task DeleteUserAsync(DeleteUserRequestDTO request);
        Task<User> LoginUserAsync(LoginUserRequestDTO request);
    }
}
