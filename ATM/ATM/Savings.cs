using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class Savings:Account
    {
        static ATMManager at = new ATMManager();
        public double InterestRate { get; set; } = 1.25;
        
        public Savings(string pinNumber, string accountNumber, double accountBalance) : base(pinNumber, accountNumber, accountBalance)
        {
        }

        public Savings()
        {
        }
        public override string ToString()
        {
            return base.PINumber + "," + base.ACcountNumber + "," + base.ACcountBalance + ",";
        }

        public void PayInterests()
        {   
                double interest;
                interest = ACcountBalance * InterestRate / 365 / 100;
                deposit(interest);            
        }
    }
}
