namespace WarehouseApp.DTOs
{
    public record struct WorkerCreateDto(string FirstName, string LastName, List<DepartmentCreateDto> departments);
}
