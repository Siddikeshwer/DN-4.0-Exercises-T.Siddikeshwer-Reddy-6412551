import java.util.HashMap;
import java.util.Map;

class Product {
    int productId;
    String productName;
    int quantity;
    double price;

    public Product(int productId, String productName, int quantity, double price) {
        this.productId = productId;
        this.productName = productName;
        this.quantity = quantity;
        this.price = price;
    }
}

class Inventory {
    private Map<Integer, Product> products;

    public Inventory() {
        this.products = new HashMap<>();
    }

    public void addProduct(Product product) {
        products.put(product.productId, product);
    }

    public void updateProduct(Product product) {
        products.put(product.productId, product);
    }

    public void deleteProduct(int productId) {
        products.remove(productId);
    }

    public Product getProduct(int productId) {
        return products.get(productId);
    }
}

/*

COMPLEXITY:
Add Operation: O(1)
Update Operation: O(1)
Delete Operation: O(1)
Using a HashMap provides constant time complexity for add, update, and delete operations, which optimizes the performance for large inventories.

 */