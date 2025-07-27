using System;

// Product.cs
public class Product
{
    public int ProdId { get; set; }
    public string ProdName { get; set; }
    public string Category { get; set; }

    public Product(int prodId, string prodName, string category)
    {
        ProdId = prodId;
        ProdName = prodName ?? throw new ArgumentNullException(nameof(prodName));
        Category = category ?? throw new ArgumentNullException(nameof(category));
    }
}

// Lsearch.cs
public static class Lsearch
{
    public static Product LinearSearch(Product[] prods, string prodName)
    {
        if (prods == null || prodName == null)
            return null;

        foreach (Product p in prods)
        {
            if (p.ProdName.Equals(prodName))
            {
                return p;
            }
        }
        return null;
    }

    public static Product BinarySearch(Product[] prods, string prodName, int left, int right)
    {
        if (prods == null || prodName == null)
            return null;

        if (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (prods[mid].ProdName.Equals(prodName))
            {
                return prods[mid];
            }
            if (string.Compare(prods[mid].ProdName, prodName) > 0)
            {
                return BinarySearch(prods, prodName, left, mid - 1);
            }
            else
            {
                return BinarySearch(prods, prodName, mid + 1, right);
            }
        }
        return null;
    }
}

/*
COMPLEXITY:
Linear Search: O(n)
Binary Search: O(log n)
Binary search is more suitable for large sorted datasets due to its logarithmic time complexity, compared to the linear time complexity of linear search.
*/
