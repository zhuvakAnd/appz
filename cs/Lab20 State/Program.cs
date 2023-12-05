using System;

// Абстрактний клас стану
public abstract class OrderState
{
    public abstract void ProcessOrder();
}

// Клас контексту (замовлення)
public class Order
{
    private OrderState state;

    public void SetState(OrderState state)
    {
        this.state = state;
    }

    public void ProcessOrder()
    {
        if (state != null)
        {
            state.ProcessOrder();
        }
    }
}

// Клас конкретного стану "В обробці"
public class InProgressState : OrderState
{
    public override void ProcessOrder()
    {
        Console.WriteLine("Замовлення в обробці");
    }
}

// Клас конкретного стану "Очікування оплати"
public class PendingPaymentState : OrderState
{
    public override void ProcessOrder()
    {
        Console.WriteLine("Замовлення очікує оплати");
    }
}

// Клас конкретного стану "Відправлено"
public class ShippedState : OrderState
{
    public override void ProcessOrder()
    {
        Console.WriteLine("Замовлення відправлено");
    }
}

class Program
{
    static void Main()
    {
        // Використання State Pattern
        Order order = new Order();

        order.SetState(new InProgressState());
        order.ProcessOrder();  // Виведе: Замовлення в обробці

        order.SetState(new PendingPaymentState());
        order.ProcessOrder();  // Виведе: Замовлення очікує оплати

        order.SetState(new ShippedState());
        order.ProcessOrder();  // Виведе: Замовлення відправлено
    }
}
