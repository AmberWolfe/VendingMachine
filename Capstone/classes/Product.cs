using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.classes
{
    public class Product
    {
        public string SlotLocation { get; }

        public string Name { get; }

        public decimal Price { get; }

        public string Type { get; }

        public Product(string slotLocation, string name, decimal price, string type)
        {
            SlotLocation = slotLocation;
            Name = name;
            Price = price;
            Type = type;
        }       
    }
}
