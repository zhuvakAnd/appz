import copy

class Book:
    def __init__(self, title, author):
        self.title = title
        self.author = author

    def clone(self):
        return copy.deepcopy(self)

book_prototype = Book("Sample Title", "Sample Author")

# Клонування книги
new_book = book_prototype.clone()
new_book.title = "New Title"
new_book.author = "New Author"

print(new_book.title, new_book.author)
