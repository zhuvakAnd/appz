using System;
using System.Collections.Generic;

// Абстрактний клас спостерігача
public abstract class Observer
{
    public abstract void Update(string message);
}

// Клас конкретного спостерігача (клієнт або працівник магазину)
public class ConcreteObserver : Observer
{
    private string name;

    public ConcreteObserver(string name)
    {
        this.name = name;
    }

    public override void Update(string message)
    {
        Console.WriteLine($"{name} отримав повідомлення: {message}");
    }
}

// Клас суб'єкта (система сповіщення про нові книги)
public class Subject
{
    private List<Observer> observers = new List<Observer>();

    public void AddObserver(Observer observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(Observer observer)
    {
        observers.Remove(observer);
    }

    public void Notify(string message)
    {
        foreach (var observer in observers)
        {
            observer.Update(message);
        }
    }
}

class Program
{
    static void Main()
    {
        // Використання Observer Pattern
        Subject subject = new Subject();

        Observer client1 = new ConcreteObserver("Клієнт 1");
        Observer client2 = new ConcreteObserver("Клієнт 2");
        Observer cashier1 = new ConcreteObserver("Касир 1");
        Observer cashier2 = new ConcreteObserver("Касир 2");

        subject.AddObserver(client1);
        subject.AddObserver(client2);
        subject.AddObserver(cashier1);
        subject.AddObserver(cashier2);

        subject.Notify("Нова книга доступна: 'Патерни проектування'");
    }
}
