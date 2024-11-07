using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.WorkingWithEntities
{
    internal static class WorkingWithProduct
    {
        public static void ViewProducts()
        {
            using (var context = new ApplicationContext())
            {
                var products = context.Products.ToList();
                foreach (var product in products)
                {
                    Console.WriteLine($"ID: {product.ProductId}, Name: {product.Name}");
                }
            }
        }

        public static void AddProduct()
        {
            Console.Write("Введите название товара: ");
            string name = Console.ReadLine();

            using (var context = new ApplicationContext())
            {
                var product = new Product { Name = name };
                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        public static void EditProduct()
        {
            Console.Write("Введите ID товара для редактирования: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                using (var context = new ApplicationContext())
                {
                    var product = context.Products.Find(id);
                    if (product != null)
                    {
                        Console.Write("Введите новое имя товара: ");
                        product.Name = Console.ReadLine();
                        context.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine("Товар не найден.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Неверный ID.");
            }
        }


        public static void DeleteProduct()
        {
            Console.Write("Введите ID товара для удаления: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                using (var context = new ApplicationContext())
                {
                    var product = context.Products.Find(id);
                    if (product != null)
                    {
                        context.Products.Remove(product);
                        context.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine("Товар не найден.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Неверный ID.");
            }
        }

    }
}
