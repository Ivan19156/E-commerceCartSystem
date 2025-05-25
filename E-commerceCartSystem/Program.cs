using System;
using System.Collections.Generic;

namespace E_commerceCartSystem
{
    public class Program
    {
        //The method outputs the list of available products for user.
        public static void ShowProducts(List<Product> products)
        {
            Console.WriteLine("Available products:");
            foreach (var p in products)
                Console.WriteLine(p.ToString());
        }

        //The method allows user to add a product to his cart.
        public static void FillCart(Cart cart, List<Product> products)
        {
            bool x = true;

            while (x)
            {
                Console.WriteLine("\nEnter a product name to add to your cart (or type 'stop' tofinish):");
                string input = Console.ReadLine().ToLower();

                if (input == "stop")
                {
                    x = false;
                    break;
                }


                var product = products.Find(p => p.Name.ToLower() == input);
                if (product != null)
                {
                    cart.AddProduct(product);
                    Console.WriteLine($"{product.Name} added to cart.");
                }
                else
                {
                    Console.WriteLine("Product not found.");
                }
            }
        }

        //This method asks user for his budget. If the input is invalid, the method will continue asking untill it can be parsed to decimal.
        public static decimal AskForBudget()
        {
            bool x = true;
            decimal budget = 0;
            while (x)
            {
                Console.WriteLine("Please enter your budget:");
                if (decimal.TryParse(Console.ReadLine(), out decimal b))
                {
                    budget = b;
                    break;
                }
                else
                {

                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
            return budget;
        }

        //The method checks whether budget is enough for purchase or not. 
        public static void CheckBudget(Cart cart)
        {
            decimal budget = AskForBudget();
            decimal totalAmount = cart.GetTotalAmount();
            if (totalAmount == 0)
            {
                Console.WriteLine("The cart is empty.");
            }
            else if (totalAmount <= budget)
            {
                Console.WriteLine($"Total: {totalAmount}. Purchase within budget.");
            }
            else
            {
                Console.WriteLine($"Total: {totalAmount}. Not enough funds.");
            }
        }

        public static void Main()
        {
            var products = new List<Product>
            {
                new Product("Bread", 40),
                new Product("Milk", 30),
                new Product("Eggs", 50),
                new Product("Butter", 60)
            };
            var cart = new Cart();


            ShowProducts(products);
            FillCart(cart, products);
            CheckBudget(cart);
        }
    }
}
