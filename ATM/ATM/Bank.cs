using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ATM
{
    public class Bank:Account
    {   
        public double MaximumTOPUP { get; set; } = 20000;
        public double RefillAmount { get; set; } = 5000;
        public Bank(string pinNumber, string accountNumber, double accountBalance)
                : base(pinNumber, accountNumber, accountBalance)
        {
        }
        public Bank()
        {
        }

        public override string ToString() 
        {
            return base.PINumber + "," + base.ACcountNumber + "," + base.ACcountBalance + "," ;
        }
        public void ReadA()
        {
            string[] elementList;

            using (StreamReader read = new StreamReader("Accounts.txt"))
            {
                string line;

                while ((line = read.ReadLine()) != null)
                {
                    elementList = line.Split(',');
                    if (elementList[0] == "B")
                    {
                        Bank c = new Bank(elementList[1], elementList[2], double.Parse(elementList[3]));
                        ACcountBalance = double.Parse(elementList[3]);                        
                    }
                }
            }
        }

        public void refillATM(string pin)
        {
            if (ACcountBalance < MaximumTOPUP)
            {
                deposit(RefillAmount);
            }
        }
    }
}
