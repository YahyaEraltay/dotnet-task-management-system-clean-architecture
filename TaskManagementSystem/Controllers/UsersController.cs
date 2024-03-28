using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskManagementSystem.Application.Auth;
using TaskManagementSystem.Application.Services;
using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Infrastructure.DTOs.UserDTOs;
using TaskManagementSystem.Infrastructure.DTOs.UserDTOs.UserRequestModel;
using TaskManagementSystem.Infrastructure.DTOs.UserDTOs.UserResponseModel;

namespace TaskManagementSystem.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IGenerateJwtToken _generateJwtToken;
        private readonly ICurrentUserService _currentUserService;

        public UsersController(IUserService userService, IGenerateJwtToken generateJwtToken, ICurrentUserService currentUserService)
        {
            _userService = userService;
            _generateJwtToken = generateJwtToken;
            _currentUserService = currentUserService;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<UserResponseDTO>> All()
        {
            var users = await _userService.All();

            return Ok(users);
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<UserResponseDTO>> Detail([FromBody] GetUserIdRequestDTO request)
        {
            var user = await _userService.Detail(request);

            return Ok(user);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<CreateUserResponseDTO>> Create([FromBody] CreateUserRequestDTO request)
        {
            var newUser = await _userService.Create(request);

            return Ok(newUser);
        }

        [HttpPut("[action]")]
        public async Task<ActionResult<UserResponseDTO>> Update([FromBody] UpdateUserRequestDTO request)
        {
            var user = await _userService.Update(request);

            return Ok(user);
        }

        [HttpDelete("[action]")]
        public async Task<ActionResult<DeleteUserResponseDTO>> Delete([FromBody] GetUserIdRequestDTO request)
        {
            var response = await _userService.Delete(request);

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody] LoginUserRequestDTO request)
        {
            var user = await _userService.Login(request);

            if (user == null)
            {
                return Unauthorized(new { message = "Invalid email" });
            }

            var token = _generateJwtToken.GenerateToken(user);

            return Ok(new { token });
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<UserResponseDTO>> CurrentUser()
        {
            var user = await _currentUserService.GetCurrentUser();

            return Ok(new { user });
        }
    }
}
