using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Application.Services;
using TaskManagementSystem.Infrastructure.DTOs.DepartmentDTOs.DepartmentRequestModel;
using TaskManagementSystem.Infrastructure.DTOs.DepartmentDTOs.DepartmentResponseModel;

namespace TaskManagementSystem.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        [Route("GetAllDepartment")]
        public async Task<IActionResult> GetAllDepartment()
        {
            var departments = await _departmentService.GetAllDepartmentAsync();
            return Ok(departments);
        }

        [HttpGet]
        public async Task<IActionResult> GetDepartmentById([FromBody] GetDepartmentByIdRequestDTO request)
        {
            var department = await _departmentService.GetDepartmentByIdAsync(request);

            return Ok(department);
        }


        [HttpPost]
        public async Task<IActionResult> AddDepartment([FromBody] DepartmentRequestDTO request)
        {
            var department = await _departmentService.AddDepartmentAsync(request);
            return Ok(department);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDepartment([FromBody] UpdateDepartmentRequestDTO request)
        {
            await _departmentService.UpdateDepartmentAsync(request);
            return Ok(request);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDepartment([FromBody] DeleteDepartmentRequestDTO request)
        {
            await _departmentService.DeleteDepartmentAsync(request);
            return Ok();
        }
    }
}
