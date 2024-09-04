using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ProductsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetProducts()
    {
        return _context.Products.ToList();
    }

    [HttpPost]
    public ActionResult<Product> AddProduct([FromBody] Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetProducts), new { id = product.Id }, product);
    }
}
