using Microsoft.AspNetCore.Mvc;
using WarehouseApp.Models;
using WarehouseApp.Services.WorkerService;

namespace WarehouseApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkersController : ControllerBase
    {
        private readonly IWorkerService _workerService;
        private readonly ILogger<DepartmentsController> _logger;
        public WorkersController(ILogger<DepartmentsController> logger, IWorkerService workerService)
        {
            _logger = logger;
            _workerService = workerService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Worker>>> GetWorkers()
        {
            return await _workerService.GetAllWorkers();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Worker>>> GetSingleWorker(int id)
        {
            var result = await _workerService.GetWorker(id);

            if (result is null)
                return NotFound("Sorry, worker is doesn't exist");

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Worker>> AddWorker(Worker worker)
        {
            var result = await _workerService.AddWorker(worker);

            if (result is null)
                return BadRequest();

            return Ok(result); 
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Worker>> UpdateWorkers(int id, Worker worker)
        {
            var result = await _workerService.UpdateWorker(id,worker);

            if (result is null)
                return NotFound("Sorry, worker is doesn't exist");
 
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Worker>> DeleteWorkers(int id)
        {
            var result =await _workerService.DeleteWorker(id);
            if (result is null)
            {
                return NotFound("Sorry, departments is doesn't exist");
            }
            return Ok(result);
        }
    }
}
