using Microsoft.EntityFrameworkCore;
using WarehouseApp.Data;
using WarehouseApp.DTOs;
using WarehouseApp.Models;

namespace WarehouseApp.Services.DepartmentService
{
    public class DepartmentService : IDepartmetnService
    {
        private readonly AppDbContext _context;

        public DepartmentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Department> AddDepartment(DepartmentCreateDto request)
        {
            var newDepartment = new Department
            {
                Name = request.Name,
            };

            var products = request.Products.Select(p => new Product { Name = p.Name, Department = newDepartment }).ToList();
            var workers = request.workers.Select(w => new Worker { FirstName = w.FirstName, LastName = w.LastName, Departments = new List<Department> { newDepartment } }).ToList();
            
            newDepartment.Products = products;
            newDepartment.Workers = workers;

            _context.Departments.Add(newDepartment);
            await _context.SaveChangesAsync();

            return newDepartment;
        }

        public async Task<Department> DeleteDepartment(int id)
        {
            var department = await _context.Departments.FindAsync(id);

            if (department is null)
                return null;

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();

            return department;
        }

        public async Task<List<Department>> GetAllDepartments()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<Department> GetDepartment(int id)
        {
            var department = await _context.Departments.FindAsync(id);

            if (department is null)
                return null;


            return department;
        }

        public async Task<Department> UpdateDepartment(int id, Department request)
        {
            var department = await _context.Departments.FindAsync(id);

            if (department is null)
                return null;

            department.Name = request.Name;
            department.Workers = request.Workers;

            await _context.SaveChangesAsync();

            return department;
        }
    }
}
