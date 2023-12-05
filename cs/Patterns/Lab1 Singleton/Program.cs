//забезп що у системі є тільки один екземп певного класу і надає глобальний доступ до екземп
//створ єдиного екземп (база даних книг). допом уникнути конфліктів при одночасному доступі до обєкту
using System;

public class CustomerLoyalty
{
    private static CustomerLoyalty instance;
    private int points;

    private CustomerLoyalty() { }

    public static CustomerLoyalty GetInstance()
    {
        if (instance == null)
        {
            instance = new CustomerLoyalty();
        }
        return instance;
    }

    public void AddPoints(int amount)
    {
        points += amount;
    }

    public int GetPoints()
    {
        return points;
    }
}

class Program
{
    static void Main()
    {
        CustomerLoyalty loyalty1 = CustomerLoyalty.GetInstance();
        loyalty1.AddPoints(100);

        CustomerLoyalty loyalty2 = CustomerLoyalty.GetInstance();
        loyalty2.AddPoints(50);

        Console.WriteLine(loyalty1.GetPoints());  // Виведе: 150
        Console.WriteLine(loyalty1 == loyalty2);  // Виведе: True
    }
}
