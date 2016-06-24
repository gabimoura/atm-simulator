using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ATM
{
    public class savingsAccounts : CollectionBase
    {        
        public void Add(Savings s) //add a new saving account
        {
            List.Add(s);
        }
    }
}
