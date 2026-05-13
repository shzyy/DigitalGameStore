using DigitalGameStore;
using System;
using System.Collections.Generic;

namespace GameStore.Models
{
    public class User
    {
        public string Name { get; set; }

        private List<Product> library = new List<Product>();

        public User(string name)
        {
            Name = name;
        }

        public bool IsOwned(Product product)
        {
            return library.Contains(product);
        }

        public void Buy(Product product)
        {
            if (IsOwned(product))
            {
                Console.WriteLine("See toode on juba ostetud!");
                return;
            }

            library.Add(product);

            Console.WriteLine($"Toode '{product.Title}' ostetud.");
        }

        public void ShowLibrary()
        {
            if (library.Count == 0)
            {
                Console.WriteLine("Teek on tühi.");
                return;
            }

            Console.WriteLine($"\n{Name} teek:");

            for (int i = 0; i < library.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                library[i].ShowInfo();
            }
        }

        public void DownloadProduct()
        {
            if (library.Count == 0)
            {
                Console.WriteLine("Teek on tühi.");
                return;
            }

            ShowLibrary();

            Console.Write("\nVali allalaaditav toode: ");

            int choice = int.Parse(Console.ReadLine());

            if (choice < 1 || choice > library.Count)
            {
                Console.WriteLine("Vale valik!");
                return;
            }

            Product product = library[choice - 1];

            if (product is IDownloadable downloadable)
            {
                downloadable.Download();
            }
            else
            {
                Console.WriteLine("Seda toodet ei saa alla laadida.");
            }
        }
    }
}