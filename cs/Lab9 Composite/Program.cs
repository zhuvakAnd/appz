//дозвол клієтові оброб окремі об і їх склад компон однаковим способом. він викор структ дерева для представлення частково-цілого ієрархічного об'єкта. Це допомагає уникнути дублювання коду та спрощує обробку складних структур
//бути ієрархічна структура категорій книг, де кожна категорія може містити підкатегорії та окремі книги. Composite Pattern дозволяє легко працювати з усією ієрархією категорій та книг, обробляючи їх як єдиний об'єкт

using System;
using System.Collections.Generic;

// Абстрактний клас для категорій книг та окремих книг
abstract class BookComponent
{
    public abstract string Display();
}

// Конкретний клас для окремих книг
class Book : BookComponent
{
    private readonly string title;

    public Book(string title)
    {
        this.title = title;
    }

    public override string Display()
    {
        return $"Книга: {title}";
    }
}

// Конкретний клас для категорій книг
class Category : BookComponent
{
    private readonly string name;
    private readonly List<BookComponent> children = new List<BookComponent>();

    public Category(string name)
    {
        this.name = name;
    }

    public void Add(BookComponent component)
    {
        children.Add(component);
    }

    public override string Display()
    {
        string result = $"Категорія: {name}\n";
        foreach (var child in children)
        {
            result += $" - {child.Display()}\n";
        }
        return result;
    }
}

class Program
{
    static void Main()
    {
        // Створення ієрархії категорій та книг
        var fantasy = new Category("Фантастика");
        fantasy.Add(new Book("Гра престолів"));
        fantasy.Add(new Book("Гаррі Поттер"));

        var detective = new Category("Детективи");
        detective.Add(new Book("Шерлок Холмс"));

        var rootCategory = new Category("Всі книги");
        rootCategory.Add(fantasy);
        rootCategory.Add(detective);

        // Виведення ієрархії
        Console.WriteLine(rootCategory.Display());
    }
}
