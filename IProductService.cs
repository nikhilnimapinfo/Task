using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.IService
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
        IEnumerable<Category> GetAllCategories();
    }
}
