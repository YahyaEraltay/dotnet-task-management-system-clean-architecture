using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Application.Services;
using TaskManagementSystem.Infrastructure.DTOs.DepartmentDTOs.DepartmentRequestModel;
using TaskManagementSystem.Infrastructure.DTOs.DepartmentDTOs.DepartmentResponseModel;

namespace TaskManagementSystem.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

       // [HttpGet("[action]")]
        public async Task<IActionResult> All()
        {
            var departments = await _departmentService.GetAllDepartmentAsync();
            return Ok(departments);
        }

       // [HttpGet("[action]")]
        public async Task<IActionResult> Detail([FromBody] GetDepartmentByIdRequestDTO request)
        {
            var department = await _departmentService.GetDepartmentByIdAsync(request);

            return Ok(department);
        }


       // [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] DepartmentRequestDTO request)
        {
            var department = await _departmentService.AddDepartmentAsync(request);
            return Ok(department);
        }

       // [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateDepartmentRequestDTO request)
        {
           var department = await _departmentService.UpdateDepartmentAsync(request);
            return Ok(department);
        }

       // [HttpDelete("[action]")]
        public async Task<IActionResult> Delete([FromBody] DeleteDepartmentRequestDTO request)
        {
            await _departmentService.DeleteDepartmentAsync(request);
            return Ok();
        }
    }
}
