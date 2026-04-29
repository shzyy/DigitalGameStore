using DigitalGameStore.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace DigitalGameStore.Models
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
            Console.WriteLine($"Mäng: {Title}, Žanr: {Genre}, Hind: {Price}€");
        }

        public void Download()
        {
            if (IsOwned())
                Console.WriteLine($"Laadin alla mängu: {Title}");
            else
                Console.WriteLine($"{Title} tuleb enne ostma.");
        }
    }
}
