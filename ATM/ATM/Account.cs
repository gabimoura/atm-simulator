using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public abstract class Account
    {
        public string PINumber { get; set; }
        public string ACcountNumber { get; set; }
        public double ACcountBalance { get; set; }
        public double MAXimumWithDrawal { get; set; } = 1.000;
        public double MAXimumTransferAmount { get; set; } = 100.000;

        public Account(string pinNumber, string accountNumber, double accountBalance)
        {
              PINumber=pinNumber;
              ACcountNumber=accountNumber;
              ACcountBalance=accountBalance;
        }
        public void withDraw(double amount)
        {
            if (ACcountBalance >= amount)
            {
                ACcountBalance -= amount;
            }       
        }
        public void deposit(double amount)
        {
            ACcountBalance += amount;            
        }
        public void transferOut(double amount)
        {
            if (ACcountBalance >= amount)
            {
                ACcountBalance -= amount;
            }
        }
        public void transferIn(double amount)
        {
            if (ACcountBalance >= amount)
            {
                ACcountBalance += amount;
            }
        }
        public string getPin()
        {
            return PINumber;
        }
        public string getAccountnumber()
        {
            return ACcountNumber;
        }
        public double getBalance()
        {
            return ACcountBalance;
        }
        public Account()
        {

        }
    }
}
