using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Infrastructure.DTOs.UserDTOs.UserRequestModel;
using TaskManagementSystem.Infrastructure.DTOs.UserDTOs.UserResponseModel;

namespace TaskManagementSystem.Application.Services
{
    public interface IUserService
    {
        Task<GetUserResponseDTO> Detail(GetUserIdRequestDTO request);
        Task<List<GetUserResponseDTO>> All();
        Task<CreateUserResponseDTO> Create(CreateUserRequestDTO request);
        Task<UpdateUserResponseDTO> Update(UpdateUserRequestDTO request);
        Task Delete(GetUserIdRequestDTO request);
        Task<User> Login(LoginUserRequestDTO request);
    }
}
