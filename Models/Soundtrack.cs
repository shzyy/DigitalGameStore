using DigitalGameStore;
using System;

namespace GameStore.Models
{
    public class Soundtrack : Product, IDownloadable
    {
        public string GameName { get; set; }

        public Soundtrack(string title, decimal price, string gameName)
            : base(title, price)
        {
            GameName = gameName;
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"[Soundtrack] {Title} | Mäng: {GameName} | Hind: {Price}€");
        }

        public void Download()
        {
            Console.WriteLine($"Soundtrack '{Title}' laaditakse alla...");
        }
    }
}