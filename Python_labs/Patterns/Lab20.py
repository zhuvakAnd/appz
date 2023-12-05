from abc import ABC, abstractmethod

# Абстрактний клас стану
class OrderState(ABC):
    @abstractmethod
    def process_order(self):
        pass

# Клас контексту (замовлення)
class Order:
    def __init__(self):
        self.state = None

    def set_state(self, state):
        self.state = state

    def process_order(self):
        if self.state:
            self.state.process_order()

# Клас конкретного стану "В обробці"
class InProgressState(OrderState):
    def process_order(self):
        print("Замовлення в обробці")

# Клас конкретного стану "Очікування оплати"
class PendingPaymentState(OrderState):
    def process_order(self):
        print("Замовлення очікує оплати")

# Клас конкретного стану "Відправлено"
class ShippedState(OrderState):
    def process_order(self):
        print("Замовлення відправлено")

# Використання State Pattern
order = Order()

order.set_state(InProgressState())
order.process_order()  # Виведе: Замовлення в обробці

order.set_state(PendingPaymentState())
order.process_order()  # Виведе: Замовлення очікує оплати

order.set_state(ShippedState())
order.process_order()  # Виведе: Замовлення відправлено
