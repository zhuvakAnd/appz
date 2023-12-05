import time

class Book:
    def __init__(self, title, author):
        self.title = title
        self.author = author

class BookPool:
    def __init__(self, size):
        self.pool = [Book("The Stormlight Archive", "Brandon Sanderson") for _ in range(size)]
        self.available = self.pool[:]

    def borrow_book(self):
        if self.available:
            return self.available.pop()
        else:
            print("Пул книг вичерпаний.")
            return None

    def return_book(self, book):
        if book not in self.available:
            self.available.append(book)

# Використання Object Pool:
book_pool = BookPool(5)
borrowed_book1 = book_pool.borrow_book()
borrowed_book2 = book_pool.borrow_book()

if borrowed_book1:
    print(f"Книгу '{borrowed_book1.title}' взяли у пулу.")

if borrowed_book2:
    print(f"Книгу '{borrowed_book2.title}' взяли у пулу.")

time.sleep(2)  # Час, коли книги у використанні

book_pool.return_book(borrowed_book1)
book_pool.return_book(borrowed_book2)
print(f"Книгу '{borrowed_book1.title}' повернули у пул.")
print(f"Книгу '{borrowed_book2.title}' повернули у пул.")
