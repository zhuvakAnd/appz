using System;

// Абстрактний клас книги
abstract class Book
{
    public abstract decimal Cost();
}

// Конкретна реалізація книги
class ConcreteBook : Book
{
    public override decimal Cost()
    {
        return 10m;
    }
}

// Декоратор для знижки
class DiscountDecorator : Book
{
    private readonly Book book;

    public DiscountDecorator(Book book)
    {
        this.book = book;
    }

    public override decimal Cost()
    {
        return 0.8m * book.Cost();
    }
}

// Декоратор для подарунків
class GiftDecorator : Book
{
    private readonly Book book;

    public GiftDecorator(Book book)
    {
        this.book = book;
    }

    public override decimal Cost()
    {
        return book.Cost() + 5m;
    }
}

class Program
{
    static void Main()
    {
        // Використання декораторів
        Book book = new ConcreteBook();
        Console.WriteLine("Звичайна книга: ${0}", book.Cost());

        Book bookWithDiscount = new DiscountDecorator(book);
        Console.WriteLine("Книга зі знижкою: ${0}", bookWithDiscount.Cost());

        Book bookWithGift = new GiftDecorator(book);
        Console.WriteLine("Книга з подарунком: ${0}", bookWithGift.Cost());
    }
}
