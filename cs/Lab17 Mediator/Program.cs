using System;
using System.Collections.Generic;

// Абстрактний клас посередника
public abstract class Mediator
{
    public abstract void Send(string message, Colleague colleague);
}

// Клас колеги
public abstract class Colleague
{
    protected Mediator mediator;

    public Colleague(Mediator mediator)
    {
        this.mediator = mediator;
    }

    public abstract void Send(string message);
}

// Клас конкретного колеги (клієнт)
public class Client : Colleague
{
    public Client(Mediator mediator) : base(mediator) { }

    public override void Send(string message)
    {
        Console.WriteLine($"Клієнт вимагає книгу: {message}");
        mediator.Send(message, this);
    }
}

// Клас конкретного колеги (касир)
public class Cashier : Colleague
{
    public Cashier(Mediator mediator) : base(mediator) { }

    public override void Send(string message)
    {
        Console.WriteLine($"Касир обробляє замовлення на книгу: {message}");
        mediator.Send(message, this);
    }
}

// Клас конкретного колеги (склад)
public class Warehouse : Colleague
{
    public Warehouse(Mediator mediator) : base(mediator) { }

    public override void Send(string message)
    {
        Console.WriteLine($"Склад відправляє книгу: {message}");
        mediator.Send(message, this);
    }
}

// Клас конкретного посередника
public class BookstoreMediator : Mediator
{
    private List<Client> clients = new List<Client>();
    private List<Cashier> cashiers = new List<Cashier>();
    private Warehouse warehouse;

    public void AddClient(Client client)
    {
        clients.Add(client);
    }

    public void AddCashier(Cashier cashier)
    {
        cashiers.Add(cashier);
    }

    public void SetWarehouse(Warehouse warehouse)
    {
        this.warehouse = warehouse;
    }

    public override void Send(string message, Colleague colleague)
    {
        if (colleague is Client)
        {
            foreach (var cashier in cashiers)
            {
                cashier.Send(message);
            }
        }
        else if (colleague is Cashier)
        {
            warehouse.Send(message);
        }
    }
}

class Program
{
    static void Main()
    {
        // Використання Mediator Pattern
        var mediator = new BookstoreMediator();

        var client1 = new Client(mediator);
        var client2 = new Client(mediator);

        var cashier1 = new Cashier(mediator);
        var cashier2 = new Cashier(mediator);

        mediator.AddClient(client1);
        mediator.AddClient(client2);

        mediator.AddCashier(cashier1);
        mediator.AddCashier(cashier2);

        var warehouse = new Warehouse(mediator);
        mediator.SetWarehouse(warehouse);

        client1.Send("Патерни проектування");
    }
}
