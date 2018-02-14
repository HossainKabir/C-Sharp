using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace E_ATM_O
{
    class E_ATMOOP
    {
        List<Account> accounts = new List<Account>();
        Dictionary<int, int> transection = new Dictionary<int, int>();
        public void InitDefaultValuse(Account account)
        {
            

            accounts.Add( new Account() { CardNumber = 1, PinNumber = 123, Balance = 500 });
            accounts.Add( new Account() { CardNumber = 2, PinNumber = 234, Balance = 1000 });
            accounts.Add( new Account() { CardNumber = 3, PinNumber = 345, Balance = 800 });
            for (int i = 0; i < accounts.Count; i++)
            {
                transection.Add(accounts[i].CardNumber, 0);
            }

            
            
        }

        public void start()
        {
          var account =  GetCardNumber();
            if (account == null)
            {
                Console.WriteLine("Your card number is invalid.");
                start();
            }
            

            var isValidPin = CheckPinNumber(account);
            if (isValidPin == true)
            {
                options(account);
            }
            else
            {
                Console.WriteLine("Your pin number imvalid.");
                start();
            }
        }

        public void options(Account account)
        {
            Console.WriteLine("\n 1- for balance check\n 2- for cash withdrawal\n 3- for exit.\n");
            var pressNumber = int.Parse(Console.ReadLine());
            switch (pressNumber)
            {
                case 1:
                    BalanceCheck(account);
                    break;
                case 2:
                    CashWithdrawal(account);
                    break;
                case 3:
                    exit(account);
                    break;
            }
        }

        public void exit(Account account)
        {
            start();
        }

        public void CashWithdrawal(Account account)
        {
            Console.WriteLine("Enter your amount:");
            var withdrawal = int.Parse(Console.ReadLine());
            var counter=0;

            if (transection[account.CardNumber] < 3)
            {


                if (withdrawal <= account.Balance && withdrawal < 1000)
                {
                    account.Balance = account.Balance - withdrawal;
                    Console.WriteLine("Transaction is successful and your balance is {0}",
                        account.Balance);
                    //counter++;
                    transection[account.CardNumber]++;

                }
                else if (withdrawal > account.Balance)
                {
                    Console.WriteLine("You have not this money for withdrawal. Please try again.");
                }
                else
                {
                    Console.WriteLine("Please again try.");
                }
                options(account);
            }
            else
            {
                Console.WriteLine("Your daily limit.");
                options(account);
            }
        }

        public void BalanceCheck(Account account)
        {
            Console.WriteLine("Your balance is :{0}", account.Balance);
            options(account);
        }
        public bool CheckPinNumber(Account account)
        {
            Console.WriteLine("Enter your pin Number");
            var accountPin = Convert.ToInt32(Console.ReadLine());
            if (accountPin == account.PinNumber)
            {
                return true;
            }
            return false;
        }

        public Account GetCardNumber()
        {
            int accountNumber;
            Console.WriteLine("Enter your card number:");
            accountNumber = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < accounts.Count; i++)
            {
                if ( accounts[i].CardNumber == accountNumber)
                {
                    return accounts[i];
                }
            }
            return null;
        }
    }
}
