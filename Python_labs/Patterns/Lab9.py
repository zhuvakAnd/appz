from abc import ABC, abstractmethod

# Абстрактний клас для категорій книг та окремих книг
class BookComponent(ABC):
    @abstractmethod
    def display(self):
        pass

# Конкретний клас для окремих книг
class Book(BookComponent):
    def __init__(self, title):
        self.title = title

    def display(self):
        return f"Книга: {self.title}"

# Конкретний клас для категорій книг
class Category(BookComponent):
    def __init__(self, name):
        self.name = name
        self.children = []

    def add(self, component):
        self.children.append(component)

    def display(self):
        result = f"Категорія: {self.name}\n"
        for child in self.children:
            result += f" - {child.display()}\n"
        return result

# Створення ієрархії категорій та книг
fantasy = Category("Фантастика")
fantasy.add(Book("Гра престолів"))
fantasy.add(Book("Гаррі Поттер"))

detective = Category("Детективи")
detective.add(Book("Шерлок Холмс"))

root_category = Category("Всі книги")
root_category.add(fantasy)
root_category.add(detective)

# Виведення ієрархії
print(root_category.display())
