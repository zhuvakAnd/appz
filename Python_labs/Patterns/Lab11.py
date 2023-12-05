# Підсистема для пошуку книг
class BookSearch:
    def search_by_title(self, title):
        print(f"Пошук книги за назвою: {title}")

# Підсистема для додавання книг до кошика
class Cart:
    def add_to_cart(self, book):
        print(f"Додано книгу до кошика: {book}")

# Підсистема для оформлення замовлення
class Order:
    def place_order(self):
        print("Замовлення оформлено")

# Фасад, який надає простий інтерфейс для клієнтів
class BookStoreFacade:
    def __init__(self):
        self.book_search = BookSearch()
        self.cart = Cart()
        self.order = Order()

    def search_and_add_to_cart(self, title):
        self.book_search.search_by_title(title)
        self.cart.add_to_cart(title)

    def place_order(self):
        self.cart.add_to_cart("Книга 1")
        self.cart.add_to_cart("Книга 2")
        self.order.place_order()

# Використання фасаду
facade = BookStoreFacade()
facade.search_and_add_to_cart("Гра престолів")
facade.search_and_add_to_cart("Гаррі Поттер")
facade.place_order()
