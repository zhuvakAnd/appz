//дозв ефект керувати ресурс (об), утримуючи певну к-сть об у "пулі" і надаючи можлив взяття і повернення об до пулу для подал викорис
//для управл доступними книгами, які клієнти можуть взяти напрокат. Пул об допом уникну надмірного створ та знищ книг
using System;
using System.Collections.Generic;

class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
}

class BookPool
{
    private List<Book> pool;
    private List<Book> available;

    public BookPool(int size)
    {
        pool = new List<Book>();
        available = new List<Book>();

        for (int i = 0; i < size; i++)
        {
            pool.Add(new Book { Title = "The Stormlight Archive", Author = "Brandon Sanderson" });
            available.Add(pool[i]);
        }
    }

    public Book BorrowBook()
    {
        if (available.Count > 0)
        {
            Book book = available[available.Count - 1];
            available.RemoveAt(available.Count - 1);
            return book;
        }
        else
        {
            Console.WriteLine("Пул книг вичерпаний.");
            return null;
        }
    }

    public void ReturnBook(Book book)
    {
        if (!available.Contains(book))
        {
            available.Add(book);
        }
    }
}

class Program
{
    static void Main()
    {
        BookPool bookPool = new BookPool(5);
        Book borrowedBook1 = bookPool.BorrowBook();
        Book borrowedBook2 = bookPool.BorrowBook();

        if (borrowedBook1 != null)
        {
            Console.WriteLine($"Книгу '{borrowedBook1.Title}' взяли у пулу.");
        }

        if (borrowedBook2 != null)
        {
            Console.WriteLine($"Книгу '{borrowedBook2.Title}' взяли у пулу.");
        }

        System.Threading.Thread.Sleep(2000);  // Час, коли книги у використанні

        bookPool.ReturnBook(borrowedBook1);
        bookPool.ReturnBook(borrowedBook2);
        Console.WriteLine($"Книгу '{borrowedBook1.Title}' повернули у пул.");
        Console.WriteLine($"Книгу '{borrowedBook2.Title}' повернули у пул.");
    }
}
