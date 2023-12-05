from abc import ABC, abstractmethod

# Абстрактний клас посередника
class Mediator(ABC):
    @abstractmethod
    def send(self, message, colleague):
        pass

# Клас колеги
class Colleague:
    def __init__(self, mediator):
        self.mediator = mediator

    def send(self, message):
        self.mediator.send(message, self)

# Клас конкретного колеги (клієнт)
class Client(Colleague):
    def request_book(self, title):
        print(f"Клієнт вимагає книгу: {title}")
        self.send(title)

# Клас конкретного колеги (касир)
class Cashier(Colleague):
    def process_order(self, book_title):
        print(f"Касир обробляє замовлення на книгу: {book_title}")
        self.send(book_title)

# Клас конкретного колеги (склад)
class Warehouse(Colleague):
    def fulfill_order(self, book_title):
        print(f"Склад відправляє книгу: {book_title}")
        self.send(book_title)

# Клас конкретного посередника
class BookstoreMediator(Mediator):
    def __init__(self):
        self.clients = []
        self.cashiers = []
        self.warehouse = Warehouse(self)

    def add_client(self, client):
        self.clients.append(client)

    def add_cashier(self, cashier):
        self.cashiers.append(cashier)

    def send(self, message, colleague):
        if colleague in self.clients:
            for cashier in self.cashiers:
                cashier.process_order(message)
        elif colleague in self.cashiers:
            self.warehouse.fulfill_order(message)

# Використання Mediator Pattern
mediator = BookstoreMediator()

client1 = Client(mediator)
client2 = Client(mediator)

cashier1 = Cashier(mediator)
cashier2 = Cashier(mediator)

mediator.add_client(client1)
mediator.add_client(client2)

mediator.add_cashier(cashier1)
mediator.add_cashier(cashier2)

client1.request_book("Патерни проектування")
