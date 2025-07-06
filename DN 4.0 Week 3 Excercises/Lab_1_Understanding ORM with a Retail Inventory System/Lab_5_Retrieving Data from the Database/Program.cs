using Microsoft.EntityFrameworkCore;
using RetailInventory.Models;

var context = new AppDbContext();

var products = await context.Products.Include(p => p.Category).ToListAsync();
Console.WriteLine(" All Products:");
foreach (var p in products)
{
    Console.WriteLine($"{p.Name} - ₹{p.Price} - Category: {p.Category?.Name}");
}

var product = await context.Products.FindAsync(1);
Console.WriteLine($"\n Find by ID 1: {product?.Name}");

var expensive = await context.Products.FirstOrDefaultAsync(p => p.Price > 50000);
Console.WriteLine($"\n Expensive Product: {expensive?.Name}");
