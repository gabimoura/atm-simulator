using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ATM
{
    public class ATMManager
    {
        public Customers allcustomers = new Customers();
        public checkingAccounts allCheckings = new checkingAccounts();
        public savingsAccounts allSavings = new savingsAccounts();
        public Transactions alltransactions = new Transactions();
       
        public string Bank { get; set; }
        public string Customers { get; set; }
        public string CheckingAccounts { get; set; }
        public string SavingAccounts { get; set; }
        public double CurrentAccountBalance { get; set; }

        public ATMManager(string bank, string customers, string checkingAccounts, string savingAccounts, double currentAccountBalance)
        {
            Bank = bank;
            Customers = customers;
            CheckingAccounts = checkingAccounts;
            SavingAccounts = savingAccounts;
            CurrentAccountBalance = currentAccountBalance;
        }
        public ATMManager()
        {
        }
        public bool ValidateUser(string name, string pin)
        {
            return true;
        } 
        public bool WithdrawChecking(string pin, double amount)
        {
            Checking c = new Checking();
            bool found = false;
            foreach (Checking d in allCheckings)
            {
                if (d.PINumber == pin)
                {
                    c = d;
                    found = true;
                    break;
                }
            }
            if (found == true)
            {
                c.withDraw(amount);
                return true;
            }
            return false;
        }
        public bool WithdrawSavings(string pin, double amount)
        {
            Savings s = new Savings();
            bool found = false;
            foreach (Savings d in allSavings)
            {
                if (d.PINumber == pin)
                {
                    s = d;
                    found = true;
                    break;
                }
            }
            if (found == true)
            {
                s.withDraw(amount);
                return true;
            }
            return false;
        } 
        public bool DepositChecking(string pinNumber, double amount)
        {
            Checking c = new Checking();
            bool found = false;
            foreach(Checking d in allCheckings)
            {
                if(d.PINumber==pinNumber)
                {
                    c = d;
                    found = true;
                    break;
                }                      
            }
            if(found==true)
            {
                 c.deposit(amount); return true;    
            }         
                    
            return false;       
        }
        public bool DepositSavings(string pinNumber, double amount)
        {
            Savings s = new Savings();
            bool found = false;
            foreach (Savings d in allSavings)
            {
                if (d.PINumber == pinNumber)
                {
                    s = d;
                    found = true;
                    break;
                }
            }
            if (found == true)
            {
                s.deposit(amount); return true;
            }
            return false;
        }
        public bool PayBill(string pin, double amount)
        {
            Checking c = new Checking();
            bool found = false;
            foreach (Checking d in allCheckings)
            {
                if (d.PINumber == pin)
                {
                    c = d;
                    found = true;
                    break;
                }
            }
            if (found == true)
            {
                c.PayBill(amount);
                return true;
            }
            return false;
        } 
        public void TransferFunds(string pin, double amount, char accountType)
        {
            Checking c = new Checking();
            bool found = false;
            foreach (Checking d in allCheckings)
            {
                if (d.PINumber == pin)
                {
                    c = d;
                    found = true;
                    break;
                }
            }
            if (found == true)
            {
                if (accountType == 'C')
                {
                    c.transferOut(amount);
                    DepositSavings(pin,amount);
                }
            }
            
        }
        public double DisplayCheckingAccountBalance(string pin)        
        {
            foreach (Checking c in allCheckings)
            {
                if(pin == c.getPin())
                {
                    CurrentAccountBalance = c.getBalance();                    
                }
            }
            return CurrentAccountBalance;
        }
        public double DisplaySavingsAccountBalance(string pin)
        {
            foreach (Savings c in allSavings)
            {
                if (pin == c.getPin())
                {
                    CurrentAccountBalance = c.getBalance();
                }
            }

            return CurrentAccountBalance;
        }
        public bool PayInterests(string pin)
        {
            Savings s = new Savings();
            bool found = false;
            foreach (Savings d in allSavings)
            {
                s = d;                
                found = true;
                s.PayInterests();
            }

            if (found == true)
            {                
                return true;
            }
            return false;
        }
        public bool ReadCustomers()
        {
            bool customerRead = false;
            string[] elementList;

            using (StreamReader read = new StreamReader("Customers.txt"))
            {
                string line;

                while ((line = read.ReadLine()) != null)
                {
                    customerRead = true;
                    elementList = line.Split(',');
                    Customer cus = new Customer(elementList[0], elementList[1]);
                    allcustomers.Add(cus);
                }
            }
            return customerRead;
        }
        public bool ReadAccounts()
        {
            bool accountsRead = false;
            string[] elementList;

            using (StreamReader read = new StreamReader("Accounts.txt"))
            {
                string line;

                while ((line = read.ReadLine()) != null)
                {
                    accountsRead = true;
                    elementList = line.Split(',');
                    if (elementList[0] == "B")
                    {
                        Bank c = new Bank(elementList[1], elementList[2], double.Parse(elementList[3]));
                        c.getBalance();               
                    }
                    if (elementList[0] == "C")
                    {
                        Checking c = new Checking(elementList[1], elementList[2], double.Parse(elementList[3]));
                        allCheckings.Add(c);
                    }
                    if (elementList[0] == "S")
                    {
                        Savings s = new Savings(elementList[1], elementList[2], double.Parse(elementList[3]));
                        allSavings.Add(s);
                    }
                }
            }
            return accountsRead;
        }
        public bool WriteAccounts()
        {    
            bool writtingAccounts = false;
            string fileName = "Accounts.txt";

            using (StreamWriter writer = new StreamWriter(fileName, false))
                {                                      
                    writer.Write("B"+ "," + ban.getPin() + "," + ban.getAccountnumber() + "," + ban.getBalance() + "," );
                }

                foreach (Checking check in allCheckings)
                {
                    using (StreamWriter writer = new StreamWriter(fileName, true))
                    {
                        writer.Write("C" + "," + check + "," );
                    }
                }
                foreach (Savings sav in allSavings)
                {
                    using (StreamWriter writer = new StreamWriter(fileName, true))
                    {
                        writer.Write("S" + "," + sav + "," );
                        writtingAccounts = true;
                    }
                }
            
            if(writtingAccounts == false)
            {
                return false;
            }
            else
            {
                return true;
            }            
        }
        public bool ReadTransactions()
        {
            bool transactionRead = false;
            string[] elementList;

            using (StreamReader read = new StreamReader("Transactions.txt"))
            {
                string line;

                while ((line = read.ReadLine()) != null)
                {
                    transactionRead = true;
                    elementList = line.Split(',');
                    Transaction transac = new Transaction(elementList[0], elementList[1], elementList[2], elementList[3], Double.Parse(elementList[4]));
                    alltransactions.Add(transac);
                }
            }
            return transactionRead;
        }
    }
}
