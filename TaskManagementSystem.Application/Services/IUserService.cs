using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Infrastructure.DTOs.UserDTOs.UserRequestModel;
using TaskManagementSystem.Infrastructure.DTOs.UserDTOs.UserResponseModel;

namespace TaskManagementSystem.Application.Services
{
    public interface IUserService
    {
        Task<GetUserByIdResponseDTO> Detail(GetUserByIdRequestDTO request);
        Task<List<GetUserResponseDTO>> All();
        Task<UserResponseDTO> Create(UserRequestDTO request);
        Task<UpdateUserResponseDTO> Update(UpdateUserRequestDTO request);
        Task Delete(DeleteUserRequestDTO request);
        Task<User> Login(LoginUserRequestDTO request);
    }
}
