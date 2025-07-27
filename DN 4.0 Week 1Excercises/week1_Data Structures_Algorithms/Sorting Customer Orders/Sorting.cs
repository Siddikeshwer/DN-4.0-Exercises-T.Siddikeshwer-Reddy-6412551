using System;

// Order.cs
public class Order
{
    public int OrderId { get; set; }
    public string CustomerName { get; set; }
    public double TotalPrice { get; set; }

    public Order(int orderId, string customerName, double totalPrice)
    {
        OrderId = orderId;
        CustomerName = customerName ?? throw new ArgumentNullException(nameof(customerName));
        TotalPrice = totalPrice;
    }
}

// Sorting.cs
public static class Sorting
{
    public static void BubbleSort(Order[] orders)
    {
        if (orders == null)
            throw new ArgumentNullException(nameof(orders));

        int n = orders.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (orders[j].TotalPrice > orders[j + 1].TotalPrice)
                {
                    Order temp = orders[j];
                    orders[j] = orders[j + 1];
                    orders[j + 1] = temp;
                }
            }
        }
    }

    public static void QuickSort(Order[] orders, int low, int high)
    {
        if (orders == null)
            throw new ArgumentNullException(nameof(orders));

        if (low < high)
        {
            int pi = Partition(orders, low, high);
            QuickSort(orders, low, pi - 1);
            QuickSort(orders, pi + 1, high);
        }
    }

    private static int Partition(Order[] orders, int low, int high)
    {
        double pivot = orders[high].TotalPrice;
        int i = low - 1;
        for (int j = low; j < high; j++)
        {
            if (orders[j].TotalPrice <= pivot)
            {
                i++;
                Order temp = orders[i];
                orders[i] = orders[j];
                orders[j] = temp;
            }
        }
        Order temp1 = orders[i + 1];
        orders[i + 1] = orders[high];
        orders[high] = temp1;
        return i + 1;
    }
}

/*
COMPLEXITY:
Bubble Sort: O(n^2)
Quick Sort: O(n log n)
Quick Sort is generally preferred due to its better average-case time complexity compared to Bubble Sort.
*/
