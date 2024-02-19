using System.Text.Json.Serialization;

namespace WarehouseApp.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int DepartmentId { get; set; }
        [JsonIgnore]
        public Department Department { get; set; } = null!;
    }
}
