# Клас, що представляє пристосуванця (спільні атрибути)
class BookFlyweight:
    def __init__(self, genre, language):
        self.genre = genre
        self.language = language

# Фабрика пристосуванців
class BookFlyweightFactory:
    flyweights = {}

    @staticmethod
    def get_flyweight(genre, language):
        if (genre, language) not in BookFlyweightFactory.flyweights:
            BookFlyweightFactory.flyweights[(genre, language)] = BookFlyweight(genre, language)
        return BookFlyweightFactory.flyweights[(genre, language)]

# Клас для окремих книжок, які використовують пристосуванця
class Book:
    def __init__(self, title, flyweight):
        self.title = title
        self.flyweight = flyweight

    def display(self):
        return f"Книга: {self.title}, Жанр: {self.flyweight.genre}, Мова: {self.flyweight.language}"

# Використання Flyweight Pattern
flyweight_factory = BookFlyweightFactory()
book1 = Book("Книга 1", flyweight_factory.get_flyweight("Фантастика", "Англійська"))
book2 = Book("Книга 2", flyweight_factory.get_flyweight("Фантастика", "Англійська"))
book3 = Book("Книга 3", flyweight_factory.get_flyweight("Детектив", "Французька"))

print(book1.display())
print(book2.display())
print(book3.display())
