using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ATM
{
    public class Transactions : CollectionBase
    {
        
        public void Add(Transaction transaction) //add a new transaction
        {
            List.Add(transaction);
        }                
    }
}
