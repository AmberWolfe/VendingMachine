using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.classes
{
    public class VendingMachine
    {
        public Dictionary<string, int> Inventory { get; } = new Dictionary<string, int>();

        public List<Product> Manifest = new List<Product>();

        public bool StockInventory()
        {
            //string filePath = "C:\\Users\\Student\\workspace\\pairs\\csharp-capstone-module-1-team-5\\vendingmachine.csv";
            string fileName = "vendingmachine.csv";
            string directory = Environment.CurrentDirectory;
            string filePath = Path.Combine(directory, fileName);
            
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] temp = new string[4];
                        temp = line.Split('|');
                        Product product = new Product(temp[0], temp[1], decimal.Parse(temp[2]), temp[3]);
                        Manifest.Add(product);
                        Inventory[product.SlotLocation] = 5;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            
            return true;
        }
    }
}
