using System;
using System.Collections.Generic;

// Product.cs
public class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }

    public Product(int productId, string productName, int quantity, double price)
    {
        ProductId = productId;
        ProductName = productName ?? throw new ArgumentNullException(nameof(productName));
        Quantity = quantity;
        Price = price;
    }
}

// Inventory.cs
public class Inventory
{
    private readonly Dictionary<int, Product> _products;

    public Inventory()
    {
        _products = new Dictionary<int, Product>();
    }

    public void AddProduct(Product product)
    {
        if (product == null)
            throw new ArgumentNullException(nameof(product));
        _products[product.ProductId] = product;
    }

    public void UpdateProduct(Product product)
    {
        if (product == null)
            throw new ArgumentNullException(nameof(product));
        _products[product.ProductId] = product;
    }

    public void DeleteProduct(int productId)
    {
        _products.Remove(productId);
    }

    public Product GetProduct(int productId)
    {
        _products.TryGetValue(productId, out var product);
        return product;
    }
}

/*
COMPLEXITY:
Add Operation: O(1)
Update Operation: O(1)
Delete Operation: O(1)
Using a Dictionary provides constant time complexity for add, update, and delete operations, which optimizes the performance for large inventories.
*/
