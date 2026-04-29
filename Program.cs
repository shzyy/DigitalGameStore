using DigitalGameStore.Interfaces;
using DigitalGameStore.Models;
using DigitalGameStore.Interfaces;
using DigitalGameStore.Models;
using System;
using System.Collections.Generic;

namespace GameStore
{
    class Program
    {
        static List<Game> games = new List<Game>
        {
            new Game("Cyber Quest", 29.99m, "RPG"),
            new Game("Speed Legends", 19.99m, "Racing"),
            new Game("Zombie Night", 24.99m, "Horror")
        };

        static List<Product> library = new List<Product>();

        static void Main(string[] args)
        {
            Console.Write("Sisesta kasutaja nimi: ");
            string userName = Console.ReadLine();

            while (true)
            {
                Console.WriteLine("\n=== MENÜÜ ===");
                Console.WriteLine("1. Kataloog ja ostmine");
                Console.WriteLine("2. Minu teek");
                Console.WriteLine("3. Laadi alla");
                Console.WriteLine("0. Välju");
                Console.Write("Valik: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        BuyFromCatalog();
                        break;

                    case "2":
                        ShowLibrary();
                        break;

                    case "3":
                        DownloadMenu();
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Vale valik.");
                        break;
                }
            }
        }

        static void BuyFromCatalog()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("\n=== MÄNGUDE KATALOOG ===");

            for (int i = 0; i < games.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {games[i].Title} - {games[i].Price}€");
            }

            Console.WriteLine("0. Tagasi");
            Console.Write("Vali mäng: ");

            string input = Console.ReadLine();

            if (input == "0")
                return;

            if (!int.TryParse(input, out int gameChoice) ||
                gameChoice < 1 ||
                gameChoice > games.Count)
            {
                Console.WriteLine("Vale valik.");
                return;
            }

            Game selectedGame = games[gameChoice - 1];

            decimal totalPrice = selectedGame.Price;
            List<Product> purchasedItems = new List<Product>
            {
                selectedGame
            };
            
            Console.WriteLine($"\nValitud mäng: {selectedGame.Title}");
            Console.WriteLine("Vali lisad:");
            Console.WriteLine("1. DLC - 9.99€");
            Console.WriteLine("2. Soundtrack - 4.99€");
            Console.WriteLine("3. Deluxe Pack - 14.99€");
            Console.WriteLine("4. Ilma lisadeta");
            Console.Write("Sisesta valikud komaga, näiteks 1,2 või 4: ");

            string extrasInput = Console.ReadLine();
            string[] extras = extrasInput.Split(',');

            foreach (string extra in extras)
            {
                string extraChoice = extra.Trim();

                switch (extraChoice)
                {
                    case "1":
                        purchasedItems.Add(new DLC(selectedGame.Title + " DLC", 9.99m, selectedGame.Title));
                        totalPrice += 9.99m;
                        break;

                    case "2":
                        purchasedItems.Add(new Soundtrack(selectedGame.Title + " Soundtrack", 4.99m));
                        totalPrice += 4.99m;
                        break;

                    case "3":
                        purchasedItems.Add(new DLC(selectedGame.Title + " Deluxe Pack", 14.99m, selectedGame.Title));
                        totalPrice += 14.99m;
                        break;

                    case "4":
                        break;

                    default:
                        Console.WriteLine($"Tundmatu lisa: {extraChoice}");
                        break;
                }
            }

            foreach (Product product in purchasedItems)
            {
                product.Buy();
                library.Add(product);
            }

            Console.WriteLine("\n=== OSTU KOKKUVÕTE ===");
            Console.WriteLine("Ostetud tooted:");

            foreach (Product product in purchasedItems)
            {
                Console.WriteLine("- " + product.Title);
            }

            Console.WriteLine($"Kokku makstud: {totalPrice}€");
            Console.WriteLine("Ost õnnestus!");
        }

        static void ShowLibrary()
        {
            Console.WriteLine("\n=== MINU TEEK ===");

            if (library.Count == 0)
            {
                Console.WriteLine("Teek on tühi.");
                return;
            }

            for (int i = 0; i < library.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                library[i].ShowInfo();
            }
        }

        static void DownloadMenu()
        {
            Console.WriteLine("\n=== ALLALAADIMINE ===");

            List<IDownloadable> downloadableItems = new List<IDownloadable>();
            List<Product> downloadableProducts = new List<Product>();

            foreach (Product product in library)
            {
                if (product is IDownloadable downloadable)
                {
                    downloadableItems.Add(downloadable);
                    downloadableProducts.Add(product);
                }
            }

            if (downloadableItems.Count == 0)
            {
                Console.WriteLine("Allalaaditavaid tooteid ei ole.");
                return;
            }

            for (int i = 0; i < downloadableProducts.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {downloadableProducts[i].Title}");
            }

            Console.WriteLine("0. Tagasi");
            Console.Write("Vali allalaadimiseks toode: ");

            string input = Console.ReadLine();

            if (input == "0")
                return;

            if (!int.TryParse(input, out int index) ||
                index < 1 ||
                index > downloadableItems.Count)
            {
                Console.WriteLine("Vale valik.");
                return;
            }

            downloadableItems[index - 1].Download();
        }
    }
}