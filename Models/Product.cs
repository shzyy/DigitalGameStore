using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalGameStore.Models
{
    public abstract class Product
    {

        public string Title { get; set; }

        private decimal price;

        public decimal Price
        {
            get { return price; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Hind ei tohi olla negatiivne.");

                price = value;

            }
        }

        public bool Owned { get; private set; }

        protected Product(string title, decimal price)
        {
            Title = title;
            Price = price;
            Owned = false;
        }

        public virtual void ShowInfo()
        {
            Console.WriteLine($"{Title} - {Price}€");
        }

        public bool IsOwned()
        {
            return Owned;
        }

        public void Buy()
        {
            if (Owned)
                Console.WriteLine($"{Title} on juba ostetud.");
            else
            {
                Owned = true;
                Console.WriteLine($"{Title} ostetud edukalt.");
            }
        }
    }
}
