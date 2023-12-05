from collections.abc import Iterable, Iterator

# Клас, що представляє книгу
class Book:
    def __init__(self, title, author):
        self.title = title
        self.author = author

# Клас колекції книг
class BookCollection(Iterable):
    def __init__(self):
        self.books = []

    def add_book(self, book):
        self.books.append(book)

    def __iter__(self) -> Iterator:
        return BookIterator(self)

# Клас ітератора
class BookIterator(Iterator):
    def __init__(self, collection):
        self.collection = collection
        self.index = 0

    def __next__(self):
        if self.index < len(self.collection.books):
            book = self.collection.books[self.index]
            self.index += 1
            return book
        raise StopIteration

# Використання Iterator Pattern
book_collection = BookCollection()
book_collection.add_book(Book("Патерни проектування", "Еріх Гамма"))
book_collection.add_book(Book("Чистий код", "Роберт Мартін"))
book_collection.add_book(Book("Алгоритми та структури даних", "Томас Кормен"))

for book in book_collection:
    print(f"{book.title} ({book.author})")
