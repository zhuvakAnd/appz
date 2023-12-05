from abc import ABC, abstractmethod

# Абстрактний клас команди
class Command(ABC):
    @abstractmethod
    def execute(self):
        pass

# Конкретна команда для додавання товару до кошика
class AddToCartCommand(Command):
    def __init__(self, item_name):
        self.item_name = item_name

    def execute(self):
        print(f"Товар '{self.item_name}' додано до кошика.")

# Конкретна команда для оформлення замовлення
class PlaceOrderCommand(Command):
    def execute(self):
        print("Замовлення оформлено.")

# Одиниця управління (Invoker)
class RemoteControl:
    def __init__(self):
        self.commands = []

    def add_command(self, command):
        self.commands.append(command)

    def execute_commands(self):
        for command in self.commands:
            command.execute()

# Використання Command Pattern
remote_control = RemoteControl()

add_item_command = AddToCartCommand("Книга 'Патерни проектування'")
place_order_command = PlaceOrderCommand()

remote_control.add_command(add_item_command)
remote_control.add_command(place_order_command)

remote_control.execute_commands()
