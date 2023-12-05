//надає інтрфейс для створ сімейства взаємопов обєктів без залежності від їх конкрет класів
//створ сімейств повязаних обєктів таких як книги і закладки. різні фабр створять різні типи книг та закл(всі взаємозал)
using System;

abstract class Book
{
    public abstract string DisplayInfo();
}

class Novel : Book
{
    public override string DisplayInfo()
    {
        return "Роман";
    }
}

class Textbook : Book
{
    public override string DisplayInfo()
    {
        return "Підручник";
    }
}

abstract class Bookmark
{
    public abstract string ShowInfo();
}

class PlainBookmark : Bookmark
{
    public override string ShowInfo()
    {
        return "Закладка";
    }
}

class FancyBookmark : Bookmark
{
    public override string ShowInfo()
    {
        return "Прикрашена закладка";
    }
}

abstract class BookFactory
{
    public abstract Book CreateBook();
    public abstract Bookmark CreateBookmark();
}

class NovelFactory : BookFactory
{
    public override Book CreateBook()
    {
        return new Novel();
    }

    public override Bookmark CreateBookmark()
    {
        return new PlainBookmark();
    }
}

class TextbookFactory : BookFactory
{
    public override Book CreateBook()
    {
        return new Textbook();
    }

    public override Bookmark CreateBookmark()
    {
        return new FancyBookmark();
    }
}

class Program
{
    static void Main()
    {
        BookFactory novelFactory = new NovelFactory();
        Book novel = novelFactory.CreateBook();
        Bookmark bookmark = novelFactory.CreateBookmark();
        Console.WriteLine(novel.DisplayInfo());
        Console.WriteLine(bookmark.ShowInfo());

        BookFactory textbookFactory = new TextbookFactory();
        Book textbook = textbookFactory.CreateBook();
        Bookmark fancyBookmark = textbookFactory.CreateBookmark();
        Console.WriteLine(textbook.DisplayInfo());
        Console.WriteLine(fancyBookmark.ShowInfo());
    }
}
