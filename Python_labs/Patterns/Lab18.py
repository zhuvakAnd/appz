# Клас Memento для збереження стану замовлення
class OrderMemento:
    def __init__(self, order_state):
        self.order_state = order_state

# Клас Order, стан якого потрібно зберігати та відновлювати
class Order:
    def __init__(self):
        self.order_state = "В обробці"

    def create_memento(self):
        return OrderMemento(self.order_state)

    def restore_from_memento(self, memento):
        self.order_state = memento.order_state

    def __str__(self):
        return f"Стан замовлення: {self.order_state}"

# Клас Caretaker для збереження та відновлення стану
class Caretaker:
    def __init__(self):
        self.mementos = []

    def add_memento(self, memento):
        self.mementos.append(memento)

    def get_memento(self, index):
        return self.mementos[index]

# Використання Memento Pattern
order = Order()
caretaker = Caretaker()

print(order)  # Виведе: Стан замовлення: В обробці

# Збереження стану
caretaker.add_memento(order.create_memento())

# Зміна стану замовлення
order.order_state = "Відправлено"
print(order)  # Виведе: Стан замовлення: Відправлено

# Відновлення попереднього стану
order.restore_from_memento(caretaker.get_memento(0))
print(order)  # Виведе: Стан замовлення: В обробці
