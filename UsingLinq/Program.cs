using System;
using System.Collections.Generic;
using System.Linq;

namespace UsingLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Category> categories = new List<Category>
            {
                new Category{CategoryId = 1, CategoryName = "Bilgisayar"},
                new Category{CategoryId = 2, CategoryName = "Telefon"},
            };
            List<Product> products = new List<Product>
            {
                new Product{ProductId = 1, CategoryId = 1, ProductName = "Acer Laptop", QuantityPerUnit = "32 GB RAM", UnitPrice = 10000, UnitsInStock = 5 },
                new Product{ProductId = 2, CategoryId = 1, ProductName = "Asus Laptop", QuantityPerUnit = "16 GB RAM", UnitPrice = 20000, UnitsInStock = 3 },
                new Product{ProductId = 3, CategoryId = 1, ProductName = "Hp Laptop", QuantityPerUnit = "8 GB RAM", UnitPrice = 18000, UnitsInStock = 2 },
                new Product{ProductId = 4, CategoryId = 2, ProductName = "Samsung Telefon", QuantityPerUnit = "4 GB RAM", UnitPrice = 10000, UnitsInStock = 15 },
                new Product{ProductId = 5, CategoryId = 2, ProductName = "Apple Telefon", QuantityPerUnit = "4 GB RAM", UnitPrice = 8000, UnitsInStock = 8 },
            };

            GetAll(products);

            FilterTest(products);

            AnyTest(products);

            FindTest(products);

            FindAllTest(products);

            AscDescTest(products);

            ClassicLinqTest(products);

        }
        private static void GetAll(List<Product> products)
        {
            Console.WriteLine("---List of all products:---");
            var result = from p in products
                         select new Product { ProductId = p.ProductId, ProductName = p.ProductName, UnitPrice = p.UnitPrice }; 
            foreach (var product in products)
            {
                Console.WriteLine(product.ProductName);
            }
        }

        private static void ClassicLinqTest(List<Product> products)
        {
            Console.WriteLine("---Products which descending according to price---");
            var result = from p in products
                         orderby p.UnitPrice descending
                         select new Product { ProductId = p.ProductId, ProductName = p.ProductName, UnitPrice = p.UnitPrice };

            foreach (var product in result)
            {
                Console.WriteLine(product.ProductName);
            }
        }

        private static void AscDescTest(List<Product> products)
        {
            Console.WriteLine("---List of products according to price descending, if prices are equal, products list will be according to alphabetic descending.---");
            var result = products.OrderByDescending(p=>p.UnitPrice).ThenByDescending(p => p.ProductName);

            foreach (var product in result)
            {
                Console.WriteLine(product.ProductName);
            }
        }

        private static void FindAllTest(List<Product> products)
        {
            Console.WriteLine("---Products which contains 'top' keyword:---");
            var result = products.FindAll(p => p.ProductName.Contains("top"));
            Console.WriteLine(result);
        }

        private static void FindTest(List<Product> products)
        {
            Console.WriteLine("---Products which product id is 3:---");
            var result = products.Find(p => p.ProductId == 3);
            Console.WriteLine(result.ProductName);
        }

        private static void AnyTest(List<Product> products)
        {
            Console.WriteLine("---If there is a product whatever we want, result will be true, but there isn't result will be false.---");
            var result = products.Any(p => p.ProductName == "Dell Laptop");
            Console.WriteLine(result);
        }

        private static void FilterTest(List<Product> products)
        {
            Console.WriteLine("---Products which unit price is bigger than 5000 and stock more than 3---");
            var result = products.Where(product => product.UnitPrice > 5000 && product.UnitsInStock > 3);
            foreach (var product in result)
            {
                Console.WriteLine(product.ProductName);
            }
        }
    }
    class Product
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
    }
    class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
