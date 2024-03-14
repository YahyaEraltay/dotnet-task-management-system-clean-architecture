using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Infrastructure.DTOs.UserDTOs.UserRequestModel;
using TaskManagementSystem.Infrastructure.DTOs.UserDTOs.UserResponseModel;
using TaskManagementSystem.Infrastructure.Repositories;

namespace TaskManagementSystem.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public UserService(IUserRepository userRepository, IDepartmentRepository departmentRepository)
        {
            _userRepository = userRepository;
            _departmentRepository = departmentRepository;
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
        public async Task<List<GetUserResponseDTO>> All()
        {
            var users = await _userRepository.All();
            var response = new List<GetUserResponseDTO>();

            foreach (var user in users)
            {
                response.Add(new GetUserResponseDTO()
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Mail = user.Mail,
                    DepartmentName = user.Department.DepartmentName
                });
            }
            return response;
        }
        public async Task<GetUserResponseDTO> Detail(GetUserIdRequestDTO request)
        {
            var user = await _userRepository.Detail(request.Id);
            if (user != null)
            {
                var userDTO = new GetUserResponseDTO
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
                throw new Exception("User could not be found");
            }
        }

        public async Task<User> Login(LoginUserRequestDTO request)
        {
            return await _userRepository.Login(request.Mail);
        }
        public async Task<UpdateUserResponseDTO> Update(UpdateUserRequestDTO request)
        {
            var user = await _userRepository.Detail(request.Id);

            user.UserName = request.UserName;
            user.Mail = request.Mail;
            user.DepartmentId = request.DepartmentId;

            await _userRepository.Update(request);

            return new UpdateUserResponseDTO
            {
                Id = user.Id,
                UserName = user.UserName,
                Mail = user.Mail,
                DepartmentName = user.Department.DepartmentName
            };
        }
    }
}
