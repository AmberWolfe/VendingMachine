using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.classes
{
    public class Person
    {
        public decimal Balance { get; private set; } = 0;

        public List<Product> CartItems { get; private set; } = new List<Product>();
        
        public decimal CartTotal {
            get 
            {
                return GetCartTotal(CartItems);
            }
        } 
        
        public bool AddBalance(string amount)
        {
            LogService logger = new LogService();
            
            try
            {
                if (decimal.Parse(amount) % 1 == 0)
                {
                    logger.LogBalanceDepositOrCashOut("FEED MONEY", Balance, Balance + decimal.Parse(amount));
                    Balance += int.Parse(amount);
                    return true;
                }
            } catch (Exception)
            {
                return false;
            }
            

            return false;
        }

        public bool CloseOutAccount()
        {
            Balance = 0;
            CartItems = new List<Product>();
            return true;
        }

        private decimal GetCartTotal(List<Product> products)
        {
            decimal cartTotal = 0.0M;
            foreach(Product product in products)
            {
                cartTotal += product.Price;
            }

            return cartTotal;
        }
        // Todo remove Person customer parameter
        public string SelectProduct(string slotLocation, VendingMachine vendingMachine)
        {
            List<Product> manifest = vendingMachine.Manifest;
            Dictionary<string, int> inventory = vendingMachine.Inventory;
            LogService logger = new LogService();

            foreach (Product product in manifest)
            {
                if (product.SlotLocation.Equals(slotLocation))
                {
                    if (Balance >= product.Price && inventory[slotLocation] > 0)
                    {
                        logger.LogProduct(product, Balance, (Balance - product.Price));                        
                        CartItems.Add(product);
                        inventory[slotLocation] -= 1;
                        Balance -= product.Price;

                        return product.Type;

                    } else 
                    
                    {
                        
                        if (inventory[slotLocation] <= 0)
                        {
                            return "Sold Out";
                        } else if(Balance < product.Price)
                        {
                            Console.WriteLine(inventory[slotLocation]);
                            return "Insufficient Balance";
                        }
                       
                       
                    }
                }
            }

            return "Error: Location does not exist."; 
        }

        


    }
}
