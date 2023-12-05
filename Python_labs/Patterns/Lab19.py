# Абстрактний клас спостерігача
class Observer:
    def update(self, message):
        pass

# Клас конкретного спостерігача (клієнт або працівник магазину)
class ConcreteObserver(Observer):
    def __init__(self, name):
        self.name = name

    def update(self, message):
        print(f"{self.name} отримав повідомлення: {message}")

# Клас суб'єкта (система сповіщення про нові книги)
class Subject:
    def __init__(self):
        self.observers = []

    def add_observer(self, observer):
        self.observers.append(observer)

    def remove_observer(self, observer):
        self.observers.remove(observer)

    def notify(self, message):
        for observer in self.observers:
            observer.update(message)

# Використання Observer Pattern
subject = Subject()

client1 = ConcreteObserver("Клієнт 1")
client2 = ConcreteObserver("Клієнт 2")
cashier1 = ConcreteObserver("Касир 1")
cashier2 = ConcreteObserver("Касир 2")

subject.add_observer(client1)
subject.add_observer(client2)
subject.add_observer(cashier1)
subject.add_observer(cashier2)

subject.notify("Нова книга доступна: 'Патерни проектування'")
