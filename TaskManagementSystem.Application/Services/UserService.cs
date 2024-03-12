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

        public async Task<UserResponseDTO> AddUserAsync(UserRequestDTO request)
        {
            var user = new User()
            {
                UserName = request.UserName,
                Mail = request.Mail,
                DepartmentId = request.DepartmentId,
            };

            await _userRepository.AddUserAsync(user);

            return new UserResponseDTO
            {
                Id = user.Id,
                UserName = user.UserName,
                Mail = user.Mail,
                DepartmentId = user.DepartmentId,
            };
        }

        public async Task DeleteUserAsync(DeleteUserRequestDTO request)
        {
            await _userRepository.DeleteUserAsync(request.Id);
        }
        public async Task<List<GetUserResponseDTO>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();
            var response = new List<GetUserResponseDTO>();
            foreach (var user in users)
            {
                var department = await _departmentRepository.GetDepartmentByIdAsync(user.DepartmentId);
                response.Add(new GetUserResponseDTO()
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Mail = user.Mail,
                    DepartmentName = department.DepartmentName,
                });
            }
            return response;
        }
        public async Task<GetUserByIdResponseDTO> GetUserByIdAsync(GetUserByIdRequestDTO request)
        {
            var user = await _userRepository.GetUserByIdAsync(request.Id);
            var department = await _departmentRepository.GetDepartmentByIdAsync(user.DepartmentId);
            var userDTO = new GetUserByIdResponseDTO
            {
                Id = user.Id,
                UserName = user.UserName,
                Mail = user.Mail,
                DepartmentName = department.DepartmentName,
            };
            return userDTO;
        }

        public async Task<User> LoginUserAsync(LoginUserRequestDTO request)
        {
            return await _userRepository.GetUserByNameAsync(request.Mail);
        }
        public async Task<UpdateUserResponseDTO> UpdateUserAsync(UpdateUserRequestDTO request)
        {
            var user = await _userRepository.GetUserByIdAsync(request.Id);
            var department = await _departmentRepository.GetDepartmentByIdAsync(request.DepartmentId);

            user.UserName = request.UserName;
            user.Mail = request.Mail;
            user.DepartmentId = request.DepartmentId;

            await _userRepository.UpdateUserAsync(request);

            return new UpdateUserResponseDTO
            {
                Id = user.Id,
                UserName = user.UserName,
                Mail = user.Mail,
                DepartmentName = department.DepartmentName
            };
        }
    }
}
