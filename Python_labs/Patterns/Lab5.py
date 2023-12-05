class Book:
    def __init__(self, title, author, genre, price):
        self.title = title
        self.author = author
        self.genre = genre
        self.price = price

class BookBuilder:
    def __init__(self):
        self.title = None
        self.author = None
        self.genre = None
        self.price = None

    def set_title(self, title):
        self.title = title
        return self

    def set_author(self, author):
        self.author = author
        return self

    def set_genre(self, genre):
        self.genre = genre
        return self

    def set_price(self, price):
        self.price = price
        return self

    def build(self):
        return Book(self.title, self.author, self.genre, self.price)

book_builder = BookBuilder()
book = book_builder.set_title(" The Stormlight Archive") \
                  .set_author("Brandon Sanderson") \
                  .set_genre(" Fantasy") \
                  .set_price(21.99) \
                  .build()

print(f"Title: {book.title}")
print(f"Author: {book.author}")
print(f"Genre: {book.genre}")
print(f"Price: ${book.price:.2f}")
