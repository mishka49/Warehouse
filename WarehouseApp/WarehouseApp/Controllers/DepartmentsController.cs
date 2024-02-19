using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WarehouseApp.DTOs;
using WarehouseApp.Models;
using WarehouseApp.Services.DepartmentService;

namespace WarehouseApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly ILogger<DepartmentsController> _logger;

        private readonly IDepartmetnService _departmentService;

        public DepartmentsController(ILogger<DepartmentsController> logger, IDepartmetnService departmetnService)
        {
            _departmentService = departmetnService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<Department>>> GetDepartments()
        {
            return await _departmentService.GetAllDepartments();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Worker>>> GetSingleDepartment(int id)
        {
            var result = await _departmentService.GetDepartment(id);

            if (result is null)
                return NotFound("Sorry, department is doesn't exist");

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Department>> AddDepartment(DepartmentCreateDto department)
        {
            var result = await _departmentService.AddDepartment(department);

            if (result is null)
                return BadRequest();

            return Created("",result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Department>> UpdateDepartment(int id, Department department)
        {
            var result = await _departmentService.UpdateDepartment(id, department);

            if (result is null)
                return NotFound("Sorry, department is doesn't exist");

            return Ok(result);
        }
        

        [HttpDelete("{id}")]
        public async Task<ActionResult<Department>> DeleteDepartment(int id)
        {
            var result = await _departmentService.DeleteDepartment(id);

            if (result is null)
                return NotFound("Sorry, departments is doesn't exist");

            return Ok(result);
        }
    }
}
