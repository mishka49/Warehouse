using WarehouseApp.DTOs;
using WarehouseApp.Models;

namespace WarehouseApp.Services.ProductService
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProducts();
        Task<Product?> GetProduct(int id);
        Task<Product?> AddProduct(Product product);
        Task<Product?> UpdateProduct(int id, Product product);
        Task<Product?> DeleteProduct(int id);
    }
}
