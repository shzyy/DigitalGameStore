using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalGameStore.Models
{
    public class User
    {
        public string Name { get; set; }
        public List<Product> Library { get; set; } = new List<Product>();

        public User(string name)
        {
            Name = name;
        }

        public void BuyProduct(Product product)
        {
            if (!product.IsOwned())
            {
                product.Buy();
                Library.Add(product);
            }
            else
            {
                Console.WriteLine("Toode on juba teegis olemas.");
            }
        }

        public void ShowLibrary()
        {
            Console.WriteLine($"\n{Name} teek:");

            foreach (Product product in Library)
            {
                product.ShowInfo();
            }
        }
    }
}
