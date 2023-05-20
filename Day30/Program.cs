using System;
using System.Collections.Generic;

namespace InvoiceGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of InvoiceGenerator
            InvoiceGenerator generator = new InvoiceGenerator();

            // Add some sample items to the invoice
            generator.AddItem("Product 1", 10, 19.99);
            generator.AddItem("Product 2", 5, 9.99);
            generator.AddItem("Product 3", 2, 24.99);

            // Generate and print the invoice
            generator.GenerateInvoice();
        }
    }

    class InvoiceGenerator
    {
        private List<InvoiceItem> items;

        public InvoiceGenerator()
        {
            items = new List<InvoiceItem>();
        }

        public void AddItem(string name, int quantity, double price)
        {
            InvoiceItem item = new InvoiceItem(name, quantity, price);
            items.Add(item);
        }

        public void GenerateInvoice()
        {
            // Print the invoice header
            Console.WriteLine("===================================");
            Console.WriteLine("          INVOICE");
            Console.WriteLine("===================================");

            // Print the items table header
            Console.WriteLine("Item\t\tQuantity\tPrice\t\tTotal");

            // Print each item in the invoice
            double total = 0;
            foreach (InvoiceItem item in items)
            {
                double itemTotal = item.Price * item.Quantity;
                total += itemTotal;

                Console.WriteLine($"{item.Name}\t\t{item.Quantity}\t\t{item.Price}\t\t{itemTotal}");
            }

            // Print the total
            Console.WriteLine("===================================");
            Console.WriteLine($"Total:\t\t\t\t\t{total}");
        }
    }

    class InvoiceItem
    {
        public string Name { get; }
        public int Quantity { get; }
        public double Price { get; }

        public InvoiceItem(string name, int quantity, double price)
        {
            Name = name;
            Quantity = quantity;
            Price = price;
        }
    }
}
