using System;
using System.Collections;

namespace POSwithOOP
{
    public class Customer
    {
        private readonly ArrayList _storePurchase;
        private Item CompositionItem { get; set; }

        public Customer(Item comItem)
        {
            CompositionItem = comItem;
            _storePurchase=new ArrayList();
        }

        private void PurchesItem(int index)
        {
            var purchesItem = CompositionItem.ItemNameList[index];
            var puchesItemIndex=0;
            foreach (var item in CompositionItem.AllItems)
            {
                if (item.ItemName == purchesItem)
                {
                    puchesItemIndex = CompositionItem.AllItems.IndexOf(item);
                    break;
                    

                }
            }
            var purchesItemStock = CompositionItem.AllItems[puchesItemIndex].ItemStock;

            if (purchesItemStock > 0)
            {
                leve1:
                Console.WriteLine("\t\t0 Back.");
                Console.Write("Please enter quantity of " + CompositionItem.AllItems[puchesItemIndex].ItemName +
                              " to buy :");
                var quantity = Convert.ToInt32(Console.ReadLine());

                if (quantity > 0 && quantity <= CompositionItem.AllItems[puchesItemIndex].ItemStock)
                {
                    var itemExist = false;
                    var existItemIndex = 0;
                    foreach (var itemName in _storePurchase)
                    {
                        if (itemName.Equals(CompositionItem.AllItems[puchesItemIndex].ItemName))
                        {
                            Console.WriteLine(CompositionItem.AllItems[puchesItemIndex].ItemName+" Exist");
                            itemExist = true;
                            existItemIndex = _storePurchase.IndexOf(CompositionItem.AllItems[puchesItemIndex].ItemName);
                        }
                    }

                    if (itemExist)
                    {
                        var currentQuantity = (int) _storePurchase[existItemIndex + 1];
                        var currentSum = (double)_storePurchase[existItemIndex + 3];
                        _storePurchase[existItemIndex + 1] = (currentQuantity + quantity);
                        _storePurchase[existItemIndex + 3] = currentSum +
                                                            (CompositionItem.AllItems[puchesItemIndex].ItemPrice*
                                                             quantity);
                    }
                    else
                    {
                        _storePurchase.Add(CompositionItem.AllItems[puchesItemIndex].ItemName);
                        _storePurchase.Add(quantity);
                        _storePurchase.Add(CompositionItem.AllItems[puchesItemIndex].ItemPrice);
                        _storePurchase.Add(CompositionItem.AllItems[puchesItemIndex].ItemPrice * quantity);                        
                    }


                    CompositionItem.AllItems[puchesItemIndex].ItemStock -= quantity;

                    Console.WriteLine("\t\t" + CompositionItem.AllItems[puchesItemIndex].ItemName + " Quantity " +
                                      quantity + ", Purches Successfull.");
                }
                else if (quantity == 0)
                {
                    SystemForCustomer();
                }
                else if (quantity < 0)
                {
                    Console.WriteLine("Quantity Can't be Less then or Equal 0.");
                    goto leve1;
                }
                else
                {
                    Console.WriteLine("Less Your Quantity, Maximum Stock :" +
                                      CompositionItem.AllItems[puchesItemIndex].ItemStock);
                    goto leve1;
                }
            }
            else
            {
                Console.WriteLine("\t\tOut of Stock. Please try other Item.");
                SystemForCustomer();
            }

            

        }

        private void CheckOut()
        {
            var j = 0;
            var totalSum = 0d;
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
                    totalSum += (double)item;
                    Console.WriteLine();

                }
            }
            Console.WriteLine();
            Console.WriteLine("Total price\t\t\t\t\t" + totalSum);
            _storePurchase.Clear();
            Console.WriteLine();
        }

        public void SystemForCustomer()
        {
            var customerSystemFlag = true;
            while (customerSystemFlag)
            {
                var i = 0;
                foreach (var item in CompositionItem.AllItems)
                {
                    i++;
                    Console.WriteLine(i+" "+item.ItemName+", "+item.ItemPrice);
                }
                Console.WriteLine("101 for Checkout.");
                Console.WriteLine("0 Back.");
                Console.Write("Enter your Choice :");
                var choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 0)
                {
                    customerSystemFlag = false;
                }
                else if (choice >= 0 && choice <=CompositionItem.AllItems.Count)
                {
                    var index = choice - 1;
                    PurchesItem(index);
                }
                else if (choice == 101)
                {
                    CheckOut();
                }
                else
                {
                    Console.WriteLine("\t\tWrong Key Press.");
                    Console.WriteLine("\t\tGive Correct Input.");

                }

            }
        }

    }
}