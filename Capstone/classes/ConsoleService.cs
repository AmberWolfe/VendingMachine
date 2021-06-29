using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Capstone.classes;

namespace Capstone.classes
{
    public class ConsoleService
    {
        public void Run()
        {

            Person user = new Person();
            
            VendingMachine vendingMachine = new VendingMachine();
            if(vendingMachine.StockInventory())
            {
                StartMenu(user, vendingMachine);
            } else
            {
                Console.WriteLine("Inventory Not Stocked Correctly. Please resolve the problem and restart the program.");
            }

        }

        private void StartMenu(Person user, VendingMachine vendingMachine)
        {
            string userSelection;
            while (true)
            {
                Console.WriteLine("-------------------------------------------------------");
                Console.WriteLine("Welcome to the Tech Elevator Vending Machine.");
                Console.WriteLine("1) Display Vending Machine Items.");
                Console.WriteLine("2) Purchase");
                Console.WriteLine("3) Exit");
                Console.WriteLine("-------------------------------------------------------");
                userSelection = Console.ReadLine();

                if (userSelection == "1")
                {
                    DisplayVendingMachineItemsConsole(vendingMachine);
                } 
                else if (userSelection == "2")
                {
                    PurchaseMenu(user, vendingMachine);
                } 
                else if (userSelection == "3")
                {
                    break;
                }


            }            
        }
            
        

        private void PurchaseMenu(Person user, VendingMachine vendingMachine)
        {
            string userSelection;

            while(true)
            {
                Console.WriteLine("--------------------------------------------------------------");
                Console.WriteLine("");
                Console.WriteLine("1) Feed Money");
                Console.WriteLine("2) Select Product");
                Console.WriteLine("3) Finish Transation");
                Console.WriteLine("");
                Console.WriteLine($"Current Balance is  {user.Balance:C2}");
                Console.WriteLine("");
                Console.WriteLine($"Current Cart total is {user.CartTotal:C2}");
                Console.WriteLine("");
                Console.WriteLine("Products in cart");
                Console.WriteLine("");
                

                //Print out Products currently in the Cart

                foreach (Product product in user.CartItems)
                {
                    Console.WriteLine(product.Name);
                }

                Console.WriteLine("-------------------------------------------------------------");
                
                userSelection = Console.ReadLine();

                if(userSelection == "1")
                {
                    FeedMoneyConsole(user);

                } else if(userSelection == "2")
                {
                    SelectProductConsole(user, vendingMachine);

                } else if(userSelection == "3")
                {
                    FinishTransactionConsole(user);
                    break;

                }
            }
            
        }

        private void FeedMoneyConsole(Person person)
        {
            string userSelection;
            do
            {

                while (true)
                {
                    Console.WriteLine("Please enter in the amount of cash you wish to deposit.");
                    Console.WriteLine("Whole Integer Amounts required or press 'E' to exit.");


                    string userInput = Console.ReadLine();

                    if(userInput.ToUpper() == "E")
                    {
                        goto PurchaseMenu;
                    }

                    if (!person.AddBalance(userInput))
                    {
                        Console.WriteLine("Invalid Entry. Please Try Again.");
                    }
                    else
                    {
                        break;
                    };
                   
                }
                
                                
                while (true)
                {
                    Console.WriteLine("Would you like to enter in another bill? (Y/N)");
                    userSelection = Console.ReadLine();
                    if (userSelection.ToLower() == "y" || userSelection.ToLower() == "n")
                    {
                        break;
                    }
                }
            } while (userSelection == "y");

        PurchaseMenu:;
            //return 
        }

        private void DisplayVendingMachineItemsConsole(VendingMachine vendingMachine)
        {
            List<Product> manifest = vendingMachine.Manifest;
            Dictionary<string, int> inventory = vendingMachine.Inventory;
            
            Console.WriteLine("");

            string column1 = $"Location";
            string column2 = $"Name";
            string column3 = $"Price";
            string column4 = $"Qty Remaining";

            bool once = true; 

            foreach(Product product in manifest)
            {
                if (once)
                {
                    Console.WriteLine(column1.PadRight(11) + "|" + column2.PadRight(27) + "|" + column3.PadRight(12) + "|" + column4.PadRight(11) + "|");
                    once = false;
                }
                Console.WriteLine($"{product.SlotLocation.PadRight(10)} | {product.Name.PadRight(25)} | {product.Price.ToString().PadRight(10)} | {(inventory[product.SlotLocation] <= 0 ? "Sold out".PadRight(11) : inventory[product.SlotLocation].ToString().PadRight(11))} |");
            }
            Console.WriteLine("");
        }
        private bool SelectProductConsole(Person user, VendingMachine vendingMachine)
        {
            DisplayVendingMachineItemsConsole(vendingMachine);
           
            Console.Write("Please enter the product location or press 'E' to Exit: ");
            string selection = Console.ReadLine();
            if(selection.ToUpper() == "E")
            {
                goto PurchaseMenu;
            }
            string productSelectionResponse = user.SelectProduct(selection.ToUpper(), vendingMachine);

            if(!productSelectionResponse.Equals("Error: Location does not exist.") && !productSelectionResponse.Equals("Insufficient Balance") && !productSelectionResponse.Equals("Sold Out"))
            {
                string funnyMessage = "";

                if(productSelectionResponse == "Chip")
                {
                    funnyMessage = "Crunch Crunch, Yum!";
                } else if (productSelectionResponse == "Candy")
                {
                    funnyMessage = "Munch Munch, Yum!";
                } else if(productSelectionResponse == "Drink")
                {
                    funnyMessage = "Glug Glug, Yum!";
                } else if(productSelectionResponse == "Gum")
                {
                    funnyMessage = "Chew Chew, Yum!";
                }
                Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXX");
                Console.WriteLine($"Dispensing {productSelectionResponse}");
                Console.WriteLine(funnyMessage);
                Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXX");
                return true;
            }
            else
            {
                if(productSelectionResponse == "Insufficient Balance")
                {

                    Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
                    Console.WriteLine("Error. Insufficient Balance. Please add more money.");
                    Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");

                } else if ( productSelectionResponse == "Sold Out")
                {
                    Console.WriteLine("XXXXXXXXXXXXXXXX");
                    Console.WriteLine(productSelectionResponse);
                    Console.WriteLine("XXXXXXXXXXXXXXXX");
                } else
                {
                    // Product does not exist
                    Console.WriteLine("XXXXXXXXX");
                    Console.WriteLine(productSelectionResponse);
                    Console.WriteLine("XXXXXXXXX");
                }
                
            }
            PurchaseMenu:;
            return false;
        }


        private void FinishTransactionConsole(Person user)
        {
            
            ChangeService change = new ChangeService();
            int[] changeList = new int[3];
            
            changeList = change.GetChange(user.Balance);

            
            LogService logger = new LogService();
            logger.LogBalanceDepositOrCashOut("GIVE CHANGE", user.Balance, 0);

            user.CloseOutAccount();
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("Thank you for shopping VendoMatic 800. Your change is:");
            Console.WriteLine(changeList[0] + " quarters, " + changeList[1] + " dimes, and " + changeList[2] + " nickels");
            Console.WriteLine("-------------------------------------------------------------");
            
        }

        
        
        
    }
}
