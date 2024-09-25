using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ShopsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ShopsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Shop>> GetShops()
    {
        return _context.Shops.ToList();
    }

    [HttpPost]
    public ActionResult<Shop> AddShop([FromBody] Shop Shop)
    {
        _context.Shops.Add(Shop);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetShops), new { id = Shop.Id }, Shop);
    }
}
