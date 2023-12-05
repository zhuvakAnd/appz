//створ нові обєкти викор існуючий обєкт як прототип 
//для клонування книг де є прототип (оригінал) та нові обєкти (копії)
using System;

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }

    public Book(string title, string author)
    {
        Title = title;
        Author = author;
    }

    public Book Clone()
    {
        return new Book(Title, Author);
    }
}

class Program
{
    static void Main()
    {
        Book bookPrototype = new Book("Sample Title", "Sample Author");

        // Клонування книги
        Book newBook = bookPrototype.Clone();
        newBook.Title = "New Title";
        newBook.Author = "New Author";

        Console.WriteLine(newBook.Title + " by " + newBook.Author);
    }
}
