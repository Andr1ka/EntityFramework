using System;
using System.Linq;
using EntityFramework;
using EntityFramework.WorkingWithEntities;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main(string[] args)
    {
        using (var context = new ApplicationContext())
        {
            context.Database.Migrate();
        }

        while (true)
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Управление покупателями");
            Console.WriteLine("2. Управление заказами");
            Console.WriteLine("3. Управление товарами");
            Console.WriteLine("4. Выход");
            Console.Write("Выберите опцию: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ManageCustomers();
                    break;
                case "2":
                    ManageOrders();
                    break;
                case "3":
                    ManageProducts();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }
        }
    }

    static void ManageCustomers()
    {
        while (true)
        {
            Console.WriteLine("Управление покупателями:");
            Console.WriteLine("1. Просмотр всех покупателей");
            Console.WriteLine("2. Добавление покупателя");
            Console.WriteLine("3. Редактирование покупателя");
            Console.WriteLine("4. Удаление покупателя");
            Console.WriteLine("5. Назад");
            Console.Write("Выберите опцию: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WorkingWithCustomer.ViewCustomers();
                    break;
                case "2":
                    WorkingWithCustomer.AddCustomer();
                    break;
                case "3":
                    WorkingWithCustomer.EditCustomer();
                    break;
                case "4":
                    WorkingWithCustomer.DeleteCustomer();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }
        }
    }

    

    static void ManageOrders()
    {
        while (true)
        {
            Console.WriteLine("Управление заказами:");
            Console.WriteLine("1. Просмотр всех заказов");
            Console.WriteLine("2. Добавление заказа");
            Console.WriteLine("3. Редактирование заказа");
            Console.WriteLine("4. Удаление заказа");
            Console.WriteLine("5. Назад");
            Console.Write("Выберите опцию: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WorkingWithOrders.ViewOrders();
                    break;
                case "2":
                    WorkingWithOrders.AddOrder();
                    break;
                case "3":
                    WorkingWithOrders.EditOrder();
                    break;
                case "4":
                    WorkingWithOrders.DeleteOrder();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }
        }
    }

    static void ManageProducts()
    {
        while (true)
        {
            Console.WriteLine("Управление  товарами:");
            Console.WriteLine("1. Просмотр всех товаров");
            Console.WriteLine("2. Добавление товара");
            Console.WriteLine("3. Редактирование товара");
            Console.WriteLine("4. Удаление товара");
            Console.WriteLine("5. Назад");
            Console.Write("Выберите опцию: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WorkingWithProduct.ViewProducts();
                    break;
                case "2":
                    WorkingWithProduct.AddProduct();
                    break;
                case "3":
                    WorkingWithProduct.EditProduct();
                    break;
                case "4":
                    WorkingWithProduct.DeleteProduct();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }
        }
    }

   

}
