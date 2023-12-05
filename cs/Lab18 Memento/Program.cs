using System;
using System.Collections.Generic;

// Клас Memento для збереження стану замовлення
class OrderMemento
{
    public string OrderState { get; }

    public OrderMemento(string orderState)
    {
        OrderState = orderState;
    }
}

// Клас Order, стан якого потрібно зберігати та відновлювати
class Order
{
    public string OrderState { get; set; }

    public Order()
    {
        OrderState = "В обробці";
    }

    public OrderMemento CreateMemento()
    {
        return new OrderMemento(OrderState);
    }

    public void RestoreFromMemento(OrderMemento memento)
    {
        OrderState = memento.OrderState;
    }

    public override string ToString()
    {
        return $"Стан замовлення: {OrderState}";
    }
}

// Клас Caretaker для збереження та відновлення стану
class Caretaker
{
    private List<OrderMemento> mementos = new List<OrderMemento>();

    public void AddMemento(OrderMemento memento)
    {
        mementos.Add(memento);
    }

    public OrderMemento GetMemento(int index)
    {
        return mementos[index];
    }
}

class Program
{
    static void Main()
    {
        // Використання Memento Pattern
        Order order = new Order();
        Caretaker caretaker = new Caretaker();

        Console.WriteLine(order);  // Виведе: Стан замовлення: В обробці

        // Збереження стану
        caretaker.AddMemento(order.CreateMemento());

        // Зміна стану замовлення
        order.OrderState = "Відправлено";
        Console.WriteLine(order);  // Виведе: Стан замовлення: Відправлено

        // Відновлення попереднього стану
        order.RestoreFromMemento(caretaker.GetMemento(0));
        Console.WriteLine(order);  // Виведе: Стан замовлення: В обробці
    }
}
