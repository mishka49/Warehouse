using Microsoft.EntityFrameworkCore;
using System.Data;
using WarehouseApp.Data;
using WarehouseApp.Models;
using WarehouseApp.Services.ProductService;

namespace WarehouseApp.Services.WorkerService
{
    public class WorkerService : IWorkerService
    {
        private readonly AppDbContext _context;

        public WorkerService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Worker> AddWorker(Worker worker)
        {
            _context.Workers.Add(worker);
            await _context.SaveChangesAsync();

            return worker;
        }

        public async Task<Worker?> DeleteWorker(int id)
        {
            var worker = await _context.Workers.FindAsync(id);

            if (worker is null)
                return null;

            _context.Workers.Remove(worker);
            await _context.SaveChangesAsync();

            return worker;
        }

        public async Task<List<Worker>> GetAllWorkers()
        {
            return await _context.Workers.ToListAsync();
        }

        public async Task<Worker?> GetWorker(int id)
        {
            var worker =  await _context.Workers.FindAsync(id);

            if (worker is null)
                return null;
            

            return worker;
        }

        public async Task<Worker?> UpdateWorker(int id, Worker request)
        {
            var worker = await _context.Workers.FindAsync(id);

            if(worker is null)
                return null;
            
            worker.FirstName = request.FirstName;
            worker.LastName = request.LastName;
            worker.Departments = request.Departments;

            await _context.SaveChangesAsync();

            return worker;
        }
    }
}
