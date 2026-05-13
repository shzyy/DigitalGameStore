using DigitalGameStore;
using System;

namespace GameStore.Models
{
    public class Demo : Product, IDownloadable
    {
        public Demo(string title)
            : base(title, 0)
        {
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"[Demo] {Title} | Tasuta prooviversioon");
        }

        public void Download()
        {
            Console.WriteLine($"Demo '{Title}' laaditakse alla...");
        }
    }
}