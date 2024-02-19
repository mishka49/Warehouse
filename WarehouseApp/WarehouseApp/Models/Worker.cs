namespace WarehouseApp.Models
{
    public class Worker
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public List<Department> Departments { get; set; } = new();
    }
}
