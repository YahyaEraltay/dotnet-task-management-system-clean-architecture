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

        public async Task Delete(GetUserIdRequestDTO request)
        {
            await _userRepository.Delete(request.Id);
        }
        public async Task<List<GetUserResponseDTO>> All()
        {
            var users = await _userRepository.All();
            var response = new List<GetUserResponseDTO>();
            foreach (var user in users)
            {
                var department = await _departmentRepository.Detail(user.DepartmentId);
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
        public async Task<GetUserResponseDTO> Detail(GetUserIdRequestDTO request)
        {
            var user = await _userRepository.Detail(request.Id);
            var department = await _departmentRepository.Detail(user.DepartmentId);
            var userDTO = new GetUserResponseDTO
            {
                Id = user.Id,
                UserName = user.UserName,
                Mail = user.Mail,
                DepartmentName = department.DepartmentName,
            };
            return userDTO;
        }

        public async Task<User> Login(LoginUserRequestDTO request)
        {
            return await _userRepository.Login(request.Mail);
        }
        public async Task<UpdateUserResponseDTO> Update(UpdateUserRequestDTO request)
        {
            var user = await _userRepository.Detail(request.Id);
            var department = await _departmentRepository.Detail(request.DepartmentId);

            user.UserName = request.UserName;
            user.Mail = request.Mail;
            user.DepartmentId = request.DepartmentId;

            await _userRepository.Update(request);

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
