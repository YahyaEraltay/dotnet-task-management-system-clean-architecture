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

namespace TaskManagementSystem.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IGenerateJwtToken _generateJwtToken;
        private readonly ICurrentUserService _currentUserService;

        public UserController(IUserService userService, IGenerateJwtToken generateJwtToken, ICurrentUserService currentUserService)
        {
            _userService = userService;
            _generateJwtToken = generateJwtToken;
            _currentUserService = currentUserService;
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAllUser()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet]
        public async Task<IActionResult> GetUserById([FromBody] GetUserByIdRequestDTO request)
        {
            var user = await _userService.GetUserByIdAsync(request);
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] UserRequestDTO request)
        {
            var newUser = await _userService.AddUserAsync(request);

            return Ok(newUser);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequestDTO request)
        {
            var user = await _userService.UpdateUserAsync(request);
            return Ok(user);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser([FromBody] DeleteUserRequestDTO request)
        {
            await _userService.DeleteUserAsync(request);
            return Ok();
        }
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUserRequestDTO request)
        {
            var user = await _userService.LoginUserAsync(request);
            if (user == null)
            {
                return Unauthorized(new { message = "Invalid username" });
            }
            var token = _generateJwtToken.GenerateToken(user);
            return Ok(new { token });
        }

        [HttpGet("GetCurrrentUser")]
        public IActionResult GetCurrentUser()
        {
            var user = _currentUserService.GetCurrentUser();
            return Ok(new { user });
        }

    }
}
