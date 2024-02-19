using WarehouseApp.Models;

namespace WarehouseApp.Services.WorkerService
{
    public interface IWorkerService
    {
        Task<List<Worker>> GetAllWorkers();
        Task<Worker?> GetWorker(int id);
        Task<Worker?> AddWorker(Worker worker);
        Task<Worker?> UpdateWorker(int id, Worker worker);
        Task<Worker?> DeleteWorker(int id);
    }
}
