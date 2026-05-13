using System;

namespace GameStore.Models
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
            Console.WriteLine($"[Subscription] {Title} | Kestus: {DurationDays} päeva | Hind: {Price}€");
        }
    }
}