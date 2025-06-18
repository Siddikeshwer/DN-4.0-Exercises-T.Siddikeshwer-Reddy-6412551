class Book {
    int bookId;
    String title;
    String author;

    public Book(int bookId, String title, String author) {
        this.bookId = bookId;
        this.title = title;
        this.author = author;
    }
}

class LibraryManagement {
    public static Book linearSearch(Book[] books, String title) {
        for (Book book : books) {
            if (book.title.equals(title)) {
                return book;
            }
        }
        return null;
    }

    public static Book binarySearch(Book[] books, String title, int left, int right) {
        if (left <= right) {
            int mid = left + (right - left) / 2;
            if (books[mid].title.equals(title)) {
                return books[mid];
            }
            if (books[mid].title.compareTo(title) > 0) {
                return binarySearch(books, title, left, mid - 1);
            } else {
                return binarySearch(books, title, mid + 1, right);
            }
        }
        return null;
    }
}

/*

COMPLEXITY:
Linear Search: O(n)
Binary Search: O(log n)
Binary search is preferred for sorted data due to its logarithmic time complexity.

*/