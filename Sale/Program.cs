using System;

namespace SaleApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Sale
    {
        public string Item { get; set; }
        public string Customer { get; set; }
        public double PricePerItem { get; set; }
        public int Quantity { get; set; }
        public string Address { get; set; }
        public bool ExpeditedShipping { get; set; }
    }

    class Program
    {
        static void Main()
        {
            List<Sale> Sales = new List<Sale>
        {
            new Sale { Item = "Tea", Customer = "ABC LLC", PricePerItem = 15.0, Quantity = 2, Address = "123 Main St", ExpeditedShipping = true },
            new Sale { Item = "Coffee", Customer = "XYZ Inc", PricePerItem = 8.0, Quantity = 1, Address = "456 Elm St", ExpeditedShipping = false },
            new Sale { Item = "Tea", Customer = "DEF llc", PricePerItem = 12.0, Quantity = 3, Address = "789 Oak St", ExpeditedShipping = false },
            new Sale { Item = "Tea", Customer = "GHI LLC", PricePerItem = 20.0, Quantity = 4, Address = "101 Pine St", ExpeditedShipping = true },
        };

            // 1. Get a collection of all Sale objects where PricePerItem is over 10.0.
            var salesOver10 = from sale in Sales
                              where sale.PricePerItem > 10.0
                              select sale;

            // 2. Get a collection of all Sale objects where Quantity is 1 and order by PricePerItem in descending order.
            var salesQuantity1 = from sale in Sales
                                 where sale.Quantity == 1
                                 orderby sale.PricePerItem descending
                                 select sale;

            // 3. Get a collection of Sale objects where Item is "Tea" and ExpeditedShipping is false.
            var teaWithoutExpeditedShipping = from sale in Sales
                                              where sale.Item == "Tea" && !sale.ExpeditedShipping
                                              select sale;

            // 4. Get a collection of all addresses of Sale objects where total order cost is over 100.0.
            var addressesTotalOver100 = from sale in Sales
                                        where (sale.PricePerItem * sale.Quantity) > 100.0
                                        select sale.Address;

            // 5. Get a collection of new anonymous objects with Item, TotalPrice, and Shipping.
            var customItems = from sale in Sales
                              where sale.Customer.ToLower().Contains("llc")
                              orderby (sale.PricePerItem * sale.Quantity)
                              select new
                              {
                                  Item = sale.Item,
                                  TotalPrice = sale.PricePerItem * sale.Quantity,
                                  Shipping = sale.ExpeditedShipping ? sale.Address + " EXPEDITE" : sale.Address
                              };

            // Output the results
            Console.WriteLine("Sales with PricePerItem over 10.0:");
            foreach (var sale in salesOver10)
            {
                Console.WriteLine($"Item: {sale.Item}, PricePerItem: {sale.PricePerItem}");
            }

            Console.WriteLine("\nSales with Quantity = 1, ordered by PricePerItem (descending):");
            foreach (var sale in salesQuantity1)
            {
                Console.WriteLine($"Item: {sale.Item}, PricePerItem: {sale.PricePerItem}");
            }

            Console.WriteLine("\nTea sales without Expedited Shipping:");
            foreach (var sale in teaWithoutExpeditedShipping)
            {
                Console.WriteLine($"Item: {sale.Item}, Expedited Shipping: {sale.ExpeditedShipping}");
            }

            Console.WriteLine("\nAddresses with total order cost over 100.0:");
            foreach (var address in addressesTotalOver100)
            {
                Console.WriteLine($"Address: {address}");
            }

            Console.WriteLine("\nCustom Items:");
            foreach (var item in customItems)
            {
                Console.WriteLine($"Item: {item.Item}, TotalPrice: {item.TotalPrice}, Shipping: {item.Shipping}");
            }
        }
    }

}
