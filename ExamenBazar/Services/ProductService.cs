using ExamenBazar.Models;
using ExamenBazar.Data;

namespace ExamenBazar.Services
{
    public class ProductService
    {
        private readonly BazarDbContext _context;

        public ProductService(BazarDbContext context)
        {
            _context = context;
        }

        public List<Product> SearchProducts(string query)
        {
            return _context.Products
                .Where(p => p.Title.Contains(query))
                .ToList();
        }

        public Product GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }
    }
}