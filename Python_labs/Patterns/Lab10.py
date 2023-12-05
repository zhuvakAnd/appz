from abc import ABC, abstractmethod

# Абстрактний клас книги
class Book(ABC):
    @abstractmethod
    def cost(self):
        pass

# Конкретна реалізація книги
class ConcreteBook(Book):
    def cost(self):
        return 10

# Декоратор для знижки
class DiscountDecorator(Book):
    def __init__(self, book):
        self.book = book

    def cost(self):
        return 0.8 * self.book.cost()

# Декоратор для подарунків
class GiftDecorator(Book):
    def __init__(self, book):
        self.book = book

    def cost(self):
        return self.book.cost() + 5

# Використання декораторів
book = ConcreteBook()
print("Звичайна книга: ${}".format(book.cost()))

book_with_discount = DiscountDecorator(book)
print("Книга зі знижкою: ${}".format(book_with_discount.cost()))

book_with_gift = GiftDecorator(book)
print("Книга з подарунком: ${}".format(book_with_gift.cost()))
