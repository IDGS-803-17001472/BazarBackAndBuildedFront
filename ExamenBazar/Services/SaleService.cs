using ExamenBazar.Data;
using ExamenBazar.Models;

namespace ExamenBazar.Services
{
    public class SaleService
    {
        private readonly BazarDbContext _context;

        public SaleService(BazarDbContext context)
        {
            _context = context;
        }

    }
}
