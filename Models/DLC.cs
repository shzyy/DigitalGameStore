using DigitalGameStore.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace DigitalGameStore.Models
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
            Console.WriteLine($"DLC: {Title}, Põhimäng: {BaseGame}, Hind: {Price}€");
        }

        public void Download()
        {
            if (IsOwned())
                Console.WriteLine($"Laadin alla DLC: {Title}");
            else
                Console.WriteLine($"{Title} tuleb enne ostma.");
        }
    }
}
