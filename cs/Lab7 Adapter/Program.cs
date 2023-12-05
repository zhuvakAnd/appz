//доз об прац разом, навіть якщо вони мають несумісні інтерфейси. це досяг шляхом введ адаптеру, який конверт один інтер в інший
//є друк та елект книги, але для спрощ роботи з книгами ми робимо так щоб всі книги викорис спільн метод read
using System;

// Інтерфейс книги
interface IBook
{
    void Read();
}

// Клас для друкованих книг
class PrintedBook
{
    public void PrintBook()
    {
        Console.WriteLine("Друкована книга");
    }
}

// Адаптер для забезпечення читання друкованих книг
class PrintedBookAdapter : IBook
{
    private readonly PrintedBook printedBook;

    public PrintedBookAdapter(PrintedBook book)
    {
        printedBook = book;
    }

    public void Read()
    {
        printedBook.PrintBook();
    }
}

// Клас для електронних книг
class EBook
{
    public void ReadEBook()
    {
        Console.WriteLine("Електронна книга");
    }
}

// Клас для читача, який працює з електронними книгами
class EBookReader : IBook
{
    private readonly EBook ebook;

    public EBookReader(EBook ebook)
    {
        this.ebook = ebook;
    }

    public void Read()
    {
        ebook.ReadEBook();
    }
}

class Program
{
    static void Main()
    {
        // Використання адаптера для читання друкованих книг
        PrintedBook printedBook = new PrintedBook();
        IBook bookAdapter = new PrintedBookAdapter(printedBook);
        bookAdapter.Read();

        // Використання електронної книги
        EBook ebook = new EBook();
        IBook ebookReader = new EBookReader(ebook);
        ebookReader.Read();
    }
}
