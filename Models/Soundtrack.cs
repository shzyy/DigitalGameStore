using DigitalGameStore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalGameStore.Models
{
    public class Soundtrack : Product, IDownloadable
    {
        public Soundtrack(string title, decimal price)
            : base(title, price)
        {
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"Soundtrack: {Title}, Hind: {Price}€");
        }

        public void Download()
        {
            if (IsOwned())
                Console.WriteLine($"Laadin alla soundtracki: {Title}");
            else
                Console.WriteLine($"{Title} tuleb enne ostma.");
        }
    }
}
