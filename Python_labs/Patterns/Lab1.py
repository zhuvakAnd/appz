class CustomerLoyalty:
    _instance = None

    def __new__(cls):
        if cls._instance is None:
            cls._instance = super(CustomerLoyalty, cls).__new__(cls)
            cls._instance.points = 0
        return cls._instance

    def add_points(self, amount):
        self.points += amount

    def get_points(self):
        return self.points

loyalty1 = CustomerLoyalty()
loyalty1.add_points(100)

loyalty2 = CustomerLoyalty()
loyalty2.add_points(50)

print(loyalty1.get_points())  # Виведе: 150
print(loyalty1 is loyalty2)  # Виведе: True
