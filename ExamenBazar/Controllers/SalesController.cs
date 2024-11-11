using ExamenBazar.Data;
using ExamenBazar.Dtos;
using ExamenBazar.Models;
using ExamenBazar.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamenBazar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : Controller
    {
        private readonly BazarDbContext _context;


        public SalesController(BazarDbContext context)
        {
            _context = context;
        }

        [HttpPost("addSale")]
        public async Task<IActionResult> AddSale([FromBody] SaleDto saleDto)
        {
            if (saleDto == null || saleDto.ProductId <= 0)
                return BadRequest("Datos de venta inválidos");

            var sale = new Sale
            {
                ProductId = saleDto.ProductId,
                Quantity = saleDto.Quantity
            };

            _context.Sales.Add(sale);
            await _context.SaveChangesAsync();

            return Ok(true); // Devuelve true si la venta se registra exitosamente
        }

        [HttpGet("sales")]
        public async Task<IActionResult> GetSales()
        {
            var sales = await _context.Sales
                .Select(s => new
                {
                    s.SaleId,
                    s.ProductId,
                    s.SaleDate,
                    s.Quantity
                })
                .ToListAsync();

            return Ok(sales);
        }


    }
}
