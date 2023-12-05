from abc import ABC, abstractmethod

class Book(ABC):
    @abstractmethod
    def display_info(self):
        pass

class Novel(Book):
    def display_info(self):
        return "Роман"

class Fantasy(Book):
    def display_info(self):
        return "Фентезі"

class BookStore(ABC):
    @abstractmethod
    def create_book(self):
        pass

class NovelStore(BookStore):
    def create_book(self):
        return Novel()

class FantasyStore(BookStore):
    def create_book(self):
        return Fantasy()

novel_store = NovelStore()
novel = novel_store.create_book()
print(novel.display_info())

fantasy_store = FantasyStore()
fantasy = fantasy_store.create_book()
print(fantasy.display_info())
