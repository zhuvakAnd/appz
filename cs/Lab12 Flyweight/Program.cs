using System;
using System.Collections.Generic;

// Клас, що представляє пристосуванця (спільні атрибути)
class BookFlyweight
{
    public string Genre { get; }
    public string Language { get; }

    public BookFlyweight(string genre, string language)
    {
        Genre = genre;
        Language = language;
    }
}

// Фабрика пристосуванців
class BookFlyweightFactory
{
    private readonly Dictionary<(string, string), BookFlyweight> flyweights = new Dictionary<(string, string), BookFlyweight>();

    public BookFlyweight GetFlyweight(string genre, string language)
    {
        var key = (genre, language);
        if (!flyweights.ContainsKey(key))
        {
            flyweights[key] = new BookFlyweight(genre, language);
        }
        return flyweights[key];
    }
}

// Клас для окремих книжок, які використовують пристосуванця
class Book
{
    public string Title { get; }
    public BookFlyweight Flyweight { get; }

    public Book(string title, BookFlyweight flyweight)
    {
        Title = title;
        Flyweight = flyweight;
    }

    public string Display()
    {
        return $"Книга: {Title}, Жанр: {Flyweight.Genre}, Мова: {Flyweight.Language}";
    }
}

class Program
{
    static void Main()
    {
        // Використання Flyweight Pattern
        var flyweightFactory = new BookFlyweightFactory();
        var book1 = new Book("Книга 1", flyweightFactory.GetFlyweight("Фантастика", "Англійська"));
        var book2 = new Book("Книга 2", flyweightFactory.GetFlyweight("Фантастика", "Англійська"));
        var book3 = new Book("Книга 3", flyweightFactory.GetFlyweight("Детектив", "Французька"));

        Console.WriteLine(book1.Display());
        Console.WriteLine(book2.Display());
        Console.WriteLine(book3.Display());
    }
}
