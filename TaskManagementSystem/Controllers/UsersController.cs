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
        public async Task<IActionResult> All()
        {
            var users = await _userService.GetAllUsersAsync();

            return Ok(users);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Detail([FromBody] GetUserByIdRequestDTO request)
        {
            var user = await _userService.GetUserByIdAsync(request);

            return Ok(user);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] UserRequestDTO request)
        {
            var newUser = await _userService.AddUserAsync(request);

            return Ok(newUser);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateUserRequestDTO request)
        {
            var user = await _userService.UpdateUserAsync(request);

            return Ok(user);
        }

       [HttpDelete("[action]")]
        public async Task<IActionResult> Delete([FromBody] DeleteUserRequestDTO request)
        {
            await _userService.DeleteUserAsync(request);
            return Ok();
        }
        [AllowAnonymous]
        [HttpPost("[action]")]
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

        [HttpGet("[action]")]
        public IActionResult CurrentUser()
        {
            var user = _currentUserService.GetCurrentUser();

            return Ok(new { user });
        }

    }
}
