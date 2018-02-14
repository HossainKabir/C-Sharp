using System;
using System.Collections.Generic;

namespace POSwithOOP
{
    public class Admin
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int Flag { get; set; }

        private Item CompositionItem { get; set; }
        private readonly Dictionary<int, Admin> _adminsDictionary = new Dictionary<int, Admin>();


        public Admin(string username, string password)
        {
            Username = username;
            Password = password;
            Flag = 0;

        }
        

        public Admin(Item compositionItem)
        {
            CompositionItem = compositionItem;
            var pen =new Item("Pen",5,5);
            var shirt=new Item("Shirt",100,10);
            var cap = new Item("Cap", 50, 15);

            CompositionItem.AllItems.Add(pen);
            CompositionItem.AllItems.Add(shirt);
            CompositionItem.AllItems.Add(cap);

            CompositionItem.ItemNameList.Add(pen.ItemName);
            CompositionItem.ItemNameList.Add(shirt.ItemName);
            CompositionItem.ItemNameList.Add(cap.ItemName);

            

        }

        private void AddAdmin()
        {
            var admin1 = new Admin("admin1", "123");
            _adminsDictionary.Add(1, admin1);
            var admin2=new Admin("admin2","234");
            _adminsDictionary.Add(2,admin2);

        }

        public bool CheckAdmin()
        {
            if (Flag == 0)
            {
                AddAdmin();
                Flag++;
            }
            
            var validAdmin = false;
            level1:
            Console.Write("Enter Username :");
            var username = Console.ReadLine();
            if (username != null && username.Equals(""))
            {
                Console.WriteLine("Invalid Username.");
                goto level1;
            }

            level2:
            Console.Write("Enter Password :");
            var password = Console.ReadLine();
            if (password.Equals(""))
            {
                Console.WriteLine("Invalid Password.");
                goto level2;
            }


            foreach (KeyValuePair<int,Admin> kvp in _adminsDictionary)
            {
                var value = kvp.Value;
                if (value.Username.Equals(username) && value.Password.Equals(password))
                {
                    validAdmin = true;

                }
            }
            return validAdmin;
        }

        public void ViewInventory()
        {
            Console.WriteLine("Id\tItem Name\tStock\tPrice\\Unit");
            for (int i = 0; i < CompositionItem.AllItems.Count; i++)
            {
                Console.WriteLine((i+1)+"\t"+CompositionItem.AllItems[i].ItemName+"\t\t"+CompositionItem.AllItems[i].ItemStock+"\t"+CompositionItem.AllItems[i].ItemPrice);
            }
            Console.WriteLine();
        }

        private void UpdateStock()
        {
            level2:
            Console.Write("Enter Your Choice Id :");
            var choice = Convert.ToInt32(Console.ReadLine());

            if (choice > 0 && choice <= CompositionItem.ItemNameList.Count)
            {
                var index = choice - 1;
                var purchesItem = CompositionItem.ItemNameList[index];
                Console.WriteLine("Purches Item Name :" + purchesItem);
                var puchesItemIndex = 0;
                foreach (var item in CompositionItem.AllItems)
                {
                    if (item.ItemName == purchesItem)
                    {
                        puchesItemIndex = CompositionItem.AllItems.IndexOf(item);
                        break;


                    }
                }
                level1:
                Console.Write("Enter your Update Stock Amount[" + CompositionItem.ItemNameList[index] + "] :");
                var updateStockAmount = Convert.ToInt32(Console.ReadLine());
                if (updateStockAmount <= 0)
                {
                    Console.WriteLine("Stock Amount can't be less than or equal 0.");
                    goto level1;
                }
                CompositionItem.AllItems[puchesItemIndex].ItemStock += updateStockAmount;
                Console.WriteLine("\t\tStock Update Successfully.");

            }
            else
            {
                Console.WriteLine("\t\tWrong Key Pressed.");
                Console.WriteLine("\t\tGive Correct Input.");
                goto level2;
            }

        }

        private void AddItem()
        {
        leve1:
            Console.Write("Enter New Items Name :");
            var itemName = Console.ReadLine();
            if (itemName != null && itemName.Equals(""))
            {
                Console.WriteLine("Invalid Item Name");
                goto leve1;
            }
            leve2:
            Console.Write("Enter Price for [" + itemName + "] :");
            var priceForNewItem = Convert.ToDouble(Console.ReadLine());
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
           var newItem=new Item(itemName, priceForNewItem, stockForNewItem);
           CompositionItem.AllItems.Add(newItem);
           CompositionItem.ItemNameList.Add(itemName);

            Console.WriteLine("New Item " + itemName + ", Price " + priceForNewItem + " Stock " + stockForNewItem + " Added Successfully.");
            ViewInventory();

        }

        public void AdminOptions()
        {
            var a=CheckAdmin();

            if (a)
            {
                var adminSystemFlag = true;
                while (adminSystemFlag)
                {
                    Console.WriteLine("1 Update Stock.");
                    Console.WriteLine("2 Add Item.");
                    Console.WriteLine("3 View Inventory.");
                    Console.WriteLine("0 Back.");

                    Console.Write("Enter Your Choice :");
                    var choice = Convert.ToInt32(Console.ReadLine());

                    if (choice == 1)
                    {
                        ViewInventory();
                        UpdateStock();
                        ViewInventory();
                    }
                    else if (choice == 2)
                    {
                        AddItem();
                    }
                    else if (choice == 3)
                    {
                        ViewInventory();
                    }
                    else if (choice == 0)
                    {
                        adminSystemFlag = false;
                    }
                }

            }
            else
            {
                Console.WriteLine("Invalid Admin.");
            }

            
        }

        public void SystemWithAdmin()
        {
            while (true)
            {
                Console.WriteLine("0 Admin.");
                Console.WriteLine("1 Customer.");

                Console.Write("Enter Your Choice :");
                var choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 0:
                        AdminOptions();
                        break;
                    case 1:
                        Customer cus=new Customer(CompositionItem);
                        cus.SystemForCustomer();
                        break;
                    default:
                        Console.WriteLine("\t\tWrong Key Press.");
                        Console.WriteLine("\t\tGive Correct Input.");
                        break;

                }
            }
           
        }

     
    }
}