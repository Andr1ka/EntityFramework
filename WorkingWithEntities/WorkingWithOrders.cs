using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.WorkingWithEntities
{
    internal static class WorkingWithOrders
    {
        
        public static void ViewOrders()
        {
            using (var context = new ApplicationContext())
            {
                var orders = context.Orders
                     .Include(o => o.Customer)
                     .Include(o => o.OrderProducts)
                         .ThenInclude(op => op.Product)
                     .ToList();
                foreach (var order in orders)
                {
                    Console.WriteLine($"Order ID: {order.OrderId}, Customer: {order.Customer.Name}");
                    foreach (var orderProduct in order.OrderProducts)
                    {
                        Console.WriteLine($"  Product ID: {orderProduct.Product.ProductId}, Product Name: {orderProduct.Product.Name}");
                    }
                }
            }
        }

        public static void AddOrder()// нельзя добавлять один и тот же продукт 2 раза
        {
            Console.Write("Введите ID покупателя: ");
            if (int.TryParse(Console.ReadLine(), out int customerId))
            {
                using (var context = new ApplicationContext())
                {
                    var customer = context.Customers.Find(customerId);
                    if (customer != null)
                    {
                        var order = new Order { CustomerId = customerId };
                        context.Orders.Add(order);
                        context.SaveChanges();

                        Console.Write("Введите количество продуктов в заказе: ");
                        if (int.TryParse(Console.ReadLine(), out int productCount))
                        {
                            int i = 0;
                            while (i < productCount)
                            {
                                Console.Write($"Введите ID продукта {i + 1}: ");
                                if (int.TryParse(Console.ReadLine(), out int productId))
                                {
                                    var product = context.Products.Find(productId);
                                    if (product != null)
                                    {
                                        var orderProduct = new OrderProduct { OrderId = order.OrderId, ProductId = productId };
                                        context.OrderProducts.Add(orderProduct);
                                        i++;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Продукт не найден.");

                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Неверный ID продукта.");
                                }
                            }
                            context.SaveChanges();
                        }
                        else
                        {
                            Console.WriteLine("Неверное количество продуктов.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Покупатель не найден.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Неверный ID покупателя.");
            }
        }
        public static void EditOrder()// нельзя добавлять один и тот же продукт 2 раза
        {
            Console.Write("Введите ID заказа для редактирования: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                using (var context = new ApplicationContext())
                {
                    var order = context.Orders
                        .Include(o => o.OrderProducts)
                        .FirstOrDefault(o => o.OrderId == id);

                    if (order != null)
                    {
                        Console.WriteLine("1. Редактирование покупателя");
                        Console.WriteLine("2. Редактирование списка товаров");
                        Console.WriteLine("3. Назад");
                        Console.Write("Выберите опцию: ");
                        string choice = Console.ReadLine();

                        switch (choice)
                        {
                            case "1":
                                EditOrderCustomer(order, context);
                                break;
                            case "2":
                                EditOrderProducts(order, context);
                                break;
                            case "3":
                                return;
                            default:
                                Console.WriteLine("Неверный выбор. Попробуйте снова.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Заказ не найден.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Неверный ID.");
            }
        }

        static void EditOrderCustomer(Order order, ApplicationContext context)
        {
            Console.Write("Введите новый ID покупателя: ");
            if (int.TryParse(Console.ReadLine(), out int newCustomerId))
            {
                var customer = context.Customers.Find(newCustomerId);
                if (customer != null)
                {
                    order.CustomerId = newCustomerId;
                    context.SaveChanges();
                    Console.WriteLine("Покупатель успешно изменен.");
                }
                else
                {
                    Console.WriteLine("Покупатель не найден.");
                }
            }
            else
            {
                Console.WriteLine("Неверный ID покупателя.");
            }
        }

        static void EditOrderProducts(Order order, ApplicationContext context)
        {
            Console.Write("Введите количество продуктов в заказе: ");
            if (int.TryParse(Console.ReadLine(), out int productCount))
            {
                // Удаление существующих продуктов из заказа
                context.OrderProducts.RemoveRange(order.OrderProducts);

                // Добавление новых продуктов в заказ
                int i = 0;
                while (i < productCount)
                {
                    Console.Write($"Введите ID продукта {i + 1}: ");
                    if (int.TryParse(Console.ReadLine(), out int productId))
                    {
                        var product = context.Products.Find(productId);
                        if (product != null)
                        {
                            var orderProduct = new OrderProduct { OrderId = order.OrderId, ProductId = productId };
                            context.OrderProducts.Add(orderProduct);
                            i++;
                        }
                        else
                        {
                            Console.WriteLine("Продукт не найден.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Неверный ID продукта.");
                    }
                }
                context.SaveChanges();
                Console.WriteLine("Список товаров успешно изменен.");
            }
            else
            {
                Console.WriteLine("Неверное количество продуктов.");
            }
        }

        public static void DeleteOrder()
        {
            Console.Write("Введите ID заказа для удаления: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                using (var context = new ApplicationContext())
                {
                    var order = context.Orders.Find(id);
                    if (order != null)
                    {
                        context.Orders.Remove(order);
                        context.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine("Заказ не найден.");
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
