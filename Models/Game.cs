using DigitalGameStore;
using System;

namespace GameStore.Models
{
    public class Game : Product, IDownloadable
    {
        public string Genre { get; set; }

        public Game(string title, decimal price, string genre)
            : base(title, price)
        {
            Genre = genre;
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"[Game] {Title} | Žanr: {Genre} | Hind: {Price}€");
        }

        public void Download()
        {
            Console.WriteLine($"Mäng '{Title}' laaditakse alla...");
        }
    }
}