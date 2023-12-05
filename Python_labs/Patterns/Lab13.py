from abc import ABC, abstractmethod

# Абстрактний клас для завантаження електронної книги
class EBook(ABC):
    @abstractmethod
    def download(self):
        pass

# Реальна реалізація завантаження електронної книги
class RealEBook(EBook):
    def __init__(self, filename):
        self.filename = filename

    def download(self):
        print(f"Завантаження електронної книги: {self.filename}")

# Заступник для електронної книги
class EBookProxy(EBook):
    def __init__(self, filename, authenticated):
        self.filename = filename
        self.authenticated = authenticated

    def download(self):
        if self.authenticated:
            real_ebook = RealEBook(self.filename)
            real_ebook.download()
        else:
            print("Неавторизований користувач. Завантаження не дозволено.")

# Використання заступника
ebook = EBookProxy("book.pdf", authenticated=True)
ebook.download()

unauthorized_ebook = EBookProxy("book.pdf", authenticated=False)
unauthorized_ebook.download()




title = 'laba';