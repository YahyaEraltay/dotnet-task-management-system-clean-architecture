using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskManagementSystem.Application.Auth;
using TaskManagementSystem.Application.Services;
using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Infrastructure.DTOs;

namespace TaskManagementSystem.API.Controllers
{
    [Authorize]
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            return Ok(user);
        }

        [HttpPost]
        [Route("AddUser")]
        public async Task<IActionResult> AddUser(UserDTO userDto)
        {
            var newUser = await _userService.AddUserAsync(userDto);
            return Ok(newUser);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(UserDTO userDto, int id)
        {
            var user = await _userService.UpdateUserAsync(userDto, id);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUserAsync(id);
            return Ok();
        }
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login(string userName)
        {
            var user = await _userService.LoginUserAsync(userName);

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
            var userName = _currentUserService.GetCurrentUserName();
            return Ok(new { userName });
        }

    }
}
