namespace WarehouseApp.DTOs
{
    public record struct DepartmentCreateDto(string Name, List<ProductCreateDto> Products, List<WorkerCreateDto> workers);
}
