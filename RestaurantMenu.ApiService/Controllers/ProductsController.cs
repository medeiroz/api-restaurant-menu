using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantMenu.ApiService.Infrastructure;
using RestaurantMenu.ApiService.Models;

namespace RestaurantMenu.ApiService.Controllers;

[Route("[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var products = await _context.Products.ToListAsync();

        if (products == null)
        {
            return NotFound();
        }

        return Ok(products);
    }

    [HttpGet("{id:int}", Name="GetProduct")]
    public async Task<IActionResult> Find(int id) {
        var product = await _context.Products.FirstOrDefaultAsync(product => product.Id == id);

        if (product is null) {
            return NotFound();
        }

        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> Store(Product product)
    {
        if (product is null) {
            return BadRequest();
        }

        await _context.AddAsync(product);
        await _context.SaveChangesAsync();

        return new CreatedAtRouteResult("GetProduct", new { id = product.Id });
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, Product product)
    {

        if (id != product.Id) {
            return BadRequest();
        }

        _context.Entry(product).State = EntityState.Modified;
        _context.SaveChanges();

        return Ok(product);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var product = await _context.Products.FirstOrDefaultAsync(product => product.Id == id);

        if (product is null) {
            return NotFound("Produto Não encontrado");
        }

        _context.Products.Remove(product);
        _context.SaveChanges();

        return Ok(product);
    }
}
