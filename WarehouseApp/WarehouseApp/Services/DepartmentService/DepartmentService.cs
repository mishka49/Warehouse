using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using WarehouseApp.Data;
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

        public async Task<Department> AddDepartment(Department department)
        {
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();

            return department;
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
