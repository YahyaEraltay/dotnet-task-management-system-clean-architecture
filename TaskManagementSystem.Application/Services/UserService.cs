using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Infrastructure.DTOs.UserDTOs.UserRequestModel;
using TaskManagementSystem.Infrastructure.DTOs.UserDTOs.UserResponseModel;
using TaskManagementSystem.Infrastructure.Repositories;

namespace TaskManagementSystem.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<CreateUserResponseDTO> Create(CreateUserRequestDTO request)
        {
            var user = new User()
            {
                UserName = request.UserName,
                Mail = request.Mail,
                DepartmentId = request.DepartmentId,
            };

            await _userRepository.Create(user);

            return new CreateUserResponseDTO
            {
                Id = user.Id,
                UserName = user.UserName,
                Mail = user.Mail,
                DepartmentId = user.DepartmentId,
            };
        }

        public async Task<DeleteUserResponseDTO> Delete(GetUserIdRequestDTO request)
        {
            var user = await _userRepository.Detail(request.Id);
            var response = new DeleteUserResponseDTO();

            if (user != null)
            {
                await _userRepository.Delete(user);
                response.IsDeleted = true;
                response.Message = "User deleted";
            }
            else
            {
                response.IsDeleted = false;
                response.Message = "User could not be deleted";
            }

            return response;
        }
        public async Task<List<UserResponseDTO>> All()
        {
            var users = await _userRepository.All();
            var response = new List<UserResponseDTO>();

            foreach (var user in users)
            {
                response.Add(new UserResponseDTO()
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Mail = user.Mail,
                    DepartmentName = user.Department.DepartmentName
                });
            }
            return response;
        }
        public async Task<UserResponseDTO> Detail(GetUserIdRequestDTO request)
        {
            var user = await _userRepository.Detail(request.Id);
            if (user != null)
            {
                var userDTO = new UserResponseDTO
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Mail = user.Mail,
                    DepartmentName = user.Department.DepartmentName
                };
                return userDTO;
            }
            else
            {
                throw new Exception("User not found");
            }
        }

        public async Task<User> Login(LoginUserRequestDTO request)
        {
            return await _userRepository.Login(request.Mail);
        }
        public async Task<UserResponseDTO> Update(UpdateUserRequestDTO request)
        {
            var user = await _userRepository.Detail(request.Id);

            if (user != null)
            {
                user.UserName = request.UserName;
                user.Mail = request.Mail;
                user.DepartmentId = request.DepartmentId;

                await _userRepository.Update(request);

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
