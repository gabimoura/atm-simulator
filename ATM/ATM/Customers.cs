using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ATM
{
    public class Customers : CollectionBase
    {
        public void Add(Customer customer) //add a new customer
        {
            List.Add(customer);
        }
    }
}
