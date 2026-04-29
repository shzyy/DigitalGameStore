using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalGameStore.Models
{
    public class Subscription : Product
    {
        public int DurationDays { get; set; }

        public Subscription(string title, decimal price, int durationDays)
            : base(title, price)
        {
            DurationDays = durationDays;
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"Tellimus: {Title}, Kestus: {DurationDays} päeva, Hind: {Price}€");
        }
    }
}

