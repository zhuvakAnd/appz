from abc import ABC, abstractmethod

# Абстрактний клас обробника
class OfferHandler(ABC):
    def __init__(self, successor=None):
        self.successor = successor

    @abstractmethod
    def handle_offer(self, offer):
        pass

# Конкретний обробник для знижки
class DiscountHandler(OfferHandler):
    def handle_offer(self, offer):
        if offer.discount > 0:
            print(f"Знижка {offer.discount}% застосована.")
        elif self.successor:
            self.successor.handle_offer(offer)

# Конкретний обробник для безкоштовної доставки
class FreeShippingHandler(OfferHandler):
    def handle_offer(self, offer):
        if offer.free_shipping:
            print("Безкоштовна доставка застосована.")
        elif self.successor:
            self.successor.handle_offer(offer)

# Конкретний обробник для подарунків
class GiftHandler(OfferHandler):
    def handle_offer(self, offer):
        if offer.gift:
            print(f"Подарунок: {offer.gift}")
        elif self.successor:
            self.successor.handle_offer(offer)

# Клас, який представляє пропозицію
class Offer:
    def __init__(self, discount, free_shipping, gift):
        self.discount = discount
        self.free_shipping = free_shipping
        self.gift = gift

# Використання ланцюжка відповідальностей
offer = Offer(discount=10, free_shipping=False, gift="Блокнот")
handler = DiscountHandler(FreeShippingHandler(GiftHandler()))
handler.handle_offer(offer)
