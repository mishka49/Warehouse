namespace WarehouseApp.Models
{
    public class Department
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public List<Worker> Workers { get; set; } = new();

        public List<Product> Products { get; set; } = new();
      }
}
