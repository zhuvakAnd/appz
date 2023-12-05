//
using System;

// Абстракція для книг
abstract class Book
{
    protected readonly string title;
    protected readonly string author;
    protected readonly IBookImplementation implementation;

    public Book(string title, string author, IBookImplementation implementation)
    {
        this.title = title;
        this.author = author;
        this.implementation = implementation;
    }

    public abstract string Display();
}

// Конкретна реалізація книг для друкованих книг
class PrintedBook : Book
{
    public PrintedBook(string title, string author, IBookImplementation implementation)
        : base(title, author, implementation)
    { }

    public override string Display()
    {
        return $"Printed Book: {title} - {author}";
    }
}

// Конкретна реалізація книг для електронних книг
class EBook : Book
{
    public EBook(string title, string author, IBookImplementation implementation)
        : base(title, author, implementation)
    { }

    public override string Display()
    {
        return $"E-Book: {title} - {author}";
    }
}

// Інтерфейс для імплементації книг
interface IBookImplementation
{
    string GetInfo();
}

// Друкована книга
class PrintedBookImplementation : IBookImplementation
{
    private readonly string title;
    private readonly string author;

    public PrintedBookImplementation(string title, string author)
    {
        this.title = title;
        this.author = author;
    }

    public string GetInfo()
    {
        return $"Printed Book: {title} - {author}";
    }
}

// Електронна книга
class EBookImplementation : IBookImplementation
{
    private readonly string title;
    private readonly string author;

    public EBookImplementation(string title, string author)
    {
        this.title = title;
        this.author = author;
    }

    public string GetInfo()
    {
        return $"E-Book: {title} - {author}";
    }
}

class Program
{
    static void Main()
    {
        // Використання Bridge Pattern
        IBookImplementation printedBookImplementation = new PrintedBookImplementation("Printed Book 1", "Author 1");
        IBookImplementation ebookImplementation = new EBookImplementation("E-Book 1", "Author 2");

        Book printedBook = new PrintedBook("Ритуал", "Дяченко Дарина", printedBookImplementation);
        Book ebook = new EBook("Ритуал", "Дяченко Сергій", ebookImplementation);

        Console.WriteLine(printedBook.Display());
        Console.WriteLine(ebook.Display());
    }
}
