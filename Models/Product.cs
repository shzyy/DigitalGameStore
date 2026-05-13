using System;

namespace GameStore.Models
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
                    throw new ArgumentException("Hind ei tohi olla negatiivne!");

                price = value;
            }
        }

        public Product(string title, decimal price)
        {
            Title = title;
            Price = price;
        }

        public virtual void ShowInfo()
        {
            Console.WriteLine($"{Title} | Hind: {Price}€");
        }
    }
}