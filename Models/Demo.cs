using DigitalGameStore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalGameStore.Models
{
    public class Demo : Product, IDownloadable
    {
        public Demo(string title)
            : base(title, 0)
        {
            Buy();
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"Demo: {Title}, tasuta prooviversioon");
        }

        public void Download()
        {
            Console.WriteLine($"Laadin alla demo: {Title}");
        }
    }
}
