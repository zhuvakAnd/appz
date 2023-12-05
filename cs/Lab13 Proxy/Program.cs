using System;

// Абстрактний клас для завантаження електронної книги
abstract class EBook
{
    public abstract void Download();
}

// Реальна реалізація завантаження електронної книги
class RealEBook : EBook
{
    private readonly string filename;

    public RealEBook(string filename)
    {
        this.filename = filename;
    }

    public override void Download()
    {
        Console.WriteLine($"Завантаження електронної книги: {filename}");
    }
}

// Заступник для електронної книги
class EBookProxy : EBook
{
    private readonly string filename;
    private readonly bool authenticated;

    public EBookProxy(string filename, bool authenticated)
    {
        this.filename = filename;
        this.authenticated = authenticated;
    }

    public override void Download()
    {
        if (authenticated)
        {
            RealEBook realEBook = new RealEBook(filename);
            realEBook.Download();
        }
        else
        {
            Console.WriteLine("Неавторизований користувач. Завантаження не дозволено.");
        }
    }
}

class Program
{
    static void Main()
    {
        // Використання заступника
        EBook ebook = new EBookProxy("book.pdf", authenticated: true);
        ebook.Download();

        EBook unauthorizedEbook = new EBookProxy("book.pdf", authenticated: false);
        unauthorizedEbook.Download();
    }
}
