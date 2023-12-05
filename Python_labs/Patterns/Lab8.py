from abc import ABC, abstractmethod

# Абстракція для книг
class Book(ABC):
    def __init__(self, title, author, implementation):
        self.title = title
        self.author = author
        self.implementation = implementation

    @abstractmethod
    def display(self):
        pass

# Конкретна реалізація книг для друкованих книг
class PrintedBook(Book):
    def display(self):
        return f"Printed Book: {self.title} by {self.author}"

# Конкретна реалізація книг для електронних книг
class EBook(Book):
    def display(self):
        return f"E-Book: {self.title} by {self.author}"

# Інтерфейс для імплементації книг
class BookImplementation(ABC):
    @abstractmethod
    def get_info(self):
        pass

# Друкована книга
class PrintedBookImplementation(BookImplementation):
    def __init__(self, title, author):
        self.title = title
        self.author = author

    def get_info(self):
        return f"Printed Book: {self.title} by {self.author}"

# Електронна книга
class EBookImplementation(BookImplementation):
    def __init__(self, title, author):
        self.title = title
        self.author = author

    def get_info(self):
        return f"E-Book: {self.title} by {self.author}"

# Використання Bridge Pattern
printed_book = PrintedBook("Printed Book 1", "Author 1", PrintedBookImplementation("Printed Book 1", "Author 1"))
ebook = EBook("E-Book 1", "Author 2", EBookImplementation("E-Book 1", "Author 2"))

print(printed_book.display())
print(ebook.display())
