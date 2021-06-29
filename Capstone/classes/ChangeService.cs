using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.classes
{
    public class ChangeService
    {

        private int Quarter { get; set; }
        private int Dime { get; set; }
        private int Nickel { get; set; }

        private int[] ChangeList { get; set; } = new int[3];

        public int[] GetChange(decimal amount)
        {
            decimal total = amount;
            while(total > 0.00M)
            {
                if(total >= 0.25M)
                {
                    // Add Quater to List
                    Quarter++;
                    total -= 0.25M;
                } else if(total >= 0.10M)
                {
                    // Add Dime to List
                    Dime++;
                    total -= 0.10M;
                } else if(total >= 0.05M)
                {
                    // Add Nickel to List
                    Nickel++;
                    total -= 0.05M;
                } else
                {
                    break;
                }
            }

            ChangeList[0] = Quarter;
            ChangeList[1] = Dime;
            ChangeList[2] = Nickel;


            return ChangeList;
        }
    }
}
