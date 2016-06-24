using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class Transaction
    {
        public string Name { get; set; }
        public string TransactionDate { get; set; }
        public string TransactionCode { get; set; }
        public string AccountType { get; set; }
        public double TransactionAmount { get; set; }

        public Transaction(string name, string transactionDate, string transactionCode, string accounttype, double transactionamount)
        {
            Name = name;
            TransactionDate = transactionDate;
            TransactionCode = transactionCode;
            AccountType = accounttype;
            TransactionAmount = transactionamount;
        }       
        public void ReadTransaction()
        {
            
        }
    }
}
