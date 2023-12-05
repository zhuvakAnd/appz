using System;

// Підсистема для пошуку книг
class BookSearch
{
    public void SearchByTitle(string title)
    {
        Console.WriteLine($"Пошук книги за назвою: {title}");
    }
}

// Підсистема для додавання книг до кошика
class Cart
{
    public void AddToCart(string book)
    {
        Console.WriteLine($"Додано книгу до кошика: {book}");
    }
}

// Підсистема для оформлення замовлення
class Order
{
    public void PlaceOrder()
    {
        Console.WriteLine("Замовлення оформлено");
    }
}

// Фасад, який надає простий інтерфейс для клієнтів
class BookStoreFacade
{
    private readonly BookSearch bookSearch;
    private readonly Cart cart;
    private readonly Order order;

    public BookStoreFacade()
    {
        bookSearch = new BookSearch();
        cart = new Cart();
        order = new Order();
    }

    public void SearchAndAddToCart(string title)
    {
        bookSearch.SearchByTitle(title);
        cart.AddToCart(title);
    }

    public void PlaceOrder()
    {
        cart.AddToCart("Книга 1");
        cart.AddToCart("Книга 2");
        order.PlaceOrder();
    }
}

class Program
{
    static void Main()
    {
        // Використання фасаду
        var facade = new BookStoreFacade();
        facade.SearchAndAddToCart("Гра престолів");
        facade.SearchAndAddToCart("Гаррі Поттер");
        facade.PlaceOrder();
    }
}
