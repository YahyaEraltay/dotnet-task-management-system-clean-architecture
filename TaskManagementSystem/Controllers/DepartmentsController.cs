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

        [HttpGet("[action]")]
        public async Task<ActionResult<DepartmentResponseDTO>> All()
        {
            var departments = await _departmentService.All();
            return Ok(departments);
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<GetDepartmentByIdResponseDTO>> Detail([FromBody] GetDepartmentByIdRequestDTO request)
        {
            var department = await _departmentService.Detail(request);

            return Ok(department);
        }


        [HttpPost("[action]")]
        public async Task<ActionResult<DepartmentResponseDTO>> Create([FromBody] DepartmentRequestDTO request)
        {
            var department = await _departmentService.Create(request);
            return Ok(department);
        }

        [HttpPut("[action]")]
        public async Task<ActionResult<UpdateDepartmentResponseDTO>> Update([FromBody] UpdateDepartmentRequestDTO request)
        {
            var department = await _departmentService.Update(request);
            return Ok(department);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete([FromBody] DeleteDepartmentRequestDTO request)
        {
            await _departmentService.Delete(request);
            return Ok();
        }
    }
}
