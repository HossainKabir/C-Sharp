using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_ATM_O
{
    
    class Program
    {
        static void Main(string[] args)
        {
            var cardCall = new E_ATMOOP();
            var account = new Account();
            cardCall.InitDefaultValuse(account);
            cardCall.start();

        }
    }
}
