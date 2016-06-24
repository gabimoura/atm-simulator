using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class Checking : Account
    {

        public double BillFee { get; set; } = 1.25;
        public double MaximumBillAmount { get; set; } = 10000;

        public Checking(string pinNumber, string accountNumber, double accountBalance): base(pinNumber, accountNumber, accountBalance)
        {
        }
        public Checking()
        {
        }
        
        public override string ToString()
        {
            return base.PINumber + "," + base.ACcountNumber + "," + base.ACcountBalance + ",";
        }
        
        public void PayBill(double amount)
        {
            if(amount <= MaximumBillAmount)
            {
                amount += BillFee;
                withDraw(amount);
            }
        }
    }
}