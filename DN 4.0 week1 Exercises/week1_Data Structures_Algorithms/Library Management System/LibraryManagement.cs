using System;

// Book.cs
public class Book
{
    public int BookId { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }

    public Book(int bookId, string title, string author)
    {
        BookId = bookId;
        Title = title ?? throw new ArgumentNullException(nameof(title));
        Author = author ?? throw new ArgumentNullException(nameof(author));
    }
}

// LibraryManagement.cs
public static class LibraryManagement
{
    public static Book LinearSearch(Book[] books, string title)
    {
        if (books == null || title == null)
            return null;

        foreach (Book book in books)
        {
            if (book.Title.Equals(title))
            {
                return book;
            }
        }
        return null;
    }

    public static Book BinarySearch(Book[] books, string title, int left, int right)
    {
        if (books == null || title == null)
            return null;

        if (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (books[mid].Title.Equals(title))
            {
                return books[mid];
            }
            if (string.Compare(books[mid].Title, title) > 0)
            {
                return BinarySearch(books, title, left, mid - 1);
            }
            else
            {
                return BinarySearch(books, title, mid + 1, right);
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
