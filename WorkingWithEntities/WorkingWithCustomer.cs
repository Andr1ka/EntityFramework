using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.WorkingWithEntities
{
    internal static class WorkingWithCustomer
    {
        public static void ViewCustomers()
        {
            using (var context = new ApplicationContext())
            {
               var customers = context.Customers.ToList();
               foreach (var customer in customers)
               {
                    Console.WriteLine($"ID: {customer.CustomerId}, Name: {customer.Name}");
               }
            }
        }

        public static void AddCustomer()
        {
            Console.Write("Введите имя покупателя: ");
            string? name = Console.ReadLine();

            using (var context = new ApplicationContext())
            {
                var customer = new Customer { Name = name };
                context.Customers.Add(customer);
                context.SaveChanges();
            }
        }

        public static void EditCustomer()
        {
            Console.Write("Введите ID покупателя для редактирования: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                using (var context = new ApplicationContext())
                {
                    var customer = context.Customers.Find(id);
                    if (customer != null)
                    {
                        Console.Write("Введите новое имя покупателя: ");
                        customer.Name = Console.ReadLine();
                        context.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine("Покупатель не найден.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Неверный ID.");
            }
        }

        public static void DeleteCustomer()
        {
            Console.Write("Введите ID покупателя для удаления: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                using (var context = new ApplicationContext())
                {
                    var customer = context.Customers.Find(id);
                    if (customer != null)
                    {
                        context.Customers.Remove(customer);
                        context.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine("Покупатель не найден.");
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
