using RetailInventory.Models;

var context = new AppDbContext();

if (!context.Categories.Any())
{
    var electronics = new Category { Name = "Electronics" };
    var groceries = new Category { Name = "Groceries" };

    await context.Categories.AddRangeAsync(electronics, groceries);

    var product1 = new Product { Name = "Laptop", Price = 75000, Category = electronics };
    var product2 = new Product { Name = "Rice Bag", Price = 1200, Category = groceries };

    await context.Products.AddRangeAsync(product1, product2);

    await context.SaveChangesAsync();

    Console.WriteLine(" Data inserted successfully.");
}
else
{
    Console.WriteLine(" Data already exists in the database.");
}
