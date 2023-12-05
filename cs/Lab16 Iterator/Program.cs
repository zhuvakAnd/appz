using System;
using System.Collections;
using System.Collections.Generic;

// Клас, що представляє книгу
class Book
{
    public string Title { get; }
    public string Author { get; }

    public Book(string title, string author)
    {
        Title = title;
        Author = author;
    }
}

// Клас колекції книг
class BookCollection : IEnumerable<Book>
{
    private List<Book> books = new List<Book>();

    // Конструктор з ініціалізацією книг
    public BookCollection(IEnumerable<Book> initialBooks)
    {
        books.AddRange(initialBooks);
    }

    public IEnumerator<Book> GetEnumerator()
    {
        return books.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

class Program
{
    static void Main()
    {
        // Створення колекції книг та додавання книг
        var initialBooks = new List<Book>
        {
            new Book("Патерни проектування", "Еріх Гамма"),
            new Book("Чистий код", "Роберт Мартін"),
            new Book("Алгоритми та структури даних", "Томас Кормен")
        };

        var bookCollection = new BookCollection(initialBooks);

        // Використання Iterator Pattern
        foreach (var book in bookCollection)
        {
            Console.WriteLine($"{book.Title} ({book.Author})");
        }
    }
}
