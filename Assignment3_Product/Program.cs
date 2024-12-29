namespace Assignment3_Product
{

    class Product
    {
        public int PCode { get; }
        public string PName { get; set; }
        public int QtyInStock { get; set; }
        public double Price { get; set; }
        public static string Brand { get; set; } = "GlobalBrand";
        public double DiscountAllowed { get; set; }


        public Product(int pcode, string pname, int qtyInStock, double price, double discountAllowed)
        {
            PCode = pcode;
            PName = pname;
            QtyInStock = qtyInStock;
            Price = price;
            DiscountAllowed = discountAllowed;
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"Product Code: {PCode}, Name: {PName}, Stock: {QtyInStock}, Price: {Price:C}, Discount: {DiscountAllowed}%, Brand: {Brand}");
        }
    }

    class Order
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double TotalAmount { get; set; }

        public void DisplayOrder()
        {
            Console.WriteLine($"Product: {ProductName}, Quantity: {Quantity}, Total Amount: {TotalAmount:C}");
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {

            List<Product> products = new List<Product>();
            List<Order> orders = new List<Order>();

            while (true)
            {
                Console.WriteLine("\nWho are you?");
                Console.WriteLine("1. Admin");
                Console.WriteLine("2. Customer");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");
                int roleChoice = Convert.ToInt32(Console.ReadLine());

                if (roleChoice == 1)
                {
                    while (true)
                    {
                        Console.WriteLine("\nAdmin Menu:");
                        Console.WriteLine("1. Add Product");
                        Console.WriteLine("2. Display Products");
                        Console.WriteLine("3. Go Back");
                        Console.Write("Enter your choice: ");
                        int adminChoice = Convert.ToInt32(Console.ReadLine());

                        if (adminChoice == 1)
                        {
                            Console.Write("Enter Product Code: ");
                            int pcode = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Enter Product Name: ");
                            string pname = Console.ReadLine();

                            Console.Write("Enter Quantity in Stock: ");
                            int qtyInStock = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Enter Price: ");
                            double price = Convert.ToDouble(Console.ReadLine());

                            Console.Write("Enter Discount Allowed (%): ");
                            double discount = Convert.ToDouble(Console.ReadLine());

                            products.Add(new Product(pcode, pname, qtyInStock, price, discount));
                            Console.WriteLine("Product added successfully!");
                        }
                        else if (adminChoice == 2)
                        {
                            Console.WriteLine("\nAvailable Products:");
                            foreach (var product in products)
                            {
                                product.DisplayDetails();
                            }
                        }
                        else if (adminChoice == 3)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice. Try again.");
                        }
                    }
                }
                else if (roleChoice == 2)
                {
                    while (true)
                    {
                        Console.WriteLine("\nCustomer Menu:");
                        Console.WriteLine("1. Order Product");
                        Console.WriteLine("2. Get Bill");
                        Console.WriteLine("3. Go Back");
                        Console.Write("Enter your choice: ");
                        int customerChoice = Convert.ToInt32(Console.ReadLine());

                        if (customerChoice == 1)
                        {
                            Console.Write("Enter Product Name: ");
                            string pname = Console.ReadLine();

                            var product = products.FirstOrDefault(p => p.PName.Equals(pname, StringComparison.OrdinalIgnoreCase));
                            if (product == null)
                            {
                                Console.WriteLine("Product not found.");
                                continue;
                            }

                            Console.Write($"Enter Quantity to Order (Available: {product.QtyInStock}): ");
                            int qty = Convert.ToInt32(Console.ReadLine());

                            if (qty > product.QtyInStock)
                            {
                                Console.WriteLine("Insufficient stock available.");
                                continue;
                            }


                            double totalAmount = qty * product.Price * 0.5;


                            product.QtyInStock -= qty;


                            orders.Add(new Order
                            {
                                ProductName = product.PName,
                                Quantity = qty,
                                TotalAmount = totalAmount
                            });

                            Console.WriteLine("Order placed successfully!");
                        }
                        else if (customerChoice == 2)
                        {
                            Console.WriteLine("\nCustomer Bill:");
                            foreach (var order in orders)
                            {
                                order.DisplayOrder();
                            }

                            double grandTotal = orders.Sum(o => o.TotalAmount);
                            Console.WriteLine($"\nGrand Total: {grandTotal:C}");
                        }
                        else if (customerChoice == 3)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice. Try again.");
                        }
                    }
                }
                else if (roleChoice == 3)
                {
                    Console.WriteLine("Thank you for using the system. Goodbye!");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Try again.");
                }
            }
        }
    }
}
