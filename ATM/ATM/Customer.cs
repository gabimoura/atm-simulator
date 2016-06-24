using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ATM
{
    public class Customer
    {
        static ATMManager man = new ATMManager();
        public string Name { get; set; }
        public string PINNumber { get; set; }
        public Customer(string name, string PinNumber)
        {
            Name = name;
            PINNumber = PinNumber;
        }
        public string GetName()
        {
            return Name;            
        }
        public string GetPINNumber()
        {
            return PINNumber;
        }
        public void ReadCus()
        {
            man.ReadCustomers();
        }
    }
}
