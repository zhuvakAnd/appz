using System;

// Абстрактний клас обробника
abstract class OfferHandler
{
    protected OfferHandler successor;

    public OfferHandler(OfferHandler successor = null)
    {
        this.successor = successor;
    }

    public abstract void HandleOffer(Offer offer);
}

// Конкретний обробник для знижки
class DiscountHandler : OfferHandler
{
    public DiscountHandler(OfferHandler successor = null) : base(successor)
    {
    }

    public override void HandleOffer(Offer offer)
    {
        if (offer.Discount > 0)
        {
            Console.WriteLine($"Знижка {offer.Discount}% застосована.");
        }
        else if (successor != null)
        {
            successor.HandleOffer(offer);
        }
    }
}

// Конкретний обробник для безкоштовної доставки
class FreeShippingHandler : OfferHandler
{
    public FreeShippingHandler(OfferHandler successor = null) : base(successor)
    {
    }

    public override void HandleOffer(Offer offer)
    {
        if (offer.FreeShipping)
        {
            Console.WriteLine("Безкоштовна доставка застосована.");
        }
        else if (successor != null)
        {
            successor.HandleOffer(offer);
        }
    }
}

// Конкретний обробник для подарунків
class GiftHandler : OfferHandler
{
    public override void HandleOffer(Offer offer)
    {
        if (!string.IsNullOrEmpty(offer.Gift))
        {
            Console.WriteLine($"Подарунок: {offer.Gift}");
        }
        else if (successor != null)
        {
            successor.HandleOffer(offer);
        }
    }
}

// Клас, який представляє пропозицію
class Offer
{
    public int Discount { get; }
    public bool FreeShipping { get; }
    public string Gift { get; }

    public Offer(int discount, bool freeShipping, string gift)
    {
        Discount = discount;
        FreeShipping = freeShipping;
        Gift = gift;
    }
}

class Program
{
    static void Main()
    {
        // Використання ланцюжка відповідальностей
        Offer offer = new Offer(discount: 10, freeShipping: false, gift: "Блокнот");
        OfferHandler handler = new DiscountHandler(new FreeShippingHandler(new GiftHandler()));
        handler.HandleOffer(offer);
    }
}
