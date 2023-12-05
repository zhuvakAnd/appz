# Інтерфейс книжки
class Book:
    def read(self):
        pass

# Клас для друкованих книг
class PrintedBook:
    def print_book(self):
        print("Друкована книга")

# Адаптер для забезпечення читання друкованих книг
class PrintedBookAdapter(Book):
    def __init__(self, printed_book):
        self.printed_book = printed_book

    def read(self):
        self.printed_book.print_book()

# Клас для електронних книг
class EBook:
    def read_ebook(self):
        print("Електронна книга")

# Клас для читача, який працює з електронними книгами
class EBookReader:
    def __init__(self, ebook):
        self.ebook = ebook

    def read(self):
        self.ebook.read_ebook()

# Використання адаптера для читання друкованих книг
printed_book = PrintedBook()
book_adapter = PrintedBookAdapter(printed_book)
book_adapter.read()

# Використання електронної книги
ebook = EBook()
ebook_reader = EBookReader(ebook)
ebook_reader.read()
