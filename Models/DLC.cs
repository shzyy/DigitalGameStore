using DigitalGameStore;
using System;

namespace GameStore.Models
{
    public class DLC : Product, IDownloadable
    {
        public string BaseGame { get; set; }

        public DLC(string title, decimal price, string baseGame)
            : base(title, price)
        {
            BaseGame = baseGame;
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"[DLC] {Title} | Põhimäng: {BaseGame} | Hind: {Price}€");
        }

        public void Download()
        {
            Console.WriteLine($"DLC '{Title}' laaditakse alla...");
        }
    }
}