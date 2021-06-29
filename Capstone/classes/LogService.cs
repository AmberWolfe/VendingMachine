using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.classes
{
    public class LogService
    {
        private static string FileName { get; } = "Log.txt";
        private static string Directory { get; } = Environment.CurrentDirectory;
        private readonly string FilePath = Path.Combine(Directory, FileName);

        public void LogProduct(Product product, decimal startingBalance, decimal endingBalance)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(FilePath, true))
                {
                    DateTime now = DateTime.Now;
                    sw.WriteLine(now + " " + product.Name + " " + product.SlotLocation + " " + startingBalance.ToString("c2") + " " + endingBalance.ToString("c2"));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void LogBalanceDepositOrCashOut(string transactionType, decimal startingBalance, decimal endingBalance)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(FilePath, true))
                {
                    DateTime now = DateTime.Now;
                    sw.WriteLine(now + " " + transactionType + " " + startingBalance.ToString("c2") + " " + endingBalance.ToString("c2"));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
