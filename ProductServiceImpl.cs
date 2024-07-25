using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.DAL;
using WebApplication1.IService;
using WebApplication1.Models;

namespace WebApplication1.ServicesImpl
{
    public class ProductServiceImpl : IProductService
    {
        private readonly MyAppDbContext _context;

        public ProductServiceImpl(MyAppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.Include("Categories").ToList();
        }

        public Product GetProductById(int id)
        {
            return _context.Products.Find(id);
        }

        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }
    }
}
