using System;
using System.Collections.Generic;

// Абстрактний клас команди
abstract class Command
{
    public abstract void Execute();
}

// Конкретна команда для додавання товару до кошика
class AddToCartCommand : Command
{
    private readonly string itemName;

    public AddToCartCommand(string itemName)
    {
        this.itemName = itemName;
    }

    public override void Execute()
    {
        Console.WriteLine($"Товар '{itemName}' додано до кошика.");
    }
}

// Конкретна команда для оформлення замовлення
class PlaceOrderCommand : Command
{
    public override void Execute()
    {
        Console.WriteLine("Замовлення оформлено.");
    }
}

// Одиниця управління (Invoker)
class RemoteControl
{
    private readonly List<Command> commands = new List<Command>();

    public void AddCommand(Command command)
    {
        commands.Add(command);
    }

    public void ExecuteCommands()
    {
        foreach (var command in commands)
        {
            command.Execute();
        }
    }
}

class Program
{
    static void Main()
    {
        // Використання Command Pattern
        RemoteControl remoteControl = new RemoteControl();

        AddToCartCommand addItemCommand = new AddToCartCommand("Книга 'Патерни проектування'");
        PlaceOrderCommand placeOrderCommand = new PlaceOrderCommand();

        remoteControl.AddCommand(addItemCommand);
        remoteControl.AddCommand(placeOrderCommand);

        remoteControl.ExecuteCommands();
    }
}
