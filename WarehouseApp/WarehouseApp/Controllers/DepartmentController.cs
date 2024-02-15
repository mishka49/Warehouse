using Microsoft.AspNetCore.Mvc;
using WarehouseApp.UI.Models;

namespace WarehouseApp.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllDepartments()
        {
            var departments = new List<DepartmentModel>
            {
                new DepartmentModel{Id = 1, Name = "Tools"},
                new DepartmentModel{Id = 2, Name = "Industrial Wood"},
                new DepartmentModel{Id= 3, Name = "Metal"}
            };


            return Ok(departments);
        }

    }
}
