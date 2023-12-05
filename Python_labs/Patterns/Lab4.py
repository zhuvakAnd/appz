from abc import ABC, abstractmethod

# Абстрактні класи для книг і закладок
class Book(ABC):
    @abstractmethod
    def display_info(self):
        pass

class Bookmark(ABC):
    @abstractmethod
    def show_info(self):
        pass

# Конкретні реалізації книг і закладок
class Novel(Book):
    def display_info(self):
        return "Роман"

class Textbook(Book):
    def display_info(self):
        return "Підручник"

class PlainBookmark(Bookmark):
    def show_info(self):
        return "Закладка"

class FancyBookmark(Bookmark):
    def show_info(self):
        return "Прикрашена закладка"

# Абстрактна фабрика
class BookFactory(ABC):
    @abstractmethod
    def create_book(self):
        pass

    @abstractmethod
    def create_bookmark(self):
        pass

# Конкретні фабрики
class NovelFactory(BookFactory):
    def create_book(self):
        return Novel()

    def create_bookmark(self):
        return PlainBookmark()

class TextbookFactory(BookFactory):
    def create_book(self):
        return Textbook()

    def create_bookmark(self):
        return FancyBookmark()

novel_factory = NovelFactory()
novel = novel_factory.create_book()
bookmark = novel_factory.create_bookmark()
print(novel.display_info())
print(bookmark.show_info())

textbook_factory = TextbookFactory()
textbook = textbook_factory.create_book()
fancy_bookmark = textbook_factory.create_bookmark()
print(textbook.display_info())
print(fancy_bookmark.show_info())
