using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Infrastructure.DTOs.UserDTOs.UserRequestModel;
using TaskManagementSystem.Infrastructure.DTOs.UserDTOs.UserResponseModel;

namespace TaskManagementSystem.Application.Services
{
    public interface IUserService
    {
        Task<UserResponseDTO> Detail(GetUserIdRequestDTO request);
        Task<List<UserResponseDTO>> All();
        Task<CreateUserResponseDTO> Create(CreateUserRequestDTO request);
        Task<UserResponseDTO> Update(UpdateUserRequestDTO request);
        Task<DeleteUserResponseDTO> Delete(GetUserIdRequestDTO request);
        Task<User> Login(LoginUserRequestDTO request);
    }
}
