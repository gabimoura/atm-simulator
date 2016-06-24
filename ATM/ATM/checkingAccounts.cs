using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ATM
{
    public class checkingAccounts : CollectionBase
    {
        public void Add(Checking checking) //add a new checking account
        {
            List.Add(checking);
        }        
    }
}
