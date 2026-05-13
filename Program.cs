using System;
using System.Collections.Generic;
using GameStore.Models;

namespace GameStore
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            List<Product> products = new List<Product>
            {
                new Game("Cyber Adventure", 29.99m, "RPG"),
                new Game("Racing Pro", 19.99m, "Racing"),
                new DLC("Winter Pack", 9.99m, "Cyber Adventure"),
                new Subscription("Premium", 14.99m, 30),
                new Demo("Racing Pro Demo"),
                new Soundtrack("Cyber Adventure OST", 4.99m, "Cyber Adventure")
            };

            User user = new User("Eugene");

            bool running = true;

            while (running)
            {
                Console.WriteLine("\n===== GameStore =====");
                Console.WriteLine("1. Kuva kõik tooted");
                Console.WriteLine("2. Osta toode");
                Console.WriteLine("3. Minu teek");
                Console.WriteLine("4. Laadi alla");
                Console.WriteLine("0. Välju");

                Console.Write("Valik: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ShowProducts(products);
                        break;

                    case "2":
                        ShowProducts(products);

                        Console.Write("Vali toode: ");

                        if (int.TryParse(Console.ReadLine(), out int buyChoice))
                        {
                            if (buyChoice >= 1 && buyChoice <= products.Count)
                            {
                                user.Buy(products[buyChoice - 1]);
                            }
                            else
                            {
                                Console.WriteLine("Vale valik!");
                            }
                        }
                        break;

                    case "3":
                        user.ShowLibrary();
                        break;

                    case "4":
                        user.DownloadProduct();
                        break;

                    case "0":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Vale valik!");
                        break;
                }
            }
        }

        static void ShowProducts(List<Product> products)
        {
            Console.WriteLine("\nKõik tooted:");

            for (int i = 0; i < products.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                products[i].ShowInfo();
            }
        }
    }
}