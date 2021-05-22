using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rema1000.Data;
using Rema1000.Models;

namespace Rema1000.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly Rema1000Context _context;

        public ProductsController(Rema1000Context context)
        {
            _context = context;
            DBInitializer init = new DBInitializer();
            init.DbInitialize(_context);
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products.Include(p => p.Supplier)
                                          .Include(p => p.Category).ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProducts(int id)
        {
            var products = await _context.Products.Include(p => p.Supplier)
                                                  .Include(p => p.Category).FirstOrDefaultAsync(p => p.ID == id);

            if (products == null)
            {
                return NotFound();
            }

            return products;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducts(int id, Product products)
        {
            if (id != products.ID)
            {
                return BadRequest();
            }

            _context.Entry(products).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProducts(Product products, int supplierID, int categoryID)
        {
            //if (supplierID != null)
            //{
                products.Supplier = await _context.Supplier.FindAsync(supplierID);
            //}

            //if (categoryID != null)
            //{
                products.Category = await _context.Category.FindAsync(categoryID);
            //}

            _context.Products.Add(products);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProducts", new { id = products.ID }, products);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducts(int id)
        {
            var products = await _context.Products.FindAsync(id);
            if (products == null)
            {
                return NotFound();
            }

            _context.Products.Remove(products);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductsExists(int id)
        {
            return _context.Products.Any(e => e.ID == id);
        }
    }
}
