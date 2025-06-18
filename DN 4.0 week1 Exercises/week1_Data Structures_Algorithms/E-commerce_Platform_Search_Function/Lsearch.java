class Product {
    int prodId;
    String prodName;
    String category;

    public Product(int prodId, String prodName, String category) {
        this.prodId = prodId;
        this.prodName = prodName;
        this.category = category;
    }
}

class Lsearch {
    public static Product linearSearch(Product[] prods, String prodName) {
        for (Product p: prods) {
            if (p.prodName.equals(prodName)) {
                return p;
            }
        }
        return null;
    }

    public static Product binarySearch(Product[] prods, String prodName, int left, int right) {
        if (left <= right) {
            int mid = left + (right - left) / 2;
            if (prods[mid].prodName.equals(prodName)) {
                return prods[mid];
            }
            if (prods[mid].prodName.compareTo(prodName) > 0) {
                return binarySearch(prods, prodName, left, mid - 1);
            } else {
                return binarySearch(prods, prodName, mid + 1, right);
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
