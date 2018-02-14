using System;
using System.Collections;

namespace SimpleConsolePOS
{
    public class AllFunctionality
    {
        private  int[] _priceArray;
        private  string[] _items;
        private  int[] _stock;
        private readonly ArrayList _storePurchase;
        private int _quantity;
        private int _checkSecondTime;
        public AllFunctionality()
        {
            _items = new [] { "pen", "shirt", "cap" };
            _priceArray = new [] { 5, 100, 50 };
            _stock = new[] { 5, 10, 15 };
            _storePurchase =new ArrayList();
            _quantity = 0;
            _checkSecondTime=-1;

        }

    private void GenericPurchase(int index)
        {
            if(_checkSecondTime==index)
            Console.WriteLine("You can purchase, " + _items[index] + " Maximum {0}", _stock[index]);

            Console.WriteLine("\t\t0 Back.");
            Console.Write("Please enter quantity of "+_items[index]+ "(s) to buy :");
            _quantity = Convert.ToInt32(Console.ReadLine());
            
            if (_quantity <0)
            {
                Console.WriteLine("Ops.....?");
                Console.WriteLine("Quantity can't be less than or equal 0");
                Console.Write("Re-Enter your Quantity :");
                GenericPurchase(index);

                
            }
            else if (_quantity == 0)
            {
                RunSystem();
            }
            else
            {
                var availableStock = _stock[index];
                var foundFlag = false;
                var i = 0;
                var currentItem = _items[index];

                

                if (availableStock >= _quantity)
                {
                    for (; i < _storePurchase.Count; i++)
                    {
                        if (currentItem.Equals(_storePurchase[i]))
                        {
                            foundFlag = true;
                            break;
                        }
                    }
                    if (foundFlag)
                    {
                        var currentQuantity = _storePurchase[i + 1];
                        var currentSum = _quantity * _priceArray[index]+(int)_storePurchase[i + 3];
                        _storePurchase[i + 1] = _quantity+(int)currentQuantity;
                        _storePurchase[i + 3] = currentSum;

                    }
                    else
                    {
                        _storePurchase.Add(_items[index]);
                        _storePurchase.Add(_quantity);
                        _storePurchase.Add(_priceArray[index]);
                        var totalCost = _quantity * _priceArray[index];
                        _storePurchase.Add(totalCost);
                        availableStock -= _quantity;
                        _stock[index] = availableStock;
                        Console.WriteLine(_items[index] + ", Quantity " + _quantity + ", Purches Successfull.\n");
                        _checkSecondTime = index;
                    }

                    

                }
                else
                {
                    if (availableStock <= 0)
                        Console.WriteLine(_items[index] + ", Out of Stock.Try other item(s).");
                    else
                    {
                        Console.WriteLine("Available "+_items[index]+" Quantity "+_stock[index]);
                        Console.WriteLine("Please give quantity less than or equal "+_stock[index]);
                        GenericPurchase(index);
                    }
                }


            }
        }

        private void CheckOut()
        {
            var j = 0;
            var totalSum = 0;
            Console.Write("Item     \tQuantity  \tUnit price\tSum\n");
            Console.Write("____     \t________  \t__________\t__________");
            Console.WriteLine();

            foreach (object item in _storePurchase)
            {
                j++;
                Console.Write(item);
                Console.Write("\t\t");
                if (j % 4 == 0)
                {
                    totalSum += (int)item;
                    Console.WriteLine();

                }
            }
            Console.WriteLine();
            Console.WriteLine("Total price\t\t\t\t\t" + totalSum);
            _storePurchase.Clear();
            Console.WriteLine();
        }
        public void RunSystem()
        {
            var flagCustomerOption = true;
            int i;
            while (flagCustomerOption)
            {

                for (i = 0; i < _items.Length; i++)
                {
                    Console.WriteLine((i + 1) + " " + _items[i] + ", {0}.", _priceArray[i]);
                }
                Console.WriteLine("101 Checkout.");
                Console.WriteLine("0 Back.");
                Console.Write("Enter Your Choice :");
                var choice = Convert.ToInt32(Console.ReadLine());


                var index = choice - 1;
                if (choice > 0 && choice < _items.Length+1)
                {
                    GenericPurchase(index);
                }
                else if (choice == 0)
                {
                    flagCustomerOption = false;
                }
                else if (choice == 101)
                {
                    CheckOut();
                }
                else
                {
                    Console.WriteLine("Wrong Key Pressed.");
                    Console.WriteLine("Please, give Correct input.");
                    Console.WriteLine();
                }

            }
           
            // ReSharper disable once FunctionNeverReturns
        }

        private void UpdateAllItems(int index)
        {
            Console.Write("Enter the amount of Stock for Update ["+_items[index]+"] :");
            var updateAmount = Convert.ToInt32(Console.ReadLine());
            _stock[index] = _stock[index]+updateAmount;
            Console.WriteLine("Stock of "+_items[index]+", Updated Successfully.");

            ViewStock();
        }

        private void UpdateStock()
        {
            var flagForUpdateChoice = true;
            while (flagForUpdateChoice)
            {
                Console.WriteLine("0 Back.");
                Console.Write("Enter Your Choice Id:");
                var choiceForUpdateStock = Convert.ToInt32(Console.ReadLine());

                if (choiceForUpdateStock > 0 && choiceForUpdateStock<_items.Length+1)
                {
                    var index = choiceForUpdateStock - 1;
                    UpdateAllItems(index);
                    
                }
                else if (choiceForUpdateStock == 0)
                {
                    flagForUpdateChoice = false;
                }
                else
                {
                    Console.WriteLine("Wrong Key Pressed.");
                    Console.WriteLine("Please, give Correct input.");
                    Console.WriteLine();
                }
                
                    
                        
                       
                
            }
            

        }

        private void AddNewItems()
        {
            leve1:
            Console.Write("Enter New Items Name :");
            var itemName =(Console.ReadLine());
            if (itemName.Equals(""))
            {
                Console.WriteLine("Invalid Item Name");
                goto leve1;
            }
            leve2:
            Console.Write("Enter Price for ["+itemName+"] :");
            var priceForNewItem = Convert.ToInt32(Console.ReadLine());
            if (priceForNewItem <= 0)
            {
                Console.WriteLine("Item Price Can't be less than or equal 0.");
                goto leve2;
            }
            leve3:
            Console.Write("Enter Stock Amount :");
            var stockForNewItem = Convert.ToInt32(Console.ReadLine());
            if (stockForNewItem <= 0)
            {
                Console.WriteLine("Stock Item Can't be less than or equal 0");
                goto leve3;
            }
            Array.Resize(ref _items,_items.Length+1);
            Array.Resize(ref _priceArray,_priceArray.Length+1);
            Array.Resize(ref _stock,_stock.Length+1);
            _items[_items.Length-1] = itemName;
            _priceArray[_priceArray.Length-1] = priceForNewItem;
            _stock[_stock.Length - 1] = stockForNewItem;

            Console.WriteLine("New Item "+itemName+", Price "+priceForNewItem+" Stock"+stockForNewItem+" Added Successfully.");
            ViewStock();
        }

        private void ViewStock()
        {
            Console.WriteLine("Id\tItem\tStock\tPrice\\Unit\t");

            for (int j = 0; j < _items.Length; j++)
            {
                Console.WriteLine((j+1)+"\t"+_items[j] + "\t" + _stock[j] + "\t" + _priceArray[j]);
            }
            Console.WriteLine();
        }
        private void AdminPanel()
        {
            var flagAdmin = true;
            while (flagAdmin)
            {
                Console.WriteLine("1 Upadte Stock.");
                Console.WriteLine("2 Add Item(s).");
                Console.WriteLine("3 View Stock.");
                Console.WriteLine("0 Back.");
                Console.Write("Enter your choice :");
                var choiceForAdminEdit = Convert.ToInt32(Console.ReadLine());

                switch (choiceForAdminEdit)
                {
                    case 1:
                        ViewStock();
                        UpdateStock();
                        break;
                    case 2:
                        AddNewItems();
                        break;
                    case 3:
                        ViewStock();
                        break;
                    case 0:
                        flagAdmin = false;
                        break;
                    default:
                        Console.WriteLine("Wrong Key Pressed.");
                        Console.WriteLine("Please, give Correct input.");
                        Console.WriteLine();
                        break;
                }
            }

        }

        public void RunSystemWithAdmin()
        {
            while (true)
            {
                Console.WriteLine("0 Admin.");
                Console.WriteLine("1 Customer.");
                Console.Write("Enter Choice :");
                var choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 0:
                        AdminPanel();
                        break;
                    case 1:
                        RunSystem();
                        break;
                    default:
                        Console.WriteLine("Wrong Key Pressed.");
                        Console.WriteLine("Please, give Correct input.");
                        Console.WriteLine();
                        break;
                } 
            }
            
            // ReSharper disable once FunctionNeverReturns
        }
    }
}