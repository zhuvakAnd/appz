//констр складних об зі склад влас, забезпечуючи зручний спосіб ініціал об
//для створ книг з визнач їх заголовку, автору, жанру, ціни
using System;

class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public decimal Price { get; set; }
}

class BookBuilder
{
    private string title;
    private string author;
    private string genre;
    private decimal price;

    public BookBuilder SetTitle(string title)
    {
        this.title = title;
        return this;
    }

    public BookBuilder SetAuthor(string author)
    {
        this.author = author;
        return this;
    }

    public BookBuilder SetGenre(string genre)
    {
        this.genre = genre;
        return this;
    }

    public BookBuilder SetPrice(decimal price)
    {
        this.price = price;
        return this;
    }

    public Book Build()
    {
        return new Book
        {
            Title = title,
            Author = author,
            Genre = genre,
            Price = price
        };
    }
}

class Program
{
    static void Main()
    {
        BookBuilder bookBuilder = new BookBuilder();
        Book book = bookBuilder.SetTitle(" The Stormlight Archive")
                              .SetAuthor("Brandon Sanderson")
                              .SetGenre(" Fantasy")
                              .SetPrice(21.99M)
                              .Build();

        Console.WriteLine($"Title: {book.Title}");
        Console.WriteLine($"Author: {book.Author}");
        Console.WriteLine($"Genre: {book.Genre}");
        Console.WriteLine($"Price: ${book.Price:F2}");
    }
}
