﻿using WarehouseApp.DTOs;
using WarehouseApp.Models;

namespace WarehouseApp.Services.DepartmentService
{
    public interface IDepartmetnService
    {
        Task<List<Department>> GetAllDepartments();
        Task<Department?> GetDepartment(int id);
        Task<Department?> AddDepartment(DepartmentCreateDto department);
        Task<Department?> UpdateDepartment(int id, Department department);
        Task<Department?> DeleteDepartment(int id);

    }
}
